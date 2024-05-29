using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ZooLifeForm
{
    public partial class NovoFuncionario : Form
    {
        private Form prevForm;
        private SqlConnection cn;
        private string selectedZoo;
        private string selectedRole;
        private string connectionString;

        public NovoFuncionario(Form prevForm, string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.prevForm = prevForm;
            this.FormClosing += new FormClosingEventHandler(this.NovoFuncionario_FormClosing);
            NovoFuncionarioGeneroCombo.Items.Add("M");
            NovoFuncionarioGeneroCombo.Items.Add("F");
            NovoFuncionarioGeneroCombo.SelectedIndex = 0;
            NovoFuncionarioFuncao.Items.Add("Veterinário");
            NovoFuncionarioFuncao.Items.Add("Tratador");
            NovoFuncionarioFuncao.Items.Add("Funcionário de Limpeza");
            NovoFuncionarioFuncao.Items.Add("Segurança");
            NovoFuncionarioFuncao.Items.Add("Funcionário de Bilheteira");
            NovoFuncionarioFuncao.Items.Add("Funcionário de Restauração");
            NovoFuncionarioFuncao.SelectedIndex = 0;
            NovoFuncionarioContratoCombo.Items.Add("Part-Time");
            NovoFuncionarioContratoCombo.Items.Add("Full-Time");
            NovoFuncionarioContratoCombo.SelectedIndex = 0;
            selectedZoo = NovoFuncionarioZoo.Text;
            selectedRole = NovoFuncionarioFuncao.Text;
            PopulateZoos();


        }

        private void PopulateZoos()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM ZOO.JARDIM_ZOOLOGICO", cn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                NovoFuncionarioZoo.Items.Add(reader["Nome"].ToString());
            }

            NovoFuncionarioZoo.SelectedIndex = 0;
            reader.Close();
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

        private bool GeneroCerto()
        {
            return (NovoFuncionarioGeneroCombo.Text.Equals("M") || NovoFuncionarioGeneroCombo.Text.Equals("F"));
        }


        private void CheckValidInput()
        {
            ConfirmarButton.Enabled = true;
            bool goodParse = float.TryParse(NovoFuncionarioSalario.Text, out float result);
            bool goodParse2 = int.TryParse(NovoFuncionarioCC.Text, out int result2);
            if (NovoFuncionarioNome.Text.Equals("") || !goodParse2 || NovoFuncionarioCC.Text.Length != 8 || !GeneroCerto() || NovoFuncionarioFuncao.Text.Equals("") || NovoFuncionarioContratoCombo.Text.Equals("") || !goodParse || result < 740 || NovoFuncionarioInicioContrato.Value > NovoFuncionarioFimContrato.Value || NovoFuncionarioIngresso.Value > NovoFuncionarioInicioContrato.Value)
            {
                ConfirmarButton.Enabled = false;
            }

            if (NovoFuncionarioFuncao.Text.Equals("Funcionário de Bilheteira") || NovoFuncionarioFuncao.Text.Equals("Funcionário de Restauração") || NovoFuncionarioFuncao.Text.Equals("Segurança"))
            {
                NovoFuncionarioRecintos.Visible = true;
                label2.Visible = true;
                if (NovoFuncionarioZoo.Text != selectedZoo || NovoFuncionarioFuncao.Text != selectedRole)
                {
                    selectedZoo = NovoFuncionarioZoo.Text;
                    PopulateRecintos();
                    NovoFuncionarioRecintos.SelectedIndex = 0;
                }
            }

            else
            {
                NovoFuncionarioRecintos.Visible = false;
            }
        }

        private void PopulateRecintos()
        {
            NovoFuncionarioRecintos.Items.Clear();
            if (!verifySGBDConnection())
                return;

            string addQuery = "";
            switch (NovoFuncionarioFuncao.Text)
            {
                case "Funcionário de Bilheteira":
                    addQuery = " INNER JOIN ZOO.BILHETEIRA ON ZOO.RECINTO.ID = ZOO.BILHETEIRA.Recinto_ID";
                    break;
                case "Funcionário de Restauração":
                    addQuery = " INNER JOIN ZOO.RESTAURACAO ON ZOO.RECINTO.ID = ZOO.RESTAURACAO.Recinto_ID";
                    break;
            }

            SqlCommand cmd = new SqlCommand("SELECT ZOO.RECINTO.* FROM ZOO.RECINTO" + addQuery + " WHERE ZOO.RECINTO.Nome_JZ = @Nome_JZ", cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome_JZ", NovoFuncionarioZoo.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                NovoFuncionarioRecintos.Items.Add(reader["ID"].ToString() + ". " + reader["Nome"].ToString());
            }

            reader.Close();
        }

        private void NovoFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {

            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Something went catastrophicly wrong.");
                return;
            }

            string table = "";
            string addParam = "";
            switch (NovoFuncionarioFuncao.Text)
            {
                case "Veterinário":
                    table = "ZOO.sp_adicionarVeterinario";
                    break;
                case "Tratador":
                    table = "ZOO.sp_adicionarTratador";
                    break;
                case "Funcionário de Limpeza":
                    table = "ZOO.sp_adicionarFuncionarioLimpeza";
                    break;
                case "Segurança":
                    table = "ZOO.sp_adicionarSeguranca";
                    addParam = ", @Recinto";
                    break;
                case "Funcionário de Bilheteira":
                    table = "ZOO.sp_adicionarFuncionarioBilheteira";
                    addParam = ", @Recinto";
                    break;
                case "Funcionário de Restauração":
                    table = "ZOO.sp_adicionarFuncionarioRestauracao";
                    addParam = ", @Recinto";
                    break;
            }

            string query = "EXEC " + table + " @CC, @Nome, @Genero, @DataNascimento, @Zoo, @DataIngresso, @TipoContrato, @Salario, @DataInicioContrato, @DataFimContrato" + addParam;
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome", NovoFuncionarioNome.Text);
            cmd.Parameters.AddWithValue("@CC", int.Parse(NovoFuncionarioCC.Text));
            cmd.Parameters.AddWithValue("@Genero", char.Parse(NovoFuncionarioGeneroCombo.Text));
            cmd.Parameters.AddWithValue("@DataNascimento", NovoFuncionarioNascimento.Value);
            cmd.Parameters.AddWithValue("@DataIngresso", NovoFuncionarioIngresso.Value);
            cmd.Parameters.AddWithValue("@Salario", float.Parse(NovoFuncionarioSalario.Text));
            cmd.Parameters.AddWithValue("@DataInicioContrato", NovoFuncionarioInicioContrato.Value);
            cmd.Parameters.AddWithValue("@DataFimContrato", NovoFuncionarioFimContrato.Value);
            cmd.Parameters.AddWithValue("@TipoContrato", NovoFuncionarioContratoCombo.Text);
            cmd.Parameters.AddWithValue("@Zoo", NovoFuncionarioZoo.Text);
            if (addParam != "") {
                cmd.Parameters.AddWithValue("@Recinto", int.Parse(NovoFuncionarioRecintos.Text.Split('.')[0]));
            }
            Console.WriteLine(NovoFuncionarioNome.Text + " | " + int.Parse(NovoFuncionarioCC.Text) + " | " + NovoFuncionarioGeneroCombo.Text + " | " + NovoFuncionarioNascimento.Value + " | " + NovoFuncionarioIngresso.Value + " | " + NovoFuncionarioSalario.Text + " | " + NovoFuncionarioInicioContrato.Value + " | " + NovoFuncionarioFimContrato.Value + " | " + NovoFuncionarioContratoCombo.Text + " | " + NovoFuncionarioZoo.Text + " | " + int.Parse(NovoFuncionarioRecintos.Text.Split('.')[0]));
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Funcionário adicionado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar funcionário: " + ex.Message);
            }
        }

        private void NovoFuncionarioNome_TextChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void NovoFuncionarioCC_TextChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void NovoFuncionarioGeneroCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void NovoFuncionarioNascimento_ValueChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void NovoFuncionarioFuncao_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void NovoFuncionarioIngresso_ValueChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void NovoFuncionarioContratoCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void NovoFuncionarioSalario_TextChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void NovoFuncionarioInicioContrato_ValueChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void NovoFuncionarioFimContrato_ValueChanged(object sender, EventArgs e)
        {
            CheckValidInput();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
