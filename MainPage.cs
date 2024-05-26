using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooLifeForm
{
    public partial class MainPage : Form
    {

        private SqlConnection cn;
        String selectedZoo;

        public MainPage()
        {
            InitializeComponent();
            verifySGBDConnection();
            populateZooMenuItems(); // Call the function to populate menu items on form load
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

        private void populateZooMenuItems()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            }

            escolherZooToolStripMenuItem.DropDownItems.Clear(); // Clear any existing items

            string query = "SELECT Nome FROM ZOO.JARDIM_ZOOLOGICO"; // Assuming a table named 'Zoos' with a column 'ZooName'
            SqlCommand cmd = new SqlCommand(query, cn);

            try
            {
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
            this.Text = "ZooLife - Página Principal (" + selectedZoo + ")";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // No need to call verifySGBDConnection() or populateZooMenuItems() here
            // They are already called in the constructor
        }

        private void escolherZooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This event handler is not strictly necessary if you've added click handlers to individual menu items
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.selectedZoo == null)
            {
                MessageBox.Show("Please select a zoo first.");
                return;
            }

            AnimalList animalListForm = new AnimalList(this.selectedZoo, this); // Create an instance of the AnimalList form
            animalListForm.Show(); // Show the AnimalList form
            this.Hide();
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FuncionarioList funcionarioListForm = new FuncionarioList(this.selectedZoo ,this); // Create an instance of the FuncionarioList form
            funcionarioListForm.Show(); // Show the FuncionarioList form
            this.Hide();
        }
    }
}
