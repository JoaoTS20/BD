using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestão_Scouting
{
    public partial class UpdateClube : Form
    {
        private SqlConnection cn;
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source=LAPTOP-MH91MTBV;integrated security=true;initial catalog=Trabalho_Final");
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        public UpdateClube(String id)
        {
            InitializeComponent();
            loadClubedata(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadClubedata(String id)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_Lista_Clubes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderBy", "");

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Clube C = new Clube();
                C.Clube_Numero_Inscricao_FIFA = reader["Clube_Numero_Inscricao_FIFA"].ToString();
                C.Clube_Nome = reader["Clube_Nome"].ToString();
                C.Clube_Pais = reader["Clube_Pais"].ToString();
                if (C.Clube_Numero_Inscricao_FIFA == id) {
                    textBoxClubeNome.Text = C.Clube_Nome;
                    textBoxNumeroInscricaoFifaClube.Text = C.Clube_Numero_Inscricao_FIFA;
                    textBoxNumeroInscricaoFifaClube.Enabled = false;
                    textBoxClubePais.Text = C.Clube_Pais;
                }
            }
            reader.Close();
        }


        private void buttonEditClube_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            try
            {
                SqlCommand cmda = new SqlCommand();
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Update_Clube", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@Clube_Numero_Inscricao", textBoxNumeroInscricaoFifaClube.Text);
                cmda.Parameters.AddWithValue("@Clube_Pais", textBoxClubePais.Text);
                cmda.Parameters.AddWithValue("@Clube_Nome", textBoxClubeNome.Text);


                try
                {
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Clube " + textBoxClubeNome.Text + " Editado!");
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Falhou Editar Clube na BD database. \n ERROR MESSAGE:" + ex.Message);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Dados. \n ERROR MESSAGE:" + ex.Message);
            }
        }
    }
}
