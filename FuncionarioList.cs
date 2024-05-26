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

namespace ZooLifeForm
{
    public partial class FuncionarioList : Form
    {
        Form prevForm;
        SqlConnection cn;
        string selectedZoo;
        Object[] funcionarios_CC = new Object[100];
        int selectedFuncionario;


        public FuncionarioList(string selectedZoo, Form prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            this.selectedZoo = selectedZoo;
            this.FormClosing += new FormClosingEventHandler(this.FuncionarioList_FormClosing);
            PopulateFuncionarios();
        }

        private void FuncionarioList_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p8g5; uid = p8g5; password = grupoRRBD2024");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void PopulateFuncionarios()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Funcionarios could not be loaded.");
                return;
            }

            ListaFuncionarios.Items.Clear();

            string query = "SELECT Numero_CC, Num_Funcionario, Nome FROM ZOO.FUNCIONARIO_DETALHADO WHERE ZOO.FUNCIONARIO_DETALHADO.Nome_JZ = @Nome_JZ";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Nome_JZ", this.selectedZoo);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListaFuncionarios.Items.Add(reader["Num_Funcionario"] + ". " + reader["Nome"]);
                        funcionarios_CC[ListaFuncionarios.Items.Count - 1] = reader["Numero_CC"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve Funcionarios. \n ERROR MESSAGE: \n" + ex.Message);
            }
        }

        private void FuncionarioList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedFuncionario = int.Parse(ListaFuncionarios.Text.Split('.')[0]);
            int CC = (int)funcionarios_CC[ListaFuncionarios.SelectedIndex];
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Funcionario could not be loaded.");
                return;
            }
            string query = "SELECT * FROM ZOO.FUNCIONARIO_DETALHADO WHERE ZOO.FUNCIONARIO_DETALHADO.Numero_CC = @CC";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@CC", CC);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())

                {
                    while (reader.Read())
                    {
                        Nome.Text = reader["Nome"].ToString();
                        NumeroCC.Text = reader["Numero_CC"].ToString();
                        NumeroFuncionario.Text = reader["Num_Funcionario"].ToString();
                        DataNascimento.Text = reader["Data_Nascimento"].ToString();
                        DataContrato.Text = reader["Data_Contrato"].ToString();
                        Salario.Text = reader["Salario"].ToString();
                        Cargo.Text = reader["Cargo"].ToString();
                        Horario.Text = reader["Horario"].ToString();
                        Contacto.Text = reader["Contacto"].ToString();
                        Email.Text = reader["Email"].ToString();
                        Morada.Text = reader["Morada"].ToString();
                    }
                }
            }
        }

        private void AdicionarFuncionario_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Funcionario could not be added.");
                return;
            }


        }

        private void RemoverFuncionario_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Funcionario could not be removed.");
                return;
            }

            if (ListaFuncionarios.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Funcionario to remove.");
                return;
            }

            string[] funcionario = ListaFuncionarios.SelectedItem.ToString().Split('-');
            int funcionarioID = Int32.Parse(funcionario[0].Trim());

            string query = "DELETE FROM ZOO.Funcionario WHERE ID = @funcionarioID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@funcionarioID", funcionarioID);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Funcionario removed successfully.");
                PopulateFuncionarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to remove Funcionario. \n ERROR MESSAGE: \n" + ex.Message);
            }
        }

        private void EditarFuncionario_Click(object sender, EventArgs e)
        {
            if (ListaFuncionarios.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Funcionario to edit.");
                return;
            }

            string[] funcionario = ListaFuncionarios.SelectedItem.ToString().Split('-');
            int funcionarioID = Int32.Parse(funcionario[0].Trim());

        }


        private void escolherHToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FuncionarioList_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
