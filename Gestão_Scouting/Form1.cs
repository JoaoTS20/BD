﻿using System;
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
        private static String List="";
        private static String Order="";
        public static  String[] ids;
        //Clubes TAB
        private int currentClube;
        private int currentClubeComp;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            //Jogadores
            LoadJogadores(List,Order);
            GetListaObservacaoSelecao();
            ComboBoxOrderJogadores();
            comboBoxListaSelecaoJogadores.SelectedIndex=0;
            comboBoxOrder.SelectedIndex = 0;
            //Clubes
            LoadClubes("");
            ComboBoxOrderClubes();

        }

        //Funções SQL
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source=LAPTOP-MH91MTBV;integrated security=true;initial catalog=Trabalho_Final");
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
            LoadJogadores("","");
            LoadClubes("");
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
            if (listBoxJogadores.SelectedIndex >= 0)
            {
                currentJogador = listBoxJogadores.SelectedIndex;
                
                //Mostrar Jogadores
                ShowJogadores();
                //Mostrar Posicoes Jogadores
                LoadPositions(textID_FIFPro.Text);
                //Mostrar Relatorios Jogadores
                GetRelatoriosJogadores(textID_FIFPro.Text);

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
        public void LoadPositions(String x)
        {
            if (!verifySGBDConnection())
                return;
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
            //ComboBox Order by
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
            if (comboBoxListaSelecaoJogadores.SelectedIndex >= 0)
            {
                Lista_Observacao_Selecao list = new Lista_Observacao_Selecao();
                list = (Lista_Observacao_Selecao)comboBoxListaSelecaoJogadores.Items[comboBoxListaSelecaoJogadores.SelectedIndex];
                String name = list.Lista_Idade_Maxima.ToString();
                List = name;
                //LoadListaNova
                LoadJogadores(List,Order);
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
        //
        private void GetNumeroJogadoresLista(String list) {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();

            //cmd.Connection = cn;
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("select Scouting.Get_NumeroJogadoresLista (@lista)", cn);
            //cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@lista", list);
            textBoxNumeroJogadoresLista.Text = cmda.ExecuteScalar().ToString();
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
            //Query quase feita
        }
            //Eliminar Jogador
        private void buttonEliminarJogador_Click(object sender, EventArgs e)
        {
            //Query Quase feita
        }

        //Adicionar Posição
        private void buttonInserirPos_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (textBoxinsertPosicoes.Text.Length == 0)
                return;
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Insert_Posicoes", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@ID", textID_FIFPro.Text);
            cmda.Parameters.AddWithValue("J_Posicoes", textBoxinsertPosicoes.Text);
            try
            {
                cmda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Inserir Posição Jogador na BD database. \n ERROR MESSAGE: \n" + ex.Message);

            }
            finally
            {
                MessageBox.Show("Posição " + textBoxinsertPosicoes.Text + " Inserida!");
                textBoxinsertPosicoes.Clear();
                LoadPositions(textID_FIFPro.Text);
            }

        }
            //Remover Posição
        private void buttonRemovePos_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (listBoxPosicoes.Items.Count == 0)
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
            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Remover Posição Jogador na BD database. \n ERROR MESSAGE: \n" + ex.Message);

            }
            finally
            {
                MessageBox.Show("Posição " + textBoxinsertPosicoes.Text + " Removida!");
                textBoxinsertPosicoes.Clear();
                LoadPositions(textID_FIFPro.Text);
            }
        }


        //-----------------------------------------------------------------------------

        //Funções Relatorio
        public void GetRelatoriosJogadores(String x)
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
                listBoxRelatoriosJogador.Items.Add(L);
            }
            readera.Close();

        }

        private void GoToInfoRelatorio(object sender, MouseEventArgs e)
        {
            if (listBoxRelatoriosJogador.SelectedIndex >= 0)
            {
                currentRelatorioJogador = listBoxRelatoriosJogador.SelectedIndex;
                String dados = listBoxRelatoriosJogador.GetItemText(listBoxRelatoriosJogador);

                //String[] texto = listBoxRelatoriosJogador.GetItemText(dados).Split(' ');
                //String id = texto[0];
                Relatorio rel = new Relatorio();
                rel = (Relatorio)listBoxRelatoriosJogador.Items[currentRelatorioJogador];
                String ID = rel.ID.ToString();
                DadosRelatorio dr = new DadosRelatorio(ID, cn);
                dr.ShowDialog();
            }
        }
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
                GetClubeJogosCompeticao(textBoxNumeroInscricaoFifaClube.Text,"");
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
            textBoxNúmeroJogadores.ReadOnly = true;
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
             textBoxNumeroJogadoresAtuais.Text = cmda.ExecuteScalar().ToString();
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

        private void GetClubeJogosCompeticao(String Club, String Comp) {
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


        private void GetTreinadorAtualClube(String x) {


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
                MessageBox.Show(namec+ "Funciona crl com dados certos");
                //Mostrar Jogos do Clube na Competicao
                GetClubeJogosCompeticao(textBoxNumeroInscricaoFifaClube.Text, namec);
            }
        }


    }
}



