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
using System.Security.Authentication;


namespace Gestão_Scouting
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        //Jogador TAB
        private int currentJogador;
        private int currentRelatorioJogador;
        private static String List = "";
        private static String Order = "";
        public static String[] ids;
        //Clubes TAB
        private int currentClube;
        private int currentClubeComp;
        //Observador TAB
        private int currentObservador;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            //Jogadores
            LoadJogadores(List, Order);
            GetListaObservacaoSelecao();
            ComboBoxOrderJogadores();
            comboBoxListaSelecaoJogadores.SelectedIndex = 0;
            comboBoxOrder.SelectedIndex = 0;
            //Clubes
            LoadClubes("");
            ComboBoxOrderClubes();
            //Observador
            LoadObservador();

        }

        //Funções SQL
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source = LAPTOP-MH91MTBV; integrated security = true; initial catalog = Trabalho_Final");
            //MH91MTBV
            //2KEGA0ER
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
            //Meter muito mais coisas
            LoadJogadores("", "");
            LoadClubes("");
            LoadObservador();
            comboBoxListaSelecaoJogadores.SelectedIndex = 0;
            comboBoxOrder.SelectedIndex = 0;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //-----------------------------------------------------------------------------
        //TAB JOGADORES
        //Jogadores Functions
        private void LoadJogadores(String numero, String Order) //Possivel bug no Order By Idade
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmd.Connection = cn;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("Scouting.GetListaJogadores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText="EXEC Scouting.GetListaJogadores @IdadeList , @OrderBy";
                cmd.Parameters.AddWithValue("@IdadeList", numero);
                cmd.Parameters.AddWithValue("@OrderBy", Order);

                reader = cmd.ExecuteReader();
                listBoxJogadores.Items.Clear();
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
                }
                //cn.Close();
                reader.Close();
                currentJogador = 0;
                LockJogadoresControls();
                ShowJogadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Load Jogador na BD database. \n ERROR MESSAGE:" + ex.Message);
            }
        }

        private void listBoxJogadores_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBoxJogadores.SelectedIndex >= 0)
            {
                currentJogador = listBoxJogadores.SelectedIndex;

                //Mostrar Jogadores
                ShowJogadores();
                //Mostrar Posicoes Jogadores
                LoadPositions(textID_FIFPro.Text);
                //Mostrar Relatorios Jogadores
                GetRelatoriosJogadores(textID_FIFPro.Text);
                //Mostrar Número de Relatórios do Jogador
                GetNumeroRelatoriosJogador(textID_FIFPro.Text);
                //Mostrar Clube Atual
                loadClubeAtual(textID_FIFPro.Text);
                //Mostrar Clubes Passados
                GetClubesJogadorPassados(textID_FIFPro.Text);
                //Clear
                listBoxMetodos.Items.Clear();
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
            textPeso.Text = jogador.Jogador_Peso.ToString() + " Kg";
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
        public void LoadPositions(String x)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            try
            {
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
            catch (Exception ex)
            {
                throw new Exception("Falhou Carregar Posições da BD database. \n ERROR MESSAGE: " + ex.Message);
            }

        }

        //Mostrar Jogadores por Lista
        public void GetListaObservacaoSelecao()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_Listas_Observacao_Selecao", cn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();


                Lista_Observacao_Selecao S = new Lista_Observacao_Selecao();
                S.Lista_Nome = "Todos";
                S.Lista_Idade_Maxima = "";

                comboBoxListaSelecaoJogadores.Items.Add(S);
                while (reader.Read())
                {
                    Lista_Observacao_Selecao L = new Lista_Observacao_Selecao();
                    L.Lista_Nome = reader["Lista_Nome"].ToString();
                    L.Lista_Idade_Maxima = reader["Lista_Idade_Maxima"].ToString();
                    comboBoxListaSelecaoJogadores.Items.Add(L);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Carregar Lista da BD database. \n ERROR MESSAGE: " + ex.Message);
            }
        }
        //ComboBox Order by Lista Jogadores
        public void ComboBoxOrderJogadores()
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
            Numero_Internacionalizao.Text = "Internacionalizações";
            Numero_Internacionalizao.Value = "Numero_Internacionalizacoes";
            comboBoxOrder.Items.Add(Numero_Internacionalizao);
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
            radioButtonEsquerdo.Enabled = false;
            radioButtonDireito.Enabled = false;
        }
        //Selecionar Tipo de Selecao
        private void comboBoxListaSelecao_SelectedIndexChanged(object sender, EventArgs e) //Função na 90% certa
        {
            if (comboBoxListaSelecaoJogadores.SelectedIndex >= 0)
            {
                Lista_Observacao_Selecao list = new Lista_Observacao_Selecao();
                list = (Lista_Observacao_Selecao)comboBoxListaSelecaoJogadores.Items[comboBoxListaSelecaoJogadores.SelectedIndex];
                String name = list.Lista_Idade_Maxima.ToString();
                List = name;
                //LoadListaNova
                LoadJogadores(List, Order);
                //LoadNumeroNovo
                GetNumeroJogadoresLista(List);

            }
        }
        //Selecionar Order
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxListaSelecaoJogadores.SelectedIndex >= 0)
            {
                ComboBoxOrder list = new ComboBoxOrder();
                list = (ComboBoxOrder)comboBoxOrder.Items[comboBoxOrder.SelectedIndex];
                String x = list.Value.ToString();
                Order = x;
                //Alterar Load Jogadores
                LoadJogadores(List, Order);

            }
        }
        //Get Número de Jogadores
        private void GetNumeroJogadoresLista(String list)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            try
            {
                //cmd.Connection = cn;
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("select Scouting.Get_NumeroJogadoresLista (@lista)", cn);
                //cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@lista", list);
                textBoxNumeroJogadoresLista.Text = cmda.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Obter o número de  Jogadores da BD database. \n ERROR MESSAGE: " + ex.Message);
            }
        }
        //Obter Clubes Passados
        private void GetClubesJogadorPassados(String id)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_ClubesPassado", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            reader = cmd.ExecuteReader();
            listBoxJogadorClubePassados.Items.Clear();
            while (reader.Read())
            {
                Clube C = new Clube();
                C.Clube_Numero_Inscricao_FIFA = reader["JPC_Clube_Numero_Inscricao_FIFA"].ToString();
                C.Clube_Nome = reader["Clube_Nome"].ToString();
                C.Clube_Pais = reader["Clube_Pais"].ToString();
                DateTime Data_Inicio = DateTime.Parse(reader["Pertence_Data_Inicio"].ToString());
                DateTime Data_Fim = DateTime.Parse(reader["Pertence_Data_Saida"].ToString());
                listBoxJogadorClubePassados.Items.Add(Data_Inicio.ToShortDateString() + "->" + Data_Fim.ToShortDateString() + " " + C.Clube_Nome.ToString());
            }
            reader.Close();

        }

        //Criar Jogador
        private void buttonCriarJogadores_Click(object sender, EventArgs e)
        {
            if (listBoxJogadores.SelectedIndex > -1)
            {
                listBoxJogadores.ClearSelected();
            }
            InsertPlayer ap = new InsertPlayer();
            ap.ShowDialog();
            List = "";
            Order = "";
            comboBoxListaSelecaoJogadores.SelectedIndex = 0;
            comboBoxOrder.SelectedIndex = 0;
            LoadJogadores("", "");

        }

        // Editar Jogador
        private void buttonEditarJogador_Click(object sender, EventArgs e)
        {
            EditarJogador ap = new EditarJogador(textID_FIFPro.Text);
            ap.ShowDialog();
            List = "";
            Order = "";
            comboBoxListaSelecaoJogadores.SelectedIndex = 0;
            comboBoxOrder.SelectedIndex = 0;
            LoadJogadores("", "");
            GetNumeroJogadoresLista(List);


        }
        //Eliminar Jogador
        private void buttonEliminarJogador_Click(object sender, EventArgs e)
        {
            if (listBoxJogadores.Items.Count == 0 | currentJogador < 0)
                return;
            String ID = textID_FIFPro.Text;
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Delete_Jogador", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@ID_FIFPro", ID);
            try
            {
                cmda.ExecuteNonQuery();
                MessageBox.Show("Jogador " + textID_FIFPro.Text + " Removido!");
                LoadJogadores(List, Order);
                GetNumeroJogadoresLista(List);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro Remover Jogador na BD database. \n ERROR MESSAGE: " + ex.Message);

            }


        }

        //Adicionar Posição
        private void buttonInserirPos_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (listBoxJogadores.Items.Count == 0 | currentJogador < 0)
                return;

            if (textBoxinsertPosicoes.Text.Length == 0)
                return;
            try
            {
                SqlCommand cmda = new SqlCommand();
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Insert_Posicoes", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@ID", textID_FIFPro.Text);
                cmda.Parameters.AddWithValue("J_Posicoes", textBoxinsertPosicoes.Text);

                cmda.ExecuteNonQuery();
                MessageBox.Show("Posição " + textBoxinsertPosicoes.Text + " Inserida!");
                textBoxinsertPosicoes.Clear();
                LoadPositions(textID_FIFPro.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO! " + textBoxinsertPosicoes.Text + " Não Inserida! \n ERROR MESSAGE: " + ex.Message);
            }


        }
        //Remover Posição
        private void buttonRemovePos_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (listBoxPosicoes.Items.Count == 0)
                return;
            if (listBoxPosicoes.SelectedIndex < 0) //NÃO ESQUECER COLOCAR
                return;
            String pos = (String)listBoxPosicoes.Items[listBoxPosicoes.SelectedIndex].ToString();
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Delete_Posicoes", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@ID", textID_FIFPro.Text);
            cmda.Parameters.AddWithValue("J_Posicoes", pos);
            try
            {
                cmda.ExecuteNonQuery();
                MessageBox.Show("Posição " + textBoxinsertPosicoes.Text + " Removida!");
                textBoxinsertPosicoes.Clear();
                LoadPositions(textID_FIFPro.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Remover Posição Jogador na BD database. \n ERROR MESSAGE: \n" + ex.Message);

            }
        }
        //Obter Clube Atual
        public void loadClubeAtual(String ID)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //Obter Clube
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Get_ClubeAtual_Jogador", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@id", ID);
                readera = cmda.ExecuteReader();
                while (readera.Read())
                {
                    Clube C = new Clube();
                    C.Clube_Numero_Inscricao_FIFA = readera["Clube_Numero_Inscricao_FIFA"].ToString();
                    C.Clube_Nome = readera["Clube_Nome"].ToString();
                    C.Clube_Pais = readera["Clube_Pais"].ToString();
                    //
                    textBoxClubeAtual.Text = C.Clube_Nome;
                }

                textBoxClubeAtual.Enabled = false;
                readera.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Carregar Clube do Jogador da BD database. \n ERROR MESSAGE: " + ex.Message);
            }

        }

        //-----------------------------------------------------------------------------

        //Funções Relatorio
        public void GetRelatoriosJogadores(String x)
        {
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmd.Connection = cn;
            try
            {
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
                    listBoxRelatoriosJogador.Items.Add(L);
                }
                readera.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Load Relatórios da BD. \n ERROR MESSAGE:" + ex.Message);
            }
        }
        //Adicionar Relatórios
        private void AdicionarRelatorioJogador_Click(object sender, EventArgs e)
        {
            InsertRelatorio ap = new InsertRelatorio(textID_FIFPro.Text);
            ap.ShowDialog();
            GetRelatoriosJogadores(textID_FIFPro.Text);


        }
        //Remover Relatorio
        private void buttonRemoverRelatorio_Click(object sender, EventArgs e)
        {
            if (listBoxRelatoriosJogador.SelectedIndex >= 0)
            {
                currentRelatorioJogador = listBoxRelatoriosJogador.SelectedIndex;
                Relatorio rel = new Relatorio();
                rel = (Relatorio)listBoxRelatoriosJogador.Items[currentRelatorioJogador];
                String ID = rel.ID.ToString();
                if (!verifySGBDConnection())
                    return;
                SqlCommand cmda = new SqlCommand();
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Delete_Relatorio", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@ID", ID);
                try
                {
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Relatório de " + textJNome.Text + " Removido!");
                    GetRelatoriosJogadores(textID_FIFPro.Text);
                    GetNumeroRelatoriosJogador(textID_FIFPro.Text);
                    listBoxMetodos.Items.Clear();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro Remover Relatorio na BD database. \n ERROR MESSAGE: " + ex.Message);

                }


            }
        }
        //Inserir Metodo
        private void buttonInsertMetodo_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (listBoxRelatoriosJogador.SelectedIndex < 0) { return; }
            if (textBoxMetodo.Text is null) { return; }

            currentRelatorioJogador = listBoxRelatoriosJogador.SelectedIndex;
            Relatorio rel = new Relatorio();
            rel = (Relatorio)listBoxRelatoriosJogador.Items[currentRelatorioJogador];
            String ID = rel.ID.ToString();
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Insert_Metodo_Observacao", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@ID", ID);
            cmda.Parameters.AddWithValue("@Metodo", textBoxMetodo.Text);
            try
            {
                cmda.ExecuteNonQuery();

                MessageBox.Show("Metodo em " + rel + " Inserido!");
                textBoxMetodo.Clear();
                Load_Metodos(ID);
            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Insert Metodo Observação na BD database. \n ERROR MESSAGE: \n" + ex.Message);
            }
        }
        //Remover Metodo
        private void buttonDeleteMetodo_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (listBoxMetodos.Items.Count == 0)
                return;
            if (listBoxMetodos.SelectedIndex < 0) //NÃO ESQUECER COLOCAR
                return;
            if (listBoxRelatoriosJogador.SelectedIndex < 0) { return; }


            currentRelatorioJogador = listBoxRelatoriosJogador.SelectedIndex;
            String pos = (String)listBoxMetodos.Items[listBoxMetodos.SelectedIndex].ToString();

            Relatorio rel = new Relatorio();
            rel = (Relatorio)listBoxRelatoriosJogador.Items[currentRelatorioJogador];
            String ID = rel.ID.ToString();
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Delete_Metodo_Observacao", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@ID", ID);
            cmda.Parameters.AddWithValue("@Metodo", pos);
            try
            {
                cmda.ExecuteNonQuery();
                MessageBox.Show("Metodo " + rel + " Inserido!");
                textBoxinsertPosicoes.Clear();
                Load_Metodos(ID);
            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Inserir Metodo  Observacao na BD database. \n ERROR MESSAGE: \n" + ex.Message);

            }
        }

        private void listBoxRelatoriosJogador_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxMetodos.Items.Clear();
            currentRelatorioJogador = listBoxRelatoriosJogador.SelectedIndex;
            String dados = listBoxRelatoriosJogador.GetItemText(listBoxRelatoriosJogador);
            Relatorio rel = new Relatorio();
            rel = (Relatorio)listBoxRelatoriosJogador.Items[currentRelatorioJogador];
            String ID = rel.ID.ToString();
            Load_Metodos(ID);
        }
        //Get INFO REL
        private void GoToInfoRelatorio(object sender, MouseEventArgs e)
        {
            if (listBoxRelatoriosJogador.SelectedIndex >= 0)
            {
                currentRelatorioJogador = listBoxRelatoriosJogador.SelectedIndex;
                String dados = listBoxRelatoriosJogador.GetItemText(listBoxRelatoriosJogador);
                Relatorio rel = new Relatorio();
                rel = (Relatorio)listBoxRelatoriosJogador.Items[currentRelatorioJogador];
                String ID = rel.ID.ToString();
                ViewRelatorio dr = new ViewRelatorio(ID, cn);
                dr.ShowDialog();
            }
        }
        //Editar Relatório
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBoxRelatoriosJogador.SelectedIndex < 0) { return; }
            currentRelatorioJogador = listBoxRelatoriosJogador.SelectedIndex;
            String dados = listBoxRelatoriosJogador.GetItemText(listBoxRelatoriosJogador);
            Relatorio rel = new Relatorio();
            rel = (Relatorio)listBoxRelatoriosJogador.Items[currentRelatorioJogador];
            String ID = rel.ID.ToString();
            UpdateRelatorio dr = new UpdateRelatorio(ID);
            dr.ShowDialog();
            GetRelatoriosJogadores(textID_FIFPro.Text);
        }

        private void GetNumeroRelatoriosJogador(String list)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();

            //cmd.Connection = cn;
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("select Scouting.Get_NumeroRelatoriosJogadores (@id)", cn);
            //cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@id", list);
            textBoxNumeroRelatoriosJogador.Text = cmda.ExecuteScalar().ToString();
        }
        private void Load_Metodos(String id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmda.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_Metodo_Observacao", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRel", id);
            reader = cmd.ExecuteReader();
            listBoxMetodos.Items.Clear();
            while (reader.Read())
            {
                String s = reader["Rel_Metodo_de_Observacao"].ToString();
                listBoxMetodos.Items.Add(s);
            }
            reader.Close();
        }


        //----------------------------------------------------------------------------------------------------------------------
        //TAB CLUBES
        //Funções Clubes
        private void LoadClubes(String Order)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_Lista_Clubes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderBy", Order);

            reader = cmd.ExecuteReader();
            listBoxClubes.Items.Clear();
            while (reader.Read())
            {
                Clube C = new Clube();
                C.Clube_Numero_Inscricao_FIFA = reader["Clube_Numero_Inscricao_FIFA"].ToString();
                C.Clube_Nome = reader["Clube_Nome"].ToString();
                C.Clube_Pais = reader["Clube_Pais"].ToString();
                listBoxClubes.Items.Add(C);
            }
            reader.Close();
            currentClube = 0;
            LockClubesControls();
            ShowClubes();
        }
        //Mostrar Dados Clube
        private void ShowClubes()
        {
            if (listBoxClubes.Items.Count == 0 | currentClube < 0)
                return;
            Clube clube = new Clube();
            clube = (Clube)listBoxClubes.Items[currentClube];
            textBoxClubeNome.Text = clube.Clube_Nome;
            textBoxClubePais.Text = clube.Clube_Pais;
            textBoxNumeroInscricaoFifaClube.Text = clube.Clube_Numero_Inscricao_FIFA;


        }
        //MostrarDadosClubeSelected
        private void listBoxClubes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClubes.SelectedIndex >= 0)
            {
                currentClube = listBoxClubes.SelectedIndex;

                //Mostrar Clubes
                ShowClubes();
                //Mostrar Competições Clube
                GetClubeCompeticoes(textBoxNumeroInscricaoFifaClube.Text);
                //Mostrar Jogos do Clube na Competicao
                GetClubeJogosCompeticao(textBoxNumeroInscricaoFifaClube.Text, "");
                //Mostrar Jogadores Atuais do Clube
                GetClubeJogadores(textBoxNumeroInscricaoFifaClube.Text);
                //Mostrar Treinador Atual
                GetTreinadorAtualClube(textBoxNumeroInscricaoFifaClube.Text);
                //Obter Número Jogadores Atuais
                GetNumeroJogadoresClubeAtuais(textBoxNumeroInscricaoFifaClube.Text);
            }

        }
        //PrencherComboBoxOrderClubes
        public void ComboBoxOrderClubes()
        {
            ComboBoxOrder Null = new ComboBoxOrder();
            Null.Text = "Null";
            Null.Value = "";
            comboBoxOrderClubes.Items.Add(Null);

            ComboBoxOrder Clube_Numero_Inscricao_FIFA = new ComboBoxOrder();
            Clube_Numero_Inscricao_FIFA.Text = "Número de Inscrição FIFA";
            Clube_Numero_Inscricao_FIFA.Value = "Clube_Numero_Inscricao_FIFA";
            comboBoxOrderClubes.Items.Add(Clube_Numero_Inscricao_FIFA);

            ComboBoxOrder Clube_Pais = new ComboBoxOrder();
            Clube_Pais.Text = "País";
            Clube_Pais.Value = "Clube_Pais";
            comboBoxOrderClubes.Items.Add(Clube_Pais);

            ComboBoxOrder Clube_Nome = new ComboBoxOrder();
            Clube_Nome.Text = "Nome";
            Clube_Nome.Value = "Clube_Nome";
            comboBoxOrderClubes.Items.Add(Clube_Nome);
        }
        //Bloquear Dados Jogadores
        public void LockClubesControls()
        {
            textBoxClubeNome.ReadOnly = true;
            textBoxClubePais.ReadOnly = true;
            textBoxNumeroInscricaoFifaClube.ReadOnly = true;
            textBoxNumeroJogadores.ReadOnly = true;
            textBoxTreinadorAtual.ReadOnly = true;
        }
        //OrderSelected
        private void comboBoxOrderClubes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrderClubes.SelectedIndex >= 0)
            {
                ComboBoxOrder list = new ComboBoxOrder();
                list = (ComboBoxOrder)comboBoxOrderClubes.Items[comboBoxOrderClubes.SelectedIndex];
                String x = list.Value.ToString();
                Order = x;
                LoadClubes(Order);
            }
        }

        //Obter Numero De jogadores Atuais
        private void GetNumeroJogadoresClubeAtuais(String clube)
        {

            SqlCommand cmda = new SqlCommand();
            //cmd.Connection = cn;
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("select Scouting.Get_NumeroJogadoresEquipa (@Clube_Numero_Inscricao_FIFA)", cn);
            //cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@Clube_Numero_Inscricao_FIFA", clube);
            textBoxNumeroJogadores.Text = cmda.ExecuteScalar().ToString();
        }





        //CompetiçõesClubes Load
        private void GetClubeCompeticoes(String x)
        {
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmd.Connection = cn;
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Get_Competicoes_By_Clube", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@Club_ID", x);
            readera = cmda.ExecuteReader();
            listBoxCompeticaoClube.Items.Clear();
            Competicao n = new Competicao();
            n.Competicao_ID_FIFA = "0";
            n.Competicao_Nome = "Null";
            n.Competicao_Numero_Equipas = "Null";
            comboBoxOrderClubes.Items.Add(n);
            while (readera.Read())
            {
                Competicao P = new Competicao();
                P.Competicao_ID_FIFA = readera["Competicao_ID_FIFA"].ToString();
                P.Competicao_Nome = readera["Competicao_Nome"].ToString();
                P.Competicao_Numero_Equipas = readera["Competicao_Numero_Equipas"].ToString();
                listBoxCompeticaoClube.Items.Add(P);
            }
            readera.Close();
        }

        private void GetClubeJogosCompeticao(String Club, String Comp)
        {
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmd.Connection = cn;
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Get_Jogos_By_Clube", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@Club_ID", Club);
            cmda.Parameters.AddWithValue("@Comp_ID", Comp);
            readera = cmda.ExecuteReader();
            listBoxJogosClubeCompeticao.Items.Clear();
            while (readera.Read())
            {
                Jogo J = new Jogo();
                J.Jogo_Data = readera["Jogo_Data"].ToString();
                J.Jogo_Local = readera["Jogo_Local"].ToString();
                J.Resultado = readera["Resultado"].ToString();
                J.Jogo_Competicao_ID_FIFA = readera["Jogo_Competicao_ID_FIFA"].ToString();
                J.Obs_Num_Iden_Federacao = readera["Obs_Num_Iden_Federacao"].ToString();
                listBoxJogosClubeCompeticao.Items.Add(J);
            }
            readera.Close();
        }
        //Get  Jogadores
        private void GetClubeJogadores(String x)
        {

            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_JogadoresAtuais_By_Clube", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText="EXEC Scouting.GetListaJogadores @IdadeList , @OrderBy";
            cmd.Parameters.AddWithValue("@Club_ID", x);

            reader = cmd.ExecuteReader();
            listBoxJogadoresClube.Items.Clear();
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
                listBoxJogadoresClube.Items.Add(C);
            }
            //cn.Close();
            reader.Close();

        }


        private void GetTreinadorAtualClube(String x)
        {


            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_TreinadorAtual_By_Clube", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText="EXEC Scouting.GetListaJogadores @IdadeList , @OrderBy";
            cmd.Parameters.AddWithValue("@Club_ID", x);

            reader = cmd.ExecuteReader();
            textBoxTreinadorAtual.Clear();
            while (reader.Read())
            {

                textBoxTreinadorAtual.Text = reader["Treinador_Nome"].ToString();

            }
            //cn.Close();
            reader.Close();
        }

        private void listBoxCompeticaoClube_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClubes.SelectedIndex >= 0)
            {
                currentClubeComp = listBoxCompeticaoClube.SelectedIndex;
                Competicao c = new Competicao();
                c = (Competicao)listBoxCompeticaoClube.Items[listBoxCompeticaoClube.SelectedIndex];
                String namec = c.Competicao_ID_FIFA.ToString();
                //Mostrar Jogos do Clube na Competicao
                GetClubeJogosCompeticao(textBoxNumeroInscricaoFifaClube.Text, namec);
            }
        }
        //Inserir Clube
        private void buttonInsertClube_Click(object sender, EventArgs e)
        {
            if (listBoxClubes.SelectedIndex > -1)
            {
                listBoxClubes.ClearSelected();
            }
            InsertClube ap = new InsertClube();
            ap.ShowDialog();
            comboBoxListaSelecaoJogadores.SelectedIndex = 0;
            comboBoxOrder.SelectedIndex = 0;
            LoadClubes("");
        }
        //Editar Clube
        private void buttonEditClube_Click(object sender, EventArgs e)
        {
            UpdateClube ap = new UpdateClube(textBoxNumeroInscricaoFifaClube.Text);
            ap.ShowDialog();
            comboBoxOrderClubes.SelectedIndex = 0;
            LoadClubes("");

        }





        //TAB OBSERVADOR
        private void LoadObservador() //SEM ORDER BY PARA AGORA (REUTILIZAR A DO CRIAR RELATORIO
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmd.Connection = cn;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("Scouting.Get_Observador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                LISTA_OBSERVADORES.Items.Clear();
                while (reader.Read())
                {
                    Observador O = new Observador();
                    O.Numero_Identificacao_Federacao = reader["Numero_Identificacao_Federacao"].ToString();
                    O.Observador_Nome = reader["Observador_Nome"].ToString();
                    O.Observador_Idade = reader["Observador_Idade"].ToString();
                    O.Observador_Nacionalidade = reader["Observador_Nacionalidade"].ToString();
                    O.Area_Observacao = reader["Area_Observacao"].ToString();
                    O.Observador_Qualificacoes = reader["Observador_Qualificações"].ToString();
                    LISTA_OBSERVADORES.Items.Add(O);
                }
                //cn.Close();
                reader.Close();
                currentObservador = 0;
                LockObservadorControls();
                ShowObservador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Load Observadores na BD database. \n ERROR MESSAGE:" + ex.Message);
            }
        }


        public void ShowObservador()
        {
            if (LISTA_OBSERVADORES.Items.Count == 0 | currentObservador < 0)
                return;
            Observador observador = new Observador();
            observador = (Observador)LISTA_OBSERVADORES.Items[currentObservador];
            ID_FEDER.Text = observador.Numero_Identificacao_Federacao;
            NOME_OBS.Text = observador.Observador_Nome;
            QUALIFIC_OBS.Text = observador.Observador_Qualificacoes;
            NACIONALIDADE_OBS.Text = observador.Observador_Nacionalidade;
            IDADE_OBS.Text = observador.Observador_Idade;
            AREA_OBSERVACAO.Text = observador.Area_Observacao;

        }

        //Obter Relatorios Observador
        private void GetRelatoriosObservador(String x, String Order)
        {
            Console.WriteLine("Entrou");
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmd.Connection = cn;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("Scouting.Get_Relatorios_Observador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", x);
                cmd.Parameters.AddWithValue("@Order_By", Order);
                reader = cmd.ExecuteReader();
                RELATORIOS_OBS.Items.Clear();
                while (reader.Read())
                {
                    Relatorio L = new Relatorio();
                    L.ID = reader["ID"].ToString();
                    L.Relatorio_Titulo = reader["Relatorio_Titulo"].ToString();
                    L.Relatorio_Data = reader["Relatorio_Data"].ToString();
                    L.Numero_Identificacao_Federacao = reader["Numero_Identificacao_Federacao"].ToString();
                    L.ID_FIFPro = reader["ID_FIFPro"].ToString();
                    L.Jogo_Local = reader["Jogo_Local"].ToString();
                    L.Jogo_Data = reader["Jogo_Data"].ToString();
                    RELATORIOS_OBS.Items.Add(L);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Load Relatórios da BD. \n ERROR MESSAGE:" + ex.Message);
            }

        }

        private void LockObservadorControls()
        {

            ID_FEDER.Enabled = false;
            NOME_OBS.Enabled = false;
            QUALIFIC_OBS.Enabled = false;
            NACIONALIDADE_OBS.Enabled = false;
            IDADE_OBS.Enabled = false;
            AREA_OBSERVACAO.Enabled = false;

        }

        private void LISTA_OBSERVADORES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LISTA_OBSERVADORES.SelectedIndex >= 0)
            {
                currentObservador = LISTA_OBSERVADORES.SelectedIndex;

                //Mostrar Observador
                ShowObservador();
                //Mostrar Relatorios
                GetRelatoriosObservador(ID_FEDER.Text, ""); //Sem Order por causa da ComboBox
            }
        }
        //Criar Observador
        private void buttonInserirObs_Click(object sender, EventArgs e)
        {
            Inserir_Observador io = new Inserir_Observador();
            io.ShowDialog();
            LoadObservador();
        }
        //Editar Observador
        private void buttonEditObservador_Click(object sender, EventArgs e)
        {
            if (LISTA_OBSERVADORES.SelectedIndex < 0)
            {
                return;
            }
            Update_Observador io = new Update_Observador(ID_FEDER.Text);
            io.ShowDialog();
            LoadObservador();
        }
        //Eliminar Observador
        private void buttonDeleteObs_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (LISTA_OBSERVADORES.SelectedIndex < 0)
            {
                return;
            }
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Delete_Observador", cn);
            cmda.CommandType = CommandType.StoredProcedure;

            cmda.Parameters.AddWithValue("@id_Fed", ID_FEDER.Text);

            try
            {
                cmda.ExecuteNonQuery();
                MessageBox.Show("Observador " + NOME_OBS.Text.ToString() + " Eliminado!");
                LoadObservador();
                GetRelatoriosJogadores(textID_FIFPro.Text);
                RELATORIOS_OBS.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Editar Observador na BD database. \n ERROR MESSAGE:" + ex.Message);

            }
        }
        private void buttonJogadorClube_Click(object sender, EventArgs e)
        {

        }

    }
}



