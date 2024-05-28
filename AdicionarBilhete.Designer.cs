namespace ZooLifeForm
{
    partial class AdicionarBilhete
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_nome_visitante = new System.Windows.Forms.Label();
            this.label_genero = new System.Windows.Forms.Label();
            this.label_data_nascimento = new System.Windows.Forms.Label();
            this.label_id_bilheteira = new System.Windows.Forms.Label();
            this.label_preco = new System.Windows.Forms.Label();
            this.label_cc_visitante = new System.Windows.Forms.Label();
            this.label_cc_funcionario = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_jz = new System.Windows.Forms.Label();
            this.label_data_compra = new System.Windows.Forms.Label();
            this.textBox_nome = new System.Windows.Forms.TextBox();
            this.textBox_cc = new System.Windows.Forms.TextBox();
            this.textBox_preco = new System.Windows.Forms.TextBox();
            this.dateTimePicker_data_nascimento = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_data_compra = new System.Windows.Forms.DateTimePicker();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_adicionar = new System.Windows.Forms.Button();
            this.comboBox_genero = new System.Windows.Forms.ComboBox();
            this.comboBox_jz = new System.Windows.Forms.ComboBox();
            this.comboBox_bilheteira = new System.Windows.Forms.ComboBox();
            this.comboBox_funcionario_cc = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adicionar Bilhete";
            // 
            // label_nome_visitante
            // 
            this.label_nome_visitante.AutoSize = true;
            this.label_nome_visitante.Location = new System.Drawing.Point(72, 91);
            this.label_nome_visitante.Name = "label_nome_visitante";
            this.label_nome_visitante.Size = new System.Drawing.Size(44, 16);
            this.label_nome_visitante.TabIndex = 1;
            this.label_nome_visitante.Text = "Nome";
            // 
            // label_genero
            // 
            this.label_genero.AutoSize = true;
            this.label_genero.Location = new System.Drawing.Point(72, 140);
            this.label_genero.Name = "label_genero";
            this.label_genero.Size = new System.Drawing.Size(52, 16);
            this.label_genero.TabIndex = 2;
            this.label_genero.Text = "Género";
            // 
            // label_data_nascimento
            // 
            this.label_data_nascimento.AutoSize = true;
            this.label_data_nascimento.Location = new System.Drawing.Point(427, 140);
            this.label_data_nascimento.Name = "label_data_nascimento";
            this.label_data_nascimento.Size = new System.Drawing.Size(130, 16);
            this.label_data_nascimento.TabIndex = 3;
            this.label_data_nascimento.Text = "Data de Nascimento";
            // 
            // label_id_bilheteira
            // 
            this.label_id_bilheteira.AutoSize = true;
            this.label_id_bilheteira.Location = new System.Drawing.Point(360, 246);
            this.label_id_bilheteira.Name = "label_id_bilheteira";
            this.label_id_bilheteira.Size = new System.Drawing.Size(63, 16);
            this.label_id_bilheteira.TabIndex = 4;
            this.label_id_bilheteira.Text = "Bilheteira";
            this.label_id_bilheteira.Click += new System.EventHandler(this.label5_Click);
            // 
            // label_preco
            // 
            this.label_preco.AutoSize = true;
            this.label_preco.Location = new System.Drawing.Point(73, 292);
            this.label_preco.Name = "label_preco";
            this.label_preco.Size = new System.Drawing.Size(43, 16);
            this.label_preco.TabIndex = 5;
            this.label_preco.Text = "Preço";
            // 
            // label_cc_visitante
            // 
            this.label_cc_visitante.AutoSize = true;
            this.label_cc_visitante.Location = new System.Drawing.Point(427, 91);
            this.label_cc_visitante.Name = "label_cc_visitante";
            this.label_cc_visitante.Size = new System.Drawing.Size(191, 16);
            this.label_cc_visitante.TabIndex = 6;
            this.label_cc_visitante.Text = "Número de Cartão de Cidadão";
            // 
            // label_cc_funcionario
            // 
            this.label_cc_funcionario.AutoSize = true;
            this.label_cc_funcionario.Location = new System.Drawing.Point(360, 295);
            this.label_cc_funcionario.Name = "label_cc_funcionario";
            this.label_cc_funcionario.Size = new System.Drawing.Size(272, 16);
            this.label_cc_funcionario.TabIndex = 7;
            this.label_cc_funcionario.Text = "Numero de Cartão de Cidadão (Funcionário)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Informações de Visitante";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Informações da empresa";
            // 
            // label_jz
            // 
            this.label_jz.AutoSize = true;
            this.label_jz.Location = new System.Drawing.Point(75, 243);
            this.label_jz.Name = "label_jz";
            this.label_jz.Size = new System.Drawing.Size(112, 16);
            this.label_jz.TabIndex = 10;
            this.label_jz.Text = "Jardim Zoológico";
            // 
            // label_data_compra
            // 
            this.label_data_compra.AutoSize = true;
            this.label_data_compra.Location = new System.Drawing.Point(75, 338);
            this.label_data_compra.Name = "label_data_compra";
            this.label_data_compra.Size = new System.Drawing.Size(106, 16);
            this.label_data_compra.TabIndex = 11;
            this.label_data_compra.Text = "Data de Compra";
            // 
            // textBox_nome
            // 
            this.textBox_nome.Location = new System.Drawing.Point(122, 88);
            this.textBox_nome.Name = "textBox_nome";
            this.textBox_nome.Size = new System.Drawing.Size(252, 22);
            this.textBox_nome.TabIndex = 12;
            // 
            // textBox_cc
            // 
            this.textBox_cc.Location = new System.Drawing.Point(624, 88);
            this.textBox_cc.Name = "textBox_cc";
            this.textBox_cc.Size = new System.Drawing.Size(164, 22);
            this.textBox_cc.TabIndex = 14;
            // 
            // textBox_preco
            // 
            this.textBox_preco.Location = new System.Drawing.Point(131, 289);
            this.textBox_preco.Name = "textBox_preco";
            this.textBox_preco.Size = new System.Drawing.Size(194, 22);
            this.textBox_preco.TabIndex = 17;
            // 
            // dateTimePicker_data_nascimento
            // 
            this.dateTimePicker_data_nascimento.Location = new System.Drawing.Point(564, 140);
            this.dateTimePicker_data_nascimento.Name = "dateTimePicker_data_nascimento";
            this.dateTimePicker_data_nascimento.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_data_nascimento.TabIndex = 19;
            // 
            // dateTimePicker_data_compra
            // 
            this.dateTimePicker_data_compra.Location = new System.Drawing.Point(187, 338);
            this.dateTimePicker_data_compra.Name = "dateTimePicker_data_compra";
            this.dateTimePicker_data_compra.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_data_compra.TabIndex = 20;
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(388, 397);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(169, 34);
            this.button_cancelar.TabIndex = 21;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_adicionar
            // 
            this.button_adicionar.Location = new System.Drawing.Point(587, 397);
            this.button_adicionar.Name = "button_adicionar";
            this.button_adicionar.Size = new System.Drawing.Size(177, 34);
            this.button_adicionar.TabIndex = 22;
            this.button_adicionar.Text = "Adicionar";
            this.button_adicionar.UseVisualStyleBackColor = true;
            this.button_adicionar.Click += new System.EventHandler(this.button_adicionar_Click);
            // 
            // comboBox_genero
            // 
            this.comboBox_genero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_genero.FormattingEnabled = true;
            this.comboBox_genero.Location = new System.Drawing.Point(131, 137);
            this.comboBox_genero.Name = "comboBox_genero";
            this.comboBox_genero.Size = new System.Drawing.Size(243, 24);
            this.comboBox_genero.TabIndex = 23;
            // 
            // comboBox_jz
            // 
            this.comboBox_jz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_jz.FormattingEnabled = true;
            this.comboBox_jz.Location = new System.Drawing.Point(204, 243);
            this.comboBox_jz.Name = "comboBox_jz";
            this.comboBox_jz.Size = new System.Drawing.Size(121, 24);
            this.comboBox_jz.TabIndex = 24;
            this.comboBox_jz.SelectedIndexChanged += new System.EventHandler(this.comboBox_jz_SelectedIndexChanged);
            // 
            // comboBox_bilheteira
            // 
            this.comboBox_bilheteira.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bilheteira.FormattingEnabled = true;
            this.comboBox_bilheteira.Location = new System.Drawing.Point(461, 243);
            this.comboBox_bilheteira.Name = "comboBox_bilheteira";
            this.comboBox_bilheteira.Size = new System.Drawing.Size(324, 24);
            this.comboBox_bilheteira.TabIndex = 25;
            this.comboBox_bilheteira.SelectedIndexChanged += new System.EventHandler(this.comboBox_bilheteira_SelectedIndexChanged);
            // 
            // comboBox_funcionario_cc
            // 
            this.comboBox_funcionario_cc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_funcionario_cc.FormattingEnabled = true;
            this.comboBox_funcionario_cc.Location = new System.Drawing.Point(653, 292);
            this.comboBox_funcionario_cc.Name = "comboBox_funcionario_cc";
            this.comboBox_funcionario_cc.Size = new System.Drawing.Size(132, 24);
            this.comboBox_funcionario_cc.TabIndex = 26;
            this.comboBox_funcionario_cc.SelectedIndexChanged += new System.EventHandler(this.comboBox_funcionario_cc_SelectedIndexChanged);
            // 
            // AdicionarBilhete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox_funcionario_cc);
            this.Controls.Add(this.comboBox_bilheteira);
            this.Controls.Add(this.comboBox_jz);
            this.Controls.Add(this.comboBox_genero);
            this.Controls.Add(this.button_adicionar);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.dateTimePicker_data_compra);
            this.Controls.Add(this.dateTimePicker_data_nascimento);
            this.Controls.Add(this.textBox_preco);
            this.Controls.Add(this.textBox_cc);
            this.Controls.Add(this.textBox_nome);
            this.Controls.Add(this.label_data_compra);
            this.Controls.Add(this.label_jz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_cc_funcionario);
            this.Controls.Add(this.label_cc_visitante);
            this.Controls.Add(this.label_preco);
            this.Controls.Add(this.label_id_bilheteira);
            this.Controls.Add(this.label_data_nascimento);
            this.Controls.Add(this.label_genero);
            this.Controls.Add(this.label_nome_visitante);
            this.Controls.Add(this.label1);
            this.Name = "AdicionarBilhete";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdicionarBilhete_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_nome_visitante;
        private System.Windows.Forms.Label label_genero;
        private System.Windows.Forms.Label label_data_nascimento;
        private System.Windows.Forms.Label label_id_bilheteira;
        private System.Windows.Forms.Label label_preco;
        private System.Windows.Forms.Label label_cc_visitante;
        private System.Windows.Forms.Label label_cc_funcionario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_jz;
        private System.Windows.Forms.Label label_data_compra;
        private System.Windows.Forms.TextBox textBox_nome;
        private System.Windows.Forms.TextBox textBox_cc;
        private System.Windows.Forms.TextBox textBox_preco;
        private System.Windows.Forms.DateTimePicker dateTimePicker_data_nascimento;
        private System.Windows.Forms.DateTimePicker dateTimePicker_data_compra;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_adicionar;
        private System.Windows.Forms.ComboBox comboBox_genero;
        private System.Windows.Forms.ComboBox comboBox_jz;
        private System.Windows.Forms.ComboBox comboBox_bilheteira;
        private System.Windows.Forms.ComboBox comboBox_funcionario_cc;
    }
}