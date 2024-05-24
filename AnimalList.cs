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
    public partial class AnimalList : Form
    {

        private String selectedZoo;
        private String chosenHabitat;
        private String chosenHabitaculo;
        private SqlConnection cn;
        private Boolean showHabitaculos = false;
        public AnimalList(string selectedZoo)
        {
            InitializeComponent();
            
            escolherHabitáculoToolStripMenuItem.Visible = showHabitaculos;
            VerifySqlConnection();
            this.selectedZoo = selectedZoo;
            this.Text = "ZooLife - Lista de Animais (" + this.selectedZoo + ")";
            cn = SqlConnection();
            populateZooMenuItems();
            PopulateAnimalList(); // Call the function to populate animal names on form load
            populateHabitatMenuItems();
        }

        private void updateVisibilityHabitaculos(Boolean newValue)
        {
            this.showHabitaculos = newValue;
            escolherHabitáculoToolStripMenuItem.Visible = showHabitaculos;
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

        private void PopulateAnimalList()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Animal names cannot be loaded.");
                return;
            }

            listBox1.Items.Clear(); // Clear any existing items
            string chosenHabitatQuery = (this.chosenHabitat != null) ? "AND ZOO.ANIMAL.Habitat_ID = " + this.chosenHabitat : "";
            string chosenHabitaculoQuery = (this.chosenHabitaculo != null) ? "AND ZOO.ANIMAL.Habitaculo_ID = " + this.chosenHabitaculo : "";

            string query = "SELECT Nome, ID FROM ZOO.ANIMAL WHERE ZOO.ANIMAL.Nome_JZ = \'" + this.selectedZoo + "\'" + chosenHabitatQuery + chosenHabitaculoQuery; // Assuming a table named 'Animals' with a column 'AnimalName'
            SqlCommand cmd = new SqlCommand(query, this.cn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["ID"].ToString() + ". " + reader["Nome"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load animal names. Error: " + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Do something when an animal is selected
            MessageBox.Show("Selected animal: " + listBox1.SelectedItem.ToString());
            FillTextBoxesWithSelectedAnimal();
        }

        private void escolherZooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Do something when the 'Choose Zoo' menu item is clicked
            MessageBox.Show("Choose Zoo clicked");
        }

        private void opção1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Do something when the 'Option 1' menu item is clicked
            MessageBox.Show("Option 1 clicked");
        }

        private void populateHabitaculoMenuItems()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Habitat names cannot be loaded.");
                return;
            }

            escolherHabitáculoToolStripMenuItem.DropDownItems.Clear(); // Clear any existing items
            string query = "SELECT ZOO.HABITACULO.ID FROM ZOO.HABITACULO INNER JOIN ZOO.RECINTO ON ZOO.HABITACULO.Habitat_ID = ZOO.RECINTO.ID WHERE ZOO.HABITACULO.Habitat_ID = " + this.chosenHabitat + " AND ZOO.HABITACULO.Nome_JZ = \'" + this.selectedZoo + "\'"; // Assuming a table named 'Habitats' with a column 'HabitatName'
            MessageBox.Show(query);
            SqlCommand cmd = new SqlCommand(query, this.cn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string habitaculoName = reader["ID"].ToString(); // Assuming the first column (index 0) contains habitat names
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(habitaculoName);
                        // Add an event handler for menu item click (optional)
                        menuItem.Click += new EventHandler(menuItem_ClickHabitaculo);
                        escolherHabitáculoToolStripMenuItem.DropDownItems.Add(menuItem);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving habitat names: " + ex.Message);
            }
        }

        private void populateHabitatMenuItems()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Habitat names cannot be loaded.");
                return;
            }

            escolherHToolStripMenuItem.DropDownItems.Clear(); // Clear any existing items

            string query = "SELECT Recinto_ID, Nome FROM ZOO.HABITAT INNER JOIN ZOO.RECINTO ON ZOO.HABITAT.Recinto_ID = ZOO.RECINTO.ID where ZOO.HABITAT.Nome_JZ = \'" + this.selectedZoo + "\'"; // TODO: MUDAR PARA A TABELA DE HABITATS
            SqlCommand cmd = new SqlCommand(query, this.cn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())  
                    {
                        string habitatName = reader["Recinto_ID"].ToString() + ". " + reader["Nome"]; // Assuming the first column (index 0) contains habitat names
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(habitatName);
                        // Add an event handler for menu item click (optional)
                        menuItem.Click += new EventHandler(menuItem_ClickHabitat);
                        escolherHToolStripMenuItem.DropDownItems.Add(menuItem);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving habitat names: " + ex.Message);
            }
        }   

        private void populateZooMenuItems()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            }

            escolherZooToolStripMenuItem.DropDownItems.Clear(); // Clear any existing items

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
                        menuItem.Click += new EventHandler(menuItem_ClickZoo);
                        escolherZooToolStripMenuItem.DropDownItems.Add(menuItem);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving zoo names: " + ex.Message);
            }
        }

        private void menuItem_ClickZoo(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            this.selectedZoo = clickedItem.Text;
            this.chosenHabitat = null;
            this.Text = "ZooLife - Lista de Animais (" + selectedZoo + ")";
            updateVisibilityHabitaculos(false);
            populateHabitatMenuItems(); // Add this line to update the habitat menu items
            PopulateAnimalList(); // Add this line to update the animal list
        }

        private void menuItem_ClickHabitat(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            string habitatText = clickedItem.Text.ToString();
            char[] separator = new char[1];
            separator[0] = '.'; // Assuming the habitat name is in the format 'ID. Name'    
            string habitatID = habitatText.Split(separator)[0];
                this.chosenHabitat = habitatID.ToString();
                populateHabitaculoMenuItems();
                updateVisibilityHabitaculos(true);
                PopulateAnimalList();
                // Perform actions based on the selected habitat
                this.Text = "ZooLife - Lista de Animais (" + selectedZoo + " - " + chosenHabitat + ")";
        }

        private void menuItem_ClickHabitaculo(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            this.chosenHabitaculo = clickedItem.Text;
            PopulateAnimalList();
            // Perform actions based on the selected habitat
            this.Text = "ZooLife - Lista de Animais (" + selectedZoo + " - " + chosenHabitat + " - " + chosenHabitaculo + ")";
        }
        private void FillTextBoxesWithSelectedAnimal()
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedAnimal = listBox1.SelectedItem.ToString();
                string[] animalInfo = selectedAnimal.Split('.'); // Assuming the format is "ID. Name"
                string animalID = animalInfo[0].Trim();
                string query = "SELECT * FROM ZOO.PESQUISA_ANIMAL(@AnimalID)";
                SqlCommand cmd = new SqlCommand(query, this.cn);
                cmd.Parameters.AddWithValue("@AnimalID", animalID);

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
                            const int Dieta = 1;
                            const int GrupoTaxonomico = 7;
                            const int Nome = 2;
                            const int Cor = 4;
                            const int Comprimento = 5;
                            const int Peso = 6;
                            const int Especie = 3;
                            const int Veterinario = 10;

                            NomeAnimal.Text = reader.GetValue(Nome).ToString();
                            GrupoTaxonomicoText.Text = reader.GetValue(GrupoTaxonomico).ToString();
                            EspecieAnimal.Text = reader.GetValue(Especie).ToString();
                            DietaAnimal.Text = reader.GetValue(Dieta).ToString();
                            PesoAnimal.Text = reader.GetValue(Peso).ToString();
                            ComprimentoAnimal.Text = reader.GetValue(Comprimento).ToString();
                            CorAnimal.Text = reader.GetValue(Cor).ToString();
                            VeterinarioAnimal.Text = reader.GetValue(Veterinario).ToString();

                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error retrieving animal info: " + ex.Message);
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EspecieAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RemoverAnimal_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedAnimal = listBox1.SelectedItem.ToString();
                string[] animalInfo = selectedAnimal.Split('.'); // Assuming the format is "ID. Name"
                string animalID = animalInfo[0].Trim();

                // Call the stored procedure to remove the animal
                using (SqlConnection connection = SqlConnection())
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("ZOO.sp_DeleteAnimal", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", int.Parse(animalID)); // Change the parameter name to "@ID"
                        cmd.ExecuteNonQuery();

                        // Refresh the animal list after removal
                        PopulateAnimalList();

                        MessageBox.Show("Animal removed successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to remove animal. Error: " + ex.Message);
                    }
                }
            }
        }

        private void AnimalList_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DietaAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PesoAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void NomeAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ComprimentoAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void VeterinarioAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void CorAnimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cor_Click(object sender, EventArgs e)
        {

        }

        private void AdicionarAnimal_Click(object sender, EventArgs e)
        {
            // Navigate to the NovoAnimal page
            NovoAnimal novoAnimalPage = new NovoAnimal();
            novoAnimalPage.Show();
            this.Hide();
        }
    }
}
