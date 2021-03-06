﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace UserInterface_2 {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		class Movimento {
			private int n_movs = 0;
			private string[] m = new string[2];

			public Movimento() {
				n_movs = 0;
				m[0] = null;
				m[1] = null;
			}

			public void Clear() {
				n_movs = 0;
			}

			public void SetMov(string m0) {
				n_movs = 1;
				m[0] = m0;
			}

			public void SetMov(string m0, string m1) {
				n_movs = 2;
				m[0] = m0;
				m[1] = m1;
			}

			public int GetNumMovs() {
				return n_movs;
			}

			public string GetMov(int n) {
				return m[n];
			}
		}

		Movimento mov_meu = new Movimento();			//meus movimentos na ultima rodada
		Movimento mov_dele = new Movimento();			//movimentos o oponente na ultima rodada

		static int n_total_movs = 0;
		static string equipe = "BR";

		private void enivaSerial(string text) {
/*			int[] v = new int[4];
			if(text.Length == 4) {
				v[0] = text[0] - 'a';
				v[1] = text[1] - '1';
				v[2] = text[2] - 'a';
				v[3] = text[3] - '1';
			} else if(text.Length == 5) {
				v[0] = text[0] - 'a';
				v[1] = text[1] - '1';
				v[2] = text[2] - 'a';
				v[3] = 10 * (text[3] - '1') + (text[4] - '1');
			} else
				return;				*/
			serialPort1.Write( text.Length.ToString() + text );
		}

		private string reverso(string text) {
			char[] c = new char[5];
			if(text.Length == 4) {
				c[3] = text[0];
				c[4] = text[1];
				c[0] = text[2];
				c[1] = text[3];
			}
			else if(text.Length == 5) {
				c[3] = text[0];
				c[4] = text[1];
				c[0] = text[2];
				c[1] = text[3];
				c[2] = text[4];
			}
			return c.ToString();
		}

		private string sendToPhp(string text) {
			try {
				string url = "http://remotechess.esy.es/MySQLaccess.php";
				//string url = "http://remotechess.esy.es/echo2i.php";		//versão mais antiga
				//string url = "http://localhost/my-site/MySQLaccess.php";
				//string str = textBox.Text;
				HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
				req.Method = "POST";
				// = str;//"message=" + str;
				byte[] postBytes = Encoding.ASCII.GetBytes(text);
				req.ContentType = "application/x-www-form-urlencoded";
				req.ContentLength = postBytes.Length;
				Stream requestStream = req.GetRequestStream();
				requestStream.Write(postBytes, 0, postBytes.Length);
				requestStream.Close();

				HttpWebResponse response = (HttpWebResponse)req.GetResponse();
				//Stream resStream = response.GetResponseStream();

				var sr = new StreamReader(response.GetResponseStream());
				return sr.ReadToEnd();

			} catch (WebException) {
				return "Please Check Your Internet Connection";
			} catch (Exception) {
				return "outro erro";
			}
		}
		private string parte(string text, int a, int b) {
			string res = string.Empty;
			for (int i = a; i < b; i++)
				res += text[i];
			return res;
		}
		private string finder(string text, string target) {
			string var = string.Empty;
			int i = 0, s = text.Length, a = 0, b;

			for (i = 0; i < s; i++) {
				if (text[i] == '=') {    //varre a string até encontrar o '='
					if (i > a) {
						b = i;
						var = parte(text, a, b);    //chama a função que estrai parte (entre a e b) da string
						if (var == target) {         //se a variavel for a mesma busca a resposta dela
							i++;
							a = i;
							//for (; i < s && ((i + 1) < s && !(text[i] == '&' && text[i + 1] == '&')); i++) ; //varre a string até o fim ou inicio da proxima
							bool e = false;
							for (; (i + 1) < s && !e; i++) {
								if (text[i] == '&' && text[i + 1] == '&') {
									e = true;
								}
							}
							if (e)
								b = i - 1;
							else
								b = s;
							return parte(text, a, b);
						} else {
							bool e = false;
							for (; (i + 2) < s && !e; i++) {
								if (text[i] == '&' && text[i + 1] == '&') {
									e = true;
								}
							}
							if (e)
								a = i + 1;
							else
								return string.Empty;
						}
					}
				}
			}
			return string.Empty;
		}

		private bool db_check() {
			string str1, str2;
			str1 = sendToPhp("team="+equipe);
			str2 = finder(str1, "tstate");
			if (str2 == "1") {                  //se receber "1" o oponente já concluiu sua jogada, se for "0" ele ainda está movimentando suas peças
				btn_mover.Enabled = true;
				btn_undo.Enabled = true;
				//btn_check.Enabled = false;
				btn_read.Enabled = false;
				timer1.Enabled = false;

				str2 = finder(str1, "doundo");   //1 para "DO" e 0 para "UNDO"
				if (str2 == "1") {
					str1 = sendToPhp("readn=" + n_total_movs);
					str2 = finder(str1, "errorn");
					if (str2.Length > 0) {
						richTextBox1.AppendText("Erro: o outro jogador fez mais do que dois movimentos em uma só rodada\r");
					} else {
						str2 = finder(str1, "n");
						if (str2 == "1") {
							string m0 = finder(str1, "m0");
							richTextBox2.AppendText(m0 + "\r");
							richTextBox1.AppendText("1 (um) moimento recebido\r");
							mov_dele.SetMov(m0);                    //mov_dele.AddMovimento(finder(str1, "m0"));
							n_total_movs++;

							//move a peça
							enivaSerial(m0);

						} else if (str2 == "2") {
							string m0 = finder(str1, "m0");
							string m1 = finder(str1, "m1");
							richTextBox2.AppendText(m0 + "\r" + m1 + "\r");
							richTextBox1.AppendText("2 (dois) moimentos recebidos\r");
							mov_dele.SetMov(m0, m1);             //mov_dele.SetMovimentos(finder(str1, "m0"), finder(str1, "m1"));
							n_total_movs += 2;

							//move as peças
							enivaSerial(m0);
							enivaSerial(m1);

						} else {
							mov_dele.Clear();
							richTextBox1.AppendText("nenhum movimento\r");
						}
					}
				} else {
					if(mov_meu.GetNumMovs() == 1) {
						enivaSerial("--" + reverso(mov_meu.GetMov(0)));	//manda o Tabuleiro desfazer o ultimo (indicado pelos dois '-')

						richTextBox1.AppendText("desfazer 1 movimentos:\r" + mov_meu.GetMov(0) + "\r");
						richTextBox2.Undo();
						n_total_movs--;
						mov_meu.Clear();

						//desfazer o ultimo movimento (está salvo no objeto "mov_meu" da classe Moimentos)

					} else {
						enivaSerial("--" + reverso(mov_meu.GetMov(0))); //manda o Tabuleiro desfazer o ultimo (indicado pelos dois '-')
						enivaSerial("--" + reverso(mov_meu.GetMov(1)));	//pelo numero de caracteres não se confunde com um movimento normal

						richTextBox1.AppendText("desfazer 2 movimentos:\r" + mov_meu.GetMov(0) + "\r" + mov_meu.GetMov(1) + "\r");
						richTextBox2.Undo();
						n_total_movs -= 2;
						mov_meu.Clear();

						//desfazer os dois ultimos movimentos (estam salvos nas strings last_m0 e last_m1)

					}
				}
				return true;
			} else {
				richTextBox1.AppendText(".");
				return false;
			}
		}

		private void mover() {
			string str1, str2;

			if (mov_meu.GetNumMovs() == 1) {
				str1 = sendToPhp("mover=" + equipe + "&&m0=" + mov_meu.GetMov(0));
			} else { //mov_meu.GetNumMovs() == 2
				str1 = sendToPhp("mover=" + equipe + "&&m0=" + mov_meu.GetMov(0) + "&&m1=" + mov_meu.GetMov(1));
			}
			str2 = finder(str1, "status");
			if (str2 == "1") {       //nenhum erro
				richTextBox1.AppendText("Dados inseridos com sucesso\r");

				if (mov_meu.GetNumMovs() == 1) {
					richTextBox2.AppendText(mov_meu.GetMov(0) + "\r");
					n_total_movs++;

					enivaSerial(mov_meu.GetMov(0));
				} else {
					richTextBox2.AppendText(mov_meu.GetMov(0) + "\r" + mov_meu.GetMov(1) + "\r");
					n_total_movs += 2;

					enivaSerial(mov_meu.GetMov(0));
					enivaSerial(mov_meu.GetMov(1));
				}

				btn_mover.Enabled = false;
				btn_undo.Enabled = false;
				//btn_check.Enabled = true;
				btn_read.Enabled = true;
				timer1.Enabled = true;

			} else if (str2 == "-1") {
				richTextBox1.AppendText("Erro: apenas parte dos movimentos foi desfeita.\rTry again!\r");
			} else {       //algum erro
				str2 = finder(str1, "error");
				if (str2.Length > 0) {
					richTextBox1.AppendText("Erro: " + str2 + "\r");
				} else {
					richTextBox1.AppendText("Erro desconhecido\r");
				}
			}
		}

		private string read_all() {
			string str1, str2;
			str1 = sendToPhp("readall=0");
			str2 = finder(str1, "n");

			if (str2 != "0") {
				int j;
				if (int.TryParse(str2, out j)) {
					//Console.WriteLine(j);
					string[] l = new string[j];
					for (int i = 0; i < j; i++) {
						l[i] = finder(str1, "l" + i);
						richTextBox1.AppendText("l" + i + " => " + l[i] + "\r");
					}
				} else {
					richTextBox1.AppendText("erro\r");
				}
			} else {
				richTextBox1.AppendText("nenhum movimento\r");
			}

			return str1;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			db_check();		
		}

		private void btn_read_Click(object sender, EventArgs e) {
			//string a = read_n();
			read_all();
		}

		private void btn_check_Click(object sender, EventArgs e) {
			if (!db_check()) {
				btn_mover.Enabled = false;
				btn_undo.Enabled = false;
				//btn_check.Enabled = true;
				btn_read.Enabled = true;
				timer1.Enabled = true;
				lb_status.Text = "Espere";
			}
			else
				lb_status.Text = "Jogue";
		}

		private void btn_undo_Click(object sender, EventArgs e) {
			string str1, str2;
			if (mov_dele.GetNumMovs() > 0) {
				
				str1 = sendToPhp("undo=" + equipe + "&&n=" + mov_dele.GetNumMovs());     //o usuario ai chamar a fução "done" depois de pedir o cancelamento do ultimo moimento do oponente
				str2 = finder(str1, "errorn");
				if (str2.Length > 0) {				//tratamento de possivel erro
					if (str2 == "2") {
						richTextBox1.AppendText("nenhum moimento a ser desfeito\r");
					} else {
						richTextBox1.AppendText("não é possiel desfazer mais de 2 moimentos\r");
					}
				} else {
					str2 = finder(str1, "status");
					if (str2 == "1") {
						
						enivaSerial("--" + reverso(mov_dele.GetMov(0))); //manda o Tabuleiro desfazer o ultimo (indicado pelos dois '-')
						if(mov_dele.GetNumMovs() == 2)
							enivaSerial("--" + reverso(mov_dele.GetMov(1))); //pelo numero de caracteres não se confunde com um movimento normal

						richTextBox1.AppendText("movimentos desfeitos com sucesso!\r");
						richTextBox2.Undo();
						n_total_movs -= mov_dele.GetNumMovs();

						btn_mover.Enabled = false;
						btn_undo.Enabled = false;
						//btn_check.Enabled = true;
						btn_read.Enabled = true;
						timer1.Enabled = true;

					} else if (str2 == "-1") {		//grande problema, se apenas um dado foi inserido o administrador terá que alterar o banco de dados
						richTextBox1.AppendText("Erro: apenas parte dos movimentos foi desfeita.\rTry again!\r");
					} else if (str2 == "0") {
						richTextBox1.AppendText("Erro: nenhum movimento foi desfeito\rTry again!\r");
					} else {
						richTextBox1.AppendText("erro desconhecido\r");
					}
				}
			} else {
				richTextBox1.AppendText("Seu oponente não moveu nenhuma peça no turno anterior\r");
			}
		}

		private void btn_mover_Click(object sender, EventArgs e) {
			if(textBox1.Text.Length > 0) {
				if (textBox2.Text.Length > 0) {     //dois movimentos
					mov_meu.SetMov(textBox1.Text, textBox2.Text);
					mover();
				} else {                            //um movimento
					mov_meu.SetMov(textBox1.Text);
					mover();
				}
			}
		}

		private void t_1s_Click(object sender, EventArgs e) {
			timer1.Interval = 1000;
			lb_tempo.Text = "1 s.";
		}
		private void t_2s_Click(object sender, EventArgs e) {
			timer1.Interval = 2000;
			lb_tempo.Text = "2 s.";
		}
		private void t_3s_Click(object sender, EventArgs e) {
			timer1.Interval = 3000;
			lb_tempo.Text = "3 s.";
		}
		private void t_5s_Click(object sender, EventArgs e) {
			timer1.Interval = 5000;
			lb_tempo.Text = "5 s.";
		}
		private void t_7s_Click(object sender, EventArgs e) {
			timer1.Interval = 7000;
			lb_tempo.Text = "7 s.";
		}
		private void t_10s_Click(object sender, EventArgs e) {
			timer1.Interval = 10000;
			lb_tempo.Text = "10 s.";
		}
		private void t_15s_Click(object sender, EventArgs e) {
			timer1.Interval = 15000;
			lb_tempo.Text = "15 s.";
		}

		private void eq_br_Click(object sender, EventArgs e) {
			equipe = "BR";
			lb_equipe.Text = equipe;
		}
		private void eq_fr_Click(object sender, EventArgs e) {
			equipe = "FR";
			lb_equipe.Text = equipe;
		}

		private void btn_clear_Click(object sender, EventArgs e) {
			richTextBox1.Clear();
		}

		private void conectarToolStripMenuItem_Click(object sender, EventArgs e) {
			serialPort1.PortName = toolStripComboBox1.SelectedItem.ToString();
			serialPort1.Open();
			começarToolStripMenuItem.Enabled = true;
			toolStripComboBox1.Enabled = false;
			conectarToolStripMenuItem.Enabled = false;
			desconectarToolStripMenuItem.Enabled = true;
		}

		private void desconectarToolStripMenuItem_Click(object sender, EventArgs e) {
			serialPort1.Close();
			começarToolStripMenuItem.Enabled = false;
			toolStripComboBox1.Enabled = true;
			conectarToolStripMenuItem.Enabled = true;
			desconectarToolStripMenuItem.Enabled = false;
		}

		private void portaToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
			toolStripComboBox1.Items.Clear();
			foreach(string element in System.IO.Ports.SerialPort.GetPortNames()) {
				toolStripComboBox1.Items.Add(element);
			}
		}

		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			conectarToolStripMenuItem.Enabled = true;
		}

		private void começarToolStripMenuItem_Click(object sender, EventArgs e) {
			encerrarToolStripMenuItem.Enabled = true;
			começarToolStripMenuItem.Enabled = false;
			timer1.Enabled = true;
		}

		private void encerrarToolStripMenuItem_Click(object sender, EventArgs e) {
			encerrarToolStripMenuItem.Enabled = false;
			começarToolStripMenuItem.Enabled = true;
			timer1.Enabled = false;
		}
	}
}