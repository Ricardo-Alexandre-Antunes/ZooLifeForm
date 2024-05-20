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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.escolherZooToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opção1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opção2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opção3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escolherHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escolherHabitáculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 44);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(154, 388);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
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
            this.escolherHabitáculoToolStripMenuItem.Click += new System.EventHandler(this.escolherHabitáculoToolStripMenuItem_Click);
            // 
            // AnimalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem escolherZooToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opção1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opção2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opção3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escolherHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escolherHabitáculoToolStripMenuItem;
    }
}