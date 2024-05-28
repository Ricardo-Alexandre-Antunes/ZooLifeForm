using System;
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

        private string editingNome;
        private string editingEstado;
        private bool buttonsVisibleBefore;


        public RecintosList(string selectedZoo, Form prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            VerifySqlConnection();
            this.selectedZoo = selectedZoo;
            this.Text = "ZooLife - Lista de Recintos (" + this.selectedZoo + ")";
            cn = SqlConnection();
            PopulateZooMenuItems();
            PopulateRecintoList();
            RecintoEstado.Items.Add("aberto");
            RecintoEstado.Items.Add("fechado");
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
            this.chosenTipo = null;
            this.chosenRecinto = null;
            this.Text = "ZooLife - Lista de Recintos (" + selectedZoo + ")";
            PopulateRecintoList(); // Add this line to update the animal list
        }

        private void lista_resultados_recintos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTextBoxesWithSelectedRecinto();
        }

        private void FillTextBoxesWithSelectedRecinto()
        {
            if (lista_resultados_recintos.SelectedItem != null)
            {
                Boolean isHabitat = false;
                string selectedRecinto = lista_resultados_recintos.SelectedItem.ToString();
                string[] recintoInfo = selectedRecinto.Split('.'); // Assuming the format is "ID. Name"
                string recintoID = recintoInfo[0].Trim();
                string query = "SELECT * FROM ZOO.PESQUISA_RECINTO(@recintoID)";
                string query2 = "SELECT ZOO.BILHETES_VENDIDOS(@recintoID)";
                string query3 = "SELECT ZOO.NUMERO_FUNCIONARIOS_RECINTO(@recintoID)";

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
                        if (reader.Read())
                        {
                            const int Nome = 0;
                            const int Nome_JZ = 1;
                            const int Estado = 2;
                            const int Max_capacidade = 3;
                            const int N_habitaculos = 4;

                            textbox_nome_recinto.Text = reader.GetValue(Nome).ToString();
                            textbox_recinto_jz.Text = reader.GetValue(Nome_JZ).ToString();
                            RecintoEstado.Text = reader.GetValue(Estado).ToString();

                            // Show and fill Max_capacidade textbox if not null
                            if (!reader.IsDBNull(Max_capacidade))
                            {
                                label_capacidadeMax_recinto.Visible = true;
                                textbox_capacidadeMax_recinto.Visible = true;
                                textbox_capacidadeMax_recinto.Text = reader.GetValue(Max_capacidade).ToString();
                            }
                            else
                            {
                                label_capacidadeMax_recinto.Visible = false;
                                textbox_capacidadeMax_recinto.Visible = false;
                            }

                            // Show and fill N_habitaculos textbox if not null
                            if (!reader.IsDBNull(N_habitaculos))
                            {
                                label_n_habitaculos_recinto.Visible = true;
                                textbox_n_habitaculos_recinto.Visible = true;
                                textbox_n_habitaculos_recinto.Text = reader.GetValue(N_habitaculos).ToString();
                                label_lista_habitaculos_recinto.Visible = true;
                                listBox_habitaculos_recinto.Visible = true;
                                isHabitat = true;
                            }
                            else
                            {
                                label_n_habitaculos_recinto.Visible = false;
                                textbox_n_habitaculos_recinto.Visible = false;
                                label_lista_habitaculos_recinto.Visible = false;
                                listBox_habitaculos_recinto.Visible = false;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error retrieving recinto info: " + ex.Message);
                }

                // Second query to get bilhetes vendidos
                SqlCommand cmd2 = new SqlCommand(query2, this.cn);
                cmd2.Parameters.AddWithValue("@recintoID", recintoID);

                Console.WriteLine(query2);

                try
                {
                    if (cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            const int bilhetes_vendidos = 0;

                            if (!reader.IsDBNull(bilhetes_vendidos))
                            {
                                Console.WriteLine(bilhetes_vendidos);
                                label_bilhetes_vendidos_recinto.Visible = true;
                                textbox_bilhetes_vendidos_recinto.Visible = true;
                                textbox_bilhetes_vendidos_recinto.Text = reader.GetValue(bilhetes_vendidos).ToString();
                            }
                            else
                            {
                                label_bilhetes_vendidos_recinto.Visible = false;
                                textbox_bilhetes_vendidos_recinto.Visible = false;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error retrieving bilhetes vendidos info: " + ex.Message);
                }

                if (isHabitat)
                {
                    PopulateHabitaculosList(recintoID);
                }

                SqlCommand cmd3 = new SqlCommand(query3, this.cn);
                cmd3.Parameters.AddWithValue("@recintoID", recintoID);

                try
                {
                    if (cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    using (SqlDataReader reader = cmd3.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            const int num_funcionarios = 0;

                            textbox_numero_funcionarios_recinto.Text = reader.GetValue(num_funcionarios).ToString();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error retrieving número de funcionários info: " + ex.Message);
                }
                
                PopulateFuncionariosList(recintoID);


            }
        }

        private void PopulateFuncionariosList(string recinto_id)
        {
            listbox_lista_funcionarios_recinto.Items.Clear();
            string query = "SELECT Numero_CC, Nome, Funcao FROM ZOO.PESQUISA_FUNCIONARIOS_RECINTO(@recintoID)";
            
            SqlCommand cmd = new SqlCommand(query, this.cn);
            cmd.Parameters.AddWithValue("@recintoID", recinto_id);
            
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       listbox_lista_funcionarios_recinto.Items.Add(reader["Numero_CC"].ToString()+" - " + reader["Nome"].ToString() + " (" + reader["Funcao"]+ ")");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving funcionario de recinto info: " + ex.Message);
            }
        }



        private void PopulateHabitaculosList(string recinto_id)
        {
            listBox_habitaculos_recinto.Items.Clear();
            string query = "SELECT ID FROM ZOO.HABITACULO WHERE Habitat_ID=\'" + recinto_id + "\' AND Nome_JZ = \'" + this.selectedZoo + "\'" ;
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
                MessageBox.Show("Failed to connect to database. Recinto names cannot be loaded.");
                return;
            }

            lista_resultados_recintos.Items.Clear(); // Clear any existing items
            string chosenTipoQuery = string.Empty;
            string outroQuery_where = string.Empty;

            if (!string.IsNullOrEmpty(this.chosenTipo))
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
                                          "LEFT JOIN ZOO.RESTAURACAO ON ZOO.RECINTO.ID = ZOO.RESTAURACAO.Recinto_ID ";
                        outroQuery_where= "AND ZOO.HABITAT.Recinto_ID IS NULL " +
                                          "AND ZOO.BILHETEIRA.Recinto_ID IS NULL " +
                                          "AND ZOO.RESTAURACAO.Recinto_ID IS NULL";
                        break;
                }
            }

            string query = "SELECT ZOO.RECINTO.Nome, ZOO.RECINTO.ID FROM ZOO.RECINTO " + chosenTipoQuery +
                   " WHERE ZOO.RECINTO.Nome_JZ = @selectedZoo " + outroQuery_where;

            using (SqlCommand cmd = new SqlCommand(query, this.cn))
            {
                cmd.Parameters.AddWithValue("@selectedZoo", this.selectedZoo);
                try
                {
                    Console.WriteLine(query);
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
                {
                    try
                    {
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

                        
                        SqlCommand cmd = new SqlCommand(procedure, cn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", int.Parse(recintoID)); // Change the parameter name to "@ID"
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

                string habitaculoID = listBox_habitaculos_recinto.SelectedItem.ToString().Trim();
                int id = int.Parse(habitaculoID);
                Console.WriteLine(id);

                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("ZOO.sp_removerHabitaculo", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", id);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Habitáculo removido com sucesso.");
                        }

                        // Optionally refresh the list of habitáculos
                        //LoadHabitaculosForRecinto();
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
            AdicionarHabitaculo novo_habitaculo_form = new AdicionarHabitaculo(this.selectedZoo, this); // Create an instance of the AnimalList form
            novo_habitaculo_form.Show(); // Show the AnimalList form
            this.Hide();
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

        private void RecintosList_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void escolherTipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            string tipoRecinto_text = clickedItem.Text.ToString();
            this.chosenTipo = tipoRecinto_text.ToString();
            PopulateRecintoList();
            // Perform actions based on the selected habitat
            this.Text = "ZooLife - Lista de Recintos (" + selectedZoo + " - " + this.chosenTipo + ")";
        }

        private void button_adicionar_recinto_Click(object sender, EventArgs e)
        {
            AdicionarRecinto novo_recinto_form = new AdicionarRecinto(this); // Create an instance of the AnimalList form
            novo_recinto_form.Show(); // Show the AnimalList form
            this.Hide();
        }

        private void EditarRecinto_Click(object sender, EventArgs e)
        {
            //allowing edition on name and estado fiels and disabling everything else to not allow other changes
            editingNome = textbox_nome_recinto.Text;
            editingEstado = RecintoEstado.Text;
            buttonsVisibleBefore = button_adicionar_habitaculo.Visible;
            textbox_nome_recinto.ReadOnly = false;
            RecintoEstado.Enabled = true;
            textbox_capacidadeMax_recinto.ReadOnly = true;
            textbox_n_habitaculos_recinto.ReadOnly = true;
            textbox_recinto_jz.ReadOnly = true;
            textbox_bilhetes_vendidos_recinto.ReadOnly = true;
            textbox_numero_funcionarios_recinto.ReadOnly = true;
            listbox_lista_funcionarios_recinto.Enabled = false;
            listBox_habitaculos_recinto.Enabled = false;
            lista_resultados_recintos.Enabled = false;
            button_adicionar_habitaculo.Visible = false;
            button_remover_habitaculo.Visible = false;
            butto_remover_recinto.Visible = false;
            button_adicionar_recinto.Visible = false;
            ConfirmarEdicao.Visible = true;
            CancelarEdicao.Visible = true;
            EditarRecinto.Enabled = false;

        }

        private void CancelarEdicao_Click(object sender, EventArgs e)
        {
            //put everything back to what it was before
            textbox_nome_recinto.Text = editingNome;
            RecintoEstado.Text = editingEstado;
            textbox_nome_recinto.ReadOnly = true;
            RecintoEstado.Enabled = false;
            textbox_capacidadeMax_recinto.ReadOnly = true;
            textbox_n_habitaculos_recinto.ReadOnly = true;
            textbox_recinto_jz.ReadOnly = true;
            textbox_bilhetes_vendidos_recinto.ReadOnly = true;
            textbox_numero_funcionarios_recinto.ReadOnly = true;
            listbox_lista_funcionarios_recinto.Enabled = true;
            listBox_habitaculos_recinto.Enabled = true;
            lista_resultados_recintos.Enabled = true;
            button_adicionar_habitaculo.Visible = buttonsVisibleBefore;
            button_remover_habitaculo.Visible = buttonsVisibleBefore;
            butto_remover_recinto.Visible = true;
            button_adicionar_recinto.Visible = true;
            ConfirmarEdicao.Visible = false;
            CancelarEdicao.Visible = false;
            EditarRecinto.Enabled = true;
        }

        private void ConfirmarEdicao_Click(object sender, EventArgs e)
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Recinto names cannot be loaded.");
                return;
            }

            if (lista_resultados_recintos.SelectedItem != null)
            {
                string selectedRecinto = lista_resultados_recintos.SelectedItem.ToString();
                string[] recintoInfo = selectedRecinto.Split('.'); // Assuming the format is "ID. Name"
                string recintoID = recintoInfo[0].Trim();

                // Call the stored procedure to remove the animal
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("ZOO.sp_editarRecinto", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", int.Parse(recintoID)); // Change the parameter name to "@ID"
                            cmd.Parameters.AddWithValue("@nome", textbox_nome_recinto.Text);
                            cmd.Parameters.AddWithValue("@estado", RecintoEstado.Text);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Recinto editado com sucesso.");
                        }

                        // Refresh the animal list after removal
                        PopulateRecintoList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to edit Recinto. Error: " + ex.Message);
                    }
                }
            }
            //put everything back to what it was before
            textbox_nome_recinto.ReadOnly = true;
            RecintoEstado.Enabled = false;
            textbox_capacidadeMax_recinto.ReadOnly = true;
            textbox_n_habitaculos_recinto.ReadOnly = true;
            textbox_recinto_jz.ReadOnly = true;
            textbox_bilhetes_vendidos_recinto.ReadOnly = true;
            textbox_numero_funcionarios_recinto.ReadOnly = true;
            listbox_lista_funcionarios_recinto.Enabled = true;
            listBox_habitaculos_recinto.Enabled = true;
            lista_resultados_recintos.Enabled = true;
            button_adicionar_habitaculo.Visible = buttonsVisibleBefore;
            button_remover_habitaculo.Visible = buttonsVisibleBefore;
            butto_remover_recinto.Visible = true;
            button_adicionar_recinto.Visible = true;
            ConfirmarEdicao.Visible = false;
            CancelarEdicao.Visible = false;
            EditarRecinto.Enabled = true;
        }
    }
}
