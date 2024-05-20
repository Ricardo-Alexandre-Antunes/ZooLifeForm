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
        SqlConnection cn;
        String ZooName;
        List<string> animalList = new List<string>();
        public AnimalList(String ZooName)
        {
            this.ZooName = ZooName;
            InitializeComponent();
            verifySGBDConnection();
            populateAnimalList();
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

        private void populateAnimalList()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Animal names cannot be loaded.");
                return;
            }

            listBox1.Items.Clear(); // Clear any existing items
            listBox1.Items.Add("Animal List for " + ZooName);

            string query = "SELECT Nome FROM ZOO.ANIMAL"; // Assuming a table named 'Animals' with a column 'AnimalName'
            SqlCommand cmd = new SqlCommand(query, cn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Put data into the textbox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load animal names. Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void escolherHabitáculoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
