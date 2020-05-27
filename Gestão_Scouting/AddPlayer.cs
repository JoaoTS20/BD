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
    public partial class AddPlayer : Form
    {
        private SqlConnection cn;

        public AddPlayer()
        {
            InitializeComponent();
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

        private void Adicionar_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd;
            SqlDataReader reader;
            
            cmd = new SqlCommand("SELECT * FROM Scouting.Jogador", cn);
            

            reader = cmd.ExecuteReader();
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
            }
        
            try
            {
                int id = Int32.Parse(ID.Text);

            }
            catch (InvalidCastException)
            {
                return;
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
