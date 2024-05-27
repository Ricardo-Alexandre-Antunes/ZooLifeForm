namespace ZooLifeForm
{
    partial class RecintosList
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
            this.lista_resultados_recintos = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.zOOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escolherTipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habitatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilheteiraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restauraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_nome_recinto = new System.Windows.Forms.Label();
            this.label_estado_recinto = new System.Windows.Forms.Label();
            this.label_recinto_jz = new System.Windows.Forms.Label();
            this.textbox_nome_recinto = new System.Windows.Forms.TextBox();
            this.textbox_estado_recinto = new System.Windows.Forms.TextBox();
            this.textbox_recinto_jz = new System.Windows.Forms.TextBox();
            this.label_capacidadeMax_recinto = new System.Windows.Forms.Label();
            this.textbox_capacidadeMax_recinto = new System.Windows.Forms.TextBox();
            this.label_n_habitaculos_recinto = new System.Windows.Forms.Label();
            this.textbox_n_habitaculos_recinto = new System.Windows.Forms.TextBox();
            this.button_adicionar_recinto = new System.Windows.Forms.Button();
            this.butto_remover_recinto = new System.Windows.Forms.Button();
            this.label_bilhetes_vendidos_recinto = new System.Windows.Forms.Label();
            this.textbox_bilhetes_vendidos_recinto = new System.Windows.Forms.TextBox();
            this.label_lista_habitaculos_recinto = new System.Windows.Forms.Label();
            this.listBox_habitaculos_recinto = new System.Windows.Forms.ListBox();
            this.button_adicionar_habitaculo = new System.Windows.Forms.Button();
            this.button_remover_habitaculo = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista_resultados_recintos
            // 
            this.lista_resultados_recintos.FormattingEnabled = true;
            this.lista_resultados_recintos.ItemHeight = 16;
            this.lista_resultados_recintos.Location = new System.Drawing.Point(12, 43);
            this.lista_resultados_recintos.Name = "lista_resultados_recintos";
            this.lista_resultados_recintos.Size = new System.Drawing.Size(199, 404);
            this.lista_resultados_recintos.Sorted = true;
            this.lista_resultados_recintos.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zOOToolStripMenuItem,
            this.escolherTipoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // zOOToolStripMenuItem
            // 
            this.zOOToolStripMenuItem.Name = "zOOToolStripMenuItem";
            this.zOOToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.zOOToolStripMenuItem.Text = "Escolher Zoo";
            this.zOOToolStripMenuItem.Click += new System.EventHandler(this.zOOToolStripMenuItem_Click);
            // 
            // escolherTipoToolStripMenuItem
            // 
            this.escolherTipoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habitatToolStripMenuItem,
            this.bilheteiraToolStripMenuItem,
            this.restauraçãoToolStripMenuItem,
            this.outroToolStripMenuItem});
            this.escolherTipoToolStripMenuItem.Name = "escolherTipoToolStripMenuItem";
            this.escolherTipoToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.escolherTipoToolStripMenuItem.Text = "Escolher Tipo";
            // 
            // habitatToolStripMenuItem
            // 
            this.habitatToolStripMenuItem.Name = "habitatToolStripMenuItem";
            this.habitatToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.habitatToolStripMenuItem.Text = "Habitat";
            // 
            // bilheteiraToolStripMenuItem
            // 
            this.bilheteiraToolStripMenuItem.Name = "bilheteiraToolStripMenuItem";
            this.bilheteiraToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.bilheteiraToolStripMenuItem.Text = "Bilheteira";
            // 
            // restauraçãoToolStripMenuItem
            // 
            this.restauraçãoToolStripMenuItem.Name = "restauraçãoToolStripMenuItem";
            this.restauraçãoToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.restauraçãoToolStripMenuItem.Text = "Restauração";
            // 
            // outroToolStripMenuItem
            // 
            this.outroToolStripMenuItem.Name = "outroToolStripMenuItem";
            this.outroToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.outroToolStripMenuItem.Text = "Outro";
            // 
            // label_nome_recinto
            // 
            this.label_nome_recinto.AutoSize = true;
            this.label_nome_recinto.Location = new System.Drawing.Point(247, 56);
            this.label_nome_recinto.Name = "label_nome_recinto";
            this.label_nome_recinto.Size = new System.Drawing.Size(44, 16);
            this.label_nome_recinto.TabIndex = 2;
            this.label_nome_recinto.Text = "Nome";
            // 
            // label_estado_recinto
            // 
            this.label_estado_recinto.AutoSize = true;
            this.label_estado_recinto.Location = new System.Drawing.Point(247, 100);
            this.label_estado_recinto.Name = "label_estado_recinto";
            this.label_estado_recinto.Size = new System.Drawing.Size(50, 16);
            this.label_estado_recinto.TabIndex = 3;
            this.label_estado_recinto.Text = "Estado";
            // 
            // label_recinto_jz
            // 
            this.label_recinto_jz.AutoSize = true;
            this.label_recinto_jz.Location = new System.Drawing.Point(247, 142);
            this.label_recinto_jz.Name = "label_recinto_jz";
            this.label_recinto_jz.Size = new System.Drawing.Size(112, 16);
            this.label_recinto_jz.TabIndex = 4;
            this.label_recinto_jz.Text = "Jardim Zoológico";
            // 
            // textbox_nome_recinto
            // 
            this.textbox_nome_recinto.Location = new System.Drawing.Point(307, 53);
            this.textbox_nome_recinto.Name = "textbox_nome_recinto";
            this.textbox_nome_recinto.ReadOnly = true;
            this.textbox_nome_recinto.Size = new System.Drawing.Size(522, 22);
            this.textbox_nome_recinto.TabIndex = 5;
            // 
            // textbox_estado_recinto
            // 
            this.textbox_estado_recinto.Location = new System.Drawing.Point(307, 97);
            this.textbox_estado_recinto.Name = "textbox_estado_recinto";
            this.textbox_estado_recinto.ReadOnly = true;
            this.textbox_estado_recinto.Size = new System.Drawing.Size(522, 22);
            this.textbox_estado_recinto.TabIndex = 6;
            // 
            // textbox_recinto_jz
            // 
            this.textbox_recinto_jz.Location = new System.Drawing.Point(365, 139);
            this.textbox_recinto_jz.Name = "textbox_recinto_jz";
            this.textbox_recinto_jz.ReadOnly = true;
            this.textbox_recinto_jz.Size = new System.Drawing.Size(464, 22);
            this.textbox_recinto_jz.TabIndex = 7;
            // 
            // label_capacidadeMax_recinto
            // 
            this.label_capacidadeMax_recinto.AutoSize = true;
            this.label_capacidadeMax_recinto.Location = new System.Drawing.Point(247, 184);
            this.label_capacidadeMax_recinto.Name = "label_capacidadeMax_recinto";
            this.label_capacidadeMax_recinto.Size = new System.Drawing.Size(132, 16);
            this.label_capacidadeMax_recinto.TabIndex = 10;
            this.label_capacidadeMax_recinto.Text = "Capacidade Máxima";
            this.label_capacidadeMax_recinto.Visible = false;
            // 
            // textbox_capacidadeMax_recinto
            // 
            this.textbox_capacidadeMax_recinto.Location = new System.Drawing.Point(385, 181);
            this.textbox_capacidadeMax_recinto.Name = "textbox_capacidadeMax_recinto";
            this.textbox_capacidadeMax_recinto.ReadOnly = true;
            this.textbox_capacidadeMax_recinto.Size = new System.Drawing.Size(444, 22);
            this.textbox_capacidadeMax_recinto.TabIndex = 11;
            this.textbox_capacidadeMax_recinto.Visible = false;
            // 
            // label_n_habitaculos_recinto
            // 
            this.label_n_habitaculos_recinto.AutoSize = true;
            this.label_n_habitaculos_recinto.Location = new System.Drawing.Point(247, 261);
            this.label_n_habitaculos_recinto.Name = "label_n_habitaculos_recinto";
            this.label_n_habitaculos_recinto.Size = new System.Drawing.Size(146, 16);
            this.label_n_habitaculos_recinto.TabIndex = 12;
            this.label_n_habitaculos_recinto.Text = "Número de habitáculos";
            // 
            // textbox_n_habitaculos_recinto
            // 
            this.textbox_n_habitaculos_recinto.Location = new System.Drawing.Point(399, 261);
            this.textbox_n_habitaculos_recinto.Name = "textbox_n_habitaculos_recinto";
            this.textbox_n_habitaculos_recinto.ReadOnly = true;
            this.textbox_n_habitaculos_recinto.Size = new System.Drawing.Size(62, 22);
            this.textbox_n_habitaculos_recinto.TabIndex = 13;
            this.textbox_n_habitaculos_recinto.Visible = false;
            // 
            // button_adicionar_recinto
            // 
            this.button_adicionar_recinto.Location = new System.Drawing.Point(541, 395);
            this.button_adicionar_recinto.Name = "button_adicionar_recinto";
            this.button_adicionar_recinto.Size = new System.Drawing.Size(144, 43);
            this.button_adicionar_recinto.TabIndex = 15;
            this.button_adicionar_recinto.Text = "Adicionar Recinto";
            this.button_adicionar_recinto.UseVisualStyleBackColor = true;
            // 
            // butto_remover_recinto
            // 
            this.butto_remover_recinto.Location = new System.Drawing.Point(691, 395);
            this.butto_remover_recinto.Name = "butto_remover_recinto";
            this.butto_remover_recinto.Size = new System.Drawing.Size(138, 43);
            this.butto_remover_recinto.TabIndex = 16;
            this.butto_remover_recinto.Text = "Remover Recinto";
            this.butto_remover_recinto.UseVisualStyleBackColor = true;
            this.butto_remover_recinto.Click += new System.EventHandler(this.butto_remover_recinto_Click);
            // 
            // label_bilhetes_vendidos_recinto
            // 
            this.label_bilhetes_vendidos_recinto.AutoSize = true;
            this.label_bilhetes_vendidos_recinto.Location = new System.Drawing.Point(247, 226);
            this.label_bilhetes_vendidos_recinto.Name = "label_bilhetes_vendidos_recinto";
            this.label_bilhetes_vendidos_recinto.Size = new System.Drawing.Size(116, 16);
            this.label_bilhetes_vendidos_recinto.TabIndex = 17;
            this.label_bilhetes_vendidos_recinto.Text = "Bilhetes Vendidos";
            this.label_bilhetes_vendidos_recinto.Visible = false;
            // 
            // textbox_bilhetes_vendidos_recinto
            // 
            this.textbox_bilhetes_vendidos_recinto.Location = new System.Drawing.Point(369, 223);
            this.textbox_bilhetes_vendidos_recinto.Name = "textbox_bilhetes_vendidos_recinto";
            this.textbox_bilhetes_vendidos_recinto.ReadOnly = true;
            this.textbox_bilhetes_vendidos_recinto.Size = new System.Drawing.Size(460, 22);
            this.textbox_bilhetes_vendidos_recinto.TabIndex = 18;
            this.textbox_bilhetes_vendidos_recinto.Visible = false;
            // 
            // label_lista_habitaculos_recinto
            // 
            this.label_lista_habitaculos_recinto.AutoSize = true;
            this.label_lista_habitaculos_recinto.Location = new System.Drawing.Point(528, 267);
            this.label_lista_habitaculos_recinto.Name = "label_lista_habitaculos_recinto";
            this.label_lista_habitaculos_recinto.Size = new System.Drawing.Size(126, 16);
            this.label_lista_habitaculos_recinto.TabIndex = 19;
            this.label_lista_habitaculos_recinto.Text = "Lista de habitáculos";
            this.label_lista_habitaculos_recinto.Visible = false;
            // 
            // listBox_habitaculos_recinto
            // 
            this.listBox_habitaculos_recinto.FormattingEnabled = true;
            this.listBox_habitaculos_recinto.ItemHeight = 16;
            this.listBox_habitaculos_recinto.Location = new System.Drawing.Point(660, 261);
            this.listBox_habitaculos_recinto.Name = "listBox_habitaculos_recinto";
            this.listBox_habitaculos_recinto.Size = new System.Drawing.Size(169, 100);
            this.listBox_habitaculos_recinto.Sorted = true;
            this.listBox_habitaculos_recinto.TabIndex = 20;
            this.listBox_habitaculos_recinto.Visible = false;
            this.listBox_habitaculos_recinto.SelectedIndexChanged += new System.EventHandler(this.listBox_habitaculos_recinto_SelectedIndexChanged);
            // 
            // button_adicionar_habitaculo
            // 
            this.button_adicionar_habitaculo.Location = new System.Drawing.Point(382, 395);
            this.button_adicionar_habitaculo.Name = "button_adicionar_habitaculo";
            this.button_adicionar_habitaculo.Size = new System.Drawing.Size(153, 43);
            this.button_adicionar_habitaculo.TabIndex = 21;
            this.button_adicionar_habitaculo.Text = "Adicionar Habitáculo";
            this.button_adicionar_habitaculo.UseVisualStyleBackColor = true;
            this.button_adicionar_habitaculo.Visible = false;
            // 
            // button_remover_habitaculo
            // 
            this.button_remover_habitaculo.Location = new System.Drawing.Point(229, 395);
            this.button_remover_habitaculo.Name = "button_remover_habitaculo";
            this.button_remover_habitaculo.Size = new System.Drawing.Size(147, 43);
            this.button_remover_habitaculo.TabIndex = 22;
            this.button_remover_habitaculo.Text = "Remover Habitáculo";
            this.button_remover_habitaculo.UseVisualStyleBackColor = true;
            this.button_remover_habitaculo.Visible = false;
            // 
            // RecintosList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 450);
            this.Controls.Add(this.button_remover_habitaculo);
            this.Controls.Add(this.button_adicionar_habitaculo);
            this.Controls.Add(this.listBox_habitaculos_recinto);
            this.Controls.Add(this.label_lista_habitaculos_recinto);
            this.Controls.Add(this.textbox_bilhetes_vendidos_recinto);
            this.Controls.Add(this.label_bilhetes_vendidos_recinto);
            this.Controls.Add(this.butto_remover_recinto);
            this.Controls.Add(this.button_adicionar_recinto);
            this.Controls.Add(this.textbox_n_habitaculos_recinto);
            this.Controls.Add(this.label_n_habitaculos_recinto);
            this.Controls.Add(this.textbox_capacidadeMax_recinto);
            this.Controls.Add(this.label_capacidadeMax_recinto);
            this.Controls.Add(this.textbox_recinto_jz);
            this.Controls.Add(this.textbox_estado_recinto);
            this.Controls.Add(this.textbox_nome_recinto);
            this.Controls.Add(this.label_recinto_jz);
            this.Controls.Add(this.label_estado_recinto);
            this.Controls.Add(this.label_nome_recinto);
            this.Controls.Add(this.lista_resultados_recintos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RecintosList";
            this.Text = "ZooLife - Lista de Recintos";
            this.Load += new System.EventHandler(this.RecintosList_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lista_resultados_recintos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zOOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escolherTipoToolStripMenuItem;
        private System.Windows.Forms.Label label_nome_recinto;
        private System.Windows.Forms.Label label_estado_recinto;
        private System.Windows.Forms.Label label_recinto_jz;
        private System.Windows.Forms.TextBox textbox_nome_recinto;
        private System.Windows.Forms.TextBox textbox_estado_recinto;
        private System.Windows.Forms.TextBox textbox_recinto_jz;
        private System.Windows.Forms.Label label_capacidadeMax_recinto;
        private System.Windows.Forms.TextBox textbox_capacidadeMax_recinto;
        private System.Windows.Forms.Label label_n_habitaculos_recinto;
        private System.Windows.Forms.TextBox textbox_n_habitaculos_recinto;
        private System.Windows.Forms.Button button_adicionar_recinto;
        private System.Windows.Forms.Button butto_remover_recinto;
        private System.Windows.Forms.ToolStripMenuItem habitatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilheteiraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restauraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outroToolStripMenuItem;
        private System.Windows.Forms.Label label_bilhetes_vendidos_recinto;
        private System.Windows.Forms.TextBox textbox_bilhetes_vendidos_recinto;
        private System.Windows.Forms.Label label_lista_habitaculos_recinto;
        private System.Windows.Forms.ListBox listBox_habitaculos_recinto;
        private System.Windows.Forms.Button button_adicionar_habitaculo;
        private System.Windows.Forms.Button button_remover_habitaculo;
    }
}