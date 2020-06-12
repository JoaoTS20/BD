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
    public partial class Update_Observador : Form
    {
        public Update_Observador(String id)
        {
            InitializeComponent();
            LoadObservador(id);
        }
        private SqlConnection cn;
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
        private void LoadObservador(String Id) //SEM ORDER BY PARA AGORA (REUTILIZAR A DO CRIAR RELATORIO
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmd.Connection = cn;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("Scouting.Get_Observador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Observador O = new Observador();
                    O.Numero_Identificacao_Federacao = reader["Numero_Identificacao_Federacao"].ToString();
                    O.Observador_Nome = reader["Observador_Nome"].ToString();
                    O.Observador_Idade = reader["Observador_Idade"].ToString();
                    O.Observador_Nacionalidade = reader["Observador_Nacionalidade"].ToString();
                    O.Area_Observacao = reader["Area_Observacao"].ToString();
                    O.Observador_Qualificacoes = reader["Observador_Qualificações"].ToString();
                    if (O.Numero_Identificacao_Federacao == Id)
                    {

                        ID_FEDER.Text = O.Numero_Identificacao_Federacao;
                        ID_FEDER.Enabled = false;
                        NOME_OBS.Text = O.Observador_Nome;
                        QUALIFIC_OBS.Text = O.Observador_Qualificacoes;
                        NACIONALIDADE_OBS.Text = O.Observador_Nacionalidade;
                        IDADE_OBS.Text = O.Observador_Idade;
                        AREA_OBSERVACAO.Text = O.Area_Observacao;
                    }
                }
                //cn.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Load Observadores na BD database. \n ERROR MESSAGE:" + ex.Message);
            }
        }





        private void buttonEditObs_Click(object sender, EventArgs e)
        {
            Observador O = new Observador();
            O.Area_Observacao = AREA_OBSERVACAO.Text.ToString();
            O.Numero_Identificacao_Federacao = ID_FEDER.Text.ToString();
            O.Observador_Idade = IDADE_OBS.Text.ToString();
            O.Observador_Nacionalidade = NACIONALIDADE_OBS.Text.ToString();
            O.Observador_Qualificacoes = QUALIFIC_OBS.Text.ToString();
            O.Observador_Nome = NOME_OBS.Text.ToString();

            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Update_Observador", cn);
            cmda.CommandType = CommandType.StoredProcedure;

            cmda.Parameters.AddWithValue("@id_fed", O.Numero_Identificacao_Federacao);
            cmda.Parameters.AddWithValue("@nome", O.Observador_Nome);
            cmda.Parameters.AddWithValue("@qualificacoes", O.Observador_Qualificacoes);
            cmda.Parameters.AddWithValue("@nacionalidade", O.Observador_Nacionalidade);
            cmda.Parameters.AddWithValue("@idade", Int32.Parse(O.Observador_Idade));
            cmda.Parameters.AddWithValue("@area", O.Area_Observacao);
            try
            {
                cmda.ExecuteNonQuery();
                MessageBox.Show("Observador " + NOME_OBS.Text.ToString() + " Editado!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Editar Observador na BD database. \n ERROR MESSAGE:" + ex.Message);

            }
        }
    }
}
