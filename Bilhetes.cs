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
    public partial class Bilhetes : Form
    {

        private Form prevForm;
        private SqlConnection cn;

        private String selectedZoo;
        private String selectedBilheteira;
        private string connectionString;
        public Bilhetes(String selectedZoo, Form prevForm, string connectionString)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            this.connectionString = connectionString;
            VerifySqlConnection();
            this.selectedZoo = selectedZoo;
            
            this.selectedBilheteira = null;
            this.Text = "ZooLife - Lista de Bilhetes (" + this.selectedZoo + ")";
            cn = SqlConnection();
            PopulateZooMenuItems();
            PopulateBilhetesList();
            PopulateBilheteiraMenuItems();
        }

        private void Bilhetes_Closing(object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
        }
        private void Bilhetes_Load(object sender, EventArgs e)
        {

        }

        private SqlConnection SqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        private bool VerifySqlConnection()
        {
            SqlConnection cn = SqlConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void PopulateZooMenuItems()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            }

            escolherZooToolStripMenuItem.DropDownItems.Clear(); // Clear any existing items
            escolherBilheteiraToolStripMenuItem.DropDownItems.Clear();

            string query = "SELECT Nome FROM ZOO.JARDIM_ZOOLOGICO"; // Assuming a table named 'Zoos' with a column 'ZooName'
            SqlCommand cmd = new SqlCommand(query, this.cn);

            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string zooName = reader.GetString(0); // Assuming the first column (index 0) contains zoo names
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(zooName);
                        // Add an event handler for menu item click (optional)
                        menuItem.Click += new EventHandler(MenuItem_ClickZoo);
                        escolherZooToolStripMenuItem.DropDownItems.Add(menuItem);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving zoo names: " + ex.Message);
            }
        }

        private void PopulateBilheteiraMenuItems()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            }

            escolherBilheteiraToolStripMenuItem.DropDownItems.Clear();

            string query = "SELECT Nome FROM ZOO.RECINTO JOIN ZOO.BILHETEIRA ON ID=Recinto_ID WHERE @nome_jz = ZOO.RECINTO.Nome_JZ"; // Assuming a table named 'Zoos' with a column 'ZooName'
            SqlCommand cmd = new SqlCommand(query, this.cn);
            cmd.Parameters.AddWithValue("@nome_jz", this.selectedZoo);

            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string bilheteiraName = reader.GetString(0); // Assuming the first column (index 0) contains zoo names
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(bilheteiraName);
                        // Add an event handler for menu item click (optional)
                        menuItem.Click += new EventHandler(escolherBilheteiraToolStripMenuItem_Click);
                        escolherBilheteiraToolStripMenuItem.DropDownItems.Add(menuItem);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving zoo names: " + ex.Message);
            }
        }

        private void MenuItem_ClickZoo(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            this.selectedZoo = clickedItem.Text;
            this.selectedBilheteira = null;
            this.Text = "ZooLife - Lista de Bilhetes (" + selectedZoo + ")";

            PopulateBilheteiraMenuItems();
            PopulateBilhetesList(); // Add this line to update the bilheteira list
            
        }

        private void escolherBilheteiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            string bilheteira_text = clickedItem.Text.ToString();
            if (bilheteira_text=="Escolher Bilheteira") { return; }
            this.selectedBilheteira = bilheteira_text.ToString();
            PopulateBilhetesList();
            // Perform actions based on the selected habitat
            this.Text = "ZooLife - Lista de Recintos (" + selectedZoo + " - " + this.selectedBilheteira + ")";
        }



        private void PopulateBilhetesList()
        {
            listBox_bilhetes.Items.Clear();
            if (this.selectedBilheteira != null)
            {
                // Query para obter o ID do Recinto
                string query1 = "SELECT ID FROM ZOO.RECINTO WHERE Nome = @nome_recinto AND @nome_jz=Nome_JZ";

                SqlCommand cmd = new SqlCommand(query1, this.cn);
                cmd.Parameters.AddWithValue("@nome_recinto", this.selectedBilheteira);
                cmd.Parameters.AddWithValue("@nome_jz", this.selectedZoo);

                int bilheteira_id = 0;

                try
                {
                    // Abrir a conexão se estiver fechada
                    if (this.cn.State == ConnectionState.Closed)
                    {
                        this.cn.Open();
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bilheteira_id = reader.GetInt32(0);
                            Console.WriteLine("Recinto ID: " + bilheteira_id);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error getting bilheteira id info: " + ex.Message);
                    return;
                }

                // Verifique se o ID do recinto foi encontrado
                if (bilheteira_id == 0)
                {
                    MessageBox.Show("No Recinto ID found for the selected bilheteira.");
                    return;
                }

                // Query para obter os IDs dos bilhetes
                string query2 = "SELECT ID FROM ZOO.PESQUISA_BILHETES(@recintoID)";

                SqlCommand cmd2 = new SqlCommand(query2, this.cn);
                cmd2.Parameters.AddWithValue("@recintoID", bilheteira_id);

                try
                {
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox_bilhetes.Items.Add(reader["ID"].ToString());
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error retrieving bilhetes info: " + ex.Message);
                }
            }
            else
            {
                string query = "SELECT ID FROM ZOO.BILHETE WHERE @nome_jz = Nome_JZ";

                SqlCommand cmd = new SqlCommand(query, this.cn);
                cmd.Parameters.AddWithValue("@nome_jz", this.selectedZoo);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox_bilhetes.Items.Add(reader["ID"].ToString());
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error retrieving bilhetes info: " + ex.Message);
                }
            }
        }


        private void FillTextBoxesWithSelectedRecinto()
        {
            if (listBox_bilhetes.SelectedItem != null)
            {
                string selectedBilhete = listBox_bilhetes.SelectedItem.ToString();
                string bilheteID =selectedBilhete.Trim();
                string query = "SELECT * FROM ZOO.GET_ALL_BILHETE_INFO(@bilhete_ID)";

                SqlCommand cmd = new SqlCommand(query, this.cn);
                cmd.Parameters.AddWithValue("@bilhete_ID", bilheteID);

                try
                {
                    if (cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            const int id = 0;
                            const int preco = 1;
                            const int data_compra = 2;
                            const int visitante_cc = 3;
                            const int func_bilheteira_cc = 4;
                            const int recinto_nome = 5;
                            const int nome_jz = 6;
                            const int nome_visitante = 7;
                            const int genero_visitante = 8;

                            //textbox_nome_recinto.Text = reader.GetValue(Nome).ToString();
                            textBox_ID.Text = reader.GetValue(id).ToString();
                            textBox_preco.Text = reader.GetValue(preco).ToString();
                            textBox_numero_cc.Text = reader.GetValue(visitante_cc).ToString();
                            textBox_func_bilheteira.Text = reader.GetValue(func_bilheteira_cc).ToString();
                            textBox_bilheteira.Text = reader.GetValue(recinto_nome).ToString();
                            textBox_jz.Text = reader.GetValue(nome_jz).ToString();
                            textBox_nome_visitante.Text = reader.GetValue(nome_visitante).ToString();
                            textBox_genero.Text = reader.GetValue(genero_visitante).ToString();

                            if (!reader.IsDBNull(data_compra))
                            {
                                DateTime dataCompra = reader.GetDateTime(data_compra);

                                string dataCompraString = dataCompra.ToString("dd/MM/yyyy");

                                textBox_data_compra.Text = dataCompraString;
                            }
                            else
                            {
                                // Se o valor for nulo, você pode definir um valor padrão ou deixar o TextBox vazio
                                textBox_data_compra.Text = string.Empty;
                            }

                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error retrieving bilhete info: " + ex.Message);
                }
            }
        }

        private void listBox_bilhetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTextBoxesWithSelectedRecinto();
        }

        private void button_remover_Click(object sender, EventArgs e)
        {
            if (listBox_bilhetes.SelectedItem != null)
            {
                string bilheteID = listBox_bilhetes.SelectedItem.ToString();

                // Call the stored procedure to remove the animal
                {
                    try
                    {
                        string procedure = "ZOO.sp_removerBilhete";


                        SqlCommand cmd = new SqlCommand(procedure, cn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", int.Parse(bilheteID)); // Change the parameter name to "@ID"
                        cmd.ExecuteNonQuery();

                        // Refresh the animal list after removal
                        PopulateBilhetesList();

                        MessageBox.Show("Bilhete removed successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to remove bilhete. Error: " + ex.Message);
                    }
                }
            }
        }

        private void button_adicionar_bilhete_Click(object sender, EventArgs e)
        {
            AdicionarBilhete novo_bilhete_form = new AdicionarBilhete(this.selectedZoo, this, this.connectionString); // Create an instance of the AnimalList form
            novo_bilhete_form.Show(); // Show the AnimalList form
            this.Hide();
        }
    }
}
