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
    public partial class ViewRelatorio : Form
    {
        public ViewRelatorio(String id, SqlConnection cn)
        {
            InitializeComponent();
            Load_Show_Data(id, cn);
            Load_Metodos(id, cn);
            LockJogadoresControls();
        }

        private  void Load_Metodos(String id, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmda.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_Metodo_Observacao", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idRel", id);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String s = reader["Rel_Metodo_de_Observacao"].ToString();
                listBoxMetodos.Items.Add(s);
            }
            reader.Close();
        }

        
        private void Load_Show_Data(String id, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            try
            {
                //cmda.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd = new SqlCommand("Scouting.GetRelatorioData", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    textBoxTitulo.Text = reader["Relatorio_Titulo"].ToString();
                    textBoxJogID.Text = reader["ID_FIFPro"].ToString();
                    textBoxData.Text = DateTime.Parse(reader["Relatorio_Data"].ToString()).ToShortDateString();
                    textBoxJogo.Text = reader["Jogo_Local"].ToString() + "  " + DateTime.Parse(reader["Jogo_Data"].ToString()).ToShortDateString();
                    textBoxObs.Text = reader["Observador_Nome"].ToString();
                    textBoxJogID.Text = reader["ID_FIFPro"].ToString();
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
                    DBB.Determinacao = reader["Determinacao"].ToString();
                    DBB.Rel_ID = reader["Rel_ID"].ToString();
                    DBB.Nivel_tecnica = reader["Nivel_tecnica"].ToString();
                    DBB.Qualidade_Potencial = reader["Qualidade_Potencial"].ToString();
                    DBB.Qualidade_Atual = reader["Qualidade_Atual"].ToString();
                    DBB.Obs_Num_Iden_Federacao = reader["Obs_Num_Iden_Federacao"].ToString();
                    DBB.Melhor_Atributo = reader["Melhor_Atributo"].ToString();
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
                    MelhorAtribBox.Text = DBB.Melhor_Atributo;
                    //QualAtualBox.Text = DBB.Qualidade_Atual;
                    //QualPotBox.Text = DBB.Qualidade_Potencial;
                    //NivTecBox.Text = DBB.Nivel_tecnica;
                    DeterminacaoBox.Text = DBB.Determinacao;

                    //CapDecBox.Text = DBB.Capacidade_Decisao;
                    if (Int32.Parse(DBB.Capacidade_Decisao) > 85) { CapDecBox.Text = DBB.Capacidade_Decisao + " - Muito Bom "; }
                    else if (Int32.Parse(DBB.Capacidade_Decisao) < 85 && Int32.Parse(DBB.Capacidade_Decisao) > 70) { CapDecBox.Text = DBB.Capacidade_Decisao + " - Bom "; }
                    else if (Int32.Parse(DBB.Capacidade_Decisao) < 70 && Int32.Parse(DBB.Capacidade_Decisao) > 50) { CapDecBox.Text = DBB.Capacidade_Decisao + " - Médio "; }
                    else { CapDecBox.Text = DBB.Capacidade_Decisao + " - Fraco "; }


                    if (Int32.Parse(DBB.Qualidade_Atual) > 85) { QualAtualBox.Text = DBB.Capacidade_Decisao + " - Muito Bom "; }
                    else if (Int32.Parse(DBB.Qualidade_Atual) < 85 && Int32.Parse(DBB.Qualidade_Atual) > 70) { QualAtualBox.Text = DBB.Capacidade_Decisao + " - Bom "; }
                    else if (Int32.Parse(DBB.Qualidade_Atual) < 70 && Int32.Parse(DBB.Qualidade_Atual) > 50) { QualAtualBox.Text = DBB.Capacidade_Decisao + " - Médio "; }
                    else { QualAtualBox.Text = DBB.Qualidade_Atual + " - Fraco "; }

                    if (Int32.Parse(DBB.Qualidade_Potencial) > 85) { QualPotBox.Text = DBB.Capacidade_Decisao + " - Muito Alta "; }
                    else if (Int32.Parse(DBB.Qualidade_Potencial) < 85 && Int32.Parse(DBB.Qualidade_Potencial) > 70) { QualPotBox.Text = DBB.Capacidade_Decisao + " - Alta "; }
                    else if (Int32.Parse(DBB.Qualidade_Potencial) < 70 && Int32.Parse(DBB.Qualidade_Potencial) > 50) { QualPotBox.Text = DBB.Capacidade_Decisao + " - Média "; }
                    else { QualPotBox.Text = DBB.Qualidade_Potencial + " - Baixa "; }


                    if (Int32.Parse(DBB.Nivel_tecnica) > 85) { NivTecBox.Text = DBB.Capacidade_Decisao + " - Muito Alta "; }
                    else if (Int32.Parse(DBB.Nivel_tecnica) < 85 && Int32.Parse(DBB.Nivel_tecnica) > 70) { NivTecBox.Text = DBB.Capacidade_Decisao + " - Alta "; }
                    else if (Int32.Parse(DBB.Nivel_tecnica) < 70 && Int32.Parse(DBB.Nivel_tecnica) > 50) { NivTecBox.Text = DBB.Capacidade_Decisao + " - Média "; }
                    else { NivTecBox.Text = DBB.Nivel_tecnica + " - Baixa "; }

                    if (Int32.Parse(DBB.Determinacao) > 85) { DeterminacaoBox.Text = DBB.Capacidade_Decisao + " - Muito Alta "; }
                    else if (Int32.Parse(DBB.Determinacao) < 85 && Int32.Parse(DBB.Determinacao) > 70) { DeterminacaoBox.Text = DBB.Capacidade_Decisao + " - Alta "; }
                    else if (Int32.Parse(DBB.Determinacao) < 70 && Int32.Parse(DBB.Determinacao) > 50) { DeterminacaoBox.Text = DBB.Capacidade_Decisao + " - Média "; }
                    else { DeterminacaoBox.Text = DBB.Determinacao + " - Baixa "; }
                }
                reader.Close();
            }
            catch(Exception ex) {
                MessageBox.Show("Falhou Load Relatório da BD database. \n ERROR MESSAGE:" + ex.Message);


                }
        }
        //Bloquear Dados 
        public void LockJogadoresControls()
        {
            
            textBoxData.Enabled = false;
            textBoxJogID.Enabled = false;
            textBoxJogo.Enabled = false;
            textBoxObs.Enabled = false;
            textBoxTitulo.Enabled = false;
            GolosBox.Enabled = false;
            AssistsBox.Enabled = false;
            PassesBox.Enabled = false;
            PassesCompBox.Enabled = false;
            CortesBox.Enabled = false;
            MinutosBox.Enabled = false;
            DefesasBox.Enabled = false;
            DistanciaBox.Enabled = false;
            ToquesBox.Enabled = false;
            DriblesBox.Enabled = false;
            RematesBox.Enabled = false;
            EticaTrabBox.Enabled = false;
            MelhorAtribBox.Enabled = false;
            QualAtualBox.Enabled = false;
            QualPotBox.Enabled = false;
            NivTecBox.Enabled = false;
            DeterminacaoBox.Enabled = false;
            CapDecBox.Enabled = false;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
