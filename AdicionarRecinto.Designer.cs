namespace ZooLifeForm
{
    partial class AdicionarRecinto
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
            this.label_title_add_recinto = new System.Windows.Forms.Label();
            this.label_nome = new System.Windows.Forms.Label();
            this.label_jz = new System.Windows.Forms.Label();
            this.label_estado = new System.Windows.Forms.Label();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.comboBox_jz = new System.Windows.Forms.ComboBox();
            this.comboBox_estado = new System.Windows.Forms.ComboBox();
            this.label_tipo = new System.Windows.Forms.Label();
            this.comboBox_tipo = new System.Windows.Forms.ComboBox();
            this.label_max_capacidade = new System.Windows.Forms.Label();
            this.textBox_max_capacidade = new System.Windows.Forms.TextBox();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_adicionar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_title_add_recinto
            // 
            this.label_title_add_recinto.AutoSize = true;
            this.label_title_add_recinto.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title_add_recinto.Location = new System.Drawing.Point(250, 9);
            this.label_title_add_recinto.Name = "label_title_add_recinto";
            this.label_title_add_recinto.Size = new System.Drawing.Size(311, 42);
            this.label_title_add_recinto.TabIndex = 0;
            this.label_title_add_recinto.Text = "Adicionar Recinto";
            // 
            // label_nome
            // 
            this.label_nome.AutoSize = true;
            this.label_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nome.Location = new System.Drawing.Point(36, 68);
            this.label_nome.Name = "label_nome";
            this.label_nome.Size = new System.Drawing.Size(64, 25);
            this.label_nome.TabIndex = 1;
            this.label_nome.Text = "Nome";
            // 
            // label_jz
            // 
            this.label_jz.AutoSize = true;
            this.label_jz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_jz.Location = new System.Drawing.Point(36, 114);
            this.label_jz.Name = "label_jz";
            this.label_jz.Size = new System.Drawing.Size(161, 25);
            this.label_jz.TabIndex = 2;
            this.label_jz.Text = "Jardim Zoológico";
            // 
            // label_estado
            // 
            this.label_estado.AutoSize = true;
            this.label_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_estado.Location = new System.Drawing.Point(41, 162);
            this.label_estado.Name = "label_estado";
            this.label_estado.Size = new System.Drawing.Size(73, 25);
            this.label_estado.TabIndex = 3;
            this.label_estado.Text = "Estado";
            // 
            // textBox_nome
            // 
            this.textBox_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nome.Location = new System.Drawing.Point(128, 72);
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.Size = new System.Drawing.Size(628, 27);
            this.textBox_nome.TabIndex = 4;
            // 
            // comboBox_jz
            // 
            this.comboBox_jz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_jz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_jz.FormattingEnabled = true;
            this.comboBox_jz.Location = new System.Drawing.Point(218, 118);
            this.comboBox_jz.Name = "comboBox_jz";
            this.comboBox_jz.Size = new System.Drawing.Size(538, 28);
            this.comboBox_jz.TabIndex = 5;
            this.comboBox_jz.SelectedIndexChanged += new System.EventHandler(this.comboBox_jz_SelectedIndexChanged);
            // 
            // comboBox_estado
            // 
            this.comboBox_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_estado.FormattingEnabled = true;
            this.comboBox_estado.Location = new System.Drawing.Point(139, 163);
            this.comboBox_estado.Name = "comboBox_estado";
            this.comboBox_estado.Size = new System.Drawing.Size(617, 28);
            this.comboBox_estado.TabIndex = 6;
            this.comboBox_estado.SelectedIndexChanged += new System.EventHandler(this.comboBox_estado_SelectedIndexChanged);
            // 
            // label_tipo
            // 
            this.label_tipo.AutoSize = true;
            this.label_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tipo.Location = new System.Drawing.Point(41, 212);
            this.label_tipo.Name = "label_tipo";
            this.label_tipo.Size = new System.Drawing.Size(51, 25);
            this.label_tipo.TabIndex = 7;
            this.label_tipo.Text = "Tipo";
            // 
            // comboBox_tipo
            // 
            this.comboBox_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_tipo.FormattingEnabled = true;
            this.comboBox_tipo.Location = new System.Drawing.Point(139, 213);
            this.comboBox_tipo.Name = "comboBox_tipo";
            this.comboBox_tipo.Size = new System.Drawing.Size(617, 28);
            this.comboBox_tipo.TabIndex = 8;
            this.comboBox_tipo.SelectedIndexChanged += new System.EventHandler(this.comboBox_tipo_SelectedIndexChanged);
            // 
            // label_max_capacidade
            // 
            this.label_max_capacidade.AutoSize = true;
            this.label_max_capacidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_max_capacidade.Location = new System.Drawing.Point(46, 271);
            this.label_max_capacidade.Name = "label_max_capacidade";
            this.label_max_capacidade.Size = new System.Drawing.Size(203, 25);
            this.label_max_capacidade.TabIndex = 10;
            this.label_max_capacidade.Text = "Capacidade Máxima: ";
            this.label_max_capacidade.Visible = false;
            // 
            // textBox_max_capacidade
            // 
            this.textBox_max_capacidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_max_capacidade.Location = new System.Drawing.Point(255, 271);
            this.textBox_max_capacidade.Name = "textBox_max_capacidade";
            this.textBox_max_capacidade.Size = new System.Drawing.Size(92, 27);
            this.textBox_max_capacidade.TabIndex = 11;
            this.textBox_max_capacidade.Visible = false;
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(450, 386);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(147, 39);
            this.button_cancelar.TabIndex = 12;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_adicionar
            // 
            this.button_adicionar.Location = new System.Drawing.Point(617, 386);
            this.button_adicionar.Name = "button_adicionar";
            this.button_adicionar.Size = new System.Drawing.Size(139, 39);
            this.button_adicionar.TabIndex = 13;
            this.button_adicionar.Text = "Adicionar";
            this.button_adicionar.UseVisualStyleBackColor = true;
            this.button_adicionar.Click += new System.EventHandler(this.button_adicionar_Click);
            // 
            // AdicionarRecinto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_adicionar);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.textBox_max_capacidade);
            this.Controls.Add(this.label_max_capacidade);
            this.Controls.Add(this.comboBox_tipo);
            this.Controls.Add(this.label_tipo);
            this.Controls.Add(this.comboBox_estado);
            this.Controls.Add(this.comboBox_jz);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.label_estado);
            this.Controls.Add(this.label_jz);
            this.Controls.Add(this.label_nome);
            this.Controls.Add(this.label_title_add_recinto);
            this.Name = "AdicionarRecinto";
            this.Text = "Adicionar Recinto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdicionarRecinto_Closing);
            this.Load += new System.EventHandler(this.AdicionarRecinto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title_add_recinto;
        private System.Windows.Forms.Label label_nome;
        private System.Windows.Forms.Label label_jz;
        private System.Windows.Forms.Label label_estado;
        private System.Windows.Forms.TextBox textBox_nome;
        private System.Windows.Forms.ComboBox comboBox_jz;
        private System.Windows.Forms.ComboBox comboBox_estado;
        private System.Windows.Forms.Label label_tipo;
        private System.Windows.Forms.ComboBox comboBox_tipo;
        private System.Windows.Forms.Label label_max_capacidade;
        private System.Windows.Forms.TextBox textBox_max_capacidade;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_adicionar;
    }
}