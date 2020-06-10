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
using System.Globalization;

namespace Gestão_Scouting
{
    public partial class InsertPlayer : Form
    {
        private SqlConnection cn;

        public InsertPlayer()
        {
            InitializeComponent();
            GetListaObservacaoSelecaoDis();
        }

        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source=LAPTOP-MH91MTBV;integrated security=true;initial catalog=Trabalho_Final");
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        //Mostrar  Lista
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

        private void Adicionar_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;
            if (comboBoxListas.SelectedIndex < 0)
            {
                return;
            }
            
            String bitPe="";
            String bitDupl="";
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
            //
            try
            {
                float al = (float)double.Parse(TextBoxAltura.Text.ToString(), CultureInfo.CurrentCulture);
                float pe = (float)double.Parse(textBoxPeso.Text.ToString(), CultureInfo.CurrentCulture);
                SqlCommand cmda = new SqlCommand();
                cmda.CommandType = CommandType.Text;
                cmda = new SqlCommand("Scouting.Insert_Jogador", cn);
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
                    MessageBox.Show("Jogador " + TextBoxNome.Text.ToString() + " Inserido!");
                    this.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Falhou Inserir Jogador na BD database. \n ERROR MESSAGE:" + ex.Message);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Dados. \n ERROR MESSAGE:" + ex.Message);
            }
























            /*double altura;
            double peso;
            int idade;
            int inter;
            int dupnac;
            int pefav;
            SqlCommand cmd;
            SqlDataReader reader;
            if (!verifySGBDConnection())
                return;
            if(ID.Text=="" || NomeBox.Text=="" || AlturaBox.Text=="" || PesoBox.Text == "" || IdadeBox.Text == "" || NumeroInterBox.Text == "")
            {
                Console.WriteLine("Tem de preencher todos os campo!");
                return;
            }
            else if(!(DupSim.Checked || DupNao.Checked) || !(PeEsq.Checked || PeDir.Checked))
            {
                Console.WriteLine("Tem de preencher todos os campos!");
                return;
            }
            if(!Double.TryParse(AlturaBox.Text,out altura))
            {
                Console.WriteLine("Valor Altura impróprio.");
                return;
            }
            if (!Double.TryParse(PesoBox.Text, out peso))
            {
                Console.WriteLine("Valor Peso impróprio.");
                return;
            }
            if (!Int32.TryParse(IdadeBox.Text, out idade))
            {
                Console.WriteLine("Valor Idade imprópria.");
                return;
            }
            for (int i = 0; i < Form1.ids.Length; i++)//ir buscar ao ids todos os ID_FIFPro para ver se o que esta a ser introduzido ja existe
            {
                if (ID.Text == Form1.ids[i])
                {
                    Console.WriteLine("This ID already exists.");
                    return;
                }
            }
            Console.WriteLine("");
            if (DupSim.Checked){ dupnac = 1;}
            else { dupnac = 0; }
            if (PeDir.Checked) { pefav = 1; }
            else { pefav = 1; }
            //String x = "INSERT INTO Scouting.Jogador VALUES("+ID.Text+","+NomeBox.Text+")";
            //cmd = new SqlCommand(x, cn);
            //reader = cmd.ExecuteReader();
            Console.WriteLine("Inseriu");*/
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
