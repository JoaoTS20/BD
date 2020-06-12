using Gestão_Scouting.Classes;
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
            ObterCompeticaoClube(IDComp);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
        //Funções SQL
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection(ContainerConection.Connection);
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
        private void buttonInserir_Click(object sender, EventArgs e)
        {
            if(listBoxObservadores.SelectedIndex>=0 & listBoxCompeticaoClubes.SelectedIndex>=0 & !String.IsNullOrEmpty(textBoxConvocados.Text) &!String.IsNullOrEmpty(textBoxLocal.Text) & !String.IsNullOrEmpty(textBoxResultado.Text))
            {
                Observador c = new Observador();
                c = (Observador)listBoxObservadores.Items[listBoxObservadores.SelectedIndex];
                String idObsev = c.Numero_Identificacao_Federacao.ToString();

                Clube ca = new Clube();
                ca= (Clube)listBoxCompeticaoClubes.Items[listBoxCompeticaoClubes.SelectedIndex];
                String idc = ca.Clube_Numero_Inscricao_FIFA.ToString();
                try
                {
                    SqlCommand cmda = new SqlCommand();
                    cmda.CommandType = CommandType.Text;
                    cmda = new SqlCommand("Scouting.Insert_Jogo", cn);
                    cmda.CommandType = CommandType.StoredProcedure;
                    cmda.Parameters.AddWithValue("@data", dateTimePicker1.Value.Date);
                    cmda.Parameters.AddWithValue("@local", textBoxLocal.Text);
                    cmda.Parameters.AddWithValue("@resultado", textBoxResultado.Text);
                    cmda.Parameters.AddWithValue("@comp_id", textBoxCompID.Text);
                    cmda.Parameters.AddWithValue("@obs_id", idObsev);
                    cmda.Parameters.AddWithValue("@id_club",idc);
                    cmda.Parameters.AddWithValue("@convocados", Int32.Parse(textBoxConvocados.Text));
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

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
