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
    public partial class Inserir_Observador : Form
    {
        public Inserir_Observador()
        {
            InitializeComponent();

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


        private void buttonInserirObs_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            Observador O = new Observador();
            O.Area_Observacao = AREA_OBSERVACAO.Text.ToString();
            O.Numero_Identificacao_Federacao = ID_FEDER.Text.ToString();
            O.Observador_Idade = IDADE_OBS.Text.ToString();
            O.Observador_Nacionalidade = NACIONALIDADE_OBS.Text.ToString();
            O.Observador_Qualificacoes = QUALIFIC_OBS.Text.ToString();
            O.Observador_Nome = NOME_OBS.Text.ToString();

            SqlCommand cmda = new SqlCommand();
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.Insert_Observador", cn);
            cmda.CommandType = CommandType.StoredProcedure;

            cmda.Parameters.AddWithValue("@Numero_Identificacao_Federacao", O.Numero_Identificacao_Federacao);
            cmda.Parameters.AddWithValue("@Observador_Nome", O.Observador_Nome);
            cmda.Parameters.AddWithValue("@Observador_Qualificacoes", O.Observador_Qualificacoes);
            cmda.Parameters.AddWithValue("@Obsevador_Nacionalidade", O.Observador_Nacionalidade);
            cmda.Parameters.AddWithValue("@Observador_Idade", Int32.Parse(O.Observador_Idade));
            cmda.Parameters.AddWithValue("@Area_Obsevacao", O.Area_Observacao);

            try
            {
                cmda.ExecuteNonQuery();
                MessageBox.Show("Observador " + NOME_OBS.Text.ToString() + " Inserido!");
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Falhou Inserir Observador na BD database. \n ERROR MESSAGE:" + ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
