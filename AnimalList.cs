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

        private string editingNome;
        private string editingDieta;
        private string editingGrupoTaxonomico;
        private string editingEspecie;
        private string editingPeso;
        private string editingComprimento;
        private string editingCor;
        private string editingVeterinario;

        private string transferenciaZoo;
        private int transferenciaHabitat;
        private string transferenciaHabitatNome;
        private int transferenciaHabitaculo;

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
            PopulateVeterinarioList();
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
            PopulateVeterinarioList();
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
                            const int Veterinario = 11;
                            const int Habitat = 8;
                            const int HabitatNome = 9;
                            const int Habitaculo = 10;

                            NomeAnimal.Text = reader.GetValue(Nome).ToString();
                            GrupoTaxonomicoText.Text = reader.GetValue(GrupoTaxonomico).ToString();
                            EspecieAnimal.Text = reader.GetValue(Especie).ToString();
                            DietaAnimal.Text = reader.GetValue(Dieta).ToString();
                            PesoAnimal.Text = reader.GetValue(Peso).ToString();
                            ComprimentoAnimal.Text = reader.GetValue(Comprimento).ToString();
                            CorAnimal.Text = reader.GetValue(Cor).ToString();
                            VeterinarioAnimal.Text = reader.GetValue(Veterinario).ToString();
                            this.transferenciaZoo = this.selectedZoo;
                            this.transferenciaHabitat = int.Parse(reader.GetValue(Habitat).ToString());
                            this.transferenciaHabitatNome = reader.GetValue(HabitatNome).ToString();
                            this.transferenciaHabitaculo = int.Parse(reader.GetValue(Habitaculo).ToString());

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

        private void EditarAnimal_Click(object sender, EventArgs e)
        {
            NomeAnimal.ReadOnly = false;
            editingNome = NomeAnimal.Text;
            GrupoTaxonomicoText.ReadOnly = false;
            editingGrupoTaxonomico = GrupoTaxonomicoText.Text;
            EspecieAnimal.ReadOnly = false;
            editingEspecie = EspecieAnimal.Text;
            DietaAnimal.ReadOnly = false;
            editingDieta = DietaAnimal.Text;
            PesoAnimal.ReadOnly = false;
            editingPeso = PesoAnimal.Text;
            ComprimentoAnimal.ReadOnly = false;
            editingComprimento = ComprimentoAnimal.Text;
            CorAnimal.ReadOnly = false;
            editingCor = CorAnimal.Text;
            VeterinarioAnimal.Enabled = true;
            editingVeterinario = VeterinarioAnimal.Text;
            EditarConfirmar.Visible = true;
            TransferenciaCancelar.Visible = true;
            AdicionarAnimal.Visible = false;
            RemoverAnimal.Visible = false;
            EditarAnimal.Visible = false;
            listBox1.Enabled = false;
        }   

        private void EditarCancelar_Click(object sender, EventArgs e)
        {
            NomeAnimal.ReadOnly = true;
            NomeAnimal.Text = editingNome;
            GrupoTaxonomicoText.ReadOnly = true;
            GrupoTaxonomicoText.Text = editingGrupoTaxonomico;
            EspecieAnimal.ReadOnly = true;
            EspecieAnimal.Text = editingEspecie;
            DietaAnimal.ReadOnly = true;
            DietaAnimal.Text = editingDieta;
            PesoAnimal.ReadOnly = true;
            PesoAnimal.Text = editingPeso;
            ComprimentoAnimal.ReadOnly = true;
            ComprimentoAnimal.Text = editingComprimento;
            CorAnimal.ReadOnly = true;
            CorAnimal.Text = editingCor;
            VeterinarioAnimal.Enabled = false;
            VeterinarioAnimal.Text = editingVeterinario;
            EditarConfirmar.Visible = false;
            TransferenciaCancelar.Visible = false;
            AdicionarAnimal.Visible = true;
            RemoverAnimal.Visible = true;
            EditarAnimal.Visible = true;
            listBox1.Enabled = true;

        }

        private void TransferenciaCancelar_Click(object sender, EventArgs e)
        {
            NomeAnimal.ReadOnly = true;
            NomeAnimal.Text = editingNome;
            GrupoTaxonomicoText.ReadOnly = true;
            GrupoTaxonomicoText.Text = editingGrupoTaxonomico;
            EspecieAnimal.ReadOnly = true;
            EspecieAnimal.Text = editingEspecie;
            DietaAnimal.ReadOnly = true;
            DietaAnimal.Text = editingDieta;
            PesoAnimal.ReadOnly = true;
            PesoAnimal.Text = editingPeso;
            ComprimentoAnimal.ReadOnly = true;
            ComprimentoAnimal.Text = editingComprimento;
            CorAnimal.ReadOnly = true;
            CorAnimal.Text = editingCor;
            VeterinarioAnimal.Enabled = false;
            VeterinarioAnimal.Text = editingVeterinario;
            EditarConfirmar.Visible = false;
            TransferenciaCancelar.Visible = false;
            AdicionarAnimal.Visible = true;
            RemoverAnimal.Visible = true;
            EditarAnimal.Visible = true;
            listBox1.Enabled = true;
            ZooCombo.Visible = false;
            HabitatCombo.Visible = false;
            HabitaculoCombo.Visible = false;
            label8.Visible = true;
            ListaRelacionamentos.Visible = true;
            ZooAtual.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            AnimalTransferir.Visible = true;

        }

        private void PopulateZooComboBox()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            }

            using (SqlConnection connection = SqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Nome FROM ZOO.JARDIM_ZOOLOGICO", connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ZooCombo.Items.Clear();
                        while (reader.Read())
                        {
                           ZooCombo.Items.Add(reader["Nome"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load zoo names. Error: " + ex.Message);
                }
            }
        }   

        private void PopulateHabitatComboBox()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Habitat names cannot be loaded.");
                return;
            }

            using (SqlConnection connection = SqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Recinto_ID, Nome FROM ZOO.HABITAT_DETALHADO WHERE Nome_JZ = @Nome_JZ", connection);
                    cmd.Parameters.AddWithValue("@Nome_JZ", ZooCombo.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        HabitatCombo.Items.Clear();
                        while (reader.Read())
                        {
                            HabitatCombo.Items.Add(reader["Recinto_ID"].ToString() + ". " + reader["Nome"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load habitat names. Error: " + ex.Message);
                }
            }
        }   

        private void PopulateHabitaculoComboBox()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Habitat names cannot be loaded.");
                return;
            }

            using (SqlConnection connection = SqlConnection())
            {
                try
                {
                    HabitaculoCombo.Items.Clear();
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT ID FROM ZOO.PESQUISA_HABITACULOS_VAGOS(@Nome_JZ, @Habitat_ID)", connection);
                    cmd.Parameters.AddWithValue("@Nome_JZ", ZooCombo.Text);
                    cmd.Parameters.AddWithValue("@Habitat_ID", HabitatCombo.Text.Substring(0,2).Trim('.'));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            HabitaculoCombo.Items.Add(reader["ID"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load habitat names. Error: " + ex.Message);
                }
            }
        }

        private void ZooCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabitatCombo.Items.Clear();
            HabitaculoCombo.Items.Clear();
            HabitatCombo.Text = null;
            HabitaculoCombo.Text = null;
            if (ZooCombo.Text != null)
            {
                PopulateHabitatComboBox();
                HabitatCombo.Enabled = true;
                HabitaculoCombo.Enabled = false;
            }
            else
            {
                HabitatCombo.Enabled = false;
                HabitaculoCombo.Enabled = false;

            }
        }

        private void HabitatCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabitaculoCombo.Items.Clear();
            HabitaculoCombo.Text = null;
            if (HabitatCombo.Text != null)
            {
                PopulateHabitaculoComboBox();
                HabitaculoCombo.Enabled = true;
            }
            else
            {
                HabitaculoCombo.Enabled = false;
            }
        }

        private void HabitaculoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HabitaculoCombo.Text != null)
            {
                transferenciaZoo = ZooCombo.Text;
                transferenciaHabitat = int.Parse(HabitatCombo.Text.Substring(0,1));
                transferenciaHabitaculo = int.Parse(HabitaculoCombo.Text);
            }
        }

        private void TransferenciaConfirmar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedAnimal = listBox1.SelectedItem.ToString();
                string[] animalInfo = selectedAnimal.Split('.'); // Assuming the format is "ID. Name"
                string animalID = animalInfo[0].Trim();

                // Update the animal details in the database
                using (SqlConnection connection = SqlConnection())
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE ZOO.ANIMAL SET Habitat_ID = @Habitat, Habitaculo_ID = @Habitaculo, Nome_JZ = @Nome_JZ WHERE ID = @ID", connection);
                        cmd.Parameters.AddWithValue("@Nome_JZ", ZooCombo.Text);
                        cmd.Parameters.AddWithValue("@Habitat", int.Parse(HabitatCombo.Text.Substring(0,2).Trim('.')));
                        cmd.Parameters.AddWithValue("@Habitaculo", HabitaculoCombo.Text);
                        cmd.Parameters.AddWithValue("@ID", int.Parse(animalID));
                        cmd.ExecuteNonQuery();
                       
                        // Refresh the animal list after updating
                        PopulateAnimalList();

                        MessageBox.Show("Animal details updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to update animal details. Error: " + ex.Message);
                    }
                }
                EditarConfirmar.Visible = false;
                TransferenciaCancelar.Visible = false;
                AdicionarAnimal.Visible = true;
                RemoverAnimal.Visible = true;
                EditarAnimal.Visible = true;
                listBox1.Enabled = true;
                NomeAnimal.ReadOnly = true;
                GrupoTaxonomicoText.ReadOnly = true;
                EspecieAnimal.ReadOnly = true;
                DietaAnimal.ReadOnly = true;
                PesoAnimal.ReadOnly = true;
                ComprimentoAnimal.ReadOnly = true;
                CorAnimal.ReadOnly = true;
                VeterinarioAnimal.Enabled = false;
                ZooCombo.Visible = false;
                HabitatCombo.Visible = false;
                HabitaculoCombo.Visible = false;
                label8.Visible = true;
                ListaRelacionamentos.Visible = true;
                ZooAtual.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                AnimalTransferir.Visible = true;


            }
        }

        private void TransferirAnimal_Click(object sender, EventArgs e)
        {
            NomeAnimal.ReadOnly = true;
            GrupoTaxonomicoText.ReadOnly = true;
            EspecieAnimal.ReadOnly = true;
            DietaAnimal.ReadOnly = true;
            PesoAnimal.ReadOnly = true;
            ComprimentoAnimal.ReadOnly = true;
            CorAnimal.ReadOnly = true;
            VeterinarioAnimal.Enabled = false;
            EditarConfirmar.Visible = false;
            TransferenciaCancelar.Visible = true;
            AdicionarAnimal.Visible = false;
            RemoverAnimal.Visible = false;
            EditarAnimal.Visible = false;
            listBox1.Enabled = false;
            TransferenciaConfirmar.Visible = true;
            AnimalTransferir.Visible = false;
            ZooCombo.Visible = true;
            HabitatCombo.Visible = true;
            HabitaculoCombo.Visible = true;
            label8.Visible = false;
            ListaRelacionamentos.Visible = false;
            ZooAtual.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            ZooCombo.Text = transferenciaZoo;
            HabitatCombo.Text = transferenciaHabitat.ToString() + ". " + transferenciaHabitatNome.ToString();
            HabitaculoCombo.Text = transferenciaHabitaculo.ToString();
            PopulateZooComboBox();
            PopulateHabitatComboBox();
            PopulateHabitaculoComboBox();
        }

        private int getVeterinarioCC(string name)
        {
            string query = "SELECT Numero_CC FROM ZOO.VETERINARIO_DETALHADO WHERE Nome = @Nome";
            SqlCommand cmd = new SqlCommand(query, this.cn);
            cmd.Parameters.AddWithValue("@Nome", name);
            int cc = -1;

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
                        cc = reader.GetInt32(0);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving veterinarian CC: " + ex.Message);
            }

            return cc;
            }

        private void PopulateVeterinarioList()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Veterinarian names cannot be loaded.");
                return;
            }

            VeterinarioAnimal.Items.Clear(); // Clear any existing items

            string query = "SELECT Nome, Nome_JZ FROM ZOO.VETERINARIO_DETALHADO WHERE Nome_JZ = @Nome_JZ"; // Assuming a table named 'Veterinarians' with a column 'VeterinarianName'
            SqlCommand cmd = new SqlCommand(query, this.cn);
            cmd.Parameters.AddWithValue("@Nome_JZ", this.selectedZoo);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string veterinarianName = reader.GetString(0); // Assuming the first column (index 0) contains veterinarian names
                        VeterinarioAnimal.Items.Add(veterinarianName);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving veterinarian names: " + ex.Message);
            }
        }   

        private Boolean validarEditar()
        {
            if (NomeAnimal.Text == "")
            {
                MessageBox.Show("Nome do animal não pode estar vazio.");
                return false;
            }
            if (GrupoTaxonomicoText.Text == "")
            {
                MessageBox.Show("Grupo Taxonómico do animal não pode estar vazio.");
                return false;
            }
            if (EspecieAnimal.Text == "")
            {
                MessageBox.Show("Espécie do animal não pode estar vazio.");
                return false;
            }
            if (DietaAnimal.Text == "")
            {
                MessageBox.Show("Dieta do animal não pode estar vazio.");
                return false;
            }
            if (PesoAnimal.Text == "")
            {
                MessageBox.Show("Peso do animal não pode estar vazio.");
                return false;
            }
            if (ComprimentoAnimal.Text == "")
            {
                MessageBox.Show("Comprimento do animal não pode estar vazio.");
                return false;
            }
            if (CorAnimal.Text == "")
            {
                MessageBox.Show("Cor do animal não pode estar vazio.");
                return false;
            }
            if (VeterinarioAnimal.Text == "")
            {
                MessageBox.Show("Veterinário do animal não pode estar vazio.");
                return false;
            }
            return true;
        }

        private void EditarConfirmar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && validarEditar())
            {
                string selectedAnimal = listBox1.SelectedItem.ToString();
                string[] animalInfo = selectedAnimal.Split('.'); // Assuming the format is "ID. Name"
                string animalID = animalInfo[0].Trim();

                // Update the animal details in the database
                using (SqlConnection connection = SqlConnection())
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE ZOO.ANIMAL SET Nome = @Nome, Dieta = @Dieta, Grupo_Taxonomico = @GrupoTaxonomico, Especie = @Especie, Peso = @Peso, Comprimento = @Comprimento, Cor = @Cor, Veterinario_CC = @Veterinario WHERE ID = @ID", connection);
                        cmd.Parameters.AddWithValue("@Nome", NomeAnimal.Text);
                        cmd.Parameters.AddWithValue("@Dieta", DietaAnimal.Text);
                        cmd.Parameters.AddWithValue("@GrupoTaxonomico", GrupoTaxonomicoText.Text);
                        cmd.Parameters.AddWithValue("@Especie", EspecieAnimal.Text);
                        cmd.Parameters.AddWithValue("@Peso", float.Parse(PesoAnimal.Text));
                        cmd.Parameters.AddWithValue("@Comprimento", float.Parse(ComprimentoAnimal.Text));
                        cmd.Parameters.AddWithValue("@Cor", CorAnimal.Text);
                        cmd.Parameters.AddWithValue("@Veterinario", getVeterinarioCC(VeterinarioAnimal.Text));
                        cmd.Parameters.AddWithValue("@ID", int.Parse(animalID));
                        cmd.ExecuteNonQuery();

                        // Refresh the animal list after updating
                        PopulateAnimalList();

                        MessageBox.Show("Animal details updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to update animal details. Error: " + ex.Message);
                    }
                }
                EditarConfirmar.Visible = false;
                TransferenciaCancelar.Visible = false;
                AdicionarAnimal.Visible = true;
                RemoverAnimal.Visible = true;
                EditarAnimal.Visible = true;
                listBox1.Enabled = true;
                NomeAnimal.ReadOnly = true;
                GrupoTaxonomicoText.ReadOnly = true;
                EspecieAnimal.ReadOnly = true;
                DietaAnimal.ReadOnly = true;
                PesoAnimal.ReadOnly = true;
                ComprimentoAnimal.ReadOnly = true;
                CorAnimal.ReadOnly = true;
                VeterinarioAnimal.Enabled = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
