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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            addPlayers();
            // dataGridView1.DataSource
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


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            addPlayers();
        }
        private void addPlayers()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Scouting.Jogador", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
            //listBox1.Items.Add("ID   Nome  Altura   Peso   Idade   NºInternacionalizações");
            //List<Jogador> n = new List<Jogador>();
            // DataTable dt = new DataTable();

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
                listBox1.Items.Add(C);

            }

            //dataGridView1.DataSource = dt;

            //Para a Data Grid



            cn.Close();


            currentJogador = 0;
            //LockControls();
            //ShowJogador();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadPlayerAndDataById()
        {
            Console.WriteLine("Entrou bro");
            /*DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT * FROM Scouting.Jogador", cn);
            adpt.Fill(dt);
            listBox2.DataSource = dt;*/
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox1.Visible = false;
            listBox2.Visible = true;
            string indice = listBox1.Text;
            string[] vals = indice.Split('\t');
            label1.Text="Relatório relativo a "+vals[1];
            label1.Visible = true;
            loadPlayerAndDataById();
        }
    }
    }

