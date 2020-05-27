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
        public static String[] ids;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            LoadJogadores("");
            GetListaObservacaoSelecao();


        }

        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source= LAPTOP-2KEGA0ER;integrated security=true;initial catalog=Proj");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        //Utils Functions
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LoadJogadores("");
            comboBoxListaSelecao.SelectedIndex = 0;
        }




        //Jogadores Functions
        private void LoadJogadores(String numero) //Com as alterações fica 70%feita
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd;
            SqlDataReader reader;
            //Esta parte aqui é feita numa query UDF ou Stored Procedure
            if (numero == "")
            {   
                
                cmd = new SqlCommand("SELECT * FROM Scouting.Jogador", cn);
            }
            else
            {
                String x = "SELECT * FROM Scouting.Jogador WHERE Lista_Idade_Maxima =" + numero;
                cmd = new SqlCommand(x, cn);
            }
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
                C.Numero_Internacionalizao = reader["Numero_Internacionalizao"].ToString();
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
                ShowJogadores();

            }
        }
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


        public void GetListaObservacaoSelecao()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Scouting.Lista_Observacao_Selecao", cn);
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

        //--Bloquear Dados Jogadores
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

        private void comboBoxListaSelecao_SelectedIndexChanged(object sender, EventArgs e) //Função na 80% certa
        {
            if (comboBoxListaSelecao.SelectedIndex >= 0)
            {
                Lista_Observacao_Selecao list = new Lista_Observacao_Selecao();
                list = (Lista_Observacao_Selecao)comboBoxListaSelecao.Items[comboBoxListaSelecao.SelectedIndex];
                String name = list.Lista_Idade_Maxima.ToString();
                LoadJogadores(name);

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCriarJogadores_Click(object sender, EventArgs e)
        {
            if (listBoxJogadores.SelectedIndex > -1)
            {
                listBoxJogadores.ClearSelected();
            }
            AddPlayer ap = new AddPlayer();
            ap.ShowDialog();
        }
    }
}

