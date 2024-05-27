namespace ZooLifeForm
{
    partial class NovoAnimal
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
            this.NovoAnimalNomeLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NovoAnimalDietaLabel = new System.Windows.Forms.Label();
            this.NovoAnimalPesoLabel = new System.Windows.Forms.Label();
            this.NovoAnimalEspécieLabel = new System.Windows.Forms.Label();
            this.NovoAnimalNome = new System.Windows.Forms.TextBox();
            this.NovoAnimalEspecie = new System.Windows.Forms.TextBox();
            this.NovoAnimalDieta = new System.Windows.Forms.TextBox();
            this.NovoAnimalPeso = new System.Windows.Forms.TextBox();
            this.NovoAnimalComprimentoLabel = new System.Windows.Forms.Label();
            this.NovoAnimalComprimento = new System.Windows.Forms.TextBox();
            this.NovoAnimalCorLabel = new System.Windows.Forms.Label();
            this.NovoAnimalCor = new System.Windows.Forms.TextBox();
            this.ConfirmarButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NovoAnimalHabitatLabel = new System.Windows.Forms.Label();
            this.NovoAnimalZooLabel = new System.Windows.Forms.Label();
            this.NovoAnimalHabitaculoLabel = new System.Windows.Forms.Label();
            this.NovoAnimalZooCombo = new System.Windows.Forms.ComboBox();
            this.NovoAnimalHabitatCombo = new System.Windows.Forms.ComboBox();
            this.NovoAnimalHabitaculoCombo = new System.Windows.Forms.ComboBox();
            this.NovoAnimalVeterinario = new System.Windows.Forms.Label();
            this.NovoAnimalVeterinarioCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NovoAnimalNomeLabel
            // 
            this.NovoAnimalNomeLabel.AutoSize = true;
            this.NovoAnimalNomeLabel.Location = new System.Drawing.Point(24, 100);
            this.NovoAnimalNomeLabel.Name = "NovoAnimalNomeLabel";
            this.NovoAnimalNomeLabel.Size = new System.Drawing.Size(44, 16);
            this.NovoAnimalNomeLabel.TabIndex = 0;
            this.NovoAnimalNomeLabel.Text = "Nome";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(132, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(552, 69);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Inserir Novo Animal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 2;
            // 
            // NovoAnimalDietaLabel
            // 
            this.NovoAnimalDietaLabel.AutoSize = true;
            this.NovoAnimalDietaLabel.Location = new System.Drawing.Point(24, 190);
            this.NovoAnimalDietaLabel.Name = "NovoAnimalDietaLabel";
            this.NovoAnimalDietaLabel.Size = new System.Drawing.Size(39, 16);
            this.NovoAnimalDietaLabel.TabIndex = 3;
            this.NovoAnimalDietaLabel.Text = "Dieta";
            // 
            // NovoAnimalPesoLabel
            // 
            this.NovoAnimalPesoLabel.AutoSize = true;
            this.NovoAnimalPesoLabel.Location = new System.Drawing.Point(24, 235);
            this.NovoAnimalPesoLabel.Name = "NovoAnimalPesoLabel";
            this.NovoAnimalPesoLabel.Size = new System.Drawing.Size(65, 16);
            this.NovoAnimalPesoLabel.TabIndex = 4;
            this.NovoAnimalPesoLabel.Text = "Peso (kg)";
            // 
            // NovoAnimalEspécieLabel
            // 
            this.NovoAnimalEspécieLabel.AutoSize = true;
            this.NovoAnimalEspécieLabel.Location = new System.Drawing.Point(24, 145);
            this.NovoAnimalEspécieLabel.Name = "NovoAnimalEspécieLabel";
            this.NovoAnimalEspécieLabel.Size = new System.Drawing.Size(57, 16);
            this.NovoAnimalEspécieLabel.TabIndex = 5;
            this.NovoAnimalEspécieLabel.Text = "Espécie";
            // 
            // NovoAnimalNome
            // 
            this.NovoAnimalNome.Location = new System.Drawing.Point(155, 97);
            this.NovoAnimalNome.Name = "NovoAnimalNome";
            this.NovoAnimalNome.Size = new System.Drawing.Size(289, 22);
            this.NovoAnimalNome.TabIndex = 6;
            this.NovoAnimalNome.TextChanged += new System.EventHandler(this.NovoAnimalNome_TextChanged);
            // 
            // NovoAnimalEspecie
            // 
            this.NovoAnimalEspecie.Location = new System.Drawing.Point(155, 139);
            this.NovoAnimalEspecie.Name = "NovoAnimalEspecie";
            this.NovoAnimalEspecie.Size = new System.Drawing.Size(289, 22);
            this.NovoAnimalEspecie.TabIndex = 7;
            this.NovoAnimalEspecie.TextChanged += new System.EventHandler(this.NovoAnimalEspecie_TextChanged);
            // 
            // NovoAnimalDieta
            // 
            this.NovoAnimalDieta.Location = new System.Drawing.Point(155, 187);
            this.NovoAnimalDieta.Name = "NovoAnimalDieta";
            this.NovoAnimalDieta.Size = new System.Drawing.Size(289, 22);
            this.NovoAnimalDieta.TabIndex = 8;
            this.NovoAnimalDieta.TextChanged += new System.EventHandler(this.NovoAnimalDieta_TextChanged);
            // 
            // NovoAnimalPeso
            // 
            this.NovoAnimalPeso.Location = new System.Drawing.Point(155, 232);
            this.NovoAnimalPeso.Name = "NovoAnimalPeso";
            this.NovoAnimalPeso.Size = new System.Drawing.Size(289, 22);
            this.NovoAnimalPeso.TabIndex = 9;
            this.NovoAnimalPeso.TextChanged += new System.EventHandler(this.NovoAnimalPeso_TextChanged);
            // 
            // NovoAnimalComprimentoLabel
            // 
            this.NovoAnimalComprimentoLabel.AutoSize = true;
            this.NovoAnimalComprimentoLabel.Location = new System.Drawing.Point(24, 276);
            this.NovoAnimalComprimentoLabel.Name = "NovoAnimalComprimentoLabel";
            this.NovoAnimalComprimentoLabel.Size = new System.Drawing.Size(109, 16);
            this.NovoAnimalComprimentoLabel.TabIndex = 10;
            this.NovoAnimalComprimentoLabel.Text = "Comprimento (m)";
            // 
            // NovoAnimalComprimento
            // 
            this.NovoAnimalComprimento.Location = new System.Drawing.Point(155, 273);
            this.NovoAnimalComprimento.Name = "NovoAnimalComprimento";
            this.NovoAnimalComprimento.Size = new System.Drawing.Size(289, 22);
            this.NovoAnimalComprimento.TabIndex = 11;
            this.NovoAnimalComprimento.TextChanged += new System.EventHandler(this.NovoAnimalComprimento_TextChanged);
            // 
            // NovoAnimalCorLabel
            // 
            this.NovoAnimalCorLabel.AutoSize = true;
            this.NovoAnimalCorLabel.Location = new System.Drawing.Point(24, 314);
            this.NovoAnimalCorLabel.Name = "NovoAnimalCorLabel";
            this.NovoAnimalCorLabel.Size = new System.Drawing.Size(28, 16);
            this.NovoAnimalCorLabel.TabIndex = 12;
            this.NovoAnimalCorLabel.Text = "Cor";
            // 
            // NovoAnimalCor
            // 
            this.NovoAnimalCor.Location = new System.Drawing.Point(155, 311);
            this.NovoAnimalCor.Name = "NovoAnimalCor";
            this.NovoAnimalCor.Size = new System.Drawing.Size(289, 22);
            this.NovoAnimalCor.TabIndex = 13;
            this.NovoAnimalCor.TextChanged += new System.EventHandler(this.NovoAnimalCor_TextChanged);
            // 
            // ConfirmarButton
            // 
            this.ConfirmarButton.Enabled = false;
            this.ConfirmarButton.Location = new System.Drawing.Point(682, 392);
            this.ConfirmarButton.Name = "ConfirmarButton";
            this.ConfirmarButton.Size = new System.Drawing.Size(106, 46);
            this.ConfirmarButton.TabIndex = 14;
            this.ConfirmarButton.Text = "Confirmar";
            this.ConfirmarButton.UseVisualStyleBackColor = true;
            this.ConfirmarButton.Click += new System.EventHandler(this.ConfirmarButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(570, 392);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(106, 46);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // NovoAnimalHabitatLabel
            // 
            this.NovoAnimalHabitatLabel.AutoSize = true;
            this.NovoAnimalHabitatLabel.Location = new System.Drawing.Point(479, 145);
            this.NovoAnimalHabitatLabel.Name = "NovoAnimalHabitatLabel";
            this.NovoAnimalHabitatLabel.Size = new System.Drawing.Size(50, 16);
            this.NovoAnimalHabitatLabel.TabIndex = 16;
            this.NovoAnimalHabitatLabel.Text = "Habitat";
            // 
            // NovoAnimalZooLabel
            // 
            this.NovoAnimalZooLabel.AutoSize = true;
            this.NovoAnimalZooLabel.Location = new System.Drawing.Point(479, 100);
            this.NovoAnimalZooLabel.Name = "NovoAnimalZooLabel";
            this.NovoAnimalZooLabel.Size = new System.Drawing.Size(31, 16);
            this.NovoAnimalZooLabel.TabIndex = 17;
            this.NovoAnimalZooLabel.Text = "Zoo";
            // 
            // NovoAnimalHabitaculoLabel
            // 
            this.NovoAnimalHabitaculoLabel.AutoSize = true;
            this.NovoAnimalHabitaculoLabel.Location = new System.Drawing.Point(479, 190);
            this.NovoAnimalHabitaculoLabel.Name = "NovoAnimalHabitaculoLabel";
            this.NovoAnimalHabitaculoLabel.Size = new System.Drawing.Size(72, 16);
            this.NovoAnimalHabitaculoLabel.TabIndex = 18;
            this.NovoAnimalHabitaculoLabel.Text = "Habitáculo";
            // 
            // NovoAnimalZooCombo
            // 
            this.NovoAnimalZooCombo.FormattingEnabled = true;
            this.NovoAnimalZooCombo.Location = new System.Drawing.Point(565, 97);
            this.NovoAnimalZooCombo.Name = "NovoAnimalZooCombo";
            this.NovoAnimalZooCombo.Size = new System.Drawing.Size(211, 24);
            this.NovoAnimalZooCombo.TabIndex = 19;
            this.NovoAnimalZooCombo.SelectedIndexChanged += new System.EventHandler(this.NovoAnimalZooCombo_SelectedIndexChanged);
            // 
            // NovoAnimalHabitatCombo
            // 
            this.NovoAnimalHabitatCombo.Enabled = false;
            this.NovoAnimalHabitatCombo.FormattingEnabled = true;
            this.NovoAnimalHabitatCombo.Location = new System.Drawing.Point(565, 139);
            this.NovoAnimalHabitatCombo.Name = "NovoAnimalHabitatCombo";
            this.NovoAnimalHabitatCombo.Size = new System.Drawing.Size(211, 24);
            this.NovoAnimalHabitatCombo.TabIndex = 20;
            this.NovoAnimalHabitatCombo.SelectedIndexChanged += new System.EventHandler(this.NovoAnimalHabitatCombo_SelectedIndexChanged);
            // 
            // NovoAnimalHabitaculoCombo
            // 
            this.NovoAnimalHabitaculoCombo.Enabled = false;
            this.NovoAnimalHabitaculoCombo.FormattingEnabled = true;
            this.NovoAnimalHabitaculoCombo.Location = new System.Drawing.Point(565, 187);
            this.NovoAnimalHabitaculoCombo.Name = "NovoAnimalHabitaculoCombo";
            this.NovoAnimalHabitaculoCombo.Size = new System.Drawing.Size(211, 24);
            this.NovoAnimalHabitaculoCombo.TabIndex = 21;
            this.NovoAnimalHabitaculoCombo.SelectedIndexChanged += new System.EventHandler(this.NovoAnimalHabitaculoCombo_SelectedIndexChanged);
            // 
            // NovoAnimalVeterinario
            // 
            this.NovoAnimalVeterinario.AutoSize = true;
            this.NovoAnimalVeterinario.Location = new System.Drawing.Point(479, 235);
            this.NovoAnimalVeterinario.Name = "NovoAnimalVeterinario";
            this.NovoAnimalVeterinario.Size = new System.Drawing.Size(72, 16);
            this.NovoAnimalVeterinario.TabIndex = 22;
            this.NovoAnimalVeterinario.Text = "Veterinário";
            // 
            // NovoAnimalVeterinarioCombo
            // 
            this.NovoAnimalVeterinarioCombo.Enabled = false;
            this.NovoAnimalVeterinarioCombo.FormattingEnabled = true;
            this.NovoAnimalVeterinarioCombo.Location = new System.Drawing.Point(565, 232);
            this.NovoAnimalVeterinarioCombo.Name = "NovoAnimalVeterinarioCombo";
            this.NovoAnimalVeterinarioCombo.Size = new System.Drawing.Size(211, 24);
            this.NovoAnimalVeterinarioCombo.TabIndex = 23;
            this.NovoAnimalVeterinarioCombo.SelectedIndexChanged += new System.EventHandler(this.NovoAnimalVeterinarioCombo_SelectedIndexChanged);
            // 
            // NovoAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NovoAnimalVeterinarioCombo);
            this.Controls.Add(this.NovoAnimalVeterinario);
            this.Controls.Add(this.NovoAnimalHabitaculoCombo);
            this.Controls.Add(this.NovoAnimalHabitatCombo);
            this.Controls.Add(this.NovoAnimalZooCombo);
            this.Controls.Add(this.NovoAnimalHabitaculoLabel);
            this.Controls.Add(this.NovoAnimalZooLabel);
            this.Controls.Add(this.NovoAnimalHabitatLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmarButton);
            this.Controls.Add(this.NovoAnimalCor);
            this.Controls.Add(this.NovoAnimalCorLabel);
            this.Controls.Add(this.NovoAnimalComprimento);
            this.Controls.Add(this.NovoAnimalComprimentoLabel);
            this.Controls.Add(this.NovoAnimalPeso);
            this.Controls.Add(this.NovoAnimalDieta);
            this.Controls.Add(this.NovoAnimalEspecie);
            this.Controls.Add(this.NovoAnimalNome);
            this.Controls.Add(this.NovoAnimalEspécieLabel);
            this.Controls.Add(this.NovoAnimalPesoLabel);
            this.Controls.Add(this.NovoAnimalDietaLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.NovoAnimalNomeLabel);
            this.Name = "NovoAnimal";
            this.Text = "NovoAnimal";
            this.Load += new System.EventHandler(this.NovoAnimal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NovoAnimalNomeLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NovoAnimalDietaLabel;
        private System.Windows.Forms.Label NovoAnimalPesoLabel;
        private System.Windows.Forms.Label NovoAnimalEspécieLabel;
        private System.Windows.Forms.TextBox NovoAnimalNome;
        private System.Windows.Forms.TextBox NovoAnimalEspecie;
        private System.Windows.Forms.TextBox NovoAnimalDieta;
        private System.Windows.Forms.TextBox NovoAnimalPeso;
        private System.Windows.Forms.Label NovoAnimalComprimentoLabel;
        private System.Windows.Forms.TextBox NovoAnimalComprimento;
        private System.Windows.Forms.Label NovoAnimalCorLabel;
        private System.Windows.Forms.TextBox NovoAnimalCor;
        private System.Windows.Forms.Button ConfirmarButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label NovoAnimalHabitatLabel;
        private System.Windows.Forms.Label NovoAnimalZooLabel;
        private System.Windows.Forms.Label NovoAnimalHabitaculoLabel;
        private System.Windows.Forms.ComboBox NovoAnimalZooCombo;
        private System.Windows.Forms.ComboBox NovoAnimalHabitaculoCombo;
        private System.Windows.Forms.Label NovoAnimalVeterinario;
        private System.Windows.Forms.ComboBox NovoAnimalVeterinarioCombo;
        private System.Windows.Forms.ComboBox NovoAnimalHabitatCombo;
    }
}