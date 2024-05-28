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
    public partial class GerirResponsabilidades : Form
    {
        private Form prevForm;
        private string funcionario;
        private string function;
        private int CC;
        private SqlConnection cn;
        private string currentZoo;
        public GerirResponsabilidades(Form prevForm, string funcionario, int cc, string function, string currentZoo)
        {
            InitializeComponent();
            Console.WriteLine(currentZoo);
            this.prevForm = prevForm;
            this.funcionario = funcionario;
            label1.Text += "\n" + funcionario;
            this.CC = cc;
            this.function = function;
            this.currentZoo = currentZoo;
            PopulateCurResponsibilities();
            PopulateNonResponsibilities();
            if (this.function.Equals("VETERINARIO"))
            {
                label2.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void GerirResponsabilidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.prevForm.Show();
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

        private void PopulateCurResponsibilities()
        {
            ResponsabilidadesAtuais.Items.Clear();
            if (!verifySGBDConnection())
            {
                return;
            }
            string query = "";
            Console.WriteLine(this.function);
            Console.WriteLine(this.CC);
            switch (this.function)
            {
                case ("VETERINARIO"):
                    query = "SELECT * FROM ZOO.ANIMAL WHERE Veterinario_CC = @CC";
                    break;
                case ("TRATADOR"):
                    query = "SELECT * FROM ZOO.RESPONSAVEL_POR_DETALHADO WHERE Numero_CC = @CC";
                    break;
                case ("SEGURANCA"):
                    query = "SELECT * FROM ZOO.SEGURANCA_DETALHADO WHERE Numero_CC = @CC";
                    break;
                case ("FUNCIONARIO_LIMPEZA"):
                    query = "SELECT * FROM ZOO.LIMPA_DETALHADO WHERE Numero_CC = @CC";
                    break;
                case ("TRABALHADOR_RESTAURACAO"):
                    query = "SELECT * FROM ZOO.TRABALHADOR_RESTAURACAO_DETALHADO WHERE Numero_CC = @CC";
                    break;
                case ("FUNCIONARIO_BILHETEIRA"):
                    query = "SELECT ZOO.BILHETEIRA_DETALHADA.* FROM ZOO.FUNCIONARIO_BILHETEIRA INNER JOIN ZOO.BILHETEIRA_DETALHADA ON ZOO.FUNCIONARIO_BILHETEIRA.Bilheteira_ID = ZOO.BILHETEIRA_DETALHADA.ID WHERE F_Numero_CC = @CC";
                    break;
            }

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@CC", this.CC);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                switch (this.function)
                {
                    case ("VETERINARIO"):
                        ResponsabilidadesAtuais.Items.Add(reader["ID"] + ". " +reader["Nome"].ToString());
                        break;
                    case ("TRATADOR"):
                        ResponsabilidadesAtuais.Items.Add(reader["RECINTO_ID"] + ". " + reader["RECINTO_NOME"].ToString());
                        break;
                    case ("SEGURANCA"):
                        ResponsabilidadesAtuais.Items.Add(reader["RECINTO_ID"] + ". " + reader["RECINTO_NOME"].ToString());
                        break;
                    case ("FUNCIONARIO_LIMPEZA"):
                        ResponsabilidadesAtuais.Items.Add(reader["ID"] + ". " + reader["Nome_Recinto"].ToString());
                        break;
                    case ("TRABALHADOR_RESTAURACAO"):
                        ResponsabilidadesAtuais.Items.Add(reader["RECINTO_ID"] + ". " + reader["RECINTO_NOME"].ToString());
                        break;
                    case ("FUNCIONARIO_BILHETEIRA"):
                        ResponsabilidadesAtuais.Items.Add(reader["ID"] + ". " + reader["Nome"].ToString());
                        break;
                }
            }
            reader.Close();

        }  

        private void PopulateNonResponsibilities()
        {
            ResponsabilidadesPossiveis.Items.Clear();
            if (!verifySGBDConnection())
            {
                return;
            }

            string query = "";
            switch (this.function)
            {
                case ("VETERINARIO"):
                    query = "SELECT * FROM ZOO.ANIMAL WHERE ZOO.ANIMAL.Nome_JZ = @NomeJZ and Veterinario_CC <> @CC";
                    break;
                case ("TRATADOR"):
                    query = "SELECT * FROM ZOO.TRATADOR_DISPONIVEIS(@CC, @NomeJZ)";
                    break;
                case ("SEGURANCA"):
                    query = "SELECT * FROM ZOO.SEGURANCA_DISPONIVEIS(@CC, @NomeJZ)";
                    break;
                case ("FUNCIONARIO_LIMPEZA"):
                    query = "SELECT * FROM ZOO.FUNCIONARIO_LIMPEZA_DISPONIVEIS(@CC, @NomeJZ)";
                    break;
                case ("TRABALHADOR_RESTAURACAO"):
                    query = "SELECT * FROM ZOO.TRABALHADOR_RESTAURACAO_DISPONIVEIS(@CC, @NomeJZ)";
                    break;
                case ("FUNCIONARIO_BILHETEIRA"):
                    query = "SELECT * FROM ZOO.FUNCIONARIO_BILHETEIRAS_DISPONIVEIS(@CC, @NomeJZ)";
                    break;
            }

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@CC", this.CC);
            cmd.Parameters.AddWithValue("@NomeJZ", this.currentZoo);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ResponsabilidadesPossiveis.Items.Add(reader["ID"] + ". " + reader["Nome"].ToString());
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }

            if (ResponsabilidadesPossiveis.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor selecione uma responsabilidade para adicionar.");
                return;
            }

            string query = "";
 

            switch (this.function)
            {
                case ("TRATADOR"):
                    query = "INSERT INTO ZOO.RESPONSAVEL_POR VALUES (@CC, @NomeJZ, @RecintoID)";

                    break;
                case ("SEGURANCA"):
                    if (MessageBox.Show("Ao adicionar este recinto como responsabilidade, o recinto anterior passará a não ser patrulhado por este segurança. Tem a certeza que deseja continuar?", "Tem a certeza?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    query = "UPDATE ZOO.SEGURANCA SET Recinto_ID = @RecintoID WHERE F_Numero_CC = @CC ";
                    break;
                case ("FUNCIONARIO_LIMPEZA"):
                    query = "INSERT INTO ZOO.LIMPA VALUES (@NomeJZ, @RecintoID, @CC)";
                    break;
                case ("TRABALHADOR_RESTAURACAO"):
                    if (MessageBox.Show("Ao adicionar este recinto como responsabilidade, este trabalhador deixará de trabalhar no restaurante atual. Tem a certeza que deseja continuar?", "Tem a certeza?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    query = "UPDATE ZOO.TRABALHADOR_RESTAURACAO SET Restauracao_ID = @RecintoID WHERE F_Numero_CC = @CC";
                    break;
                case ("FUNCIONARIO_BILHETEIRA"):
                    if (MessageBox.Show(Text = "Ao adicionar esta bilheteira como responsabilidade, este funcionário deixará de trabalhar na bilheteira atual. Tem a certeza que deseja continuar?", "Tem a certeza?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                    query = "UPDATE ZOO.FUNCIONARIO_BILHETEIRA SET Bilheteira_ID = @RecintoID WHERE F_Numero_CC = @CC";
                    break;
            }
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@RecintoID", int.Parse(ResponsabilidadesPossiveis.Text.ToString().Split('.')[0]));
            Console.WriteLine(int.Parse(ResponsabilidadesPossiveis.Text.ToString().Split('.')[0]));
            cmd.Parameters.AddWithValue("@CC", this.CC);
            cmd.Parameters.AddWithValue("@NomeJZ", this.currentZoo);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            PopulateCurResponsibilities();
            PopulateNonResponsibilities();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                return;
            }

            if (ResponsabilidadesAtuais.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor selecione uma responsabilidade para remover.");
                return;
            }

            string query = "";

            switch (this.function)
            {
                case ("TRATADOR"):
                    query = "DELETE FROM ZOO.RESPONSAVEL_POR WHERE T_Numero_CC = @CC and Habitat_ID = @RecintoID";
                    break;
                case ("SEGURANCA"):
                    query = "UPDATE ZOO.SEGURANCA SET Recinto_ID = NULL WHERE F_Numero_CC = @CC";
                    break;
                case ("FUNCIONARIO_LIMPEZA"):
                    query = "DELETE FROM ZOO.LIMPA WHERE FL_Numero_CC = @CC and Recinto_ID = @RecintoID";
                    break;
                case ("TRABALHADOR_RESTAURACAO"):
                    query = "UPDATE ZOO.TRABALHADOR_RESTAURACAO SET Restauracao_ID = NULL WHERE F_Numero_CC = @CC";
                    break;
                case ("FUNCIONARIO_BILHETEIRA"):
                    query = "UPDATE ZOO.FUNCIONARIO_BILHETEIRA SET Bilheteira_ID = NULL WHERE F_Numero_CC = @CC";
                    break;
            }

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@RecintoID", int.Parse(ResponsabilidadesAtuais.Text.ToString().Split('.')[0]));
            cmd.Parameters.AddWithValue("@CC", this.CC);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            PopulateCurResponsibilities();
            PopulateNonResponsibilities();

        }
    }
}
