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
    public partial class UpdateCompeticao : Form
    {

        SqlConnection cn;
        public UpdateCompeticao(String x)
        {
            InitializeComponent();
            textBoxIDcomp.Text = x;
            textBoxIDcomp.Enabled = false;
            DATACompeticao(x);
        }
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
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdateCompeticao_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmd.Connection = cn;
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Update_Competicao", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@id_fifa", textBoxIDcomp.Text);
                cmda.Parameters.AddWithValue("@nome", textBoxNomeComp.Text);
                cmda.Parameters.AddWithValue("@num_equipas", textBoxNumero.Text);
                cmda.ExecuteNonQuery();
                MessageBox.Show("Competição: Editada");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Load Competição:  " + ex.Message);
            }
        }
        private void DATACompeticao(String x)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmd.Connection = cn;
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Get_Lista_Competicoes", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@orderby", "");
                readera = cmda.ExecuteReader();
                while (readera.Read())
                {
                    Competicao P = new Competicao();
                    P.Competicao_ID_FIFA = readera["Competicao_ID_FIFA"].ToString();
                    P.Competicao_Nome = readera["Competicao_Nome"].ToString();
                    P.Competicao_Numero_Equipas = readera["Competicao_Numero_Equipas"].ToString();
                    if (P.Competicao_ID_FIFA == x)
                    {
                        textBoxNomeComp.Text = P.Competicao_Nome;
                        textBoxNumero.Text = P.Competicao_Numero_Equipas;
                    }
                }
                readera.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Load Competição:  " + ex.Message);
            }
        }
    }
}
