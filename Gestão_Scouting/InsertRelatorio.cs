using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestão_Scouting
{
    public partial class InsertRelatorio : Form
    {
        private SqlConnection cn;
        public InsertRelatorio(String idJogador)
        {

            InitializeComponent();
            textBoxJogID.Text = idJogador;
            textBoxJogID.Enabled = false;
            loadClubeAtual(idJogador);
            LoadObservador();
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
        private void LoadObservador()
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
        public void loadClubeAtual(String ID)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            //Obter Clube
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Get_ClubeAtual_Jogador", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@id", ID);
                readera = cmda.ExecuteReader();
                while (readera.Read())
                {
                    Clube C = new Clube();
                    C.Clube_Numero_Inscricao_FIFA = readera["Clube_Numero_Inscricao_FIFA"].ToString();
                    C.Clube_Nome = readera["Clube_Nome"].ToString();
                    C.Clube_Pais = readera["Clube_Pais"].ToString();
                    //
                    textBoxClubeAtual.Text = C.Clube_Numero_Inscricao_FIFA;
                }
               
                textBoxClubeAtual.Enabled = false;
                readera.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Falhou Carregar Clube do Jogador da BD database. \n ERROR MESSAGE: " + ex.Message);
            }

        }
        public void LoadJogos(String IDClube, String Obs)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmda = new SqlCommand();
            SqlDataReader readera;
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Get_Jogos_By_Clube_Observador", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@club_id", IDClube);
                cmda.Parameters.AddWithValue("@obs_id", Obs);
                readera = cmda.ExecuteReader();
                listBoxJogos.Items.Clear();
                while (readera.Read())
                {
                    Jogo J = new Jogo();
                    J.Jogo_Data = readera["Jogo_Data"].ToString();
                    J.Jogo_Local = readera["Jogo_Local"].ToString();
                    J.Resultado = readera["Resultado"].ToString();
                    J.Jogo_Competicao_ID_FIFA = readera["Jogo_Competicao_ID_FIFA"].ToString();
                    J.Obs_Num_Iden_Federacao = readera["Obs_Num_Iden_Federacao"].ToString();
                    listBoxJogos.Items.Add(J);
                }
                readera.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falhou Carregar Clube do Jogador da BD database. \n ERROR MESSAGE: " + ex.Message);
            }

        }

        private void listBoxJogos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxObservadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxObservadores.SelectedIndex >= 0)
            {
                Observador c = new Observador();
                c = (Observador)listBoxObservadores.Items[listBoxObservadores.SelectedIndex];
                String idObsev = c.Numero_Identificacao_Federacao.ToString();
                LoadJogos(textBoxClubeAtual.Text, idObsev);

            }
        }

        private void buttonInserirRelatorio_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (listBoxJogos.SelectedIndex < 0)
            {
                return;
            }
            if (listBoxObservadores.SelectedIndex < 0)
            {
                return;
            }

            //Restantes Checks



            SqlCommand cmda = new SqlCommand();
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Insert_Relatorio", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@Titulo", textBoxTitulo.Text);
                cmda.Parameters.AddWithValue("@Data", dateTimePicker1.Value.ToString());//Hope it works
                //
                Observador O = new Observador();
                O = (Observador)listBoxObservadores.Items[listBoxObservadores.SelectedIndex];
                String id = O.Numero_Identificacao_Federacao.ToString();
                cmda.Parameters.AddWithValue("@ID_Federacao_Obs", id);
                //
                cmda.Parameters.AddWithValue("@ID", textBoxJogID.Text);
                //
                Jogo J = new Jogo();
                J = (Jogo)listBoxJogos.Items[listBoxJogos.SelectedIndex];
                String local = J.Jogo_Local.ToString();
                String Data = J.Jogo_Data.ToString();
                cmda.Parameters.AddWithValue("@Local", local);
                cmda.Parameters.AddWithValue("@Jogo_Data", Data);
                //
                //Inserir Métricas
                
                //@Numero_Golo,@ID_Rel,@assistencias,@passes_efec,@passes_comp,@numero_cortes, @minutos_jogados, @Defesa_Realizada, @distancia, @toques, @dribles, @remates, @ID_Federacao_Obs

                //Analisar Jogadores
                
                //@ID_Rel,@Qualidade_Atual,@Qualidade_Potencial, @M_Atributo, @Etica, @Determinacao, @Decisao, @Tecnica, @ID_Federacao_Obs


                try
                {
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Relatório " + textBoxTitulo.Text.ToString() + " Inserido!");
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Falhou Inserir Relatório na BD database. \n ERROR MESSAGE:" + ex.Message);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Dados. \n ERROR MESSAGE:" + ex.Message);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
