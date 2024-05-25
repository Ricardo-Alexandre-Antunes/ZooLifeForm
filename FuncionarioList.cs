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
    public partial class FuncionarioList : Form
    {
        Form prevForm;
        public FuncionarioList(Form prevForm)
        {
            InitializeComponent();
            this.prevForm = prevForm;
        }

        private void escolherHToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FuncionarioList_Load(object sender, EventArgs e)
        {

        }
    }
}
