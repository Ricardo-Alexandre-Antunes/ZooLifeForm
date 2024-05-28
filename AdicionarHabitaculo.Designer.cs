namespace ZooLifeForm
{
    partial class AdicionarHabitaculo
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
            this.label_titulo = new System.Windows.Forms.Label();
            this.label_jz = new System.Windows.Forms.Label();
            this.label_habitat = new System.Windows.Forms.Label();
            this.label_dimensoes = new System.Windows.Forms.Label();
            this.label_capacidade_max = new System.Windows.Forms.Label();
            this.comboBox_jz = new System.Windows.Forms.ComboBox();
            this.comboBox_habitat = new System.Windows.Forms.ComboBox();
            this.textBox_capacidade_max = new System.Windows.Forms.TextBox();
            this.button_adicionar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.textBox_dimensoes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_titulo.Location = new System.Drawing.Point(240, 9);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(316, 38);
            this.label_titulo.TabIndex = 0;
            this.label_titulo.Text = "Adicionar Habitáculo";
            // 
            // label_jz
            // 
            this.label_jz.AutoSize = true;
            this.label_jz.Location = new System.Drawing.Point(39, 133);
            this.label_jz.Name = "label_jz";
            this.label_jz.Size = new System.Drawing.Size(112, 16);
            this.label_jz.TabIndex = 2;
            this.label_jz.Text = "Jardim Zoológico";
            // 
            // label_habitat
            // 
            this.label_habitat.AutoSize = true;
            this.label_habitat.Location = new System.Drawing.Point(39, 171);
            this.label_habitat.Name = "label_habitat";
            this.label_habitat.Size = new System.Drawing.Size(50, 16);
            this.label_habitat.TabIndex = 3;
            this.label_habitat.Text = "Habitat";
            // 
            // label_dimensoes
            // 
            this.label_dimensoes.AutoSize = true;
            this.label_dimensoes.Location = new System.Drawing.Point(39, 212);
            this.label_dimensoes.Name = "label_dimensoes";
            this.label_dimensoes.Size = new System.Drawing.Size(76, 16);
            this.label_dimensoes.TabIndex = 4;
            this.label_dimensoes.Text = "Dimensões";
            // 
            // label_capacidade_max
            // 
            this.label_capacidade_max.AutoSize = true;
            this.label_capacidade_max.Location = new System.Drawing.Point(39, 251);
            this.label_capacidade_max.Name = "label_capacidade_max";
            this.label_capacidade_max.Size = new System.Drawing.Size(132, 16);
            this.label_capacidade_max.TabIndex = 5;
            this.label_capacidade_max.Text = "Capacidade Máxima";
            // 
            // comboBox_jz
            // 
            this.comboBox_jz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_jz.FormattingEnabled = true;
            this.comboBox_jz.Location = new System.Drawing.Point(176, 130);
            this.comboBox_jz.Name = "comboBox_jz";
            this.comboBox_jz.Size = new System.Drawing.Size(579, 24);
            this.comboBox_jz.TabIndex = 7;
            this.comboBox_jz.SelectedIndexChanged += new System.EventHandler(this.comboBox_jz_SelectedIndexChanged);
            // 
            // comboBox_habitat
            // 
            this.comboBox_habitat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_habitat.FormattingEnabled = true;
            this.comboBox_habitat.Location = new System.Drawing.Point(111, 168);
            this.comboBox_habitat.Name = "comboBox_habitat";
            this.comboBox_habitat.Size = new System.Drawing.Size(644, 24);
            this.comboBox_habitat.TabIndex = 8;
            this.comboBox_habitat.SelectedIndexChanged += new System.EventHandler(this.comboBox_habitat_SelectedIndexChanged);
            // 
            // textBox_capacidade_max
            // 
            this.textBox_capacidade_max.Location = new System.Drawing.Point(193, 248);
            this.textBox_capacidade_max.Name = "textBox_capacidade_max";
            this.textBox_capacidade_max.Size = new System.Drawing.Size(562, 22);
            this.textBox_capacidade_max.TabIndex = 10;
            // 
            // button_adicionar
            // 
            this.button_adicionar.Location = new System.Drawing.Point(595, 393);
            this.button_adicionar.Name = "button_adicionar";
            this.button_adicionar.Size = new System.Drawing.Size(160, 45);
            this.button_adicionar.TabIndex = 11;
            this.button_adicionar.Text = "Adicionar";
            this.button_adicionar.UseVisualStyleBackColor = true;
            this.button_adicionar.Click += new System.EventHandler(this.button_adicionar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(412, 393);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(159, 45);
            this.button_cancelar.TabIndex = 12;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // textBox_dimensoes
            // 
            this.textBox_dimensoes.Location = new System.Drawing.Point(142, 209);
            this.textBox_dimensoes.Name = "textBox_dimensoes";
            this.textBox_dimensoes.Size = new System.Drawing.Size(613, 22);
            this.textBox_dimensoes.TabIndex = 13;
            // 
            // AdicionarHabitaculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_dimensoes);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_adicionar);
            this.Controls.Add(this.textBox_capacidade_max);
            this.Controls.Add(this.comboBox_habitat);
            this.Controls.Add(this.comboBox_jz);
            this.Controls.Add(this.label_capacidade_max);
            this.Controls.Add(this.label_dimensoes);
            this.Controls.Add(this.label_habitat);
            this.Controls.Add(this.label_jz);
            this.Controls.Add(this.label_titulo);
            this.Name = "AdicionarHabitaculo";
            this.Text = "Adicionar Habitáculo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdicionarHabitaculo_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Label label_jz;
        private System.Windows.Forms.Label label_habitat;
        private System.Windows.Forms.Label label_dimensoes;
        private System.Windows.Forms.Label label_capacidade_max;
        private System.Windows.Forms.ComboBox comboBox_jz;
        private System.Windows.Forms.ComboBox comboBox_habitat;
        private System.Windows.Forms.TextBox textBox_capacidade_max;
        private System.Windows.Forms.Button button_adicionar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.TextBox textBox_dimensoes;
    }
}