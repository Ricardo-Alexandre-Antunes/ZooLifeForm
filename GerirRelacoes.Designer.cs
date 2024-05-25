namespace ZooLifeForm
{
    partial class GerirRelacoes
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
            this.ListaAnimais1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NovaRelacao = new System.Windows.Forms.TextBox();
            this.ListaAnimais2 = new System.Windows.Forms.ListBox();
            this.AdicionarRelacao = new System.Windows.Forms.Button();
            this.CurRelacoes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RemoverRelacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gerir Relações";
            // 
            // ListaAnimais1
            // 
            this.ListaAnimais1.FormattingEnabled = true;
            this.ListaAnimais1.ItemHeight = 16;
            this.ListaAnimais1.Location = new System.Drawing.Point(201, 81);
            this.ListaAnimais1.Name = "ListaAnimais1";
            this.ListaAnimais1.Size = new System.Drawing.Size(140, 212);
            this.ListaAnimais1.TabIndex = 1;
            this.ListaAnimais1.SelectedIndexChanged += new System.EventHandler(this.ListaAnimais1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome da Relação";
            // 
            // NovaRelacao
            // 
            this.NovaRelacao.Location = new System.Drawing.Point(363, 158);
            this.NovaRelacao.Name = "NovaRelacao";
            this.NovaRelacao.Size = new System.Drawing.Size(100, 22);
            this.NovaRelacao.TabIndex = 3;
            // 
            // ListaAnimais2
            // 
            this.ListaAnimais2.FormattingEnabled = true;
            this.ListaAnimais2.ItemHeight = 16;
            this.ListaAnimais2.Location = new System.Drawing.Point(478, 81);
            this.ListaAnimais2.Name = "ListaAnimais2";
            this.ListaAnimais2.Size = new System.Drawing.Size(140, 212);
            this.ListaAnimais2.TabIndex = 4;
            this.ListaAnimais2.SelectedIndexChanged += new System.EventHandler(this.ListaAnimais2_SelectedIndexChanged);
            // 
            // AdicionarRelacao
            // 
            this.AdicionarRelacao.Location = new System.Drawing.Point(375, 186);
            this.AdicionarRelacao.Name = "AdicionarRelacao";
            this.AdicionarRelacao.Size = new System.Drawing.Size(75, 23);
            this.AdicionarRelacao.TabIndex = 5;
            this.AdicionarRelacao.Text = "Adicionar";
            this.AdicionarRelacao.UseVisualStyleBackColor = true;
            this.AdicionarRelacao.Click += new System.EventHandler(this.AdicionarRelacao_Click);
            // 
            // CurRelacoes
            // 
            this.CurRelacoes.FormattingEnabled = true;
            this.CurRelacoes.ItemHeight = 16;
            this.CurRelacoes.Location = new System.Drawing.Point(28, 332);
            this.CurRelacoes.Name = "CurRelacoes";
            this.CurRelacoes.Size = new System.Drawing.Size(723, 100);
            this.CurRelacoes.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Relações do Animal Selecionado";
            // 
            // RemoverRelacao
            // 
            this.RemoverRelacao.Location = new System.Drawing.Point(572, 438);
            this.RemoverRelacao.Name = "RemoverRelacao";
            this.RemoverRelacao.Size = new System.Drawing.Size(179, 23);
            this.RemoverRelacao.TabIndex = 8;
            this.RemoverRelacao.Text = "Remover Relação";
            this.RemoverRelacao.UseVisualStyleBackColor = true;
            this.RemoverRelacao.Click += new System.EventHandler(this.RemoverRelacao_Click);
            // 
            // GerirRelacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 473);
            this.Controls.Add(this.RemoverRelacao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CurRelacoes);
            this.Controls.Add(this.AdicionarRelacao);
            this.Controls.Add(this.ListaAnimais2);
            this.Controls.Add(this.NovaRelacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListaAnimais1);
            this.Controls.Add(this.label1);
            this.Name = "GerirRelacoes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ListaAnimais1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NovaRelacao;
        private System.Windows.Forms.ListBox ListaAnimais2;
        private System.Windows.Forms.Button AdicionarRelacao;
        private System.Windows.Forms.ListBox CurRelacoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RemoverRelacao;
    }
}