using Gestão_Scouting.Classes;
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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            loadClubeAtual(idJogador);
            ComboBoxOrder();
            comboBoxObservadoresList.SelectedIndex = 0;
            LoadObservador("");
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
                    J.Jogo_Data = readera["Jogo_Data"].ToString().Replace("/","-");
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
                return;
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
            if (String.IsNullOrEmpty(textBoxTitulo.Text))
            {
                MessageBox.Show("Prencher Parâmetros Título!");
                
            }
            if (String.IsNullOrEmpty(GolosBox.Text))
            {
                MessageBox.Show("Prencher Parâmetro Golos!");
                
            }
            if (String.IsNullOrEmpty(AssistsBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Assistências!");
                
            }
            if (String.IsNullOrEmpty(PassesBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Passes!");
                
            }
            if (String.IsNullOrEmpty(PassesCompBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Passes Completos!");
                
            }
            if (String.IsNullOrEmpty(ToquesBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Toques!");
                
            }
            if (String.IsNullOrEmpty(RematesBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Remates!");
                
            }
            if (String.IsNullOrEmpty(CortesBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Cortes!");
                
            }
            if (String.IsNullOrEmpty(MinutosBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Minutos!");
                
            }
            if (String.IsNullOrEmpty(DefesasBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Defesas!");
            }
            if (String.IsNullOrEmpty(DistanciaBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Distâncias!");
                
            }
            if (String.IsNullOrEmpty(DriblesBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Dribles!");
                
            }
            if (String.IsNullOrEmpty(QualAtualBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Qualidade Atual!");
                
            }
            if (String.IsNullOrEmpty(QualPotBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Qualidade Potencial!");
                
            }
            if (String.IsNullOrEmpty(MelhorAtribBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Melhor Atributos!");
                
            }
            if (String.IsNullOrEmpty(EticaTrabBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Ética de Trabalho!");
                
            }
            if (String.IsNullOrEmpty(DeterminacaoBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Determinação!");
                
            }
            if (String.IsNullOrEmpty(CapDecBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Capacidade de Decisão!");
                
            }
            if (String.IsNullOrEmpty(NivTecBox.Text))
            {
                MessageBox.Show("Prencher Parâmetros Nível Técnica!");
                
            }
            //Restantes Checks



            SqlCommand cmda = new SqlCommand();
            try
            {
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Insert_Relatorio", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@Titulo", textBoxTitulo.Text);
                cmda.Parameters.AddWithValue("@Data", dateTimePicker1.Value.Date);//Hope it works

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
                String Data = J.Jogo_Data.ToString().Replace("/","-");
 
                cmda.Parameters.AddWithValue("@Local", local);
                cmda.Parameters.AddWithValue("@Jogo_Data", DateTime.Parse(Data));
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
                cmda.Parameters.AddWithValue("@metodo_observacao", textBoxMetodo.Text);
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

        private void comboBoxObservadoresList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxObservadoresList.SelectedIndex >= 0)
            {
                ComboBoxOrder list = new ComboBoxOrder();
                list = (ComboBoxOrder)comboBoxObservadoresList.Items[comboBoxObservadoresList.SelectedIndex];
                String x = list.Value.ToString();
                //Alterar Load oBSERVADORES
                LoadObservador(x);
                listBoxJogos.Items.Clear();
            }
        }
    }
}
