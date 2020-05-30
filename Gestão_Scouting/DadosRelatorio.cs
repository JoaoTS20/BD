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

    public partial class DadosRelatorio : Form
    {


        public DadosRelatorio(String id, SqlConnection cn)
        {
            InitializeComponent();

            showData(id,cn);
        }
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source=LAPTOP-2KEGA0ER;integrated security=true;initial catalog=Project");
        }

        private void Voltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void showData(String id,SqlConnection cn)
        {
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //cmda.Connection = cn;
            cmda.CommandType = CommandType.Text;
            cmda = new SqlCommand("Scouting.GetRelatorioData", cn);
            cmda.CommandType = CommandType.StoredProcedure;
            cmda.Parameters.AddWithValue("@ID", id);
            readera = cmda.ExecuteReader();
            String dados = "";
            String[] dadossep;
            while (readera.Read())
            {
                Dados_Analiticos_Abs DAA = new Dados_Analiticos_Abs();
                DAA.Numero_Golos = readera["Numero_Golos"].ToString();
                DAA.Numero_Assistencias = readera["Numero_Assistencias"].ToString();
                DAA.Numero_Passes_Completos = readera["Numero_Passes_Efetuados"].ToString();
                DAA.Numero_Passes_Completos = readera["Numero_Passes_Completos"].ToString();
                DAA.Numero_Cortes = readera["Numero_Cortes"].ToString();
                DAA.Minutos_Jogados = readera["Minutos_Jogados"].ToString();
                DAA.Defesas_Realizadas = readera["Defesas_Realizadas"].ToString();
                DAA.Distancia_Percorrida = readera["Distancia_Percorrida"].ToString();
                DAA.Numero_Toques = readera["Numero_Toques"].ToString();
                DAA.Numero_Dribles = readera["Numero_Dribles"].ToString();
                DAA.Numero_Remates = readera["Numero_Remates"].ToString();
                DAA.Rel_ID = readera["Rel_ID"].ToString();
                DAA.Obs_Num_Iden_Federacao = readera["Obs_Num_Iden_Federacao"].ToString();
                dados = DAA.toString();
                dadossep = dados.Split(' ');
                GolosBox.Text = dadossep[0];
                AssistsBox.Text = DAA.Numero_Assistencias;
                PassesBox.Text = DAA.Numero_Passes_Efectuados;
                PassesCompBox.Text = DAA.Numero_Passes_Completos;
                CortesBox.Text = DAA.Numero_Cortes;
                MinutosBox.Text = DAA.Minutos_Jogados;
                DefesasBox.Text = DAA.Defesas_Realizadas;
                DistanciaBox.Text = DAA.Distancia_Percorrida;
                ToquesBox.Text = DAA.Numero_Toques;
                DriblesBox.Text = DAA.Numero_Dribles;
                RematesBox.Text = DAA.Numero_Remates;
            }
            readera.Close();
        }
    }
}
