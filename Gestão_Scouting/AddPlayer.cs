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
    public partial class AddPlayer : Form
    {
        private SqlConnection cn;

        public AddPlayer()
        {
            InitializeComponent();
        }

        private SqlConnection getSGBDConnection()
        {
            //Local a Editar!!
            return new SqlConnection("data source= LAPTOP-2KEGA0ER;integrated security=true;initial catalog=Proj");
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void Adicionar_Click(object sender, EventArgs e)
        {
            double altura;
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
            if (DupSim.Checked){ dupnac = 1;}
            else { dupnac = 0; }
            if (PeDir.Checked) { pefav = 1; }
            else { pefav = 1; }
            return;
            String x = "INSERT INTO Scouting.Jogador VALUES("+ID.Text+","+NomeBox.Text+")";
            cmd = new SqlCommand(x, cn);
            reader = cmd.ExecuteReader();
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
