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
    public partial class UpdateRelatorio : Form
    {
        private SqlConnection cn;
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection(ContainerConection.Connection);
        }
        public UpdateRelatorio(String id)
        {
            InitializeComponent();
            textBoxIDREL.Text = id;
            textBoxIDREL.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            Load_Show_Data(id);
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        private void Load_Show_Data(String id)
        {
            if (!verifySGBDConnection())
                return;
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
                    textBoxJogID.Enabled = false;
                    dateTimePicker1.Value = DateTime.Parse(reader["Relatorio_Data"].ToString());
                    textBoxJogo.Text = reader["Jogo_Local"].ToString() + "  " + DateTime.Parse(reader["Jogo_Data"].ToString()).ToShortDateString();
                    textBoxObs.Text = reader["Numero_Identificacao_Federacao"].ToString();
                    textBoxObs.Enabled = false;
                    textBoxJogo.Enabled = false;

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
                        QualAtualBox.Text = DBB.Qualidade_Atual;
                        QualPotBox.Text = DBB.Qualidade_Potencial;
                        NivTecBox.Text = DBB.Nivel_tecnica;
                        DeterminacaoBox.Text = DBB.Determinacao;
                        CapDecBox.Text = DBB.Capacidade_Decisao;

                    }
                    reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Load Relatório da BD database. \n ERROR MESSAGE:" + ex.Message);
            }
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            
            try
            {
                SqlCommand cmda = new SqlCommand();
                try
                {
                    cmda.CommandType = CommandType.Text;
                    cmda = new SqlCommand("Scouting.Update_Relatorio", cn);
                    cmda.CommandType = CommandType.StoredProcedure;
                    cmda.Parameters.AddWithValue("@idRel", textBoxIDREL.Text);
                    cmda.Parameters.AddWithValue("@Titulo", textBoxTitulo.Text);
                    cmda.Parameters.AddWithValue("@Data", dateTimePicker1.Value.Date);//Hope it works
                    cmda.Parameters.AddWithValue("@ID_Federacao_Obs", textBoxObs.Text);
                    cmda.Parameters.AddWithValue("@ID", textBoxJogID.Text);
                    Analise_Caracteristica_Jogador A = new Analise_Caracteristica_Jogador();
                    A.Qualidade_Atual = QualAtualBox.Text;
                    A.Qualidade_Potencial = QualPotBox.Text;
                    A.Melhor_Atributo = MelhorAtribBox.Text;
                    A.Etica_Trabalho = EticaTrabBox.Text;
                    A.Determinacao = DeterminacaoBox.Text;
                    A.Capacidade_Decisao = CapDecBox.Text;
                    A.Nivel_tecnica = NivTecBox.Text;

                    cmda.Parameters.AddWithValue("@Qualidade_Atual", Int32.Parse(A.Qualidade_Atual));
                    cmda.Parameters.AddWithValue("@Qualidade_Potencial", Int32.Parse(A.Qualidade_Potencial.ToString()));
                    cmda.Parameters.AddWithValue("@M_Atributo", A.Melhor_Atributo.ToString());
                    cmda.Parameters.AddWithValue("@Etica", A.Etica_Trabalho.ToString());
                    cmda.Parameters.AddWithValue("@Determinacao", Int32.Parse(A.Determinacao.ToString()));
                    cmda.Parameters.AddWithValue("@Decisao", Int32.Parse(A.Capacidade_Decisao.ToString()));
                    cmda.Parameters.AddWithValue("@Tecnica", Int32.Parse(A.Nivel_tecnica.ToString()));

                    Metricas_Jogo_Jogador M = new Metricas_Jogo_Jogador();
                    M.Numero_Golos = GolosBox.Text;
                    M.Numero_Assistencias = AssistsBox.Text;
                    M.Numero_Passes_Efectuados = PassesBox.Text;
                    M.Numero_Passes_Completos = PassesCompBox.Text;
                    M.Numero_Cortes = CortesBox.Text;
                    M.Minutos_Jogados = MinutosBox.Text;
                    M.Defesas_Realizadas = DefesasBox.Text;
                    M.Distancia_Percorrida = DistanciaBox.Text;
                    M.Numero_Toques = ToquesBox.Text;
                    M.Numero_Dribles = DriblesBox.Text;
                    M.Numero_Remates = RematesBox.Text;
                    cmda.Parameters.AddWithValue("@Numero_Golo", Int32.Parse(M.Numero_Golos.ToString()));
                    cmda.Parameters.AddWithValue("@assistencias", Int32.Parse(M.Numero_Assistencias.ToString()));
                    cmda.Parameters.AddWithValue("@passes_efec", Int32.Parse(M.Numero_Passes_Efectuados.ToString()));
                    cmda.Parameters.AddWithValue("@passes_comp", Int32.Parse(M.Numero_Passes_Completos.ToString()));
                    cmda.Parameters.AddWithValue("@numero_cortes", Int32.Parse(M.Numero_Cortes.ToString()));
                    cmda.Parameters.AddWithValue("@minutos_jogados", Int32.Parse(M.Minutos_Jogados.ToString()));
                    cmda.Parameters.AddWithValue("@Defesa_Realizada", Int32.Parse(M.Defesas_Realizadas.ToString()));
                    cmda.Parameters.AddWithValue("@distancia", Int32.Parse(M.Distancia_Percorrida.ToString()));
                    cmda.Parameters.AddWithValue("@toques", Int32.Parse(M.Numero_Toques.ToString()));
                    cmda.Parameters.AddWithValue("@dribles", Int32.Parse(M.Numero_Dribles.ToString()));
                    cmda.Parameters.AddWithValue("@remates", Int32.Parse(M.Numero_Remates.ToString()));
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Relatorio " + textBoxTitulo.Text.ToString() + " Editado !");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Falhou Editar Relatório na BD database. \n ERROR MESSAGE:" + ex.Message);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Verifique os Dados Editados:" + ex.Message);
            }

        }










        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
