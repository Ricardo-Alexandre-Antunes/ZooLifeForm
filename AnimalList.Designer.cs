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
            this.ListaRelacionamentos = new System.Windows.Forms.ListBox();
            this.EditarAnimal = new System.Windows.Forms.Button();
            this.RemoverAnimal = new System.Windows.Forms.Button();
            this.GerirRelacoes = new System.Windows.Forms.Button();
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
            this.AdicionarAnimal = new System.Windows.Forms.Button();
            this.VeterinarioAnimal = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.GrupoTaxonomicoText = new System.Windows.Forms.TextBox();
            this.TransferenciaCancelar = new System.Windows.Forms.Button();
            this.EditarConfirmar = new System.Windows.Forms.Button();
            this.AnimalTransferir = new System.Windows.Forms.Button();
            this.TransferenciaConfirmar = new System.Windows.Forms.Button();
            this.ZooAtual = new System.Windows.Forms.Label();
            this.ZooCombo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.HabitatCombo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.HabitaculoCombo = new System.Windows.Forms.ComboBox();
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
            this.label2.Location = new System.Drawing.Point(263, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Espécie";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dieta";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Comprimento (m)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Veterinário Responsável";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Relacionado com:";
            // 
            // NomeAnimal
            // 
            this.NomeAnimal.Location = new System.Drawing.Point(319, 41);
            this.NomeAnimal.Name = "NomeAnimal";
            this.NomeAnimal.ReadOnly = true;
            this.NomeAnimal.Size = new System.Drawing.Size(542, 22);
            this.NomeAnimal.TabIndex = 11;
            this.NomeAnimal.TextChanged += new System.EventHandler(this.NomeAnimal_TextChanged);
            // 
            // EspecieAnimal
            // 
            this.EspecieAnimal.Location = new System.Drawing.Point(326, 97);
            this.EspecieAnimal.Name = "EspecieAnimal";
            this.EspecieAnimal.ReadOnly = true;
            this.EspecieAnimal.Size = new System.Drawing.Size(535, 22);
            this.EspecieAnimal.TabIndex = 12;
            this.EspecieAnimal.TextChanged += new System.EventHandler(this.EspecieAnimal_TextChanged);
            // 
            // DietaAnimal
            // 
            this.DietaAnimal.Location = new System.Drawing.Point(307, 125);
            this.DietaAnimal.Name = "DietaAnimal";
            this.DietaAnimal.ReadOnly = true;
            this.DietaAnimal.Size = new System.Drawing.Size(553, 22);
            this.DietaAnimal.TabIndex = 13;
            this.DietaAnimal.TextChanged += new System.EventHandler(this.DietaAnimal_TextChanged);
            // 
            // ComprimentoAnimal
            // 
            this.ComprimentoAnimal.Location = new System.Drawing.Point(378, 181);
            this.ComprimentoAnimal.Name = "ComprimentoAnimal";
            this.ComprimentoAnimal.ReadOnly = true;
            this.ComprimentoAnimal.Size = new System.Drawing.Size(483, 22);
            this.ComprimentoAnimal.TabIndex = 15;
            this.ComprimentoAnimal.TextChanged += new System.EventHandler(this.ComprimentoAnimal_TextChanged);
            // 
            // ListaRelacionamentos
            // 
            this.ListaRelacionamentos.FormattingEnabled = true;
            this.ListaRelacionamentos.ItemHeight = 16;
            this.ListaRelacionamentos.Location = new System.Drawing.Point(396, 270);
            this.ListaRelacionamentos.Name = "ListaRelacionamentos";
            this.ListaRelacionamentos.Size = new System.Drawing.Size(464, 148);
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
            this.EditarAnimal.Click += new System.EventHandler(this.EditarAnimal_Click);
            // 
            // RemoverAnimal
            // 
            this.RemoverAnimal.Location = new System.Drawing.Point(578, 493);
            this.RemoverAnimal.Name = "RemoverAnimal";
            this.RemoverAnimal.Size = new System.Drawing.Size(140, 43);
            this.RemoverAnimal.TabIndex = 20;
            this.RemoverAnimal.Text = "Remover Animal";
            this.RemoverAnimal.UseVisualStyleBackColor = true;
            this.RemoverAnimal.Click += new System.EventHandler(this.RemoverAnimal_Click);
            // 
            // GerirRelacoes
            // 
            this.GerirRelacoes.Location = new System.Drawing.Point(646, 424);
            this.GerirRelacoes.Name = "GerirRelacoes";
            this.GerirRelacoes.Size = new System.Drawing.Size(215, 27);
            this.GerirRelacoes.TabIndex = 21;
            this.GerirRelacoes.Text = "Gerir Relacionamentos";
            this.GerirRelacoes.UseVisualStyleBackColor = true;
            this.GerirRelacoes.Click += new System.EventHandler(this.GerirRelacoes_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Peso (kg)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // PesoAnimal
            // 
            this.PesoAnimal.Location = new System.Drawing.Point(334, 153);
            this.PesoAnimal.Name = "PesoAnimal";
            this.PesoAnimal.ReadOnly = true;
            this.PesoAnimal.Size = new System.Drawing.Size(527, 22);
            this.PesoAnimal.TabIndex = 14;
            this.PesoAnimal.TextChanged += new System.EventHandler(this.PesoAnimal_TextChanged);
            // 
            // CorAnimal
            // 
            this.CorAnimal.Location = new System.Drawing.Point(308, 239);
            this.CorAnimal.Name = "CorAnimal";
            this.CorAnimal.ReadOnly = true;
            this.CorAnimal.Size = new System.Drawing.Size(553, 22);
            this.CorAnimal.TabIndex = 23;
            this.CorAnimal.TextChanged += new System.EventHandler(this.CorAnimal_TextChanged);
            // 
            // Cor
            // 
            this.Cor.AutoSize = true;
            this.Cor.Location = new System.Drawing.Point(263, 242);
            this.Cor.Name = "Cor";
            this.Cor.Size = new System.Drawing.Size(28, 16);
            this.Cor.TabIndex = 22;
            this.Cor.Text = "Cor";
            this.Cor.Click += new System.EventHandler(this.Cor_Click);
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
            // AdicionarAnimal
            // 
            this.AdicionarAnimal.Location = new System.Drawing.Point(435, 493);
            this.AdicionarAnimal.Name = "AdicionarAnimal";
            this.AdicionarAnimal.Size = new System.Drawing.Size(137, 43);
            this.AdicionarAnimal.TabIndex = 24;
            this.AdicionarAnimal.Text = "Novo Animal";
            this.AdicionarAnimal.UseVisualStyleBackColor = true;
            this.AdicionarAnimal.Click += new System.EventHandler(this.AdicionarAnimal_Click);
            // 
            // VeterinarioAnimal
            // 
            this.VeterinarioAnimal.Enabled = false;
            this.VeterinarioAnimal.FormattingEnabled = true;
            this.VeterinarioAnimal.Location = new System.Drawing.Point(424, 209);
            this.VeterinarioAnimal.Name = "VeterinarioAnimal";
            this.VeterinarioAnimal.Size = new System.Drawing.Size(436, 24);
            this.VeterinarioAnimal.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "Grupo Taxonómico";
            // 
            // GrupoTaxonomicoText
            // 
            this.GrupoTaxonomicoText.Location = new System.Drawing.Point(391, 69);
            this.GrupoTaxonomicoText.Name = "GrupoTaxonomicoText";
            this.GrupoTaxonomicoText.ReadOnly = true;
            this.GrupoTaxonomicoText.Size = new System.Drawing.Size(470, 22);
            this.GrupoTaxonomicoText.TabIndex = 28;
            // 
            // TransferenciaCancelar
            // 
            this.TransferenciaCancelar.Location = new System.Drawing.Point(578, 493);
            this.TransferenciaCancelar.Name = "TransferenciaCancelar";
            this.TransferenciaCancelar.Size = new System.Drawing.Size(137, 43);
            this.TransferenciaCancelar.TabIndex = 29;
            this.TransferenciaCancelar.Text = "Cancelar";
            this.TransferenciaCancelar.UseVisualStyleBackColor = true;
            this.TransferenciaCancelar.Visible = false;
            this.TransferenciaCancelar.Click += new System.EventHandler(this.TransferenciaCancelar_Click);
            // 
            // EditarConfirmar
            // 
            this.EditarConfirmar.Location = new System.Drawing.Point(723, 493);
            this.EditarConfirmar.Name = "EditarConfirmar";
            this.EditarConfirmar.Size = new System.Drawing.Size(137, 43);
            this.EditarConfirmar.TabIndex = 30;
            this.EditarConfirmar.Text = "Confirmar";
            this.EditarConfirmar.UseVisualStyleBackColor = true;
            this.EditarConfirmar.Visible = false;
            this.EditarConfirmar.Click += new System.EventHandler(this.EditarConfirmar_Click);
            // 
            // AnimalTransferir
            // 
            this.AnimalTransferir.Location = new System.Drawing.Point(292, 493);
            this.AnimalTransferir.Name = "AnimalTransferir";
            this.AnimalTransferir.Size = new System.Drawing.Size(137, 43);
            this.AnimalTransferir.TabIndex = 31;
            this.AnimalTransferir.Text = "Transferir Animal";
            this.AnimalTransferir.UseVisualStyleBackColor = true;
            this.AnimalTransferir.Click += new System.EventHandler(this.TransferirAnimal_Click);
            // 
            // TransferenciaConfirmar
            // 
            this.TransferenciaConfirmar.Location = new System.Drawing.Point(724, 493);
            this.TransferenciaConfirmar.Name = "TransferenciaConfirmar";
            this.TransferenciaConfirmar.Size = new System.Drawing.Size(137, 43);
            this.TransferenciaConfirmar.TabIndex = 32;
            this.TransferenciaConfirmar.Text = "Confirmar";
            this.TransferenciaConfirmar.UseVisualStyleBackColor = true;
            this.TransferenciaConfirmar.Visible = false;
            this.TransferenciaConfirmar.Click += new System.EventHandler(this.TransferenciaConfirmar_Click);
            // 
            // ZooAtual
            // 
            this.ZooAtual.AutoSize = true;
            this.ZooAtual.Location = new System.Drawing.Point(263, 270);
            this.ZooAtual.Name = "ZooAtual";
            this.ZooAtual.Size = new System.Drawing.Size(112, 16);
            this.ZooAtual.TabIndex = 33;
            this.ZooAtual.Text = "Jardim Zoológico";
            this.ZooAtual.Visible = false;
            // 
            // ZooCombo
            // 
            this.ZooCombo.FormattingEnabled = true;
            this.ZooCombo.Location = new System.Drawing.Point(378, 267);
            this.ZooCombo.Name = "ZooCombo";
            this.ZooCombo.Size = new System.Drawing.Size(482, 24);
            this.ZooCombo.TabIndex = 34;
            this.ZooCombo.Visible = false;
            this.ZooCombo.SelectedIndexChanged += new System.EventHandler(this.ZooCombo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(263, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 35;
            this.label9.Text = "Habitat";
            this.label9.Visible = false;
            // 
            // HabitatCombo
            // 
            this.HabitatCombo.FormattingEnabled = true;
            this.HabitatCombo.Location = new System.Drawing.Point(319, 296);
            this.HabitatCombo.Name = "HabitatCombo";
            this.HabitatCombo.Size = new System.Drawing.Size(541, 24);
            this.HabitatCombo.TabIndex = 36;
            this.HabitatCombo.Visible = false;
            this.HabitatCombo.SelectedIndexChanged += new System.EventHandler(this.HabitatCombo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(263, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 37;
            this.label10.Text = "Habitáculo";
            this.label10.Visible = false;
            // 
            // HabitaculoCombo
            // 
            this.HabitaculoCombo.FormattingEnabled = true;
            this.HabitaculoCombo.Location = new System.Drawing.Point(334, 326);
            this.HabitaculoCombo.Name = "HabitaculoCombo";
            this.HabitaculoCombo.Size = new System.Drawing.Size(527, 24);
            this.HabitaculoCombo.TabIndex = 38;
            this.HabitaculoCombo.Visible = false;
            this.HabitaculoCombo.SelectedIndexChanged += new System.EventHandler(this.HabitaculoCombo_SelectedIndexChanged);
            // 
            // AnimalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 548);
            this.Controls.Add(this.HabitaculoCombo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.HabitatCombo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ZooCombo);
            this.Controls.Add(this.ZooAtual);
            this.Controls.Add(this.TransferenciaConfirmar);
            this.Controls.Add(this.AnimalTransferir);
            this.Controls.Add(this.EditarConfirmar);
            this.Controls.Add(this.TransferenciaCancelar);
            this.Controls.Add(this.GrupoTaxonomicoText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.VeterinarioAnimal);
            this.Controls.Add(this.AdicionarAnimal);
            this.Controls.Add(this.CorAnimal);
            this.Controls.Add(this.Cor);
            this.Controls.Add(this.GerirRelacoes);
            this.Controls.Add(this.RemoverAnimal);
            this.Controls.Add(this.EditarAnimal);
            this.Controls.Add(this.ListaRelacionamentos);
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
            this.Load += new System.EventHandler(this.AnimalList_Load);
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
        private System.Windows.Forms.ListBox ListaRelacionamentos;
        private System.Windows.Forms.Button EditarAnimal;
        private System.Windows.Forms.Button RemoverAnimal;
        private System.Windows.Forms.Button GerirRelacoes;
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
        private System.Windows.Forms.Button AdicionarAnimal;
        private System.Windows.Forms.ComboBox VeterinarioAnimal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox GrupoTaxonomicoText;
        private System.Windows.Forms.Button TransferenciaCancelar;
        private System.Windows.Forms.Button EditarConfirmar;
        private System.Windows.Forms.Button AnimalTransferir;
        private System.Windows.Forms.Button TransferenciaConfirmar;
        private System.Windows.Forms.Label ZooAtual;
        private System.Windows.Forms.ComboBox ZooCombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox HabitatCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox HabitaculoCombo;
    }
}