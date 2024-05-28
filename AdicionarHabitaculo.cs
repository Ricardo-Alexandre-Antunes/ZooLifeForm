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
    public partial class AdicionarHabitaculo : Form
    {
        private String selectedZoo;
        private String selectedHabitat;
        private Form previousForm;
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader reader;
        public AdicionarHabitaculo(string selectedZoo, Form previousForm)
        {
            this.selectedZoo = selectedZoo;
            this.previousForm = previousForm;
            InitializeComponent();
            NovoRecinto_Load();
        }

        private void AdicionarHabitaculo_Closing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Show();
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

        private void NovoRecinto_Load()
        {
            PopulateZooComboBox();
            PopuplateHabitatComboBox();
        }

        private void PopulateZooComboBox()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            }

            comboBox_jz.Items.Clear(); // Clear any existing items

            string query = "SELECT Nome FROM ZOO.JARDIM_ZOOLOGICO"; // Assuming a table named 'Zoos' with a column 'ZooName'
            cmd = new SqlCommand(query, cn);

            try
            {
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string zooName = reader.GetString(0); // Assuming the first column (index 0) contains zoo names
                        comboBox_jz.Items.Add(zooName);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving zoo names: " + ex.Message);
            }
        }

        private void PopuplateHabitatComboBox()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Habitat names cannot be loaded.");
                return;
            }

            comboBox_habitat.Items.Clear();

            string query = "SELECT Nome FROM ZOO.RECINTO JOIN ZOO.HABITAT ON ID = Recinto_ID WHERE @nome_jz=Habitat.Nome_JZ";

            cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("nome_jz", this.selectedZoo);

            try
            {
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string habitatName = reader.GetString(0); // Assuming the first column (index 0) contains zoo names
                        comboBox_habitat.Items.Add(habitatName);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving habitat names: " + ex.Message);
            }

        }

        private void comboBox_jz_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedZoo = comboBox_jz.SelectedItem.ToString();
            RefreshHabitatComboBox();
        }

        private void RefreshHabitatComboBox()
        {
            PopuplateHabitatComboBox();
        }


        private bool validateForm()
        {
            Boolean dimensoesValido = textBox_dimensoes.Text.Length > 0;
            Boolean jzValido = comboBox_jz.SelectedItem != null;
            Boolean habitatValido = comboBox_habitat.SelectedItem != null;
            Boolean capacidadeValido = textBox_capacidade_max.Text.Length > 0;

            return (dimensoesValido && jzValido && habitatValido && capacidadeValido);
        }

        private void button_adicionar_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                ConfimarAdicionarHabitaculo();
            }
            else
            {
                MessageBox.Show("Erro. Insira os dados corretamente no formulário.");
            }
        }

        private void ConfimarAdicionarHabitaculo()
        {
            if (InserirHabitaculo())
            {
                this.previousForm.Show();
                this.Close();
            }
        }

        private Boolean InserirHabitaculo()
        {
            string habitaculo_jz = this.selectedZoo;
            string habitaculo_habitat = this.selectedHabitat;
            string habitaculo_dimensoes = textBox_dimensoes.Text;
            string habitaculo_capacidade = textBox_capacidade_max.Text;
            string query1 = "SELECT Recinto_ID FROM ZOO.HABITAT JOIN ZOO.RECINTO ON Recinto_ID = ID WHERE Nome = @nome";
            string query2 = "EXEC ZOO.sp_adicionarHabitaculo @nome_jz, @recinto_id, @tamanho, @max_animais";

            SqlCommand cmd1 = new SqlCommand(query1, cn);
            cmd1.Parameters.AddWithValue("@nome", habitaculo_habitat);

            try
            {
                //cn.Open();
                int recintoId = 0;

                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recintoId = reader.GetInt32(0); // Assuming Recinto_ID is an integer
                    }
                    else
                    {
                        MessageBox.Show("No Recinto ID found for the specified habitat.");
                        return false;
                    }
                }

                // Now execute the second query
                SqlCommand cmd2 = new SqlCommand(query2, cn);
                cmd2.Parameters.AddWithValue("@nome_jz", habitaculo_jz);
                cmd2.Parameters.AddWithValue("@recinto_id", recintoId);
                cmd2.Parameters.AddWithValue("@tamanho", habitaculo_dimensoes);
                cmd2.Parameters.AddWithValue("@max_animais", habitaculo_capacidade);

                cmd2.ExecuteNonQuery();
                MessageBox.Show("Habitáculo inserido com sucesso!");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return false;
            }
            finally
            {
                cn.Close();
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Close();
        }

        private void comboBox_habitat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedHabitat=comboBox_habitat.SelectedItem.ToString();
        }
    }

}
