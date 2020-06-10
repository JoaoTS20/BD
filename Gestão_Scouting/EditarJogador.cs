using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestão_Scouting
{
    public partial class EditarJogador : Form
    {
        private SqlConnection cn;
        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source=LAPTOP-MH91MTBV;integrated security=true;initial catalog=Trabalho_Final");
        }
        public EditarJogador(String ID)
        {
            InitializeComponent();
            GetListaObservacaoSelecaoDis();
            Load_Show_Data(ID);
        }

        private void Load_Show_Data(String id)
        {

            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            //cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.GetListaJogadores", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText="EXEC Scouting.GetListaJogadores @IdadeList , @OrderBy";
            cmd.Parameters.AddWithValue("@IdadeList", "");
            cmd.Parameters.AddWithValue("@OrderBy", "");

            reader = cmd.ExecuteReader();
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
                //Mostrar Dados dele
                if (C.ID_FIFPro == id)
                {
                    textBoxID.Text = C.ID_FIFPro.ToString();
                    textBoxID.Enabled = false;
                    TextBoxNome.Text = C.Jogador_Nome.ToString();
                    TextBoxAltura.Text = C.Jogador_Altura.ToString();
                    textBoxPeso.Text = C.Jogador_Peso.ToString();
                    //
                    if (C.Pe_Favorito.ToString() == "True")
                    {
                        radPeDir.Checked = true;
                        radPeEsq.Checked = false;
                    }
                    else
                    {
                        radPeEsq.Checked = true;
                        radPeDir.Checked = false;
                    }
                    //
                    if (C.Dupla_Nacionalidade.ToString() == "True")
                    {
                        radDupSim.Checked = true;
                        radDupNao.Checked = false;
                    }
                    else
                    {
                        radDupNao.Checked = true;
                        radDupSim.Checked = false;
                    }
                    //
                    TextBoxIdade.Text = C.Idade.ToString();
                    textBoxNumeroInter.Text = C.Numero_Internacionalizao.ToString();
                    //
                    Lista_Observacao_Selecao list = new Lista_Observacao_Selecao();
                    for (int i=0; i < comboBoxListas.Items.Count; i++)
                    {

                        list = (Lista_Observacao_Selecao)comboBoxListas.Items[i];
                        if (C.Lista_Idade_Maxima.ToString() == list.Lista_Idade_Maxima)
                        {
                            comboBoxListas.SelectedIndex = i;
                        }

                    }

                }
            }
            //cn.Close();
            reader.Close();

        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        public void GetListaObservacaoSelecaoDis()
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd = new SqlCommand("Scouting.Get_Listas_Observacao_Selecao", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            Lista_Observacao_Selecao S = new Lista_Observacao_Selecao();
            comboBoxListas.Items.Add(S);
            while (reader.Read())
            {
                Lista_Observacao_Selecao L = new Lista_Observacao_Selecao();
                L.Lista_Nome = reader["Lista_Nome"].ToString();
                L.Lista_Idade_Maxima = reader["Lista_Idade_Maxima"].ToString();
                comboBoxListas.Items.Add(L);
            }
            reader.Close();
        }

        private void bbtEditar_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            String bitPe = "";
            String bitDupl = "";
            if (radDupSim.Checked == true)
            {
                bitDupl = "1";
            }
            if (radDupNao.Checked == true)
            {
                bitDupl = "0";
            }
            if (radPeDir.Checked == true)
            {
                bitPe = "1";
            }
            if (radPeEsq.Checked == true)
            {
                bitPe = "0";
            }
            try
            {
                //String al =TextBoxAltura.Text.ToString();
                //String pe = TextBoxAltura.Text.ToString();
                float al = (float)double.Parse(TextBoxAltura.Text.ToString(), CultureInfo.CurrentCulture);
                float pe = (float)double.Parse(textBoxPeso.Text.ToString(), CultureInfo.CurrentCulture);
                SqlCommand cmda = new SqlCommand();
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Update_Jogador", cn);
                cmda.CommandType = CommandType.StoredProcedure;
                cmda.Parameters.AddWithValue("@ID_FIFPro", textBoxID.Text);
                cmda.Parameters.AddWithValue("@Nome", TextBoxNome.Text);
                cmda.Parameters.AddWithValue("@Altura", Math.Round(al, 2));
                cmda.Parameters.AddWithValue("@Peso", Math.Round(pe, 2));
                cmda.Parameters.AddWithValue("@Pe", bitPe);
                cmda.Parameters.AddWithValue("@Idade", TextBoxIdade.Text);
                cmda.Parameters.AddWithValue("@Dupla_Na", bitDupl);
                cmda.Parameters.AddWithValue("@numint", textBoxNumeroInter.Text);
                //
                Lista_Observacao_Selecao list = new Lista_Observacao_Selecao();
                list = (Lista_Observacao_Selecao)comboBoxListas.Items[comboBoxListas.SelectedIndex];
                String name = list.Lista_Idade_Maxima.ToString();
                cmda.Parameters.AddWithValue("@Lista", name);
                try
                {
                    cmda.ExecuteNonQuery();
                    MessageBox.Show("Jogador " + TextBoxNome.Text.ToString() + " Editado !");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falhou Editar Jogador na BD database. \n ERROR MESSAGE:" + ex.Message);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Verifique os Dados Editados:"+ ex.Message);
            }

        }
    }
}
