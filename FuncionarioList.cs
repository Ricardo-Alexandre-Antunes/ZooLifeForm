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
        string selectedRole;

        public FuncionarioList(string selectedZoo, Form prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            this.selectedZoo = selectedZoo;
            this.selectedRole = "";
            this.Text = "ZooLife - Lista de Funcionários (" + selectedZoo + ")";
            this.FormClosing += new FormClosingEventHandler(this.FuncionarioList_FormClosing);
            PopulateFuncionarios();
            PopulateZoo();
            gerenteToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            tratadorToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            veterinárioToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            funcionárioDeBilheteiraToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            funcionárioDeLimpezaToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            funcionárioDeBilheteiraToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            segurançaToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);

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

            string query = "SELECT Numero_CC, Num_Funcionario, Nome, Role FROM ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO WHERE ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Nome_JZ = @Nome_JZ";
            if (selectedRole != "")
            {
                query += " AND ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Role = @Role";
            }
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Nome_JZ", this.selectedZoo);
            if (selectedRole != "")
            {
                cmd.Parameters.AddWithValue("@Role", selectedRole);
            }

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

        private void PopulateZoo()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names could not be loaded.");
                return;
            }

            escolherZooToolStripMenuItem.DropDownItems.Clear();

            string query = "SELECT Nome FROM ZOO.JARDIM_ZOOLOGICO";
            SqlCommand cmd = new SqlCommand(query, cn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string zooName = reader.GetString(0);
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(zooName);
                        menuItem.Click += new EventHandler(menuItem_Click);
                        escolherZooToolStripMenuItem.DropDownItems.Add(menuItem);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving zoo names: " + ex.Message);
            }
        }

        

        private void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            selectedZoo = clickedItem.Text;
            selectedRole = "";
            PopulateFuncionarios();
            this.Text = "ZooLife - Lista de Funcionários (" + selectedZoo + ")";
        }

        private void escolherHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            selectedRole = clickedItem.Text;
            switch (clickedItem.Text)
            {
                case "Gerente":
                    selectedRole = "GERENTE";
                    break;
                case "Tratador":
                    selectedRole = "TRATADOR";
                    break;
                case "Veterinário":
                    selectedRole = "VETERINARIO";
                    break;
                case "Funcionário de Bilheteira":
                    selectedRole = "FUNCIONARIO_BILHETEIRA";
                    break;
                case "Funcionário de Limpeza":
                    selectedRole = "FUNCIONARIO_LIMPEZA";
                    break;
                case "Segurança":
                    selectedRole = "SEGURANCA";
                    break;
            }
            PopulateFuncionarios();
            this.Text = "ZooLife - Lista de Funcionários (" + selectedZoo + ((this.selectedRole != "") ? " - " + this.selectedRole : "") + ")";
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
            string query = "SELECT * FROM ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO WHERE ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Numero_CC = @CC";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@CC", CC);


            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())

                {
                    while (reader.Read())
                    {
                        NomeFuncionario.Text = reader["Nome"].ToString();
                        NumeroCCFuncionario.Text = reader["Numero_CC"].ToString();
                        GeneroFuncionario.Text = reader["Genero"].ToString();
                        NumeroFuncionario.Text = reader["Num_Funcionario"].ToString();
                        DataNascimentoFuncionario.Text = reader["Data_Nascimento"].ToString();
                        ContratoInicio.Text = reader["Data_inicio_contrato"].ToString();
                        ContratoFim.Text = reader["Data_fim_contrato"].ToString();
                        ContratoSalario.Text = reader["Salario"].ToString();
                        FuncaoFuncionario.Text = reader["Role"].ToString();
                        ContratoTipo.Text = reader["Tipo_contrato"].ToString();

                    }
                }

                PopulateResponsibilitiesAndBoss(CC, FuncaoFuncionario.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve Funcionario. \n ERROR MESSAGE: \n" + ex.Message);
            }
        }

        private void PopulateResponsibilitiesAndBoss(int numeroCC, string role)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Responsibilities could not be loaded.");
                return;
            }

            ListaFuncionarios.Items.Clear();
            string query;
            switch (role)
            {
                case "GERENTE":
                    query = "SELECT * FROM ZOO.GERENTE WHERE F_Numero_CC = @CC";
                    break;
                case "TRATADOR":
                    query = "SELECT * FROM ZOO.RESPONSAVEL_POR_DETALHADO WHERE T_Numero_CC = @CC";
                    break;
                case "VETERINARIO":
                    query = "SELECT * FROM ZOO.ANIMAL WHERE Veterinario_CC = @CC";
                    break;
                case "FUNCIONARIO_BILHETEIRA":
                    query = "SELECT * FROM ZOO.FUNCIONARIO_BILHETEIRA INNER JOIN ZOO.BILHETEIRA_DETALHADA ON ZOO.FUNCIONARIO_BILHETEIRA.Bilheteira_ID = ZOO.BILHETEIRA_DETALHADA.ID WHERE F_Numero_CC = @CC";
                    break;
                case "FUNCIONARIO_LIMPEZA":
                    query = "SELECT * FROM ZOO.LIMPA_DETALHADO WHERE ZOO.LIMPA_DETALHADO.FL_Numero_CC = @CC";
                    break;
                case "SEGURANCA":
                    query = "SELECT * FROM ZOO.";
                    break;
                default:
                    query = "";
                    break;
            }
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Numero_CC", this.selectedFuncionario);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListaFuncionarios.Items.Add(reader["Nome"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve Responsibilities. \n ERROR MESSAGE: \n" + ex.Message);
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


        private void FuncionarioList_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ContratoSalário_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}
