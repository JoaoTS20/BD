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
    public partial class InsertJogador_Clube : Form
    {
        private SqlConnection cn;

        public InsertJogador_Clube(String IDCl)
        {
            InitializeComponent();
            textBox1.Text = IDCl;
            textBox1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            LoadJogadores();
        }
        //Funções SQL
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source=LAPTOP-MH91MTBV;integrated security=true;initial catalog=Trabalho_Final_Video");
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



        private void LoadJogadores()
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
                cmd.Parameters.AddWithValue("@IdadeList", "");
                cmd.Parameters.AddWithValue("@OrderBy", "");

                reader = cmd.ExecuteReader();
                listBox1.Items.Clear();
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
                    listBox1.Items.Add(C);
                }
                //cn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Load Jogador na BD database. \n ERROR MESSAGE:" + ex.Message);
            }
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTransferir_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Jogador list = new Jogador();
                list = (Jogador)listBox1.Items[listBox1.SelectedIndex];
                String ID_Comp = list.ID_FIFPro.ToString();
                if (!verifySGBDConnection())
                    return;
                SqlCommand cmda = new SqlCommand();
                try
                {
                    cmda.CommandType = CommandType.Text;
                    cmda = new SqlCommand("Scouting.Insert_Jogador_To_Clube", cn);
                    cmda.CommandType = CommandType.StoredProcedure;
                    cmda.Parameters.AddWithValue("@club_insc", textBox1.Text);
                    cmda.Parameters.AddWithValue("@id_fifpro", ID_Comp);
                    cmda.Parameters.AddWithValue("@data_ini", dateTimePicker1.Value.Date);
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Jogador Inscrito!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro! " + ex.Message);
                }
            }
        }
    }
}
