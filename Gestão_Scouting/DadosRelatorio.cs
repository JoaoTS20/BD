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
            Load_Show_Data(id,cn);
        }

        private void Load_Show_Data(String id,SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmda.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.GetRelatorioData", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //Load Part
                Metricas_Jogo_Jogador DAA = new Metricas_Jogo_Jogador();
                Analise_Caracteristica_Jogador DBB = new Analise_Caracteristica_Jogador();
                DAA.Numero_Golos = reader["Numero_Golos"].ToString();
                DAA.Numero_Assistencias = reader["Numero_Assistencias"].ToString();
                DAA.Numero_Passes_Efectuados = reader["Numero_Passes_Efectuados"].ToString();
                DAA.Numero_Passes_Completos = reader["Numero_Passes_Completos"].ToString();
                DAA.Numero_Cortes = reader["Numero_Cortes"].ToString();
                DAA.Minutos_Jogados = reader["Minutos_Jogados"].ToString();
                DAA.Defesas_Realizadas = reader["Defesas_Realizadas"].ToString();
                DAA.Distancia_Percorrida = reader["Distancia_Percorrida"].ToString();
                DAA.Numero_Toques = reader["Numero_Toques"].ToString();
                DAA.Numero_Dribles = reader["Numero_Dribles"].ToString();
                DAA.Numero_Remates = reader["Numero_Remates"].ToString();
                DAA.Rel_ID = reader["Rel_ID"].ToString();
                DAA.Obs_Num_Iden_Federacao = reader["Obs_Num_Iden_Federacao"].ToString();
                //---------------------------------------------------------------------
                DBB.Etica_Trabalho = reader["Etica_Trabalho"].ToString();
                DBB.Capacidade_Decisao = reader["Capacidade_Decisao"].ToString();

                //-----------------------------------------------------------------------

                //Show Part
                    //Metricas_Jogo_Jogador
                GolosBox.Text = DAA.Numero_Golos;
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
                //-----------------------------------------------------------------------
                    //Analise_Caracteristica_Jogador
                EticaTrabBox.Text = DBB.Etica_Trabalho;
                //CapDecBox.Text = DBB.Capacidade_Decisao;

                if (Int32.Parse(DBB.Capacidade_Decisao) > 85)
                {
                    CapDecBox.Text = DBB.Capacidade_Decisao + " - Muito Bom ";
                }
                //Isto pois é copy past para os restantes e mais ifs e tal
                //E falta as datas e assim!!

            }
            reader.Close();
        }

        private void DadosRelatorio_Load(object sender, EventArgs e)
        {

        }
    }
}
