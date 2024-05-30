using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooLifeForm
{
    public partial class FuncionarioList : Form
    {
        Form prevForm;
        SqlConnection cn;
        string selectedZoo;
        int[] funcionarios_CC = new int[900];
        int selectedFuncionario;
        string selectedRole;
        Boolean toggle = false;
        string editingName;
        string editingGenero;
        string editingDataNascimento;
        string editingInicioContrato;
        string editingFimContrato;
        string editingSalario;
        string editingTipoContrato;
        string editingBoss;
        Boolean editing;
        List<String> orderingQueries = new List<String>();
        string generoFilter;
        string nomeFilter;
        string connectionString;



        public FuncionarioList(string selectedZoo, Form prevForm, string connectionString)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            this.selectedZoo = selectedZoo;
            this.selectedRole = "";
            this.generoFilter = "";
            this.nomeFilter = "";
            this.connectionString = connectionString;
            this.Text = "ZooLife - Lista de Funcionários (" + selectedZoo + ")";
            this.FormClosing += new FormClosingEventHandler(this.FuncionarioList_FormClosing);
            PopulateFuncionarios();
            ListaFuncionarios.SelectedIndex = 0;
            PopulateZoo();
            gerenteToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            tratadorToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            veterinárioToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            funcionárioDeBilheteiraToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            funcionárioDeLimpezaToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            funcionárioDeBilheteiraToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            segurançaToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);
            funcionárioDeRestauraçãoToolStripMenuItem.Click += new EventHandler(escolherHToolStripMenuItem_Click);

        }

        private void FuncionarioList_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
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

        private void PopulateFuncionarios()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Funcionarios could not be loaded.");
                return;
            }

            ListaFuncionarios.Items.Clear();

            string query = "SELECT Numero_CC, Num_Funcionario, Nome, Role FROM ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO WHERE ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Nome_JZ = @Nome_JZ";
            if (selectedRole != "")
            {
                query += " AND ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Role = @Role";
            }
            if (generoFilter != "")
            {
                query += generoFilter;
            }
            if (nomeFilter != "")
            {
                query += nomeFilter;
            }
            if (orderingQueries.Count > 0)
            {
                query += " ORDER BY ";
                for (int i = 0; i < orderingQueries.Count; i++)
                {
                    query += orderingQueries[i];
                    if (i != orderingQueries.Count - 1)
                    {
                        query += ", ";
                    }
                }
            }
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Nome_JZ", this.selectedZoo);
            if (selectedRole != "")
            {
                cmd.Parameters.AddWithValue("@Role", selectedRole);
            }

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListaFuncionarios.Items.Add(reader["Num_Funcionario"] + ". " + reader["Nome"]);
                        funcionarios_CC[int.Parse(reader["Num_Funcionario"].ToString())] = int.Parse(reader["Numero_CC"].ToString());
                    }
                }
                if (ListaFuncionarios.Items.Count > 0)
                {
                    ListaFuncionarios.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve Funcionarios. \n ERROR MESSAGE: \n" + ex.Message);
            }
        }

        private void PopulateZoo()
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Zoo names could not be loaded.");
                return;
            }

            escolherZooToolStripMenuItem.DropDownItems.Clear();

            string query = "SELECT Nome FROM ZOO.JARDIM_ZOOLOGICO";
            SqlCommand cmd = new SqlCommand(query, cn);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string zooName = reader.GetString(0);
                        ToolStripMenuItem menuItem = new ToolStripMenuItem(zooName);
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

        

        private void menuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            selectedZoo = clickedItem.Text;
            selectedRole = "";
            PopulateFuncionarios();
            this.Text = "ZooLife - Lista de Funcionários (" + selectedZoo + ")";
        }

        private void escolherHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toggle all details to false
            label2.Visible = false;
            ListaResponsabilidades.Visible = false;
            GerirResponsabilidades.Visible = false;
            label6.Visible = false;
            comboBox1.Visible = false;
            label7.Visible = true;
            this.toggle = false;
            button4.Text = "Mais Detalhes";

            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            selectedRole = clickedItem.Text;
            switch (clickedItem.Text)
            {
                case "Gerente":
                    selectedRole = "GERENTE";
                    break;
                case "Tratador":
                    selectedRole = "TRATADOR";
                    break;
                case "Veterinário":
                    selectedRole = "VETERINARIO";
                    break;
                case "Funcionário de Bilheteira":
                    selectedRole = "FUNCIONARIO_BILHETEIRA";
                    break;
                case "Funcionário de Limpeza":
                    selectedRole = "FUNCIONARIO_LIMPEZA";
                    break;
                case "Segurança":
                    selectedRole = "SEGURANCA";
                    break;
                case "Funcionário de Restauração":
                    selectedRole = "TRABALHADOR_RESTAURACAO";
                    break;
            }
            PopulateFuncionarios();
            this.Text = "ZooLife - Lista de Funcionários (" + selectedZoo + ((this.selectedRole != "") ? " - " + this.selectedRole : "") + ")";
        }




        private void FuncionarioList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //toggle all details to false
            label2.Visible = false;
            ListaResponsabilidades.Visible = false;
            GerirResponsabilidades.Visible = false;
            label6.Visible = false;
            comboBox1.Visible = false;
            label7.Visible = true;
            this.toggle = false;
            button4.Text = "Mais Detalhes";
            this.selectedFuncionario = funcionarios_CC[int.Parse(ListaFuncionarios.Text.Split('.')[0])];
            int CC = funcionarios_CC[int.Parse(ListaFuncionarios.Text.Split('.')[0])];
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Funcionario could not be loaded.");
                return;
            }
            string query = "SELECT * FROM ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO WHERE ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Numero_CC = @CC";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@CC", CC);


            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())

                {
                    while (reader.Read())
                    {
                        NomeFuncionario.Text = reader["Nome"].ToString();
                        NumeroCCFuncionario.Text = reader["Numero_CC"].ToString();
                        GeneroFuncionario.Text = reader["Genero"].ToString();
                        NumeroFuncionario.Text = reader["Num_Funcionario"].ToString();
                        DataNascimentoPicker.Value = Convert.ToDateTime(reader["Data_Nascimento"].ToString());
                        InicioContratoPicker.Value = Convert.ToDateTime(reader["Data_inicio_contrato"].ToString());
                        FimContratoPicker.Value = Convert.ToDateTime(reader["Data_fim_contrato"].ToString());
                        DataIngressoPicker.Value = Convert.ToDateTime(reader["Data_ingresso"].ToString());
                        ContratoSalario.Text = reader["Salario"].ToString();
                        FuncaoFuncionario.Text = reader["Role"].ToString();
                        if (FuncaoFuncionario.Text == "GERENTE")
                        {
                            button4.Visible = false;
                        }
                        else
                        {
                            button4.Visible = true;
                        }
                        ContratoTipo.Text = reader["Tipo_contrato"].ToString();

                    }
                }
                if (FuncaoFuncionario.Text == "TRATADOR" || FuncaoFuncionario.Text == "VETERINARIO" || FuncaoFuncionario.Text == "SEGURANCA")
                {
                    PopulateResponsibilities(CC, FuncaoFuncionario.Text);
                    PopulateComboBoxBoss(FuncaoFuncionario.Text);
                    DetermineCurBoss(CC);
                    label6.Visible = true;
                    comboBox1.Visible = true;
                }

                if (FuncaoFuncionario.Text == "FUNCIONARIO_LIMPEZA" || FuncaoFuncionario.Text == "TRABALHADOR_RESTAURACAO" || FuncaoFuncionario.Text == "FUNCIONARIO_BILHETEIRA")
                {
                    PopulateResponsibilities(CC, FuncaoFuncionario.Text);
                    label6.Visible = false;
                    comboBox1.Visible = false;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve Funcionario. \n ERROR MESSAGE: \n" + ex.Message);
            }
        }

        private void DetermineCurBoss(int numeroCC)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Boss could not be loaded.");
                return;
            }
            comboBox1.Text = "";
            string query = "SELECT Num_Funcionario, Nome FROM ZOO.DETALHES_GERENTE(@CC)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@CC", numeroCC);
            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string bossName = reader["Num_Funcionario"] + ". " + reader["Nome"];
                        comboBox1.Text = bossName;
                    }
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving boss: " + ex.Message);
            }
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Supervisor Atual";
            }
        }

        private void PopulateResponsibilities(int numeroCC, string role)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Responsibilities could not be loaded.");
                return;
            }

            ListaResponsabilidades.Items.Clear();
            string query;
            switch (role)
            {
                case "TRATADOR":
                    query = "SELECT * FROM ZOO.RESPONSAVEL_POR_DETALHADO WHERE Numero_CC = @CC";
                    label2.Text = "Habitats designados";
                    break;
                case "VETERINARIO":
                    query = "SELECT * FROM ZOO.ANIMAL WHERE Veterinario_CC = @CC";
                    label2.Text = "Animais designados";
                    break;
                case "FUNCIONARIO_BILHETEIRA":
                    query = "SELECT ZOO.BILHETEIRA_DETALHADA.* FROM ZOO.FUNCIONARIO_BILHETEIRA INNER JOIN ZOO.BILHETEIRA_DETALHADA ON ZOO.FUNCIONARIO_BILHETEIRA.Bilheteira_ID = ZOO.BILHETEIRA_DETALHADA.ID WHERE F_Numero_CC = @CC";
                    label2.Text = "Bilheteira designada";
                    break;
                case "FUNCIONARIO_LIMPEZA":
                    query = "SELECT * FROM ZOO.LIMPA_DETALHADO WHERE ZOO.LIMPA_DETALHADO.Numero_CC = @CC";
                    label2.Text = "Zonas de limpeza";
                    break;
                case "SEGURANCA":
                    query = "SELECT * FROM ZOO.SEGURANCA_DETALHADO WHERE ZOO.SEGURANCA_DETALHADO.Numero_CC = @CC";
                    label2.Text = "Patrulha";
                    break;
                case "TRABALHADOR_RESTAURACAO":
                    query = "SELECT * FROM ZOO.TRABALHADOR_RESTAURACAO_DETALHADO WHERE Numero_CC = @CC";
                    Console.WriteLine(this.selectedFuncionario);
                    label2.Text = "Restaurante designado";
                    break;
                default:
                    query = "";
                    break;
            }
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@CC", this.selectedFuncionario);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        switch (role)
                        {
                            case "TRATADOR":
                                ListaResponsabilidades.Items.Add(reader["RECINTO_ID"].ToString() + ". " + reader["RECINTO_NOME"].ToString());
                                break;
                            case "VETERINARIO":
                                ListaResponsabilidades.Items.Add(reader["ID"].ToString() + ". " + reader["Nome"].ToString());
                                break;
                            case "FUNCIONARIO_BILHETEIRA":
                                ListaResponsabilidades.Items.Add(reader["ID"].ToString() + ". " + reader["Nome"].ToString());
                                break;
                            case "FUNCIONARIO_LIMPEZA":
                                ListaResponsabilidades.Items.Add(reader["ID"].ToString() + ". " + reader["Nome_Recinto"].ToString());
                                break;
                            case "SEGURANCA":
                                ListaResponsabilidades.Items.Add(reader["RECINTO_ID"].ToString() + ". " + reader["RECINTO_NOME"].ToString());
                                break;
                            case "TRABALHADOR_RESTAURACAO":
                                ListaResponsabilidades.Items.Add(reader["RECINTO_ID"].ToString() + ". " + reader["RECINTO_NOME"].ToString());
                                break;
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve Responsibilities. \n ERROR MESSAGE: \n" + ex.Message);
            }
        }   

        private void PopulateComboBoxBoss(string role)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Bosses could not be loaded.");
                return;
            }

            comboBox1.Items.Clear();
            string query = "SELECT ZOO.PESSOA.*, ZOO.FUNCIONARIO.Num_Funcionario, ZOO.FUNCIONARIO.Nome_JZ FROM ZOO.PESSOA INNER JOIN ";
            switch (role)
            {
                case ("TRATADOR"):
                    query += "ZOO.TRATADOR ON ZOO.PESSOA.Numero_CC = ZOO.TRATADOR.F_Numero_CC ";
                    break;
                case ("VETERINARIO"):
                    query += "ZOO.VETERINARIO ON ZOO.PESSOA.Numero_CC = ZOO.VETERINARIO.F_Numero_CC ";
                    break;
                case ("SEGURANCA"):
                    query += "ZOO.SEGURANCA ON ZOO.PESSOA.Numero_CC = ZOO.SEGURANCA.F_Numero_CC ";
                    break;
            }

            query += "INNER JOIN ZOO.FUNCIONARIO ON ZOO.PESSOA.Numero_CC = ZOO.FUNCIONARIO.Numero_CC WHERE ZOO.FUNCIONARIO.Nome_JZ = @JZ";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@JZ", selectedZoo);

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string bossName = reader["Num_Funcionario"] + ". " + reader["Nome"];
                        comboBox1.Items.Add(bossName);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error retrieving bosses: " + ex.Message);
            }
        }

        private void AdicionarFuncionario_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Funcionario could not be added.");
                return;
            }


        }

        private void RemoverFuncionario_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Funcionario could not be removed.");
                return;
            }

            if (ListaFuncionarios.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Funcionario to remove.");
                return;
            }

            string[] funcionario = ListaFuncionarios.SelectedItem.ToString().Split('-');
            int funcionarioID = Int32.Parse(funcionario[0].Trim());

            string query = "DELETE FROM ZOO.Funcionario WHERE ID = @funcionarioID AND Nome_JZ = @NomeJZ";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@funcionarioID", funcionarioID);
            cmd.Parameters.AddWithValue("@NomeJZ", selectedZoo);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Funcionario removed successfully.");
                PopulateFuncionarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to remove Funcionario. \n ERROR MESSAGE: \n" + ex.Message);
            }
        }


        private void FuncionarioList_Load(object sender, EventArgs e)
        {

        }


        private void ContratoSalário_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            toggle = !toggle;
            if (toggle) {
                if (FuncaoFuncionario.Text == "FUNCIONARIO_LIMPEZA" || FuncaoFuncionario.Text == "TRABALHADOR_RESTAURACAO" || FuncaoFuncionario.Text == "FUNCIONARIO_BILHETEIRA" || FuncaoFuncionario.Text == "TRATADOR" || FuncaoFuncionario.Text == "VETERINARIO" || FuncaoFuncionario.Text == "SEGURANCA")
                {
                    label2.Visible = toggle;
                    ListaResponsabilidades.Visible = toggle;
                    GerirResponsabilidades.Visible = toggle;
                    label7.Visible = !toggle;
                    
                }
                editing = true;
                button4.Text = "Menos Detalhes";
            }
            else
            {
                label2.Visible = toggle;
                ListaResponsabilidades.Visible = toggle;
                GerirResponsabilidades.Visible = toggle;
                label7.Visible = !toggle;
                editing = false;
                button4.Text = "Mais Detalhes";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //enable writiing on everything
            NomeFuncionario.ReadOnly = false;
            GeneroFuncionario.ReadOnly = false;
            DataNascimentoPicker.Enabled = true;
            InicioContratoPicker.Enabled = true;
            FimContratoPicker.Enabled = true;
            ContratoSalario.ReadOnly = false;
            ContratoTipo.ReadOnly = false;
            comboBox1.Enabled = true;
            button3.Visible = false;
            CancelarEdicao.Visible = true;
            ConfirmarEdicao.Visible = true;
            ListaFuncionarios.Enabled = false;

            //store temp values
            editingName = NomeFuncionario.Text;
            editingGenero = GeneroFuncionario.Text;
            editingDataNascimento = DataNascimentoPicker.Value.ToString();
            editingInicioContrato = InicioContratoPicker.Value.ToString();
            editingFimContrato = FimContratoPicker.Value.ToString();
            editingSalario = ContratoSalario.Text;
            editingTipoContrato = ContratoTipo.Text;
            editingBoss = comboBox1.Text;


        }

        private void checkValidEdit()
        {

            ConfirmarEdicao.Enabled = true;
            if (NomeFuncionario.Text == "" || GeneroFuncionario.Text == "" || ContratoSalario.Text == "" || ContratoTipo.Text == "" || comboBox1.Text == "" || (GeneroFuncionario.Text != "M" && GeneroFuncionario.Text != "F"))
            {
                ConfirmarEdicao.Enabled = false;
            }
            

            try
            {
                if (float.Parse(ContratoSalario.Text) < 0)
                {
                    ConfirmarEdicao.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ConfirmarEdicao.Enabled = false;
            }

            if (DataNascimentoPicker.Value > DateTime.Now || FimContratoPicker.Value < InicioContratoPicker.Value || DataNascimentoPicker.Value > InicioContratoPicker.Value)
            {
                ConfirmarEdicao.Enabled = false;
            }
        }


        private void CancelarEdicao_Click(object sender, EventArgs e)
        {
            //disable writing on everything
            NomeFuncionario.ReadOnly = true;
            GeneroFuncionario.ReadOnly = true;
            DataNascimentoPicker.Enabled = false;
            InicioContratoPicker.Enabled = false;
            FimContratoPicker.Enabled = false;
            ContratoSalario.ReadOnly = true;
            ContratoTipo.ReadOnly = true;
            comboBox1.Enabled = false;
            button3.Visible = true;
            CancelarEdicao.Visible = false;
            ConfirmarEdicao.Visible = false;
            ListaFuncionarios.Enabled = true;
            comboBox1.Enabled = false;

            //reset values
            NomeFuncionario.Text = editingName;
            GeneroFuncionario.Text = editingGenero;
            DataNascimentoPicker.Value = Convert.ToDateTime(editingDataNascimento);
            InicioContratoPicker.Value = Convert.ToDateTime(editingInicioContrato);
            FimContratoPicker.Value = Convert.ToDateTime(editingFimContrato);
            ContratoSalario.Text = editingSalario;
            ContratoTipo.Text = editingTipoContrato;
            comboBox1.Text = editingBoss;

        }

        private void ListaResponsabilidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmarEdicao_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Failed to connect to database. Funcionario could not be edited.");
                return;
            }

            string query = "EXEC ZOO.sp_editarFuncionario @Numero_CC, @Nome, @Genero, @Data_nascimento, @Data_ingresso, @Tipo_contrato, @Salario, @Data_inicio_contrato, @Data_fim_contrato";
            if (comboBox1.Visible)
            {
                Console.WriteLine("Supervisor: " + comboBox1.Text);
                query += ", @Supervisor";
            }
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@Numero_CC", int.Parse(NumeroCCFuncionario.Text));
            cmd.Parameters.AddWithValue("@Nome", NomeFuncionario.Text);
            cmd.Parameters.AddWithValue("@Genero", char.Parse(GeneroFuncionario.Text));
            cmd.Parameters.AddWithValue("@Data_nascimento", DataNascimentoPicker.Value);
            cmd.Parameters.AddWithValue("@Data_ingresso", InicioContratoPicker.Value);
            cmd.Parameters.AddWithValue("@Tipo_contrato", ContratoTipo.Text);
            cmd.Parameters.AddWithValue("@Salario", float.Parse(ContratoSalario.Text));
            cmd.Parameters.AddWithValue("@Data_inicio_contrato", InicioContratoPicker.Value);
            cmd.Parameters.AddWithValue("@Data_fim_contrato", FimContratoPicker.Value);
            string[] boss = comboBox1.Text.Split('.');
            if (comboBox1.Visible && !comboBox1.Text.Equals("Supervisor Atual"))
            {
                Console.WriteLine("Supervisor: " + funcionarios_CC[int.Parse(boss[0])]);
                cmd.Parameters.AddWithValue("@Supervisor", funcionarios_CC[int.Parse(boss[0])]);
            }
            cmd.ExecuteNonQuery();

            MessageBox.Show("Funcionario edited successfully.");
            PopulateFuncionarios();
            //disable writing on everything
            NomeFuncionario.ReadOnly = true;
            GeneroFuncionario.ReadOnly = true;
            DataNascimentoPicker.Enabled = false;
            InicioContratoPicker.Enabled = false;
            FimContratoPicker.Enabled = false;
            ContratoSalario.ReadOnly = true;
            ContratoTipo.ReadOnly = true;
            comboBox1.Enabled = false;
            button3.Visible = true;
            CancelarEdicao.Visible = false;
            ConfirmarEdicao.Visible = false;
            ListaFuncionarios.Enabled = true;
            comboBox1.Enabled = false;

        }

        private void NomeFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (editing)
            {
                checkValidEdit();
            }
        }

        private void NumeroCCFuncionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void GeneroFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (editing)
            {
                checkValidEdit();
            }
        }

        private void DataNascimentoPicker_ValueChanged(object sender, EventArgs e)
        {
            if (editing)
            {
                checkValidEdit();
            }
        }

        private void FuncaoFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (editing)
            {
                checkValidEdit();
            }
        }

        private void NumeroFuncionario_TextChanged(object sender, EventArgs e)
        {
            if (editing)
            {
                checkValidEdit();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editing)
            {
                checkValidEdit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // User clicked "OK"
                if (!verifySGBDConnection())
                {
                    MessageBox.Show("Failed to connect to database. Funcionario could not be added.");
                    return;
                }

                string query = "EXEC ZOO.sp_eliminarFuncionario @Numero_CC";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Numero_CC", int.Parse(NumeroCCFuncionario.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Funcionario removido com sucesso.");
                PopulateFuncionarios();

                //put all fields in blank
                NomeFuncionario.Text = "";
                GeneroFuncionario.Text = "";
                DataNascimentoPicker.Value = DateTime.Now;
                InicioContratoPicker.Value = DateTime.Now;
                FimContratoPicker.Value = DateTime.Now;
                DataIngressoPicker.Value = DateTime.Now;
                ContratoSalario.Text = "";
                ContratoTipo.Text = "";
                comboBox1.Text = "";
                ListaFuncionarios.SelectedIndex = 0;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NovoFuncionario novoFuncionario = new NovoFuncionario(this, this.connectionString);
            novoFuncionario.Show();
            this.Hide();
        }

        private void GerirResponsabilidades_Click(object sender, EventArgs e)
        {
            GerirResponsabilidades responsabilidades = new GerirResponsabilidades(this, ListaFuncionarios.Text, this.selectedFuncionario, this.FuncaoFuncionario.Text, this.selectedZoo, this.connectionString);
            responsabilidades.Show();
            this.Hide();
        }

        private void ordemAscendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordemDescendenteToolStripMenuItem.Checked = false;
            if (ordemAscendenteToolStripMenuItem.Checked)
            {
                orderingQueries.Add("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Salario ASC");
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Salario DESC");
            }
            else
            {
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Salario ASC");
            }
            PopulateFuncionarios();
        }

        private void ordemDescendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordemAscendenteToolStripMenuItem.Checked = false;
            if (ordemDescendenteToolStripMenuItem.Checked)
            {
                orderingQueries.Add("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Salario DESC");
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Salario ASC");
            }
            else
            {
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Salario DESC");
            }
            PopulateFuncionarios();
        }

        private void ordemCrescenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordemDescendenteToolStripMenuItem.Checked = false;
            if (ordemCrescenteToolStripMenuItem.Checked)
            {
                orderingQueries.Add("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_nascimento ASC");
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_nascimento DESC");
            }
            else
            {
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_nascimento ASC");
            }
            PopulateFuncionarios();
        }

        private void ordemDecrescenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordemCrescenteToolStripMenuItem.Checked = false;
            if (ordemDecrescenteToolStripMenuItem.Checked)
            {
                orderingQueries.Add("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_nascimento DESC");
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_nascimento ASC");
            }
            else
            {
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_nascimento DESC");
            }
            PopulateFuncionarios();
        }

        private void ordemCrescenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ordemDecrescenteToolStripMenuItem1.Checked = false;
            if (ordemCrescenteToolStripMenuItem1.Checked)
            {
                orderingQueries.Add("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_ingresso ASC");
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_ingresso DESC");
            }
            else
            {
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_ingresso ASC");
            }
            PopulateFuncionarios();
        }

        private void ordemDecrescenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ordemCrescenteToolStripMenuItem1.Checked = false;
            if (ordemDecrescenteToolStripMenuItem1.Checked)
            {
                orderingQueries.Add("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_ingresso DESC");
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_ingresso ASC");
            }
            else
            {
                orderingQueries.Remove("ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Data_ingresso DESC");
            }
            PopulateFuncionarios();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fToolStripMenuItem.Checked = false;
            if (mToolStripMenuItem.Checked)
            {
                generoFilter = " and ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Genero = 'M'";
            }
            else
            {
                generoFilter = "";
            }
            PopulateFuncionarios();
        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mToolStripMenuItem.Checked = false;
            if (fToolStripMenuItem.Checked)
            {
                generoFilter = " and ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Genero = 'F'";
            }
            else
            {
                generoFilter = "";
            }
            PopulateFuncionarios();
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                nomeFilter = " and ZOO.FUNCIONARIO_DETALHADO_TOTAL_CONTRATO.Nome like '%" + toolStripTextBox1.Text + "%'";
                PopulateFuncionarios();
            }

        }
    }
}
