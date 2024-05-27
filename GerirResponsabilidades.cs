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
        public GerirResponsabilidades(Form prevForm, string funcionario, int cc, string function)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            this.funcionario = funcionario;
            label1.Text += funcionario;
            this.CC = cc;
            this.function = function;
            PopulateCurResponsibilities();

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
                case ("FUNCIONARIO_RESTAURACAO"):
                    query = "SELECT * FROM ZOO.FUNCIONARIO_RESTAURACAO WHERE Numero_CC = @CC";
                    break;
                case ("FUNCIONARIO_BILHETEIRA"):
                    query = "SELECT * FROM ZOO.FUNCIONARIO_BILHETEIRA INNER JOIN ZOO.BILHETEIRA_DETALHADA WHERE F_Numero_CC = @CC";
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
                    case ("FUNCIONARIO_RESTAURACAO"):
                        ResponsabilidadesAtuais.Items.Add(reader["RECINTO_ID"] + ". " + reader["RECINTO_NOME"].ToString());
                        break;
                    case ("FUNCIONARIO_BILHETEIRA"):
                        ResponsabilidadesAtuais.Items.Add(reader["ID"] + ". " + reader["Nome"].ToString());
                        break;
                }
            }

        }  
    }
}
