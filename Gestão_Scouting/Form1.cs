using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestão_Scouting
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        private int currentJogador;
        private int currentRelatorioJogador;
        private static String List="";
        private static String Order="";
        public static  String[] ids; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            LoadJogadores(List,Order);
            GetListaObservacaoSelecao();
            ListboxOrderSelec();
            comboBoxListaSelecao.SelectedIndex=0;


        }

        //Funções SQL
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source=LAPTOP-MH91MTBV;integrated security=true;initial catalog=Trabalho_Final");
            //MH91MTBV
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        //----------------------------------------------------------------------------

        //Utils Functions
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadJogadores("","");
            comboBoxListaSelecao.SelectedIndex = 0;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //-----------------------------------------------------------------------------

        //Jogadores Functions
        private void LoadJogadores(String numero, String Order) //Com as alterações fica 70%feita
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd=new SqlCommand();
            SqlDataReader reader;
            //cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.GetListaJogadores", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText="EXEC Scouting.GetListaJogadores @IdadeList , @OrderBy";
            cmd.Parameters.AddWithValue("@IdadeList", numero);
            cmd.Parameters.AddWithValue("@OrderBy", Order);
  
            reader = cmd.ExecuteReader();
            listBoxJogadores.Items.Clear();
            int i = 0;
            while (reader.Read())
            {
                Jogador C = new Jogador();
                C.ID_FIFPro = reader["ID_FIFPro"].ToString();
                C.Jogador_Nome = reader["Jogador_Nome"].ToString();
                C.Jogador_Altura = reader["Jogador_Altura"].ToString();
                C.Jogador_Peso = reader["Jogador_Peso"].ToString();
                C.Pe_Favorito = reader["Pe_Favorito"].ToString();
                C.Idade = reader["Idade"].ToString();
                C.Dupla_Nacionalidade = reader["Dupla_Nacionalidade"].ToString();
                C.Numero_Internacionalizao = reader["Numero_Internacionalizacoes"].ToString();
                C.Lista_Idade_Maxima = reader["Lista_Idade_Maxima"].ToString();
                listBoxJogadores.Items.Add(C);
                i++;
            }
            //cn.Close();
            reader.Close();
            currentJogador = 0;
            LockJogadoresControls();
            ShowJogadores();
        }

        private void listBoxJogadores_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBoxJogadores.SelectedIndex > 0)
            {
                currentJogador = listBoxJogadores.SelectedIndex;
                
                //Mostrar Jogadores
                ShowJogadores();
                //Mostrar Posicoes Jogadores
                PosicoesInsert(textID_FIFPro.Text);
                //Mostrar Relatorios Jogadores
                RelatoriosInsert(textID_FIFPro.Text);

            }
        }
            //Função Mostrar Jogadores
        public void ShowJogadores()
        {
            if (listBoxJogadores.Items.Count == 0 | currentJogador < 0)
                return;
            Jogador jogador = new Jogador();
            jogador = (Jogador)listBoxJogadores.Items[currentJogador];
            textID_FIFPro.Text = jogador.ID_FIFPro;
            textJNome.Text = jogador.Jogador_Nome;
            textAltura.Text = jogador.Jogador_Altura.ToString() + " m";
            textPeso.Text = jogador.Jogador_Peso.ToString()+ " Kg";
            //textPe_fav.Text = jogador.Pe_Favorito.ToString();
            textJogadorIdade.Text = jogador.Idade.ToString();
            textDuplaNacionalidade.Text = jogador.Dupla_Nacionalidade.ToString();
            textNumeroInter.Text = jogador.Numero_Internacionalizao.ToString();
            //text_Idade_max.Text = jogador.Lista_Idade_Maxima.ToString();
            if (jogador.Pe_Favorito.ToString() == "True")
            {
                radioButtonDireito.Checked = true;
                radioButtonEsquerdo.Checked = false;
            }
            else
            {
                radioButtonEsquerdo.Checked = true;
                radioButtonDireito.Checked = false;
            }
            if (jogador.Dupla_Nacionalidade.ToString() == "True")
            {
                textDuplaNacionalidade.Text = "Sim";
            }
            else
            {
                textDuplaNacionalidade.Text = "Não";
            }  
        }
            //ObterPosicoes;
        public void PosicoesInsert(String x)
        {
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.GetPosicoesByJogador", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@ID", x);
            readera = cmda.ExecuteReader();
            listBoxPosicoes.Items.Clear();
            while (readera.Read())
            {
                Jog_Posicoes L = new Jog_Posicoes();
                L.J_Posicoes_ID_FIFPro = readera["Jog_Posicoes_ID_FIFPro"].ToString();
                L.J_Posicoes = readera["J_Posicoes"].ToString();
                
                listBoxPosicoes.Items.Add(L.ToString());
            }
            readera.Close();
        }

            //Mostrar Jogadores por Lista
        public void GetListaObservacaoSelecao()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_Listas_Observacao_Selecao", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            Lista_Observacao_Selecao S = new Lista_Observacao_Selecao();
            S.Lista_Nome = "Todos";
            S.Lista_Idade_Maxima = "";

            comboBoxListaSelecao.Items.Add(S);
            while (reader.Read())
            {
                Lista_Observacao_Selecao L = new Lista_Observacao_Selecao();
                L.Lista_Nome = reader["Lista_Nome"].ToString();
                L.Lista_Idade_Maxima = reader["Lista_Idade_Maxima"].ToString();
                comboBoxListaSelecao.Items.Add(L);
            }
            reader.Close();
        }
            //ComboBox Order by
        public void ListboxOrderSelec()
        {
            ComboBoxOrder Null = new ComboBoxOrder();
            Null.Text = "Null";
            Null.Value = "";
            comboBoxOrder.Items.Add(Null);

            ComboBoxOrder Jogador_Nome = new ComboBoxOrder();
            Jogador_Nome.Text = "Nome";
            Jogador_Nome.Value = "Jogador_Nome";
            comboBoxOrder.Items.Add(Jogador_Nome);

            ComboBoxOrder Jogador_Altura = new ComboBoxOrder();
            Jogador_Altura.Text = "Altura";
            Jogador_Altura.Value = "Jogador_Altura";
            comboBoxOrder.Items.Add(Jogador_Altura);

            ComboBoxOrder Jogador_Peso = new ComboBoxOrder();
            Jogador_Peso.Text = "Peso";
            Jogador_Peso.Value = "Jogador_Peso";
            comboBoxOrder.Items.Add(Jogador_Peso);

            ComboBoxOrder Idade = new ComboBoxOrder();
            Idade.Text = "Idade";
            Idade.Value = "Idade";
            comboBoxOrder.Items.Add(Idade);

            ComboBoxOrder Numero_Internacionalizao = new ComboBoxOrder();
            Idade.Text = "Internacionalizações";
            Idade.Value = "Numero_Internacionalizacoes";
            comboBoxOrder.Items.Add(Idade);
        }

            //Bloquear Dados Jogadores
        public void LockJogadoresControls()
        {
            textID_FIFPro.ReadOnly = true;
            textJNome.ReadOnly = true;
            textAltura.ReadOnly = true;
            textPeso.ReadOnly = true;
            textJogadorIdade.ReadOnly = true;
            textDuplaNacionalidade.ReadOnly = true;
            textNumeroInter.ReadOnly = true;
            //text_Idade_max.ReadOnly = true;
            radioButtonEsquerdo.Enabled = false;
            radioButtonDireito.Enabled = false;
        }
            //Selecionar Tipo de Selecao
        private void comboBoxListaSelecao_SelectedIndexChanged(object sender, EventArgs e) //Função na 90% certa
        {
            if (comboBoxListaSelecao.SelectedIndex >= 0)
            {
                Lista_Observacao_Selecao list = new Lista_Observacao_Selecao();
                list = (Lista_Observacao_Selecao)comboBoxListaSelecao.Items[comboBoxListaSelecao.SelectedIndex];
                String name = list.Lista_Idade_Maxima.ToString();
                List = name;
                LoadJogadores(List,Order);

            }
        }
            //Selecionar Order
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxListaSelecao.SelectedIndex >= 0)
            {
                ComboBoxOrder list = new ComboBoxOrder();
                list = (ComboBoxOrder)comboBoxOrder.Items[comboBoxOrder.SelectedIndex];
                String x = list.Value.ToString();
                Order = x;
                LoadJogadores(List, Order);

            }
        }

            //Criar Jogador
        private void buttonCriarJogadores_Click(object sender, EventArgs e)
        {
            if (listBoxJogadores.SelectedIndex > -1)
            {
                listBoxJogadores.ClearSelected();
            }
            AddPlayer ap = new AddPlayer();
            ap.ShowDialog();

        }

            // Editar Jogador
        private void buttonEditarJogador_Click(object sender, EventArgs e)
        {

        }
            //Eliminar Jogador
        private void buttonEliminarJogador_Click(object sender, EventArgs e)
        {

        }
        //-----------------------------------------------------------------------------

        //Funções Relatorio
        public void RelatoriosInsert(String x)
        {
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmd.Connection = cn;
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.GetRelatorioByJogador", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@ID", x);
            readera = cmda.ExecuteReader();
            listBoxRelatoriosJogador.Items.Clear();
            while (readera.Read())
            {
                Relatorio L = new Relatorio();
                L.ID = readera["ID"].ToString();
                L.Relatorio_Titulo = readera["Relatorio_Titulo"].ToString();
                L.Relatorio_Data = readera["Relatorio_Data"].ToString();
                L.Numero_Identificacao_Federacao = readera["Numero_Identificacao_Federacao"].ToString();
                L.ID_FIFPro = readera["ID_FIFPro"].ToString();
                L.Jogo_Local = readera["Jogo_Local"].ToString();
                L.Jogo_Data = readera["Jogo_Data"].ToString();
                listBoxRelatoriosJogador.Items.Add(L.ToString());
            }
            readera.Close();

        }

        private void GoToInfoRelatorio(object sender, MouseEventArgs e)
        {
            String dados = listBoxRelatoriosJogador.GetItemText(listBoxRelatoriosJogador);

            String[] texto = listBoxRelatoriosJogador.GetItemText(dados).Split(' ');
            String id = texto[0];
            DadosRelatorio dr = new DadosRelatorio(id,cn);
            dr.ShowDialog();
        }
    }
}



