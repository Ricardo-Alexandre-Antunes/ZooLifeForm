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
            PopulateAnimalList(); // Call the function to populate animal names on form load
            populateZooMenuItems();
        }

        private void toggleVisibilityHabitaculos()
        {
            showHabitaculos = !showHabitaculos;
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

            string query = "SELECT Nome FROM ZOO.ANIMAL"; // Assuming a table named 'Animals' with a column 'AnimalName'
            SqlCommand cmd = new SqlCommand(query, SqlConnection());

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["Nome"].ToString());
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

        private void populateHabitatMenuItems()
        {
            if (!VerifySqlConnection())
            {
                MessageBox.Show("Failed to connect to database. Habitat names cannot be loaded.");
                return;
            }

            escolherHabitáculoToolStripMenuItem.DropDownItems.Clear(); // Clear any existing items

            string query = "SELECT Nome FROM ZOO.HABITAT"; // TODO: MUDAR PARA A TABELA DE HABITATS
            SqlCommand cmd = new SqlCommand(query, SqlConnection());

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string habitatName = reader.GetString(0); // Assuming the first column (index 0) contains habitat names
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(habitatName);
                        // Add an event handler for menu item click (optional)
                        menuItem.Click += new EventHandler(menuItem_Click);
                        escolherHabitáculoToolStripMenuItem.DropDownItems.Add(menuItem);
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

        private void menuItem_Click(object sender, EventArgs e)  // Optional event handler for menu item click
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            this.selectedZoo = clickedItem.Text;
            // Perform actions based on the selected zoo
            this.Text = "ZooLife - Lista de Animais (" + selectedZoo + ")";
            toggleVisibilityHabitaculos();
        }
    }
}
