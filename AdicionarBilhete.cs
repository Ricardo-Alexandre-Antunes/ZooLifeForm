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
    public partial class AdicionarBilhete : Form
    {
        private Form previousForm;
        private SqlConnection cn;

        private String selectedZoo;
        private String selectedBilheteira;
        private String SelectedHabitat;
        private int SelectedFuncionario;
        private int BilheteiraID;
        public AdicionarBilhete(String selectedZoo, Form previousForm)
        {
            InitializeComponent();
            this.selectedZoo = selectedZoo;
            this.Text = "Adicionar bilhete vendido";
            this.previousForm = previousForm;
            VerifySGBDConnection();
            this.cn = SGBDConnection();
            this.selectedBilheteira = null;
            this.SelectedHabitat = null;
            this.SelectedFuncionario = 0; ;
            this.BilheteiraID = 0;
            NovoRecinto_Load();
        }

        private bool VerifySGBDConnection()
        {
            if (cn == null)
                cn = SGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private SqlConnection SGBDConnection()
        {
            return new SqlConnection("data source = tcp:mednat.ieeta.pt\\SQLSERVER,8101; Initial Catalog = p8g5; uid = p8g5; password = grupoRRBD2024");
        }

        private void NovoRecinto_Load()
        {
            // Call the method to populate the zoo combo box
            PopulateGeneroComboBox();
            PopulateZooComboBox();
        }

        private void PopulateGeneroComboBox()
        {
            comboBox_genero.Items.Add("M");
            comboBox_genero.Items.Add("F");
        }

        private void PopulateZooComboBox()
        {
            if (!VerifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            }

            comboBox_jz.Items.Clear(); // Clear any existing items
            comboBox_bilheteira.Items.Clear();
            comboBox_funcionario_cc.Items.Clear();


            string query = "SELECT Nome FROM ZOO.JARDIM_ZOOLOGICO"; // Assuming a table named 'Zoos' with a column 'ZooName'
            SqlCommand cmd = new SqlCommand(query, cn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
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

        private void PopulateBilheteiraComboBox()
        {
            if (!VerifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            }

            comboBox_bilheteira.Items.Clear(); // Clear any existing items
            comboBox_funcionario_cc.Items.Clear();

            string query = "SELECT Nome FROM ZOO.BILHETEIRA JOIN ZOO.RECINTO ON Recinto_ID = ID WHERE @nome_jz = Recinto.Nome_JZ"; // Assuming a table named 'Zoos' with a column 'ZooName'
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@nome_jz", this.selectedZoo);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string bilheteiraName = reader.GetString(0); // Assuming the first column (index 0) contains zoo names
                        comboBox_bilheteira.Items.Add(bilheteiraName);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving bilheteira names: " + ex.Message);
            }
        }


        private void PopulateFuncionarioBilheteiraComboBox()
        {
            if (!VerifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names cannot be loaded.");
                return;
            } 

            comboBox_funcionario_cc.Items.Clear(); // Clear any existing items

            if (this.selectedBilheteira != null) { }

            string query1 = "SELECT ID FROM ZOO.RECINTO WHERE @nome_recinto = Nome AND @nome_jz = Nome_JZ";
            string query2 = "SELECT F_Numero_CC FROM ZOO.FUNCIONARIO_BILHETEIRA WHERE Bilheteira_ID = @bilheteiraID";

            SqlCommand cmd1 = new SqlCommand(query1, cn);
            cmd1.Parameters.AddWithValue("@nome_recinto",this.selectedBilheteira);
            cmd1.Parameters.AddWithValue("@nome_jz",this.selectedZoo);

            int bilheteiraID = 0;

            try
            {
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bilheteiraID=reader.GetInt32(0);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving zoo names: " + ex.Message);
            }

            SqlCommand cmd2 = new SqlCommand(query2, cn);
            cmd2.Parameters.AddWithValue("@bilheteiraID", bilheteiraID);

            try
            {
                using (SqlDataReader reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int func_cc = reader.GetInt32(0); // Assuming the first column (index 0) contains zoo names
                        comboBox_funcionario_cc.Items.Add(func_cc);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving funcionarios de bilheteira names: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_jz_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedZoo = comboBox_jz.SelectedItem.ToString();
            PopulateBilheteiraComboBox();
        }

        private void comboBox_bilheteira_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedBilheteira = comboBox_bilheteira.SelectedItem.ToString();
            PopulateFuncionarioBilheteiraComboBox();
        }

        private void comboBox_funcionario_cc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedFuncionario = Int32.Parse(comboBox_funcionario_cc.SelectedItem.ToString());
        }

        private Boolean ValidateForm()
        {
            Boolean nomeValido = textBox_nome.Text.Length > 0;
            Boolean numeroCC_Valido = textBox_cc.Text.Length > 0;
            Boolean generoValido = comboBox_genero.SelectedItem != null;

            Boolean jzValido = comboBox_jz.SelectedItem != null;
            Boolean bilheteiraValida = comboBox_bilheteira.SelectedItem != null;
            Boolean func_cc_Valido = comboBox_funcionario_cc != null;
            Boolean preco_valido = (textBox_preco.Text.Length > 0) && Int32.TryParse(textBox_preco.Text, out _);


            return (nomeValido && jzValido && numeroCC_Valido && generoValido && bilheteiraValida && func_cc_Valido && preco_valido);
        }
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Close();
        }

        private Boolean InserirBilhete()
        {
            string nome = textBox_nome.Text;
            int visitante_cc = Int32.Parse(textBox_cc.Text);
            string genero = comboBox_genero.SelectedItem.ToString();
            string recinto_jz = this.selectedZoo;
            int bilheteira = this.BilheteiraID;
            int funcionario_cc = this.SelectedFuncionario;
            int preco = Int32.Parse(textBox_preco.Text.ToString());
            DateTime date_compra = dateTimePicker_data_compra.Value; // Correção
            DateTime date_nascimento = dateTimePicker_data_nascimento.Value; // Correção
            string procedure = "ZOO.sp_adicionarBilhete @v_numero_cc, @v_nome, @v_genero, @v_data_nascimento, @preco, @data_compra, @f_numero_cc, @nome_jz, @bilheteira_id";

            SqlCommand cmd = new SqlCommand(procedure, cn);
            cmd.Parameters.AddWithValue("@v_numero_cc", visitante_cc);
            cmd.Parameters.AddWithValue("@v_nome", nome);
            cmd.Parameters.AddWithValue("@v_genero", genero);
            cmd.Parameters.AddWithValue("@v_data_nascimento", date_nascimento);
            cmd.Parameters.AddWithValue("@preco", preco);
            cmd.Parameters.AddWithValue("@data_compra", date_compra);
            cmd.Parameters.AddWithValue("@f_numero_cc", funcionario_cc);
            cmd.Parameters.AddWithValue("@nome_jz", recinto_jz);
            cmd.Parameters.AddWithValue("@bilheteira_id", bilheteira);


            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bilhete inserido com sucesso!");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error inserting recinto: " + ex.Message);
                return false;
            }

        }

        private void ConfirmarAdicionar()
        {
            if (InserirBilhete())
            {
                this.Close();
                this.previousForm.Show();
            }
        }
        private void button_adicionar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ConfirmarAdicionar();
            }
            else
            {
                MessageBox.Show("Erro. Insira os dados corretamente no formulário.");
            }
        }
    }
}
