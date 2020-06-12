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
    public partial class InsertCompeticao_Clube : Form
    {
        public InsertCompeticao_Clube(String IDClube)
        {
            InitializeComponent();
            textBox2.Text = IDClube;
            textBox2.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            GetCompeticoes();
        }
        private SqlConnection cn;
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source = LAPTOP-MH91MTBV; integrated security = true; initial catalog = Trabalho_Final_Video");
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
        private void GetCompeticoes()
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
                listBoxComp.Items.Clear();
                while (readera.Read())
                {
                    Competicao P = new Competicao();
                    P.Competicao_ID_FIFA = readera["Competicao_ID_FIFA"].ToString();
                    P.Competicao_Nome = readera["Competicao_Nome"].ToString();
                    P.Competicao_Numero_Equipas = readera["Competicao_Numero_Equipas"].ToString();
                    listBoxComp.Items.Add(P);

                }
                readera.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Load Competições:  " + ex.Message);
            }
        }
        private void buttonInscrever_Click(object sender, EventArgs e)
        {
            if (listBoxComp.SelectedIndex >= 0 & !String.IsNullOrEmpty(textBox1.Text))
            {
                Competicao list = new Competicao();
                list = (Competicao)listBoxComp.Items[listBoxComp.SelectedIndex];
                String ID_Comp = list.Competicao_ID_FIFA.ToString();
                int Numero_Jogadores = Int32.Parse(textBox1.Text);
                String data = dateTimePicker1.Value.Date.ToString();
                if (!verifySGBDConnection())
                    return;
                SqlCommand cmda = new SqlCommand();
                try
                {
                    cmda.CommandType = CommandType.Text;
                    cmda = new SqlCommand("Scouting.Insert_Competicao_Clube", cn);
                    cmda.CommandType = CommandType.StoredProcedure;
                    cmda.Parameters.AddWithValue("@clube_id", textBox2.Text);
                    cmda.Parameters.AddWithValue("@compet_id", ID_Comp);
                    cmda.Parameters.AddWithValue("@num_jog", Numero_Jogadores);
                    cmda.Parameters.AddWithValue("@data_insc", data);
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Clube Inscrito!");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro! " + ex.Message);
                }

            }

        }
    }
}
