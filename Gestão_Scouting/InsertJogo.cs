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
    

    public partial class InsertJogo : Form
    {
        private SqlConnection cn;
        public InsertJogo(String IDComp)
        {
            InitializeComponent();
            textBoxCompID.Text = IDComp;
            textBoxCompID.Enabled = false;
            ComboBoxOrder();
            comboBoxObservadoresList.SelectedIndex = 0;
            LoadObservador("");
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
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
        //ComboBox Order by Lista Observadores
        public void ComboBoxOrder()
        {
            ComboBoxOrder Null = new ComboBoxOrder();
            Null.Text = "Null";
            Null.Value = "";
            comboBoxObservadoresList.Items.Add(Null);

            ComboBoxOrder ID = new ComboBoxOrder();
            ID.Text = "Número Identificação Federação";
            ID.Value = "Numero_Identificacao_Federacao";
            comboBoxObservadoresList.Items.Add(ID);


            ComboBoxOrder NOME = new ComboBoxOrder();
            NOME.Text = "Nome";
            NOME.Value = "Observador_Nome";
            comboBoxObservadoresList.Items.Add(NOME);

            ComboBoxOrder QUAL = new ComboBoxOrder();
            QUAL.Text = "Qualificações";
            QUAL.Value = "Observador_Qualificações";
            comboBoxObservadoresList.Items.Add(QUAL);

            ComboBoxOrder NAC = new ComboBoxOrder();
            NAC.Text = "Nacionalidade";
            NAC.Value = "Observador_Nacionalidade";
            comboBoxObservadoresList.Items.Add(NAC);

            ComboBoxOrder Idade = new ComboBoxOrder();
            Idade.Text = "Idade";
            Idade.Value = "Observador_Idade";
            comboBoxObservadoresList.Items.Add(Idade);

            ComboBoxOrder Area = new ComboBoxOrder();
            Area.Text = "Área Observação";
            Area.Value = "Area_Observacao";
            comboBoxObservadoresList.Items.Add(Area);
        }
        private void LoadObservador(String order)
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
                cmd.Parameters.AddWithValue("@sort_by", order);
                cmd.Parameters.AddWithValue("@filter_by", "");
                cmd.Parameters.AddWithValue("@filter_value", "");

                reader = cmd.ExecuteReader();
                listBoxObservadores.Items.Clear();
                while (reader.Read())
                {
                    Observador O = new Observador();
                    O.Numero_Identificacao_Federacao = reader["Numero_Identificacao_Federacao"].ToString();
                    O.Observador_Nome = reader["Observador_Nome"].ToString();
                    O.Observador_Idade = reader["Observador_Idade"].ToString();
                    O.Observador_Nacionalidade = reader["Observador_Nacionalidade"].ToString();
                    O.Area_Observacao = reader["Area_Observacao"].ToString();
                    O.Observador_Qualificacoes = reader["Observador_Qualificações"].ToString();
                    listBoxObservadores.Items.Add(O);
                }
                //cn.Close();
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Load Observadores na BD database. \n ERROR MESSAGE:" + ex.Message);
            }

        }
        private void buttonInserir_Click(object sender, EventArgs e)
        {
            if(listBoxObservadores.SelectedIndex>=0 & !String.IsNullOrEmpty(textBoxLocal.Text) & !String.IsNullOrEmpty(textBoxResultado.Text))
            {
                Observador c = new Observador();
                c = (Observador)listBoxObservadores.Items[listBoxObservadores.SelectedIndex];
                String idObsev = c.Numero_Identificacao_Federacao.ToString();
                try
                {
                    SqlCommand cmda = new SqlCommand();
                    cmda.CommandType = CommandType.Text;
                    cmda = new SqlCommand("Scouting.Insert_Jogo", cn);
                    cmda.CommandType = CommandType.StoredProcedure;
                    cmda.Parameters.AddWithValue("@data", dateTimePicker1.Value.Date.ToString());
                    cmda.Parameters.AddWithValue("@local", textBoxLocal.Text);
                    cmda.Parameters.AddWithValue("@resultado", textBoxResultado.Text);
                    cmda.Parameters.AddWithValue("@comp_id", textBoxCompID.Text);
                    cmda.Parameters.AddWithValue("@obs_id", idObsev);
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Jogo Inserido!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falhou Delete  na BD database. \n ERROR MESSAGE: \n" + ex.Message);

                }









            }























        }
    }
}
