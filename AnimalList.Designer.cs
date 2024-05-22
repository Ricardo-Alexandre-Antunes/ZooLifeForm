namespace ZooLifeForm
{
    partial class AnimalList
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NomeAnimal = new System.Windows.Forms.TextBox();
            this.EspecieAnimal = new System.Windows.Forms.TextBox();
            this.DietaAnimal = new System.Windows.Forms.TextBox();
            this.ComprimentoAnimal = new System.Windows.Forms.TextBox();
            this.VeterinarioAnimal = new System.Windows.Forms.TextBox();
            this.ListaRelacionamentos = new System.Windows.Forms.ListBox();
            this.EditarAnimal = new System.Windows.Forms.Button();
            this.RemoverAnimal = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PesoAnimal = new System.Windows.Forms.TextBox();
            this.CorAnimal = new System.Windows.Forms.TextBox();
            this.Cor = new System.Windows.Forms.Label();
            this.escolherZooToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opção1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opção2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opção3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escolherHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escolherHabitáculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 44);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(228, 468);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Espécie";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dieta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Comprimento (m)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Veterinário Responsável";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 333);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Relacionado com:";
            // 
            // NomeAnimal
            // 
            this.NomeAnimal.Enabled = false;
            this.NomeAnimal.Location = new System.Drawing.Point(319, 41);
            this.NomeAnimal.Name = "NomeAnimal";
            this.NomeAnimal.Size = new System.Drawing.Size(542, 22);
            this.NomeAnimal.TabIndex = 11;
            // 
            // EspecieAnimal
            // 
            this.EspecieAnimal.Enabled = false;
            this.EspecieAnimal.Location = new System.Drawing.Point(326, 81);
            this.EspecieAnimal.Name = "EspecieAnimal";
            this.EspecieAnimal.Size = new System.Drawing.Size(535, 22);
            this.EspecieAnimal.TabIndex = 12;
            this.EspecieAnimal.TextChanged += new System.EventHandler(this.EspecieAnimal_TextChanged);
            // 
            // DietaAnimal
            // 
            this.DietaAnimal.Enabled = false;
            this.DietaAnimal.Location = new System.Drawing.Point(307, 119);
            this.DietaAnimal.Name = "DietaAnimal";
            this.DietaAnimal.Size = new System.Drawing.Size(553, 22);
            this.DietaAnimal.TabIndex = 13;
            // 
            // ComprimentoAnimal
            // 
            this.ComprimentoAnimal.Enabled = false;
            this.ComprimentoAnimal.Location = new System.Drawing.Point(378, 199);
            this.ComprimentoAnimal.Name = "ComprimentoAnimal";
            this.ComprimentoAnimal.Size = new System.Drawing.Size(483, 22);
            this.ComprimentoAnimal.TabIndex = 15;
            // 
            // VeterinarioAnimal
            // 
            this.VeterinarioAnimal.Enabled = false;
            this.VeterinarioAnimal.Location = new System.Drawing.Point(425, 243);
            this.VeterinarioAnimal.Name = "VeterinarioAnimal";
            this.VeterinarioAnimal.Size = new System.Drawing.Size(436, 22);
            this.VeterinarioAnimal.TabIndex = 16;
            // 
            // ListaRelacionamentos
            // 
            this.ListaRelacionamentos.FormattingEnabled = true;
            this.ListaRelacionamentos.ItemHeight = 16;
            this.ListaRelacionamentos.Location = new System.Drawing.Point(396, 333);
            this.ListaRelacionamentos.Name = "ListaRelacionamentos";
            this.ListaRelacionamentos.Size = new System.Drawing.Size(465, 100);
            this.ListaRelacionamentos.TabIndex = 18;
            // 
            // EditarAnimal
            // 
            this.EditarAnimal.Location = new System.Drawing.Point(724, 493);
            this.EditarAnimal.Name = "EditarAnimal";
            this.EditarAnimal.Size = new System.Drawing.Size(137, 43);
            this.EditarAnimal.TabIndex = 19;
            this.EditarAnimal.Text = "Editar Animal";
            this.EditarAnimal.UseVisualStyleBackColor = true;
            // 
            // RemoverAnimal
            // 
            this.RemoverAnimal.Location = new System.Drawing.Point(578, 493);
            this.RemoverAnimal.Name = "RemoverAnimal";
            this.RemoverAnimal.Size = new System.Drawing.Size(140, 43);
            this.RemoverAnimal.TabIndex = 20;
            this.RemoverAnimal.Text = "Remover Animal";
            this.RemoverAnimal.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(645, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 27);
            this.button1.TabIndex = 21;
            this.button1.Text = "Gerir Relacionamentos";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Peso (kg)";
            // 
            // PesoAnimal
            // 
            this.PesoAnimal.Enabled = false;
            this.PesoAnimal.Location = new System.Drawing.Point(334, 160);
            this.PesoAnimal.Name = "PesoAnimal";
            this.PesoAnimal.Size = new System.Drawing.Size(527, 22);
            this.PesoAnimal.TabIndex = 14;
            // 
            // CorAnimal
            // 
            this.CorAnimal.Enabled = false;
            this.CorAnimal.Location = new System.Drawing.Point(307, 285);
            this.CorAnimal.Name = "CorAnimal";
            this.CorAnimal.Size = new System.Drawing.Size(553, 22);
            this.CorAnimal.TabIndex = 23;
            // 
            // Cor
            // 
            this.Cor.AutoSize = true;
            this.Cor.Location = new System.Drawing.Point(262, 288);
            this.Cor.Name = "Cor";
            this.Cor.Size = new System.Drawing.Size(28, 16);
            this.Cor.TabIndex = 22;
            this.Cor.Text = "Cor";
            // 
            // escolherZooToolStripMenuItem
            // 
            this.escolherZooToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opção1ToolStripMenuItem,
            this.opção2ToolStripMenuItem,
            this.opção3ToolStripMenuItem});
            this.escolherZooToolStripMenuItem.Name = "escolherZooToolStripMenuItem";
            this.escolherZooToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.escolherZooToolStripMenuItem.Text = "Escolher Zoo";
            // 
            // opção1ToolStripMenuItem
            // 
            this.opção1ToolStripMenuItem.Name = "opção1ToolStripMenuItem";
            this.opção1ToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.opção1ToolStripMenuItem.Text = "Opção 1";
            // 
            // opção2ToolStripMenuItem
            // 
            this.opção2ToolStripMenuItem.Name = "opção2ToolStripMenuItem";
            this.opção2ToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.opção2ToolStripMenuItem.Text = "Opção 2";
            // 
            // opção3ToolStripMenuItem
            // 
            this.opção3ToolStripMenuItem.Name = "opção3ToolStripMenuItem";
            this.opção3ToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.opção3ToolStripMenuItem.Text = "Opção 3";
            // 
            // escolherHToolStripMenuItem
            // 
            this.escolherHToolStripMenuItem.Name = "escolherHToolStripMenuItem";
            this.escolherHToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.escolherHToolStripMenuItem.Text = "Escolher Habitat";
            // 
            // escolherHabitáculoToolStripMenuItem
            // 
            this.escolherHabitáculoToolStripMenuItem.Name = "escolherHabitáculoToolStripMenuItem";
            this.escolherHabitáculoToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.escolherHabitáculoToolStripMenuItem.Text = "Escolher Habitáculo";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escolherZooToolStripMenuItem,
            this.escolherHToolStripMenuItem,
            this.escolherHabitáculoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(877, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AnimalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 548);
            this.Controls.Add(this.CorAnimal);
            this.Controls.Add(this.Cor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RemoverAnimal);
            this.Controls.Add(this.EditarAnimal);
            this.Controls.Add(this.ListaRelacionamentos);
            this.Controls.Add(this.VeterinarioAnimal);
            this.Controls.Add(this.ComprimentoAnimal);
            this.Controls.Add(this.PesoAnimal);
            this.Controls.Add(this.DietaAnimal);
            this.Controls.Add(this.EspecieAnimal);
            this.Controls.Add(this.NomeAnimal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listBox1);
            this.Name = "AnimalList";
            this.Text = "ZooLife - Lista de Animais";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NomeAnimal;
        private System.Windows.Forms.TextBox EspecieAnimal;
        private System.Windows.Forms.TextBox DietaAnimal;
        private System.Windows.Forms.TextBox ComprimentoAnimal;
        private System.Windows.Forms.TextBox VeterinarioAnimal;
        private System.Windows.Forms.ListBox ListaRelacionamentos;
        private System.Windows.Forms.Button EditarAnimal;
        private System.Windows.Forms.Button RemoverAnimal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PesoAnimal;
        private System.Windows.Forms.TextBox CorAnimal;
        private System.Windows.Forms.Label Cor;
        private System.Windows.Forms.ToolStripMenuItem escolherZooToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opção1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opção2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opção3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escolherHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escolherHabitáculoToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}