namespace UserInterface_2 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btn_check = new System.Windows.Forms.Button();
			this.btn_read = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.btn_undo = new System.Windows.Forms.Button();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btn_mover = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lb_1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lb_equipe = new System.Windows.Forms.ToolStripStatusLabel();
			this.lb_space1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lb_2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lb_status = new System.Windows.Forms.ToolStripStatusLabel();
			this.lb_space2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lb_3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lb_tempo = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tempo = new System.Windows.Forms.ToolStripMenuItem();
			this.t_1s = new System.Windows.Forms.ToolStripMenuItem();
			this.t_2s = new System.Windows.Forms.ToolStripMenuItem();
			this.t_3s = new System.Windows.Forms.ToolStripMenuItem();
			this.t_5s = new System.Windows.Forms.ToolStripMenuItem();
			this.t_7s = new System.Windows.Forms.ToolStripMenuItem();
			this.t_10s = new System.Windows.Forms.ToolStripMenuItem();
			this.t_15s = new System.Windows.Forms.ToolStripMenuItem();
			this.equipeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eq_br = new System.Windows.Forms.ToolStripMenuItem();
			this.eq_fr = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(13, 83);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(399, 219);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			// 
			// timer1
			// 
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// textBox1
			// 
			this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.textBox1.Location = new System.Drawing.Point(12, 31);
			this.textBox1.MaxLength = 10;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(129, 20);
			this.textBox1.TabIndex = 2;
			// 
			// btn_check
			// 
			this.btn_check.Location = new System.Drawing.Point(283, 27);
			this.btn_check.Name = "btn_check";
			this.btn_check.Size = new System.Drawing.Size(129, 23);
			this.btn_check.TabIndex = 3;
			this.btn_check.Text = "Verificar";
			this.btn_check.UseVisualStyleBackColor = true;
			this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
			// 
			// btn_read
			// 
			this.btn_read.Location = new System.Drawing.Point(283, 57);
			this.btn_read.Name = "btn_read";
			this.btn_read.Size = new System.Drawing.Size(129, 23);
			this.btn_read.TabIndex = 4;
			this.btn_read.Text = "Ler todos";
			this.btn_read.UseVisualStyleBackColor = true;
			this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
			// 
			// btn_clear
			// 
			this.btn_clear.Location = new System.Drawing.Point(12, 308);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(100, 23);
			this.btn_clear.TabIndex = 5;
			this.btn_clear.Text = "Limpar";
			this.btn_clear.UseVisualStyleBackColor = true;
			this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
			// 
			// btn_undo
			// 
			this.btn_undo.Enabled = false;
			this.btn_undo.Location = new System.Drawing.Point(148, 57);
			this.btn_undo.Name = "btn_undo";
			this.btn_undo.Size = new System.Drawing.Size(129, 23);
			this.btn_undo.TabIndex = 15;
			this.btn_undo.Text = "Desfazer";
			this.btn_undo.UseVisualStyleBackColor = true;
			this.btn_undo.Click += new System.EventHandler(this.btn_undo_Click);
			// 
			// richTextBox2
			// 
			this.richTextBox2.Location = new System.Drawing.Point(417, 27);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(100, 303);
			this.richTextBox2.TabIndex = 16;
			this.richTextBox2.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.textBox2.Location = new System.Drawing.Point(12, 57);
			this.textBox2.MaxLength = 10;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(129, 20);
			this.textBox2.TabIndex = 17;
			// 
			// btn_mover
			// 
			this.btn_mover.Enabled = false;
			this.btn_mover.Location = new System.Drawing.Point(148, 27);
			this.btn_mover.Name = "btn_mover";
			this.btn_mover.Size = new System.Drawing.Size(129, 23);
			this.btn_mover.TabIndex = 18;
			this.btn_mover.Text = "Mover";
			this.btn_mover.UseVisualStyleBackColor = true;
			this.btn_mover.Click += new System.EventHandler(this.btn_mover_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_1,
            this.lb_equipe,
            this.lb_space1,
            this.lb_2,
            this.lb_status,
            this.lb_space2,
            this.lb_3,
            this.lb_tempo});
			this.statusStrip1.Location = new System.Drawing.Point(0, 339);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(529, 22);
			this.statusStrip1.TabIndex = 19;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lb_1
			// 
			this.lb_1.Name = "lb_1";
			this.lb_1.Size = new System.Drawing.Size(49, 17);
			this.lb_1.Text = "Equipe: ";
			// 
			// lb_equipe
			// 
			this.lb_equipe.Name = "lb_equipe";
			this.lb_equipe.Size = new System.Drawing.Size(21, 17);
			this.lb_equipe.Text = "BR";
			// 
			// lb_space1
			// 
			this.lb_space1.Name = "lb_space1";
			this.lb_space1.Size = new System.Drawing.Size(37, 17);
			this.lb_space1.Text = "          ";
			// 
			// lb_2
			// 
			this.lb_2.Name = "lb_2";
			this.lb_2.Size = new System.Drawing.Size(45, 17);
			this.lb_2.Text = "Status: ";
			// 
			// lb_status
			// 
			this.lb_status.Name = "lb_status";
			this.lb_status.Size = new System.Drawing.Size(104, 17);
			this.lb_status.Text = "clique em verificar";
			// 
			// lb_space2
			// 
			this.lb_space2.Name = "lb_space2";
			this.lb_space2.Size = new System.Drawing.Size(37, 17);
			this.lb_space2.Text = "          ";
			// 
			// lb_3
			// 
			this.lb_3.Name = "lb_3";
			this.lb_3.Size = new System.Drawing.Size(50, 17);
			this.lb_3.Text = "Tempo: ";
			// 
			// lb_tempo
			// 
			this.lb_tempo.Name = "lb_tempo";
			this.lb_tempo.Size = new System.Drawing.Size(24, 17);
			this.lb_tempo.Text = "5 s.";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(529, 24);
			this.menuStrip1.TabIndex = 20;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// configuraçõesToolStripMenuItem
			// 
			this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tempo,
            this.equipeToolStripMenuItem});
			this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
			this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
			this.configuraçõesToolStripMenuItem.Text = "Configurações";
			// 
			// tempo
			// 
			this.tempo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.t_1s,
            this.t_2s,
            this.t_3s,
            this.t_5s,
            this.t_7s,
            this.t_10s,
            this.t_15s});
			this.tempo.Name = "tempo";
			this.tempo.Size = new System.Drawing.Size(189, 22);
			this.tempo.Text = "Tempo de atualização";
			// 
			// t_1s
			// 
			this.t_1s.Name = "t_1s";
			this.t_1s.Size = new System.Drawing.Size(141, 22);
			this.t_1s.Text = "1 Segundo";
			this.t_1s.Click += new System.EventHandler(this.t_1s_Click);
			// 
			// t_2s
			// 
			this.t_2s.Name = "t_2s";
			this.t_2s.Size = new System.Drawing.Size(141, 22);
			this.t_2s.Text = "2 Segundos";
			this.t_2s.Click += new System.EventHandler(this.t_2s_Click);
			// 
			// t_3s
			// 
			this.t_3s.Name = "t_3s";
			this.t_3s.Size = new System.Drawing.Size(141, 22);
			this.t_3s.Text = "3 Segundos";
			this.t_3s.Click += new System.EventHandler(this.t_3s_Click);
			// 
			// t_5s
			// 
			this.t_5s.Name = "t_5s";
			this.t_5s.Size = new System.Drawing.Size(141, 22);
			this.t_5s.Text = "5 Segundos";
			this.t_5s.Click += new System.EventHandler(this.t_5s_Click);
			// 
			// t_7s
			// 
			this.t_7s.Name = "t_7s";
			this.t_7s.Size = new System.Drawing.Size(141, 22);
			this.t_7s.Text = "7 Segundos";
			this.t_7s.Click += new System.EventHandler(this.t_7s_Click);
			// 
			// t_10s
			// 
			this.t_10s.Name = "t_10s";
			this.t_10s.Size = new System.Drawing.Size(141, 22);
			this.t_10s.Text = "10 Segundos";
			this.t_10s.Click += new System.EventHandler(this.t_10s_Click);
			// 
			// t_15s
			// 
			this.t_15s.Name = "t_15s";
			this.t_15s.Size = new System.Drawing.Size(141, 22);
			this.t_15s.Text = "15 Segundos";
			this.t_15s.Click += new System.EventHandler(this.t_15s_Click);
			// 
			// equipeToolStripMenuItem
			// 
			this.equipeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eq_br,
            this.eq_fr});
			this.equipeToolStripMenuItem.Name = "equipeToolStripMenuItem";
			this.equipeToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.equipeToolStripMenuItem.Text = "Equipe";
			// 
			// eq_br
			// 
			this.eq_br.Name = "eq_br";
			this.eq_br.Size = new System.Drawing.Size(109, 22);
			this.eq_br.Text = "Brasil";
			this.eq_br.Click += new System.EventHandler(this.eq_br_Click);
			// 
			// eq_fr
			// 
			this.eq_fr.Name = "eq_fr";
			this.eq_fr.Size = new System.Drawing.Size(109, 22);
			this.eq_fr.Text = "França";
			this.eq_fr.Click += new System.EventHandler(this.eq_fr_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(529, 361);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.btn_mover);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.richTextBox2);
			this.Controls.Add(this.btn_undo);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_read);
			this.Controls.Add(this.btn_check);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.richTextBox1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Button btn_undo;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btn_mover;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tempo;
		private System.Windows.Forms.ToolStripMenuItem t_2s;
		private System.Windows.Forms.ToolStripMenuItem t_3s;
		private System.Windows.Forms.ToolStripMenuItem t_5s;
		private System.Windows.Forms.ToolStripMenuItem t_7s;
		private System.Windows.Forms.ToolStripMenuItem t_10s;
		private System.Windows.Forms.ToolStripMenuItem t_15s;
		private System.Windows.Forms.ToolStripMenuItem t_1s;
		private System.Windows.Forms.ToolStripStatusLabel lb_1;
		private System.Windows.Forms.ToolStripMenuItem equipeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eq_br;
		private System.Windows.Forms.ToolStripMenuItem eq_fr;
		private System.Windows.Forms.ToolStripStatusLabel lb_equipe;
		private System.Windows.Forms.ToolStripStatusLabel lb_space1;
		private System.Windows.Forms.ToolStripStatusLabel lb_2;
		private System.Windows.Forms.ToolStripStatusLabel lb_status;
		private System.Windows.Forms.ToolStripStatusLabel lb_space2;
		private System.Windows.Forms.ToolStripStatusLabel lb_3;
		private System.Windows.Forms.ToolStripStatusLabel lb_tempo;
	}
}

