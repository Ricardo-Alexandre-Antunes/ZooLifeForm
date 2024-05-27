using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooLifeForm
{
    public partial class NovoFuncionario : Form
    {
        Form prevForm;
        public NovoFuncionario(Form prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
            this.FormClosing += new FormClosingEventHandler(this.NovoFuncionario_FormClosing);
        }

        private void NovoFuncionario_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }
    }
}
