namespace UserInterface {
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
            this.btn_check = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rb_fr = new System.Windows.Forms.RadioButton();
            this.rb_br = new System.Windows.Forms.RadioButton();
            this.btn_done = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_read = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(12, 41);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(73, 23);
            this.btn_check.TabIndex = 17;
            this.btn_check.Text = "Check";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(391, 274);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // rb_fr
            // 
            this.rb_fr.AutoSize = true;
            this.rb_fr.Location = new System.Drawing.Point(328, 47);
            this.rb_fr.Name = "rb_fr";
            this.rb_fr.Size = new System.Drawing.Size(58, 17);
            this.rb_fr.TabIndex = 15;
            this.rb_fr.TabStop = true;
            this.rb_fr.Text = "França";
            this.rb_fr.UseVisualStyleBackColor = true;
            // 
            // rb_br
            // 
            this.rb_br.AutoSize = true;
            this.rb_br.Location = new System.Drawing.Point(272, 47);
            this.rb_br.Name = "rb_br";
            this.rb_br.Size = new System.Drawing.Size(50, 17);
            this.rb_br.TabIndex = 14;
            this.rb_br.TabStop = true;
            this.rb_br.Text = "Brasil";
            this.rb_br.UseVisualStyleBackColor = true;
            // 
            // btn_done
            // 
            this.btn_done.Location = new System.Drawing.Point(166, 41);
            this.btn_done.Name = "btn_done";
            this.btn_done.Size = new System.Drawing.Size(75, 23);
            this.btn_done.TabIndex = 13;
            this.btn_done.Text = "Done";
            this.btn_done.UseVisualStyleBackColor = true;
            this.btn_done.Click += new System.EventHandler(this.btn_done_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(328, 12);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 12;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(247, 12);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(75, 23);
            this.btn_read.TabIndex = 11;
            this.btn_read.Text = "Read";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(166, 12);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 10;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 20);
            this.textBox1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 356);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.rb_fr);
            this.Controls.Add(this.rb_br);
            this.Controls.Add(this.btn_done);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton rb_fr;
        private System.Windows.Forms.RadioButton rb_br;
        private System.Windows.Forms.Button btn_done;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox textBox1;
    }
}

