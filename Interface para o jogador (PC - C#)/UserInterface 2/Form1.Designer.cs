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
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.rbt_br = new System.Windows.Forms.RadioButton();
			this.rbt_fr = new System.Windows.Forms.RadioButton();
			this.btn_undo = new System.Windows.Forms.Button();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btn_mover = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(12, 96);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(534, 219);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			// 
			// timer1
			// 
			this.timer1.Interval = 10000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// textBox1
			// 
			this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.MaxLength = 10;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(129, 20);
			this.textBox1.TabIndex = 2;
			// 
			// btn_check
			// 
			this.btn_check.Location = new System.Drawing.Point(147, 67);
			this.btn_check.Name = "btn_check";
			this.btn_check.Size = new System.Drawing.Size(129, 23);
			this.btn_check.TabIndex = 3;
			this.btn_check.Text = "Check";
			this.btn_check.UseVisualStyleBackColor = true;
			this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
			// 
			// btn_read
			// 
			this.btn_read.Location = new System.Drawing.Point(282, 67);
			this.btn_read.Name = "btn_read";
			this.btn_read.Size = new System.Drawing.Size(129, 23);
			this.btn_read.TabIndex = 4;
			this.btn_read.Text = "Read";
			this.btn_read.UseVisualStyleBackColor = true;
			this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
			// 
			// btn_clear
			// 
			this.btn_clear.Location = new System.Drawing.Point(417, 67);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(129, 23);
			this.btn_clear.TabIndex = 5;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = true;
			this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(317, 12);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(230, 45);
			this.trackBar1.TabIndex = 6;
			this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::UserInterface_2.Properties.Resources.white;
			this.pictureBox1.Location = new System.Drawing.Point(282, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(29, 27);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(279, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Timer:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(321, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(19, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "off";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(414, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Interval:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(465, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(25, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = " - - -";
			// 
			// rbt_br
			// 
			this.rbt_br.AutoSize = true;
			this.rbt_br.Checked = true;
			this.rbt_br.Location = new System.Drawing.Point(147, 15);
			this.rbt_br.Name = "rbt_br";
			this.rbt_br.Size = new System.Drawing.Size(50, 17);
			this.rbt_br.TabIndex = 12;
			this.rbt_br.TabStop = true;
			this.rbt_br.Text = "Brasil";
			this.rbt_br.UseVisualStyleBackColor = true;
			// 
			// rbt_fr
			// 
			this.rbt_fr.AutoSize = true;
			this.rbt_fr.Location = new System.Drawing.Point(203, 15);
			this.rbt_fr.Name = "rbt_fr";
			this.rbt_fr.Size = new System.Drawing.Size(58, 17);
			this.rbt_fr.TabIndex = 13;
			this.rbt_fr.Text = "França";
			this.rbt_fr.UseVisualStyleBackColor = true;
			// 
			// btn_undo
			// 
			this.btn_undo.Location = new System.Drawing.Point(148, 37);
			this.btn_undo.Name = "btn_undo";
			this.btn_undo.Size = new System.Drawing.Size(128, 23);
			this.btn_undo.TabIndex = 15;
			this.btn_undo.Text = "Undo";
			this.btn_undo.UseVisualStyleBackColor = true;
			this.btn_undo.Click += new System.EventHandler(this.btn_undo_Click);
			// 
			// richTextBox2
			// 
			this.richTextBox2.Location = new System.Drawing.Point(550, 15);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(100, 303);
			this.richTextBox2.TabIndex = 16;
			this.richTextBox2.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.textBox2.Location = new System.Drawing.Point(12, 38);
			this.textBox2.MaxLength = 10;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(129, 20);
			this.textBox2.TabIndex = 17;
			// 
			// btn_mover
			// 
			this.btn_mover.Location = new System.Drawing.Point(12, 67);
			this.btn_mover.Name = "btn_mover";
			this.btn_mover.Size = new System.Drawing.Size(129, 23);
			this.btn_mover.TabIndex = 18;
			this.btn_mover.Text = "Mover";
			this.btn_mover.UseVisualStyleBackColor = true;
			this.btn_mover.Click += new System.EventHandler(this.btn_mover_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 327);
			this.Controls.Add(this.btn_mover);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.richTextBox2);
			this.Controls.Add(this.btn_undo);
			this.Controls.Add(this.rbt_fr);
			this.Controls.Add(this.rbt_br);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.btn_read);
			this.Controls.Add(this.btn_check);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.richTextBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbt_br;
        private System.Windows.Forms.RadioButton rbt_fr;
		private System.Windows.Forms.Button btn_undo;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btn_mover;
	}
}

