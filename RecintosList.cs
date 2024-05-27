﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ZooLifeForm
{
    public partial class RecintosList : Form
    {
        private Form prevForm;
        private SqlConnection cn;

        private String selectedZoo;
        private String chosenTipo;
        private String chosenRecinto;


        public RecintosList()
        {
            InitializeComponent();
            this.prevForm = prevForm;
            VerifySqlConnection();
            this.selectedZoo = selectedZoo;
            this.Text = "ZooLife - Lista de Animais (" + this.selectedZoo + ")";
            cn = SqlConnection();
            PopulateZooMenuItems();
            PopulateRecintoList();
        }

        private SqlConnection SqlConnection()
        {
            return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p8g5; uid = p8g5; password = grupoRRBD2024");
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

            zOOToolStripMenuItem.DropDownItems.Clear(); // Clear any existing items

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
                        zOOToolStripMenuItem.DropDownItems.Add(menuItem);
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
            this.chosenRecinto = null;
            this.Text = "ZooLife - Lista de Animais (" + selectedZoo + ")";
            PopulateRecintoList(); // Add this line to update the animal list
        }

        private void FillTextBoxesWithSelectedRecinto()
        {
            if (lista_resultados_recintos.SelectedItem != null)
            {
                string selectedRecinto = lista_resultados_recintos.SelectedItem.ToString();
                string[] recintoInfo = selectedRecinto.Split('.'); // Assuming the format is "ID. Name"
                string recintoID = recintoInfo[0].Trim();
                string query = "SELECT * FROM ZOO.PESQUISA_RECINTO(@recintoID)";
                string query2 = "SELECT * FROM ZOO.BILHETES_VENDIDOS(@recinto_ID)";
                SqlCommand cmd = new SqlCommand(query, this.cn);
                cmd.Parameters.AddWithValue("@recintoID", recintoID);

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
                            const int Nome = 0;
                            const int Nome_JZ = 1;
                            const int Estado = 2;
                            const int Max_capacidade = 3;
                            const int N_habitaculos = 4;

                            textbox_nome_recinto.Text = reader.GetValue(Nome).ToString();
                            textbox_recinto_jz.Text = reader.GetValue(Nome_JZ).ToString();
                            textbox_estado_recinto.Text = reader.GetValue(Estado).ToString();
                            if (reader.GetValue(Max_capacidade) != null)
                            {
                                label_capacidadeMax_recinto.Visible = true;
                                textbox_capacidadeMax_recinto.Visible=true;
                                textbox_capacidadeMax_recinto.Text= reader.GetValue(Max_capacidade).ToString();
                            }

                            if (reader.GetValue(N_habitaculos) != null)
                            {
                                label_n_habitaculos_recinto.Visible = true;
                                textbox_n_habitaculos_recinto.Visible = true;
                                textbox_n_habitaculos_recinto.Text= reader.GetValue(N_habitaculos).ToString();
                                label_lista_habitaculos_recinto.Visible = true;
                                listBox_habitaculos_recinto.Visible = true;
                                PopulateHabitaculosList(recintoID);
                            }

                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error retrieving recinto info: " + ex.Message);
                }

                SqlCommand cmd2 = new SqlCommand(query2, this.cn);
                cmd2.Parameters.AddWithValue("@recintoID", recintoID);

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
                            const int bilhetes_vendidos = 0;

                            if (reader.GetValue(bilhetes_vendidos) != null)
                            {
                                label_bilhetes_vendidos_recinto.Visible = true;
                                textbox_bilhetes_vendidos_recinto.Visible= true;
                                textbox_bilhetes_vendidos_recinto.Text = reader.GetValue(bilhetes_vendidos).ToString();
                            }

                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error retrieving recinto info: " + ex.Message);
                }

            }
        }

        private void PopulateHabitaculosList(string recinto_id)
        {
            string query = "SELECT ID FROM ZOO.HABITACULO WHERE Habitat_ID=\'" + recinto_id + "\'";
            SqlCommand cmd = new SqlCommand(query, this.cn);
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox_habitaculos_recinto.Items.Add(reader["ID"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving habitaculos info: " + ex.Message);
            }

        }


        private void PopulateRecintoList()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Animal names cannot be loaded.");
                return;
            }

            lista_resultados_recintos.Items.Clear(); // Clear any existing items
            string chosenTipoQuery = string.Empty;

            if (this.chosenTipo != null)
            {
                switch (this.chosenTipo)
                {
                    case "Habitat":
                        chosenTipoQuery = "JOIN ZOO.HABITAT ON ID = Recinto_ID";
                        break;
                    case "Bilheteira":
                        chosenTipoQuery = "JOIN ZOO.BILHETEIRA ON ID = Recinto_ID";
                        break;
                    case "Restauração":
                        chosenTipoQuery = "JOIN ZOO.RESTAURACAO ON ID = Recinto_ID";
                        break;
                    case "Outro":
                        chosenTipoQuery = "LEFT JOIN ZOO.HABITAT ON ZOO.RECINTO.ID = ZOO.HABITAT.Recinto_ID " +
                                          "LEFT JOIN ZOO.BILHETEIRA ON ZOO.RECINTO.ID = ZOO.BILHETEIRA.Recinto_ID " +
                                          "LEFT JOIN ZOO.RESTAURACAO ON ZOO.RECINTO.ID = ZOO.RESTAURACAO.Recinto_ID " +
                                          "WHERE ZOO.HABITAT.Recinto_ID IS NULL " +
                                          "AND ZOO.BILHETEIRA.Recinto_ID IS NULL " +
                                          "AND ZOO.RESTAURACAO.Recinto_ID IS NULL";
                        break;
                }
            }

            string query = "SELECT Nome, ID FROM ZOO.RECINTO"+ chosenTipoQuery + "WHERE ZOO.Recinto.Nome_JZ = \'" + this.selectedZoo + "\'"; // Assuming a table named 'Animals' with a column 'AnimalName'
            SqlCommand cmd = new SqlCommand(query, this.cn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista_resultados_recintos.Items.Add(reader["ID"].ToString() + ". " + reader["Nome"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load recinto names. Error: " + ex.Message);
            }
        }


        private void zOOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RecintosList_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void butto_remover_recinto_Click(object sender, EventArgs e)
        {
            if (lista_resultados_recintos.SelectedItem != null)
            {
                string selectedRecinto = lista_resultados_recintos.SelectedItem.ToString();
                string[] recintoInfo = selectedRecinto.Split('.'); // Assuming the format is "ID. Name"
                string recintoID = recintoInfo[0].Trim();

                // Call the stored procedure to remove the animal
                using (SqlConnection connection = SqlConnection())
                {
                    try
                    {
                        connection.Open();
                        string tipoRecinto = null;

                        string query = "SELECT ZOO.GET_TIPO_RECINTO(@recintoID) AS TipoRecinto";

                        using (SqlCommand cmd2 = new SqlCommand(query, cn))
                        {
                            cmd2.Parameters.AddWithValue("@recintoID", recintoID);

                            var result = cmd2.ExecuteScalar();
                            tipoRecinto = result != DBNull.Value ? result.ToString() : null;

                            Console.WriteLine($"Tipo de Recinto: {tipoRecinto}");
                        }

                        string procedure = "";
                        switch (tipoRecinto)
                        {
                            case "RESTAURACAO":
                                procedure = "ZOO.sp_removerRestauracao";
                                break;
                            case "HABITAT":
                                procedure = "ZOO.sp_removerHabitat";
                                break;
                            case "BILHETEIRA":
                                procedure = "ZOO.sp_removerBilheteira";
                                break;
                            case "RECINTO":
                                procedure = "ZOO.sp_removerRecinto";
                                break;
                        }

                        
                        SqlCommand cmd = new SqlCommand(procedure, connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@recintoID", int.Parse(recintoID)); // Change the parameter name to "@ID"
                        cmd.ExecuteNonQuery();

                        // Refresh the animal list after removal
                        PopulateRecintoList();

                        MessageBox.Show("Recinto removed successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to remove Recinto. Error: " + ex.Message);
                    }
                }
            }
        }

        private void button_remover_habitaculo_recinto_Click(object sender, EventArgs e)
        {
            if (listBox_habitaculos_recinto.SelectedItem != null)
            {
                // Assuming the habitaculo ID is stored as the value of the list item
                int habitaculoID = (int)listBox_habitaculos_recinto.SelectedValue;

                using (SqlConnection cn = new SqlConnection("your_connection_string_here"))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("ZOO.sp_remover_habitaculo", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@habitaculoID", habitaculoID);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Habitáculo removido com sucesso.");
                        }

                        // Optionally refresh the list of habitáculos
                        LoadHabitaculosForRecinto();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao remover habitáculo: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um habitáculo para remover.");
            }
        }

        private void button_adicionar_habitaculo_recinto_Click(object sender, EventArgs e)
        {
            // Supondo que esses dados sejam obtidos de algum lugar, como caixas de texto no formulário
            string nomeJZ = "NomeJZ"; // Obtenha o valor real do seu formulário
            string nome = "Nome"; // Obtenha o valor real do seu formulário
            string estado = "Estado"; // Obtenha o valor real do seu formulário
            int recintoID = 1; // Obtenha o valor real do seu formulário
            string tamanho = "Tamanho"; // Obtenha o valor real do seu formulário
            int maxAnimais = 10; // Obtenha o valor real do seu formulário

            using (SqlConnection cn = new SqlConnection("your_connection_string_here"))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("ZOO.sp_adicionarHabitaculo", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nome_jz", nomeJZ);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@recinto_id", recintoID);
                        cmd.Parameters.AddWithValue("@tamanho", tamanho);
                        cmd.Parameters.AddWithValue("@max_animais", maxAnimais);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Habitáculo adicionado com sucesso.");
                    }

                    // Opcionalmente, atualize a lista de habitáculos
                    LoadHabitaculosForRecinto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar habitáculo: " + ex.Message);
                }
            }
        }

        private void listBox_habitaculos_recinto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_habitaculos_recinto.SelectedItem != null)
            {
                button_remover_habitaculo.Visible = true;
                button_adicionar_habitaculo.Visible = true;

                // Ensure the event handlers are properly assigned
                button_remover_habitaculo.Click -= button_remover_habitaculo_recinto_Click;
                button_remover_habitaculo.Click += button_remover_habitaculo_recinto_Click;

                button_adicionar_habitaculo.Click -= button_adicionar_habitaculo_recinto_Click;
                button_adicionar_habitaculo.Click += button_adicionar_habitaculo_recinto_Click;
            }
            else
            {
                button_remover_habitaculo.Visible = false;
                button_adicionar_habitaculo.Visible = false;
            }
        }
    }
}
