using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private int[] BilheteirasID;
        private string[] BilheteirasNome;
        private int BilheteiraID;
        private int count = 0;
        private string connectionString;
        public AdicionarBilhete(String selectedZoo, Form previousForm, string connectionString)
        {
            InitializeComponent();
            this.BilheteirasID = new int[100];
            this.BilheteirasNome = new string[100];
            this.selectedZoo = selectedZoo;
            this.Text = "Adicionar bilhete vendido";
            this.previousForm = previousForm;
            this.connectionString = connectionString;
            VerifySGBDConnection();
            this.cn = SGBDConnection();
            this.selectedBilheteira = null;
            this.SelectedHabitat = null;
            this.SelectedFuncionario = 0; ;
            this.BilheteiraID = 0;
            NovoRecinto_Load();
        }


        private void AdicionarBilhete_Closing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Show();
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
            return new SqlConnection(this.connectionString);
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

            string query = "SELECT ID, Nome FROM ZOO.BILHETEIRA JOIN ZOO.RECINTO ON Recinto_ID = ID WHERE @nome_jz = Recinto.Nome_JZ and ZOO.BILHETEIRA.Estado = 'aberto'"; // Assuming a table named 'Zoos' with a column 'ZooName'
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@nome_jz", this.selectedZoo);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int bilheteiraID = int.Parse(reader["ID"].ToString());
                        string bilheteiraName = reader["Nome"].ToString(); // Assuming the first column (index 0) contains zoo names
                        
                        Console.WriteLine(bilheteiraID);
                        Console.WriteLine(bilheteiraName);
                        this.BilheteirasNome[count] = bilheteiraName;
                        this.BilheteirasID[count]  = bilheteiraID;
                        count++;
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
            button_adicionar.Enabled = ValidateForm();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_jz_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedZoo = comboBox_jz.SelectedItem.ToString();
            PopulateBilheteiraComboBox();
            button_adicionar.Enabled = ValidateForm();
        }

        private int GetBilheteiraID()
        {
            for (int i = 0; i < comboBox_bilheteira.Items.Count; i++)
            {
                if (BilheteirasNome[i].Equals(this.selectedBilheteira))
                {
                    return BilheteirasID[i];
                }
            }
            return -1;
        }

        private void comboBox_bilheteira_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedBilheteira = comboBox_bilheteira.Text.ToString();
            this.BilheteiraID = GetBilheteiraID();
            PopulateFuncionarioBilheteiraComboBox();
            button_adicionar.Enabled = ValidateForm();
        }

        private void comboBox_funcionario_cc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedFuncionario = int.Parse(comboBox_funcionario_cc.Text.ToString());
            button_adicionar.Enabled = ValidateForm();
        }

        private Boolean ValidateForm()
        {
            Boolean nomeValido = textBox_nome.Text.Length > 0;
            Boolean numeroCC_Valido = textBox_cc.Text.Length == 8 && int.TryParse(textBox_cc.Text, out int result);
            Boolean generoValido = comboBox_genero.Text == "M" || comboBox_genero.Text == "F";

            Boolean jzValido = comboBox_jz.SelectedIndex != -1;
            Boolean bilheteiraValida = comboBox_bilheteira.SelectedIndex != -1;
            Boolean func_cc_Valido = comboBox_funcionario_cc.SelectedIndex != -1;
            Boolean preco_valido = int.TryParse(textBox_preco.Text, out result);


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
            int visitante_cc = int.Parse(textBox_cc.Text);
            string genero = comboBox_genero.SelectedItem.ToString();
            string recinto_jz = this.selectedZoo;
            int bilheteira = this.BilheteiraID;
            int funcionario_cc = this.SelectedFuncionario;
            int preco = int.Parse(textBox_preco.Text.ToString());
            DateTime date_compra = dateTimePicker_data_compra.Value; // Correção
            DateTime date_nascimento = dateTimePicker_data_nascimento.Value; // Correção
            Console.WriteLine(nome + " | " + visitante_cc + " | " + genero + " | " + recinto_jz + " | " + bilheteira.ToString() + " | " + funcionario_cc.ToString() + " | " + preco.ToString() + " | " + date_compra.ToString() + " | " + date_nascimento.ToString());
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

        private void textBox_nome_TextChanged(object sender, EventArgs e)
        {
            button_adicionar.Enabled = ValidateForm();
        }

        private void comboBox_genero_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_adicionar.Enabled = ValidateForm();
        }

        private void textBox_cc_TextChanged(object sender, EventArgs e)
        {
            button_adicionar.Enabled = ValidateForm();
        }

        private void dateTimePicker_data_nascimento_ValueChanged(object sender, EventArgs e)
        {
            button_adicionar.Enabled = ValidateForm();
        }

        private void textBox_preco_TextChanged(object sender, EventArgs e)
        {
            button_adicionar.Enabled = ValidateForm();
        }

        private void dateTimePicker_data_compra_ValueChanged(object sender, EventArgs e)
        {
            button_adicionar.Enabled = ValidateForm();
        }
    }
}
