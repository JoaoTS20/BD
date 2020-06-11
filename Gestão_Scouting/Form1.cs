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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

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
            LoadObservador("");
            ComboBoxOrderObservadores();
            ORDENAR_OBS.SelectedIndex = 0;
            ComboBoxOrderRelatorios();
            ORDENAR_RELATORIOS.SelectedIndex = 0;
            //Competições
            ComboBoxOrderCompeticao();
            ORDENAR_COMP.SelectedIndex = 0;
            GetCompeticoes("");
            //Gestão
            loadListaObservacaoSelecao();
            GetTreinadores();


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
            LoadObservador("");
            comboBoxListaSelecaoJogadores.SelectedIndex = 0;
            comboBoxOrder.SelectedIndex = 0;
            ORDENAR_OBS.SelectedIndex = 0;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //-----------------------------------------------------------------------------
        //TAB JOGADORES
        //Jogadores Functions
        private void LoadJogadores(String numero, String Order) 
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
            comboBoxListaSelecaoJogadores.Items.Clear();
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
                textBoxClubeAtual.Clear();
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
            GetNumeroClubes();
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
        private void GetNumeroClubes()
        {
            SqlCommand cmda = new SqlCommand();
            //cmd.Connection = cn;
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("select Scouting.Get_Numero_Clubes ()", cn);
            textBoxNumeroClubes.Text = cmda.ExecuteScalar().ToString();
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
            if (listBoxClubes.SelectedIndex >= 0)
            {
                UpdateClube ap = new UpdateClube(textBoxNumeroInscricaoFifaClube.Text);
                ap.ShowDialog();
                comboBoxOrderClubes.SelectedIndex = 0;
                LoadClubes("");
            }
        }
        
        //Inscrever em Competição;
        private void buttonAdicionarClubeCompeticao_Click(object sender, EventArgs e)
        {
            if (listBoxClubes.SelectedIndex >= 0)
            {
               InsertCompeticao_Clube ap = new InsertCompeticao_Clube(textBoxNumeroInscricaoFifaClube.Text);
               ap.ShowDialog();
                GetClubeCompeticoes(textBoxNumeroInscricaoFifaClube.Text);
                ORDENAR_COMP.SelectedIndex = 0;
                GetCompeticoes("");
            }

        }
        //Desinscrever
        private void buttonDeleteCompClube_Click(object sender, EventArgs e)
        {
            if(listBoxClubes.SelectedIndex>=0 && listBoxCompeticaoClube.SelectedIndex >= 0)
            {
                currentClubeComp = listBoxCompeticaoClube.SelectedIndex;
                Competicao c = new Competicao();
                c = (Competicao)listBoxCompeticaoClube.Items[listBoxCompeticaoClube.SelectedIndex];
                String namec = c.Competicao_ID_FIFA.ToString();
                try {
                    SqlCommand cmda = new SqlCommand();
                    cmda.CommandType = CommandType.Text;
                    cmda = new SqlCommand("Scouting.Delete_Competicao_Clube", cn);
                    cmda.CommandType = CommandType.StoredProcedure;
                    cmda.Parameters.AddWithValue("@clube_id", textBoxNumeroInscricaoFifaClube.Text);
                    cmda.Parameters.AddWithValue("@compet_id", namec);
                    
                        cmda.ExecuteNonQuery();
                        MessageBox.Show("Desinscrição!");
                        GetClubeCompeticoes(textBoxNumeroInscricaoFifaClube.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falhou Inserir Metodo  Observacao na BD database. \n ERROR MESSAGE: \n" + ex.Message);

                }
            }
        }
        //Jogador IR para o Clube
        private void buttonAdicionarJogadorClube_Click(object sender, EventArgs e)
        {
            if (listBoxClubes.SelectedIndex >= 0)
            {
                InsertJogador_Clube ap = new InsertJogador_Clube(textBoxNumeroInscricaoFifaClube.Text);
                ap.ShowDialog();
                GetClubeCompeticoes(textBoxNumeroInscricaoFifaClube.Text);
                ORDENAR_COMP.SelectedIndex = 0;
                GetClubeJogadores(textBoxNumeroInscricaoFifaClube.Text);
            }


        }

        //Jogador Sair do Clube
        private void buttonDeleteJogadorClube_Click(object sender, EventArgs e)
        {
            if(listBoxClubes.SelectedIndex >= 0 && listBoxJogadoresClube.SelectedIndex >= 0)
            {
                currentClubeComp = listBoxCompeticaoClube.SelectedIndex;
                Jogador c = new Jogador();
                c = (Jogador)listBoxJogadoresClube.Items[listBoxJogadoresClube.SelectedIndex];
                String namec = c.ID_FIFPro.ToString();
                try
                {
                    SqlCommand cmda = new SqlCommand();
                    cmda.CommandType = CommandType.Text;
                    cmda = new SqlCommand("Scouting.Delete_Jogador_From_Clube", cn);
                    cmda.CommandType = CommandType.StoredProcedure;
                    cmda.Parameters.AddWithValue("@club_insc", textBoxNumeroInscricaoFifaClube.Text);
                    cmda.Parameters.AddWithValue("@id_fifpro", namec);
                    cmda.Parameters.AddWithValue("data_fin", dateTimePicker1.Value.Date.ToString());

                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Jogador "+namec+" já não pertence ao Clube!");
                    GetClubeJogadores(textBoxNumeroInscricaoFifaClube.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falhou Delete  na BD database. \n ERROR MESSAGE: \n" + ex.Message);

                }
            }
        }


        /////TAB OBSERVADOR\\\\\
        ///
        private void LoadObservador(String Order) //SEM ORDER BY PARA AGORA (REUTILIZAR A DO CRIAR RELATORIO
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmd.Connection = cn;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("Scouting.Get_Lista_Observadores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sort_by", Order);
                cmd.Parameters.AddWithValue("@filter_by", "");
                cmd.Parameters.AddWithValue("@filter_value", "");
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
                GetNumeroObservador();
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
        private void GetJogosObservador(String ID)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Get_Jogos_Observador", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@obs_id", ID);
                readera = cmda.ExecuteReader();
               JOGOS_ANALISADOS.Items.Clear();
                while (readera.Read())
                {
                    Jogo J = new Jogo();
                    J.Jogo_Data = readera["Jogo_Data"].ToString().Replace("/", "-");
                    J.Jogo_Local = readera["Jogo_Local"].ToString();
                    J.Resultado = readera["Resultado"].ToString();
                    J.Jogo_Competicao_ID_FIFA = readera["Jogo_Competicao_ID_FIFA"].ToString();
                    J.Obs_Num_Iden_Federacao = readera["Obs_Num_Iden_Federacao"].ToString();
                    JOGOS_ANALISADOS.Items.Add(J);
                }
                readera.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Carregar Jogos do Jogador da BD database. \n ERROR MESSAGE: " + ex.Message);
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
                ORDENAR_RELATORIOS.SelectedIndex = 0;
                
                GetRelatoriosObservador(ID_FEDER.Text, "");
                //gET nÚMERO DE Relatorios
                GetNumeroRelatorios(ID_FEDER.Text);
                //gET nÚMERO DE jogos
                GetNumeroJogosObservador(ID_FEDER.Text);
                //GET JOGOS OBS
                GetJogosObservador(ID_FEDER.Text);
            }
        }
        //PREENCHER ComboBOX oBSERVADDOR
        public void ComboBoxOrderObservadores()
        {
            ComboBoxOrder Null = new ComboBoxOrder();
            Null.Text = "Null";
            Null.Value = "";
            ORDENAR_OBS.Items.Add(Null);

            ComboBoxOrder Observador_Nome = new ComboBoxOrder();
            Observador_Nome.Text = "Nome";
            Observador_Nome.Value = "Observador_Nome";
            ORDENAR_OBS.Items.Add(Observador_Nome);

            ComboBoxOrder Observador_Qualificações = new ComboBoxOrder();
            Observador_Qualificações.Text = "Qualificações";
            Observador_Qualificações.Value = "Observador_Qualificações";
            ORDENAR_OBS.Items.Add(Observador_Qualificações);

            ComboBoxOrder Observador_Nacionalidade = new ComboBoxOrder();
            Observador_Nacionalidade.Text = "Nacionalidade";
            Observador_Nacionalidade.Value = "Observador_Nacionalidade";
            ORDENAR_OBS.Items.Add(Observador_Nacionalidade);

            ComboBoxOrder Idade = new ComboBoxOrder();
            Idade.Text = "Idade";
            Idade.Value = "Observador_Idade";
            ORDENAR_OBS.Items.Add(Idade);

            ComboBoxOrder Area_Observacao = new ComboBoxOrder();
            Area_Observacao.Text = "Área Observação";
            Area_Observacao.Value = "Area_Observacao";
            ORDENAR_OBS.Items.Add(Area_Observacao);
        }
        //pRENCHER COMBOX ORDERNAR RELATORIOS
        public void ComboBoxOrderRelatorios()
        {
            ComboBoxOrder Null = new ComboBoxOrder();
            Null.Text = "Null";
            Null.Value = "";
            ORDENAR_RELATORIOS.Items.Add(Null);

            ComboBoxOrder ID = new ComboBoxOrder();
            ID.Text = "ID";
            ID.Value = "ID";
            ORDENAR_RELATORIOS.Items.Add(ID);

            ComboBoxOrder Relatorio_Titulo = new ComboBoxOrder();
            Relatorio_Titulo.Text = "Título";
            Relatorio_Titulo.Value = "Relatorio_Titulo";
            ORDENAR_RELATORIOS.Items.Add(Relatorio_Titulo);

            ComboBoxOrder DATA = new ComboBoxOrder();
            DATA.Text = "Data";
            DATA.Value = "Relatorio_Data";
            ORDENAR_RELATORIOS.Items.Add(DATA);

            ComboBoxOrder ID_J = new ComboBoxOrder();
            ID_J.Text = "ID_FIFPro";
            ID_J.Value = "Observador_Idade";
            ORDENAR_RELATORIOS.Items.Add(ID_J);

            ComboBoxOrder Jogo_Local = new ComboBoxOrder();
            Jogo_Local.Text = "Jogo Local";
            Jogo_Local.Value = "Jogo_Local";
            ORDENAR_RELATORIOS.Items.Add(Jogo_Local);

            ComboBoxOrder Jogo_Data = new ComboBoxOrder();
            Jogo_Data.Text = "Jogo Data";
            Jogo_Data.Value = "Jogo_Data";
            ORDENAR_RELATORIOS.Items.Add(Jogo_Data);

        }



        //Criar Observador
        private void buttonInserirObs_Click(object sender, EventArgs e)
        {
            Inserir_Observador io = new Inserir_Observador();
            io.ShowDialog();
            LoadObservador("");
            ORDENAR_OBS.SelectedIndex = 0;
            GetNumeroObservador();
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
            LoadObservador("");
            ORDENAR_OBS.SelectedIndex = 0;
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
                LoadObservador("");
                ORDENAR_OBS.SelectedIndex = 0;
                GetRelatoriosJogadores(textID_FIFPro.Text);
                RELATORIOS_OBS.Items.Clear();
                GetNumeroObservador();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Editar Observador na BD database. \n ERROR MESSAGE:" + ex.Message);

            }
        }
        //ORDER OBS
        private void ORDENAR_OBS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ORDENAR_OBS.SelectedIndex >= 0)
            {
                ComboBoxOrder list = new ComboBoxOrder();
                list = (ComboBoxOrder)ORDENAR_OBS.Items[ORDENAR_OBS.SelectedIndex];
                String x = list.Value.ToString();
                //Alterar Load oBSERVADORES
                LoadObservador(x);
                RELATORIOS_OBS.Items.Clear();
                
            }
        }
        private void buttonJogadorClube_Click(object sender, EventArgs e)
        {

        }
        //Ordenar Relatorios Observador
        private void ORDENAR_RELATORIOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ORDENAR_RELATORIOS.SelectedIndex >= 0)
            {
                ComboBoxOrder list = new ComboBoxOrder();
                list = (ComboBoxOrder)ORDENAR_RELATORIOS.Items[ORDENAR_RELATORIOS.SelectedIndex];
                String x = list.Value.ToString();
                //Alterar Load oBSERVADORES

                GetRelatoriosObservador(ID_FEDER.Text, x);
            }
        }
        //
        private void GetNumeroObservador()
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("select Scouting.Get_NumeroObservadores ()", cn);
            textBoxNumeroObservadores.Text = cmda.ExecuteScalar().ToString();
        }
        private void GetNumeroRelatorios(String id)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            try
            {
                //cmd.Connection = cn;
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("select Scouting.Get_NumRelatoriosObservador (@id_obs)", cn);
                //cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@id_obs", id);
                textBoxNumeroRelatoriosObservador.Text = cmda.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Obter o número de  Relatorios da BD database. \n ERROR MESSAGE: " + ex.Message);
            }

        }
        private void GetNumeroJogosObservador(String id)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            try
            {
                //cmd.Connection = cn;
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("select Scouting.Get_NumJogosObservador (@id_obs)", cn);
                //cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@id_obs", id);
                textBoxNumeroJogosObservador.Text = cmda.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Obter o número de  Jogos da BD database. \n ERROR MESSAGE: " + ex.Message);
            }
        }

        ///TAB COMPETIÇÕES
        ///
        //pRENCHER COMBOX ORDERNAR RELATORIOS
        public void ComboBoxOrderCompeticao()
        {
            ComboBoxOrder Null = new ComboBoxOrder();
            Null.Text = "Null";
            Null.Value = "";
            ORDENAR_COMP.Items.Add(Null);

            ComboBoxOrder Competicao_Nome = new ComboBoxOrder();
            Competicao_Nome.Text = "Nome";
            Competicao_Nome.Value = "Competicao_Nome";
            ORDENAR_COMP.Items.Add(Competicao_Nome);

            ComboBoxOrder Competicao_Numero_Equipas = new ComboBoxOrder();
            Competicao_Numero_Equipas.Text = "Número de Equipas";
            Competicao_Numero_Equipas.Value = "Competicao_Numero_Equipas";
            ORDENAR_COMP.Items.Add(Competicao_Numero_Equipas);

            ComboBoxOrder Competicao_ID_FIFA = new ComboBoxOrder();
            Competicao_ID_FIFA.Text = "ID FIFA";
            Competicao_ID_FIFA.Value = "Competicao_ID_FIFA";
            ORDENAR_COMP.Items.Add(Competicao_ID_FIFA);
        }


        //Obter Lista Competições Ordenada ou Não

        private void GetCompeticoes(String order)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmd.Connection = cn;
            try {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Get_Lista_Competicoes", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@orderby", order);
                readera = cmda.ExecuteReader();
                listBoxCompeticao.Items.Clear();
                while (readera.Read())
                {
                    Competicao P = new Competicao();
                    P.Competicao_ID_FIFA = readera["Competicao_ID_FIFA"].ToString();
                    P.Competicao_Nome = readera["Competicao_Nome"].ToString();
                    P.Competicao_Numero_Equipas = readera["Competicao_Numero_Equipas"].ToString();
                    listBoxCompeticao.Items.Add(P);

                }
                readera.Close();
                GetNumeroCompeticoes();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro Load Competições:  " +ex.Message);
            }
        }
         //Obter Competicao Jogos
        private void ObterCompeticaoJogos(String ID)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmd.Connection = cn;
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Get_Jogos_By_Competicao", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@Comp_ID", ID);
                readera = cmda.ExecuteReader();
                listBoxCompeticaoJogos.Items.Clear();
                while (readera.Read())
                {
                    Jogo J = new Jogo();
                    J.Jogo_Data = readera["Jogo_Data"].ToString();
                    J.Jogo_Local = readera["Jogo_Local"].ToString();
                    J.Resultado = readera["Resultado"].ToString();
                    J.Jogo_Competicao_ID_FIFA = readera["Jogo_Competicao_ID_FIFA"].ToString();
                    J.Obs_Num_Iden_Federacao = readera["Obs_Num_Iden_Federacao"].ToString();
                    listBoxCompeticaoJogos.Items.Add(J);
                }
                readera.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro Load Competições Jogos :  " + ex.Message);
            }
        }
        //Obter Equipas Competição

        private void ObterCompeticaoClube(String id)
        {

            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmd.Connection = cn;
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Get_Clubes_By_Competicao", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@id_comp", id);
                cmda.Parameters.AddWithValue("@orderby", "");
                readera = cmda.ExecuteReader();
                listBoxCompeticaoClubes.Items.Clear();
                while (readera.Read())
                {
                    Clube C = new Clube();
                    C.Clube_Numero_Inscricao_FIFA = readera["Clube_Numero_Inscricao_FIFA"].ToString();
                    C.Clube_Nome = readera["Clube_Nome"].ToString();
                    C.Clube_Pais = readera["Clube_Pais"].ToString();
                    listBoxCompeticaoClubes.Items.Add(C);
                }
                readera.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Load Clubes Jogos :  " + ex.Message);
            }

        }
        private void ORDENAR_COMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ORDENAR_COMP.SelectedIndex >= 0)
            {
                ComboBoxOrder list = new ComboBoxOrder();
                list = (ComboBoxOrder)ORDENAR_COMP.Items[ORDENAR_COMP.SelectedIndex];
                String x = list.Value.ToString();
                //Alterar Load oBSERVADORES

                GetCompeticoes(x);
            }
        }
        // Mostrar Jogos e Equipas E data  
        private void listBoxCompeticao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCompeticao.SelectedIndex >= 0)
            {
                Competicao list = new Competicao();
                list = (Competicao)listBoxCompeticao.Items[listBoxCompeticao.SelectedIndex];
                String x = list.Competicao_ID_FIFA.ToString();
                //Obter Jogos
                ObterCompeticaoJogos(x);
                //Número de Jogos
                GetNumeroJogosCompeticoes(x);
                //Obter Clubes;
                ObterCompeticaoClube(x);
                //Obter N Clubes
                GetNumeroClubesCompeticoes(x);
            }
        }
        //Inserir Competição
        private void buttonInserirCompeticao_Click(object sender, EventArgs e)
        {
            if ( String.IsNullOrEmpty(textBoxIDcomp.Text)  || String.IsNullOrEmpty(textBoxNumero.Text) || String.IsNullOrEmpty(textBoxNomeComp.Text))
            {
                return;
            }
            if (!verifySGBDConnection())
                return;
            try
            {
                SqlCommand cmda = new SqlCommand();
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Insert_Competicao", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@Competicao_ID_FIFA", textBoxIDcomp.Text);
                cmda.Parameters.AddWithValue("@Competicao_Nome", textBoxNomeComp.Text);
                cmda.Parameters.AddWithValue("@Competicao_Numero_Equipas", textBoxNumero.Text);


                try
                {
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Competição " + textBoxNomeComp.Text + " Inserido!");
                    ORDENAR_COMP.SelectedIndex = 0;
                    GetCompeticoes("");
                    GetNumeroCompeticoes();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Falhou Inserir Competição na BD database. \n ERROR MESSAGE:" + ex.Message);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Dados. \n ERROR MESSAGE:" + ex.Message);
            }
        }
        //Update Competição
        private void buttonEditarCompeticao_Click(object sender, EventArgs e)
        {
            if (listBoxCompeticao.SelectedIndex >= 0)
            {
                Competicao list = new Competicao();
                list = (Competicao)listBoxCompeticao.Items[listBoxCompeticao.SelectedIndex];
                String x = list.Competicao_ID_FIFA.ToString();
                UpdateCompeticao dr = new UpdateCompeticao(x);
                dr.ShowDialog();
                ORDENAR_COMP.SelectedIndex = 0;
                GetCompeticoes("");
            }
        }
        //Numero Competições

        private void GetNumeroCompeticoes()
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("select Scouting.Get_Numero_Competicoes ()", cn);
            textBoxNumeroCompeticao.Text = cmda.ExecuteScalar().ToString();
        }
        private void GetNumeroJogosCompeticoes(String x)
        {
            if (!verifySGBDConnection())
                return;
            textBoxJogoC.Clear();
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("select Scouting.Get_Numero_Jogos_Por_Competicao (@id_comp)", cn);
            cmda.Parameters.AddWithValue("@id_comp", x);
            textBoxJogoC.Text = cmda.ExecuteScalar().ToString();
        }
        private void GetNumeroClubesCompeticoes(String x)
        {
            if (!verifySGBDConnection())
                return;
            textBoxNumeroClubesCompeticao.Clear();
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("select Scouting.Get_Numero_Clubes_Por_Competicao (@id_comp)", cn);
            cmda.Parameters.AddWithValue("@id_comp", x);

            textBoxNumeroClubesCompeticao.Text = cmda.ExecuteScalar().ToString();
        }
        //Apagar Competição
        private void buttonDeleteCompeticao_Click(object sender, EventArgs e)
        {
            if (listBoxCompeticao.SelectedIndex >= 0)
            {

                Competicao list = new Competicao();
                list = (Competicao)listBoxCompeticao.Items[listBoxCompeticao.SelectedIndex];
                String x = list.Competicao_ID_FIFA.ToString();
                //Meter aqui para SP
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                try
                {
                   cmd = new SqlCommand("Scouting.Delete_Competicao", cn);
                   cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_comp", x);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Competição"+ x +"Eliminada");
                    ORDENAR_COMP.SelectedIndex = 0;
                    GetCompeticoes("");
                    listBoxCompeticaoClubes.Items.Clear();
                    listBoxCompeticaoJogos.Items.Clear();
                    textBoxNumeroClubesCompeticao.Clear();
                    textBoxJogoC.Clear();
                    GetNumeroCompeticoes();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Falhou Eliminar Competição da BD database. \n ERROR MESSAGE: " + ex.Message);

                }

            }
        }
        //Inserir Jogo à Competição
        private void buttonInsertJogo_Click(object sender, EventArgs e)
        {
            if (listBoxCompeticao.SelectedIndex >= 0)
            {
                Competicao list = new Competicao();
                list = (Competicao)listBoxCompeticao.Items[listBoxCompeticao.SelectedIndex];
                String x = list.Competicao_ID_FIFA.ToString();
                InsertJogo dr = new InsertJogo(x);
                dr.ShowDialog();
                ORDENAR_COMP.SelectedIndex = 0;
                ObterCompeticaoClube(x);
                GetNumeroJogosCompeticoes(x);
            }
        }
        //Editar Jogo
        private void buttonEditJogo_Click(object sender, EventArgs e)
        {

        }
        /////////TAB GESTÃO////////
        ///
        //Load ListaObservacaoSelecao()
        public void loadListaObservacaoSelecao()
        {
            listBoxListasDeSelecao.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_Listas_Observacao_Selecao", cn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lista_Observacao_Selecao L = new Lista_Observacao_Selecao();
                    L.Lista_Nome = reader["Lista_Nome"].ToString();
                    L.Lista_Idade_Maxima = reader["Lista_Idade_Maxima"].ToString();
                    listBoxListasDeSelecao.Items.Add(L);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Carregar Lista da BD database. \n ERROR MESSAGE: " + ex.Message);
            }
        }
        //Inserir Lista Observação
        private void buttonInsLista_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBoxnomelista.Text) || String.IsNullOrEmpty(textBoxidademax.Text)) { return; }
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("Scouting.Insert_Lista_Observ", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idade_max", Int32.Parse(textBoxidademax.Text));
                cmd.Parameters.AddWithValue("@lista_nome", textBoxnomelista.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sucesso!");
                loadListaObservacaoSelecao();
                textBoxnomelista.Clear();
                textBoxnomelista.Clear();
                GetListaObservacaoSelecao();

            }
            catch(Exception ex)
            {
                MessageBox.Show("ERRO: " +ex.Message);
            }

        }


        private void GetSelecionador(String idlista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_ID_Selecionador", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idade_max", idlista);
            try
            {
                textBoxSelecionadorID.Clear();
                textBoxSelecionadorIdade.Clear();
                textBoxSelecionadorQualificacoes.Clear();
                textBoxNomeSelecionador.Clear();
                textBoxNac.Clear();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Selecionador L = new Selecionador();
                    L.Selecionador_Nome = reader["Selecionador_Nome"].ToString();
                    L.Selecionador_Idade = reader["Selecionador_Idade"].ToString();
                    L.Selecionador_Nacionalidade = reader["Selecionador_Nacionalidade"].ToString();
                    L.Selecionador_Numero_Identificacao_Federacao = reader["Selecionador_Numero_Identificacao_Federacao"].ToString();
                    L.Selecionador_Qualificacao = reader["Selecionador_Qualificacao"].ToString();
                
                    textBoxSelecionadorID.Text = L.Selecionador_Numero_Identificacao_Federacao;
                    textBoxSelecionadorIdade.Text = L.Selecionador_Idade;
                    textBoxSelecionadorQualificacoes.Text = L.Selecionador_Qualificacao;
                    textBoxNomeSelecionador.Text = L.Selecionador_Nome;
                    textBoxNac.Text = L.Selecionador_Nacionalidade;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Carregar Selec da BD database. \n ERROR MESSAGE: " + ex.Message);
            }
        }
        //Ver o Selecionador
        private void listBoxListasDeSelecao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxListasDeSelecao.SelectedIndex >= 0)
            {
                Lista_Observacao_Selecao list = new Lista_Observacao_Selecao();
                list = (Lista_Observacao_Selecao)listBoxListasDeSelecao.Items[listBoxListasDeSelecao.SelectedIndex];
                String x = list.Lista_Idade_Maxima.ToString();
                GetSelecionador(x);
            }
        }

        private void GetTreinadores()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_Treinadores", cn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Treinador L = new Treinador();
                    L.Treinador_Nome = reader["Treinador_Nome"].ToString();
                    L.Treinador_Numero_Inscricao_FIFA = reader["Treinador_Numero_Inscricao_FIFA"].ToString();
                    L.Treinador_Qualificacao = reader["Treinador_Qualificacao"].ToString();
                    L.Treindaor_Idade = reader["Treinador_Idade"].ToString();
                    L.Treindaor_Nacionalidade = reader["Treinador_Nacionalidade"].ToString();
                    listBoxTreinadores.Items.Add(L);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Carregar Selec da BD database. \n ERROR MESSAGE: " + ex.Message);
            }
        }



        //Var Dados do Treinador 
        private void listBoxTreinadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTreinadores.SelectedIndex >= 0)
            {
                Treinador list = new Treinador();
                list = (Treinador)listBoxTreinadores.Items[listBoxTreinadores.SelectedIndex];
                textBoxIDTreinador.Text = list.Treinador_Numero_Inscricao_FIFA.ToString();
                textBoxTreinadorNome.Text =list.Treinador_Nome;
                textBoxTreinadorQualificoes.Text=list.Treinador_Qualificacao.ToString();
                textBoxTreinadorIdade.Text = list.Treindaor_Idade;
                textBoxTreinadorNacionalidade.Text = list.Treindaor_Nacionalidade;
            }

        }
    }
}




