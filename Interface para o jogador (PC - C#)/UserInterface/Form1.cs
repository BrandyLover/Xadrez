using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        static int movs = 0;
        static string lastMov = null;


        private string sendToPhp(string Data) {
            string responseText = null;
            try {
                //string url = "http://remotechess.esy.es/echo2i.php";
                string url = "http://localhost/Xadrez/MySQLaccess.php";
                //string str = textBox.Text;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                // = str;//"message=" + str;
                byte[] postBytes = Encoding.ASCII.GetBytes(Data);
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = postBytes.Length;
                Stream requestStream = req.GetRequestStream();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                //Stream resStream = response.GetResponseStream();

                var sr = new StreamReader(response.GetResponseStream());
                responseText = sr.ReadToEnd();

            }
            catch (WebException) {
                responseText = "Please Check Your Internet Connection";
                MessageBox.Show("Please Check Your Internet Connection");
            }
            catch (Exception) {
                responseText = "outro erro";
            }
            //richTextBox.AppendText(responseText + "\r");
            return responseText;
        }

        private void btn_send_Click(object sender, EventArgs e) {
            if (textBox1.Text.Length > 0) {
                //sendToPhp("put=" + textBox.Text);
                richTextBox1.AppendText(sendToPhp("put=" + textBox1.Text) + "\r");
            }
            else {
                richTextBox1.AppendText("informe o dado a ser insserido no banco de dados!\r");
            }
        }

        private void btn_done_Click(object sender, EventArgs e) {
            if (rb_br.Checked)
                richTextBox1.AppendText(sendToPhp("sys=" + "DONEB") + "\r");
            else
                richTextBox1.AppendText(sendToPhp("sys=" + "DONEF") + "\r");
        }

        private void btn_read_Click(object sender, EventArgs e) {
            //sendToPhp("get=");
            //richTextBox.AppendText( sendToPhp("get=") + "\r");
            string a = sendToPhp("get=");
            /*string b = string.Empty;

            for (int i = 0; a[i] != 'm' && i<a.Length; i++) {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }
            if (b.Length > 0) {
                int val = int.Parse(b);
                if (movs < val) {
                    richTextBox1.AppendText("new mov!\r");
                    movs = val;
                }
            }*/

            richTextBox1.AppendText(a + "\r");
        }

        private void btn_clear_Click(object sender, EventArgs e) {
            richTextBox1.Clear();
        }

        private void btn_check_Click(object sender, EventArgs e) {
            string a = sendToPhp("sinc=" + movs.ToString());
            richTextBox1.AppendText(a + "\r");

            string b = string.Empty;

            for (int i = 0; a[i] != ' ' && i < a.Length - 1; i++) {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }
            if (b.Length > 0) {
                int val = int.Parse(b);
                if (movs < val) {
                    richTextBox1.AppendText("new mov!\r");
                    movs = val;
                }
            }
        }
    }
}
