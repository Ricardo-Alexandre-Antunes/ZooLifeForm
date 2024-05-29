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
    public partial class GerirRelacoes : Form
    {
        Form prevForm;
        int animal1;
        int animal2;
        private SqlConnection cn;
        private string connectionString;
        public GerirRelacoes(Form prevForm, string connectionString, int animalID = -1)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.prevForm = prevForm;
            if (animalID != -1)
            {
                // Select animal with the given ID in the first animal list
                this.animal1 = animalID;
            }
            this.animal2 = -1;
            this.FormClosing += new FormClosingEventHandler(this.GerirRelacoes_FormClosing);
            PopulateAnimais();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection(connectionString);
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void AddRelacao(int animal1ID, int animal2ID, string relacao)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Relationship could not be added.");
                return;
            }

            string query = "EXEC ZOO.sp_adicionarAnimalRelacionado @animal1ID, @animal2ID, @relacao";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@animal1ID", animal1ID);
            cmd.Parameters.AddWithValue("@animal2ID", animal2ID);
            cmd.Parameters.AddWithValue("@relacao", relacao);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Relationship added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add relationship. Error: " + ex.Message);
            }
        }


        private void GerirRelacoes_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Este código será executado quando o formulário estiver prestes a ser fechado
            this.prevForm.Show();
        }

        private void RemoverRelacao_Click(object sender, EventArgs e)
        {
            if (CurRelacoes.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a relationship to remove.");
                return;
            }
            // Remove relationship from the database
            MessageBox.Show("Removing relationship between " + int.Parse(ListaAnimais1.Text.ToString().Split('.')[0]) + " and " + int.Parse(CurRelacoes.Text.ToString().Split('.')[0]));
            RemoveRelacao(int.Parse(ListaAnimais1.Text.ToString().Split('.')[0]), int.Parse(CurRelacoes.Text.ToString().Split('.')[0]));
        }

        private void RemoveRelacao(int animal1ID, int animal2ID)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Relationship could not be removed.");
                return;
            }

            string query = "EXEC ZOO.sp_removerAnimalRelacionado @Animal1ID, @Animal2ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Animal1ID", animal1ID);
            cmd.Parameters.AddWithValue("@Animal2ID", animal2ID);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Relationship removed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to remove relationship. Error: " + ex.Message);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private void AdicionarRelacao_Click(object sender, EventArgs e)
        {
            if (animal1 == -1 || animal2 == -1)
            {
                MessageBox.Show("Please select two animals to compare.");
                return;
            }
            if (animal1 == animal2)
            {
                MessageBox.Show("Please select two different animals.");
                return;
            }
            if (NovaRelacao.Text == "")
            {
                MessageBox.Show("Please enter a relationship.");
                return;
            }
            // Add relationship to the database
            AddRelacao(animal1, animal2, NovaRelacao.Text);
        }

        private void PopulateAnimais()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Animals could not be loaded.");
                return;
            }
            string query = "SELECT ID, Nome FROM ZOO.Animal";
            SqlCommand cmd = new SqlCommand(query, cn);
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int animalID = reader.GetInt32(0);
                        string animalName = reader.GetString(1);
                        string text = animalID + ". " + animalName;
                        ListaAnimais1.Items.Add(text);
                        ListaAnimais2.Items.Add(text);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving animals: " + ex.Message);
            }
        }

        private void PopulateRelacoes()
        {
            MessageBox.Show("Populating relationships for animal " + animal1);
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Relationships could not be loaded.");
                return;
            }
            CurRelacoes.Items.Clear();
            string query = "SELECT * FROM ZOO.PESQUISA_RELACOES_ANIMAL(@AnimalID)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@AnimalID", animal1);
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string relacaoID = reader["OtherAnimalId"].ToString();
                        string animalName = reader["OtherAnimalName"].ToString();
                        string relacao = reader["Relacao"].ToString();
                        CurRelacoes.Items.Add(relacaoID + ". " + animalName + " - " + relacao);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving relationships: " + ex.Message);
            }
        }   



        private void ListaAnimais1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.animal1 = int.Parse(ListaAnimais1.Text.ToString().Split('.')[0]);
            PopulateRelacoes();  
        }

        private void ListaAnimais2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.animal2 = int.Parse(ListaAnimais2.Text.ToString().Split('.')[0]);
        }
    }
}
