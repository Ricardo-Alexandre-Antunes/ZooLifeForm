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
    public partial class NovoAnimal : Form
    {
        private String selectedZoo;
        private int selectedHabitat;
        private int selectedHabitaculo;
        private int selectedVeterinario;
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private Object[] veterinarios;
        private int counter = 0;

        public NovoAnimal()
        {
            InitializeComponent();
            NovoAnimal_Load();
            veterinarios = new Object[100];
            counter = 0;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private Boolean InsertAnimal(string nome, string especie, string dieta, float peso, float comprimento, string cor, int habitaculo, int veterinario)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Animal cannot be inserted.");
                return false;
            }

            string query = "EXEC ZOO.sp_adicionarAnimal @dieta, @grupo_taxonomico, @nome, @cor, @Comprimento, @peso, @especie, @veterinario_cc, @habitaculo_id, @habitat_id, @nome_jz";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@dieta", dieta);
            cmd.Parameters.AddWithValue("@grupo_taxonomico", "Mamifero");
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@cor", cor);
            cmd.Parameters.AddWithValue("@Comprimento", comprimento);
            cmd.Parameters.AddWithValue("@peso", peso);
            cmd.Parameters.AddWithValue("@especie", especie);
            cmd.Parameters.AddWithValue("@veterinario_cc", veterinario);
            cmd.Parameters.AddWithValue("@habitaculo_id", habitaculo);
            cmd.Parameters.AddWithValue("@habitat_id", selectedHabitat);
            cmd.Parameters.AddWithValue("@nome_jz", selectedZoo);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Animal inserido com sucesso!");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error inserting animal: " + ex.Message);
                return false;
            }
        }


        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            if (IsValidFields())
            {
                // Perform action when all fields are valid
                // Example: Insert the new animal into the database
                InsertAnimal(NovoAnimalNome.Text, NovoAnimalEspecie.Text, NovoAnimalDieta.Text, float.Parse(NovoAnimalPeso.Text), float.Parse(NovoAnimalComprimento.Text), NovoAnimalCor.Text, selectedHabitaculo, selectedVeterinario);
            }
            else
            {
                // Display error message or handle invalid fields
            }
        }

        private bool IsValidFields()
        {
            // Check the validity of all fields
            // Return true if all fields are valid, otherwise return false
            Boolean nomeValido = NovoAnimalNome.Text.Length > 0;
            Boolean especieValida = NovoAnimalEspecie.Text.Length > 0;
            Boolean dietaValida = NovoAnimalDieta.Text.Length > 0;
            Boolean PesoValido = NovoAnimalPeso.Text.Length > 0 && float.TryParse(NovoAnimalPeso.Text, out float peso);
            Boolean ComprimentoValida = NovoAnimalComprimento.Text.Length > 0 && float.TryParse(NovoAnimalComprimento.Text, out float altura);
            Boolean CorValida = NovoAnimalCor.Text.Length > 0;
            Boolean habitatValido = NovoAnimalHabitatCombo.SelectedItem != null;
            Boolean habitaculoValido = NovoAnimalHabitaculoCombo.SelectedItem != null;
            Boolean veterinarioValido = NovoAnimalVeterinarioCombo.SelectedItem != null;
            Boolean res = nomeValido && especieValida && dietaValida && PesoValido && ComprimentoValida && CorValida && habitatValido && habitaculoValido && veterinarioValido;
            //MessageBox.Show("Nome: " + nomeValido + "\nEspecie: " + especieValida + "\nDieta: " + dietaValida + "\nPeso: " + PesoValido + "\nComprimento: " + ComprimentoValida + "\nCor: " + CorValida + "\nHabitat: " + habitatValido + "\nHabitaculo: " + habitaculoValido + "\nVeterinario: " + veterinarioValido + "\nFinal: " + res);


            // Add more validation logic for other fields
            return res;
        }



        private void HabitatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh the options for valid habitaculos whenever the habitat changes
            RefreshHabitaculoOptions();
        }

        private void RefreshHabitatOptions()
        {
            if (selectedZoo == null)
            {
                // No zoo selected, clear the habitat options
                NovoAnimalHabitatCombo.Items.Clear();
                return;
            }

            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Habitat options cannot be loaded.");
                return;
            }

            NovoAnimalHabitatCombo.Items.Clear(); // Clear any existing items

            string query = "SELECT Recinto_ID, Nome FROM ZOO.HABITAT INNER JOIN ZOO.RECINTO ON ZOO.HABITAT.Recinto_ID = ZOO.RECINTO.ID WHERE ZOO.HABITAT.Nome_JZ = @SelectedZoo";
            cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@SelectedZoo", selectedZoo);

            try
            {
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string habitatID = reader.GetValue(0).ToString(); // Assuming the first column (index 0) contains habitat names
                        string habitatNome = reader.GetValue(1).ToString(); // Assuming the second column (index 1) contains habitat names
                        NovoAnimalHabitatCombo.Items.Add(habitatID + ". " + habitatNome);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving habitat options: " + ex.Message);
            }
        }

        private void RefreshHabitaculoOptions()
        {
            // Code to refresh the options for valid habitaculos based on the selected habitat
            // Similar to RefreshHabitatOptions()
            if (selectedZoo == null)
            {
                // No zoo selected, clear the habitat options
                NovoAnimalHabitatCombo.Items.Clear();
                return;
            }

            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Habitat options cannot be loaded.");
                return;
            }

            NovoAnimalHabitaculoCombo.Items.Clear(); // Clear any existing items

            string query = "SELECT ID FROM ZOO.HABITACULO INNER JOIN ZOO.HABITAT ON ZOO.HABITACULO.Habitat_ID = ZOO.HABITAT.Recinto_ID WHERE ZOO.HABITAT.Recinto_ID = @selectedHabitat";
            cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@selectedHabitat", selectedHabitat);

            try
            {
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string habitatID = reader.GetValue(0).ToString(); // Assuming the first column (index 0) contains habitat names
                        NovoAnimalHabitaculoCombo.Items.Add(habitatID);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving habitat options: " + ex.Message);
            }

        }

        private void NovoAnimal_Load()
        {
            // Call the method to populate the zoo combo box
            populateZooComboBox();
        }

        private void populateZooComboBox()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            }

            NovoAnimalZooCombo.Items.Clear(); // Clear any existing items

            string query = "SELECT Nome FROM ZOO.JARDIM_ZOOLOGICO"; // Assuming a table named 'Zoos' with a column 'ZooName'
            cmd = new SqlCommand(query, cn);

            try
            {
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string zooName = reader.GetString(0); // Assuming the first column (index 0) contains zoo names
                        NovoAnimalZooCombo.Items.Add(zooName);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving zoo names: " + ex.Message);
            }
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p8g5; uid = p8g5; password = grupoRRBD2024");
        }

        private void NovoAnimalZooCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            NovoAnimalHabitaculoCombo.SelectedItem = null;
            NovoAnimalHabitatCombo.SelectedItem = null;
            NovoAnimalVeterinarioCombo.SelectedItem = null;
            // Enable/disable the habitat combo box based on the selected zoo
            if (NovoAnimalZooCombo.SelectedItem != null && NovoAnimalZooCombo.SelectedItem.ToString() != "")
            {
                selectedZoo = NovoAnimalZooCombo.SelectedItem.ToString();
                NovoAnimalHabitatCombo.Enabled = true;
                NovoAnimalVeterinarioCombo.Enabled = true;
            }
            else
            {
                selectedZoo = null;
                NovoAnimalHabitatCombo.Enabled = false;
                NovoAnimalHabitaculoCombo.Enabled = false;
                NovoAnimalVeterinarioCombo.Enabled = false;
            }

            // Refresh the options for valid habitats
            ConfirmarButton.Enabled = IsValidFields();
            RefreshHabitatOptions();
            PopulateVeterinarioCombo();
        }



        private void NovoAnimalHabitatCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("Habitat selected: " + NovoAnimalHabitatCombo.SelectedItem.ToString());
            // Enable/disable the habitaculo combo box based on the selected habitat
            
            if (NovoAnimalHabitatCombo.SelectedItem != null)
            {
                this.selectedHabitat = Int32.Parse(NovoAnimalHabitatCombo.SelectedItem.ToString().Split('.')[0]);
                NovoAnimalHabitaculoCombo.Enabled = true;
            }
            else
            {
                NovoAnimalHabitaculoCombo.Enabled = false;
            }

            // Refresh the options for valid habitaculos
            ConfirmarButton.Enabled = IsValidFields();
            RefreshHabitaculoOptions();
        }

        private void NovoAnimalHabitaculoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable/disable the confirm button based on the selected habitaculo
            
            if (NovoAnimalHabitaculoCombo.SelectedItem != null)
            {
                this.selectedHabitaculo = Int32.Parse(NovoAnimalHabitaculoCombo.SelectedItem.ToString());
            }
            ConfirmarButton.Enabled = IsValidFields();
        }


        private string findVeterinario(string nome)
        {
            for (int i = 0; i < counter; i++)
            {
                if (((ValueTuple<string, string>)this.veterinarios[i]).Item2 == nome)
                {
                    return ((ValueTuple<string, string>)this.veterinarios[i]).Item1;
                }
            }
            return "-1";
        }

        private void NovoAnimalVeterinarioCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable/disable the confirm button based on the selected habitaculo
            
            if (NovoAnimalVeterinarioCombo.SelectedItem != null)
            {
                this.selectedVeterinario = int.Parse(findVeterinario(NovoAnimalVeterinarioCombo.SelectedItem.ToString()));
                MessageBox.Show("Veterinario selected: " + this.selectedVeterinario);
            }
            ConfirmarButton.Enabled = IsValidFields();
        }

        private void PopulateVeterinarioCombo()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Veterinario options cannot be loaded.");
                return;
            }

            NovoAnimalVeterinarioCombo.Items.Clear(); // Clear any existing items

            string query = "SELECT Nome, Numero_CC FROM ZOO.PESQUISA_VETERINARIOS_ZOO(@Nome_JZ)"; // Assuming a table named 'Veterinarios' with a column 'Nome' and 'ZooNome'
            cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Nome_JZ", selectedZoo);

            try
            {
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string veterinarioNome = reader.GetString(0); // Assuming the first column (index 0) contains veterinarian names
                        string veterinarioCC = reader.GetValue(1).ToString(); // Assuming the second column (index 1) contains veterinarian CC
                        NovoAnimalVeterinarioCombo.Items.Add(veterinarioNome);
                        this.veterinarios[counter++] = (veterinarioCC, veterinarioNome);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving veterinarian names: " + ex.Message);
            }
        }

        private void NovoAnimalNome_TextChanged(object sender, EventArgs e)
        {
            ConfirmarButton.Enabled = IsValidFields();
        }

        private void NovoAnimalEspecie_TextChanged(object sender, EventArgs e)
        {
            ConfirmarButton.Enabled = IsValidFields();
        }

        private void NovoAnimalDieta_TextChanged(object sender, EventArgs e)
        {
            ConfirmarButton.Enabled = IsValidFields();
        }

        private void NovoAnimalPeso_TextChanged(object sender, EventArgs e)
        {
            ConfirmarButton.Enabled = IsValidFields();
        }

        private void NovoAnimalComprimento_TextChanged(object sender, EventArgs e)
        {
            ConfirmarButton.Enabled = IsValidFields();
        }

        private void NovoAnimalCor_TextChanged(object sender, EventArgs e)
        {
            ConfirmarButton.Enabled = IsValidFields();
        }

        private void NovoAnimal_Load(object sender, EventArgs e)
        {

        }
    }
}
