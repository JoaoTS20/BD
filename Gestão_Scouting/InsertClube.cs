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

    public partial class InsertClube : Form
    {
        private SqlConnection cn;
        public InsertClube()
        {
            InitializeComponent();
        }
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source=LAPTOP-MH91MTBV;integrated security=true;initial catalog=Trabalho_Final_Video");
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        private void buttonDeleteClube_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            try
            {
                SqlCommand cmda = new SqlCommand();
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Insert_Clube", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@Clube_Numero_Inscricao", textBoxNumeroInscricaoFifaClube.Text);
                cmda.Parameters.AddWithValue("@Clube_Pais", textBoxClubePais.Text);
                cmda.Parameters.AddWithValue("@Clube_Nome", textBoxClubeNome.Text);


                try
                {
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Clube " + textBoxClubeNome.Text + " Inserido!");
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Falhou Inserir Clube na BD database. \n ERROR MESSAGE:" + ex.Message);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Dados. \n ERROR MESSAGE:" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxClubeNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxClubePais_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNumeroInscricaoFifaClube_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
