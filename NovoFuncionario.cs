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

        public NovoFuncionario(Form prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            this.FormClosing += new FormClosingEventHandler(this.NovoFuncionario_FormClosing);

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

        private void NovoFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }
    }
}
