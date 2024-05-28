namespace ZooLifeForm
{
    partial class Bilhetes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.escolherZooToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escolherBilheteiraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox_bilhetes = new System.Windows.Forms.ListBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_preco = new System.Windows.Forms.Label();
            this.label_data_compra = new System.Windows.Forms.Label();
            this.label_jz = new System.Windows.Forms.Label();
            this.label_bilheteira = new System.Windows.Forms.Label();
            this.label_funcionario_bilheteira = new System.Windows.Forms.Label();
            this.label_nome_visitante = new System.Windows.Forms.Label();
            this.label_genero = new System.Windows.Forms.Label();
            this.label_cc = new System.Windows.Forms.Label();
            this.textBox_jz = new System.Windows.Forms.TextBox();
            this.textBox_bilheteira = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_preco = new System.Windows.Forms.TextBox();
            this.textBox_func_bilheteira = new System.Windows.Forms.TextBox();
            this.textBox_nome_visitante = new System.Windows.Forms.TextBox();
            this.textBox_numero_cc = new System.Windows.Forms.TextBox();
            this.textBox_genero = new System.Windows.Forms.TextBox();
            this.button_adicionar_bilhete = new System.Windows.Forms.Button();
            this.textBox_data_compra = new System.Windows.Forms.TextBox();
            this.button_remover = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escolherZooToolStripMenuItem,
            this.escolherBilheteiraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // escolherZooToolStripMenuItem
            // 
            this.escolherZooToolStripMenuItem.Name = "escolherZooToolStripMenuItem";
            this.escolherZooToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.escolherZooToolStripMenuItem.Text = "Escolher Zoo";
            // 
            // escolherBilheteiraToolStripMenuItem
            // 
            this.escolherBilheteiraToolStripMenuItem.Name = "escolherBilheteiraToolStripMenuItem";
            this.escolherBilheteiraToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.escolherBilheteiraToolStripMenuItem.Text = "Escolher Bilheteira";
            this.escolherBilheteiraToolStripMenuItem.Click += new System.EventHandler(this.escolherBilheteiraToolStripMenuItem_Click);
            // 
            // listBox_bilhetes
            // 
            this.listBox_bilhetes.FormattingEnabled = true;
            this.listBox_bilhetes.ItemHeight = 16;
            this.listBox_bilhetes.Location = new System.Drawing.Point(13, 32);
            this.listBox_bilhetes.Name = "listBox_bilhetes";
            this.listBox_bilhetes.Size = new System.Drawing.Size(150, 404);
            this.listBox_bilhetes.TabIndex = 1;
            this.listBox_bilhetes.Click += new System.EventHandler(this.listBox_bilhetes_SelectedIndexChanged);
            this.listBox_bilhetes.SelectedIndexChanged += new System.EventHandler(this.listBox_bilhetes_SelectedIndexChanged);
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(206, 104);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(20, 16);
            this.label_ID.TabIndex = 2;
            this.label_ID.Text = "ID";
            // 
            // label_preco
            // 
            this.label_preco.AutoSize = true;
            this.label_preco.Location = new System.Drawing.Point(206, 139);
            this.label_preco.Name = "label_preco";
            this.label_preco.Size = new System.Drawing.Size(43, 16);
            this.label_preco.TabIndex = 3;
            this.label_preco.Text = "Preço";
            // 
            // label_data_compra
            // 
            this.label_data_compra.AutoSize = true;
            this.label_data_compra.Location = new System.Drawing.Point(206, 174);
            this.label_data_compra.Name = "label_data_compra";
            this.label_data_compra.Size = new System.Drawing.Size(106, 16);
            this.label_data_compra.TabIndex = 4;
            this.label_data_compra.Text = "Data de Compra";
            // 
            // label_jz
            // 
            this.label_jz.AutoSize = true;
            this.label_jz.Location = new System.Drawing.Point(206, 42);
            this.label_jz.Name = "label_jz";
            this.label_jz.Size = new System.Drawing.Size(112, 16);
            this.label_jz.TabIndex = 5;
            this.label_jz.Text = "Jardim Zoológico";
            // 
            // label_bilheteira
            // 
            this.label_bilheteira.AutoSize = true;
            this.label_bilheteira.Location = new System.Drawing.Point(206, 73);
            this.label_bilheteira.Name = "label_bilheteira";
            this.label_bilheteira.Size = new System.Drawing.Size(63, 16);
            this.label_bilheteira.TabIndex = 6;
            this.label_bilheteira.Text = "Bilheteira";
            // 
            // label_funcionario_bilheteira
            // 
            this.label_funcionario_bilheteira.AutoSize = true;
            this.label_funcionario_bilheteira.Location = new System.Drawing.Point(206, 208);
            this.label_funcionario_bilheteira.Name = "label_funcionario_bilheteira";
            this.label_funcionario_bilheteira.Size = new System.Drawing.Size(155, 16);
            this.label_funcionario_bilheteira.TabIndex = 7;
            this.label_funcionario_bilheteira.Text = "Funcionario de Bilheteira";
            // 
            // label_nome_visitante
            // 
            this.label_nome_visitante.AutoSize = true;
            this.label_nome_visitante.Location = new System.Drawing.Point(206, 243);
            this.label_nome_visitante.Name = "label_nome_visitante";
            this.label_nome_visitante.Size = new System.Drawing.Size(115, 16);
            this.label_nome_visitante.TabIndex = 8;
            this.label_nome_visitante.Text = "Nome de visitante";
            // 
            // label_genero
            // 
            this.label_genero.AutoSize = true;
            this.label_genero.Location = new System.Drawing.Point(206, 320);
            this.label_genero.Name = "label_genero";
            this.label_genero.Size = new System.Drawing.Size(52, 16);
            this.label_genero.TabIndex = 9;
            this.label_genero.Text = "Género";
            // 
            // label_cc
            // 
            this.label_cc.AutoSize = true;
            this.label_cc.Location = new System.Drawing.Point(206, 282);
            this.label_cc.Name = "label_cc";
            this.label_cc.Size = new System.Drawing.Size(191, 16);
            this.label_cc.TabIndex = 10;
            this.label_cc.Text = "Número de Cartão de Cidadão";
            // 
            // textBox_jz
            // 
            this.textBox_jz.Location = new System.Drawing.Point(338, 42);
            this.textBox_jz.Name = "textBox_jz";
            this.textBox_jz.ReadOnly = true;
            this.textBox_jz.Size = new System.Drawing.Size(417, 22);
            this.textBox_jz.TabIndex = 11;
            // 
            // textBox_bilheteira
            // 
            this.textBox_bilheteira.Location = new System.Drawing.Point(297, 73);
            this.textBox_bilheteira.Name = "textBox_bilheteira";
            this.textBox_bilheteira.ReadOnly = true;
            this.textBox_bilheteira.Size = new System.Drawing.Size(458, 22);
            this.textBox_bilheteira.TabIndex = 12;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(246, 101);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Size = new System.Drawing.Size(509, 22);
            this.textBox_ID.TabIndex = 13;
            // 
            // textBox_preco
            // 
            this.textBox_preco.Location = new System.Drawing.Point(265, 139);
            this.textBox_preco.Name = "textBox_preco";
            this.textBox_preco.ReadOnly = true;
            this.textBox_preco.Size = new System.Drawing.Size(490, 22);
            this.textBox_preco.TabIndex = 14;
            // 
            // textBox_func_bilheteira
            // 
            this.textBox_func_bilheteira.Location = new System.Drawing.Point(380, 208);
            this.textBox_func_bilheteira.Name = "textBox_func_bilheteira";
            this.textBox_func_bilheteira.ReadOnly = true;
            this.textBox_func_bilheteira.Size = new System.Drawing.Size(375, 22);
            this.textBox_func_bilheteira.TabIndex = 15;
            // 
            // textBox_nome_visitante
            // 
            this.textBox_nome_visitante.Location = new System.Drawing.Point(338, 243);
            this.textBox_nome_visitante.Name = "textBox_nome_visitante";
            this.textBox_nome_visitante.ReadOnly = true;
            this.textBox_nome_visitante.Size = new System.Drawing.Size(417, 22);
            this.textBox_nome_visitante.TabIndex = 16;
            // 
            // textBox_numero_cc
            // 
            this.textBox_numero_cc.Location = new System.Drawing.Point(418, 279);
            this.textBox_numero_cc.Name = "textBox_numero_cc";
            this.textBox_numero_cc.ReadOnly = true;
            this.textBox_numero_cc.Size = new System.Drawing.Size(337, 22);
            this.textBox_numero_cc.TabIndex = 17;
            // 
            // textBox_genero
            // 
            this.textBox_genero.Location = new System.Drawing.Point(275, 320);
            this.textBox_genero.Name = "textBox_genero";
            this.textBox_genero.ReadOnly = true;
            this.textBox_genero.Size = new System.Drawing.Size(480, 22);
            this.textBox_genero.TabIndex = 18;
            // 
            // button_adicionar_bilhete
            // 
            this.button_adicionar_bilhete.Location = new System.Drawing.Point(577, 398);
            this.button_adicionar_bilhete.Name = "button_adicionar_bilhete";
            this.button_adicionar_bilhete.Size = new System.Drawing.Size(178, 38);
            this.button_adicionar_bilhete.TabIndex = 19;
            this.button_adicionar_bilhete.Text = "Adicionar Bilhete";
            this.button_adicionar_bilhete.UseVisualStyleBackColor = true;
            this.button_adicionar_bilhete.Click += new System.EventHandler(this.button_adicionar_bilhete_Click);
            // 
            // textBox_data_compra
            // 
            this.textBox_data_compra.Location = new System.Drawing.Point(329, 174);
            this.textBox_data_compra.Name = "textBox_data_compra";
            this.textBox_data_compra.ReadOnly = true;
            this.textBox_data_compra.Size = new System.Drawing.Size(426, 22);
            this.textBox_data_compra.TabIndex = 20;
            // 
            // button_remover
            // 
            this.button_remover.Location = new System.Drawing.Point(380, 398);
            this.button_remover.Name = "button_remover";
            this.button_remover.Size = new System.Drawing.Size(171, 37);
            this.button_remover.TabIndex = 21;
            this.button_remover.Text = "Remover Bilhete";
            this.button_remover.UseVisualStyleBackColor = true;
            this.button_remover.Click += new System.EventHandler(this.button_remover_Click);
            // 
            // Bilhetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_remover);
            this.Controls.Add(this.textBox_data_compra);
            this.Controls.Add(this.button_adicionar_bilhete);
            this.Controls.Add(this.textBox_genero);
            this.Controls.Add(this.textBox_numero_cc);
            this.Controls.Add(this.textBox_nome_visitante);
            this.Controls.Add(this.textBox_func_bilheteira);
            this.Controls.Add(this.textBox_preco);
            this.Controls.Add(this.textBox_ID);
            this.Controls.Add(this.textBox_bilheteira);
            this.Controls.Add(this.textBox_jz);
            this.Controls.Add(this.label_cc);
            this.Controls.Add(this.label_genero);
            this.Controls.Add(this.label_nome_visitante);
            this.Controls.Add(this.label_funcionario_bilheteira);
            this.Controls.Add(this.label_bilheteira);
            this.Controls.Add(this.label_jz);
            this.Controls.Add(this.label_data_compra);
            this.Controls.Add(this.label_preco);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.listBox_bilhetes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Bilhetes";
            this.Text = "Bilhetes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bilhetes_Closing);
            this.Load += new System.EventHandler(this.Bilhetes_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem escolherZooToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escolherBilheteiraToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox_bilhetes;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_preco;
        private System.Windows.Forms.Label label_data_compra;
        private System.Windows.Forms.Label label_jz;
        private System.Windows.Forms.Label label_bilheteira;
        private System.Windows.Forms.Label label_funcionario_bilheteira;
        private System.Windows.Forms.Label label_nome_visitante;
        private System.Windows.Forms.Label label_genero;
        private System.Windows.Forms.Label label_cc;
        private System.Windows.Forms.TextBox textBox_jz;
        private System.Windows.Forms.TextBox textBox_bilheteira;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_preco;
        private System.Windows.Forms.TextBox textBox_func_bilheteira;
        private System.Windows.Forms.TextBox textBox_nome_visitante;
        private System.Windows.Forms.TextBox textBox_numero_cc;
        private System.Windows.Forms.TextBox textBox_genero;
        private System.Windows.Forms.Button button_adicionar_bilhete;
        private System.Windows.Forms.TextBox textBox_data_compra;
        private System.Windows.Forms.Button button_remover;
    }
}