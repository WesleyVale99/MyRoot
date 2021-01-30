using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyRoot
{
    public partial class Frm_Root : Form
    {
        public Login GetLogin;
        public int PlayersJgVelha;
        public char[] ValuesTabulerio;
        public bool Brincadeira1_bool = false;
        public Frm_Root()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/wesley.vale.3192");
        }

        private void bunifuTextbox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (btn_enviarnumero.text == "Digite.")
                btn_enviarnumero.text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Timer_JogoDaVelha.Enabled || Timer_MateRobô.Enabled && Brincadeira1_lbl.Visible)
                return;
            if (Menu_Panel.Width == 0 && panel3.Width == 0)
            {
                SimonLbl.Visible = false;
                Simon_P2.Visible = false;
                Menu_Panel.Visible = false;
                panel3.Visible = false;
                Menu_Panel.Width = 270;
                panel3.Width = 204;
                AnimationPrimary.Show(Menu_Panel);
                AnimationSecond.Show(panel3);
            }
            else
            {
                AnimationTercery.Show(Simon_P2);
                Simon_P2.Visible = true;
                SimonLbl.Visible = true;
                Menu_Panel.Visible = true;
                panel3.Visible = true;
                Menu_Panel.Width = 0;
                panel3.Width = 0;
            }
        }

        private void Frm_Root_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.systemLogin.Pontuação.Count; i++)
            {
                GetLogin = Program.systemLogin.Pontuação[i];
                label2.Text = "Olá [" + GetLogin.Nome + "] Bem vindo. ";
                Score_lbl.Text = "Pontuação: " + GetLogin.score;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (Timer_JogoDaVelha.Enabled || Timer_MateRobô.Enabled)
                return;
            if (!Brincadeira1_lbl.Visible)
                return;
            int numeroescolhido = int.Parse(btn_enviarnumero.text);
            if (numeroescolhido > 0 && !Brincadeira1_bool)
            {
                numeroescolhido = numeroescolhido *= 2;
                numeroescolhido = numeroescolhido += 5;
                numeroescolhido = numeroescolhido *= 50;
                btn_enviarnumero.text = "";
                Brincadeira1_bool = true;
                Brincadeira1_lbl.Text = "[Simon] Digite agora o sua idade: ";
            }
            else if (numeroescolhido > 0 && Brincadeira1_bool)
            {
                int numeroescolhido1 = int.Parse(btn_enviarnumero.text);
                numeroescolhido1 = numeroescolhido += 350;
                numeroescolhido1 -= 250;
                int Agefull = 2019 - int.Parse(numeroescolhido1.ToString().Substring(1));
                MessageBox.Show("Sua idade é: 0" + numeroescolhido1.ToString().Insert(1, "/") + "/" + Agefull);
                int score = GetLogin.score += 100;
                Score_lbl.Text = "Pontuação: " + score;
                Brincadeira1_lbl.Visible = false;
            }
            btn_enviarnumero.text = "";
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Menu_Panel.Enabled = false;
            Brincadeira1_lbl.Visible = true;
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            if (!Timer_MateRobô.Enabled)
            {
                Menu_Panel.Enabled = false;
                btn_enviarnumero.Visible = false;
                Btn_enviar.Visible = false;
                Brincadeira2_lbl.Visible = true;
                Frutinha.Visible = true;
                Timer_MateRobô.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            Timer_MateRobô.Interval = 600;
            Frutinha.Location = new Point(rand.Next(0, 425), rand.Next(0, 425));
        }

        private void Frutinha_Click(object sender, EventArgs e)
        {
            Menu_Panel.Enabled = true;
            btn_enviarnumero.Visible = true;
            Btn_enviar.Visible = true;
            Brincadeira2_lbl.Visible = false;
            Frutinha.Visible = false;
            Timer_MateRobô.Stop();
            int score = GetLogin.score += 1000;
            Score_lbl.Text = "Pontuação: " + score;
            MessageBox.Show("[Parabéns] você conseguiu matar o robô inimigo!");

        }

        private void Btn_Brincadeira3_Click(object sender, EventArgs e)
        {

        }
        private void Btn_Brincadeira4_Click(object sender, EventArgs e)
        {
          
            if (!Timer_JogoDaVelha.Enabled)
            {
                PlayersJgVelha = 1;
                ValuesTabulerio = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                Menu_Panel.Enabled = false;
                panel2.Visible = true;
                panel1.Visible = true;
                lbl_velha.Visible = true;
                Timer_JogoDaVelha.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (PlayersJgVelha % 2 == 0)
                    lbl_velha.Text = "[Simon] Player 2 é a sua vez: ";
                else
                    lbl_velha.Text = "[Simon] Player 1 é a sua vez: ";
                Tabuleiro_Jg_Velha(ValuesTabulerio);
                if (btn_enviarnumero.text.Length > 0 && btn_enviarnumero.text.Length < 2)
                {
                    int choice = int.Parse(btn_enviarnumero.text);
                    if (ValuesTabulerio[choice] != 'x' && ValuesTabulerio[choice] != 'O')
                    {

                        if (PlayersJgVelha % 2 == 0)
                        {
                            ValuesTabulerio[choice] = 'O';
                            PlayersJgVelha++;
                        }
                        else

                        {
                            ValuesTabulerio[choice] = 'x';
                            PlayersJgVelha++;
                        }
                        btn_enviarnumero.text = "";
                    }
                    Tabuleiro_Jg_Velha(ValuesTabulerio);
                    if(CheckWin() == 1)
                    {
                        panel1.Visible = false;
                        lbl_velha.Visible = false;
                        btn_enviarnumero.Visible = true;
                        Btn_enviar.Visible = true;
                        Brincadeira1_lbl.Visible = false;
                        Timer_JogoDaVelha.Stop();
                        btn_enviarnumero.text = "";
                        Menu_Panel.Enabled = true;
                        int Vencedor = (PlayersJgVelha % 2) + 1;
                        MessageBox.Show("[Simon] Vencedor foi o Jogador: [" + Vencedor + "]");
                        PlayersJgVelha = 1;
                    }
                }

            }
            catch (Exception)
            {
                panel2.Visible = false;
                panel1.Visible = false;
                lbl_velha.Visible = false;
                Timer_JogoDaVelha.Stop();
                btn_enviarnumero.text = "";
                MessageBox.Show("[Sistema Error] apenas numeros.");
            }
        }
        public void Tabuleiro_Jg_Velha(char[] arr)
        {
            Btn_Velha_1.Text = string.Concat(arr[1]);
            Btn_Velha_2.Text = string.Concat(arr[2]);
            Btn_Velha_3.Text = string.Concat(arr[3]);
            Btn_Velha_4.Text = string.Concat(arr[4]);
            Btn_Velha_5.Text = string.Concat(arr[5]);
            Btn_Velha_6.Text = string.Concat(arr[6]);
            Btn_Velha_7.Text = string.Concat(arr[7]);
            Btn_Velha_8.Text = string.Concat(arr[8]);
            Btn_Velha_9.Text = string.Concat(arr[9]);
        }
        private int CheckWin()
        {
            if (ValuesTabulerio[1] == ValuesTabulerio[2] && ValuesTabulerio[2] == ValuesTabulerio[3])
                return 1;
            else if (ValuesTabulerio[4] == ValuesTabulerio[5] && ValuesTabulerio[5] == ValuesTabulerio[6])
                return 1;
            else if (ValuesTabulerio[6] == ValuesTabulerio[7] && ValuesTabulerio[7] == ValuesTabulerio[8])
                return 1;
            else if (ValuesTabulerio[1] == ValuesTabulerio[4] && ValuesTabulerio[4] == ValuesTabulerio[7])
                return 1;

            else if (ValuesTabulerio[2] == ValuesTabulerio[5] && ValuesTabulerio[5] == ValuesTabulerio[8])
                return 1;
            else if (ValuesTabulerio[3] == ValuesTabulerio[6] && ValuesTabulerio[6] == ValuesTabulerio[9])
                return 1;
            else if (ValuesTabulerio[1] == ValuesTabulerio[5] && ValuesTabulerio[5] == ValuesTabulerio[9])
                return 1;
            else if (ValuesTabulerio[3] == ValuesTabulerio[5] && ValuesTabulerio[5] == ValuesTabulerio[7])
                return 1;

            else if (ValuesTabulerio[1] != '1' && ValuesTabulerio[2] != '2' && ValuesTabulerio[3] != '3' && ValuesTabulerio[4] != '4' && ValuesTabulerio[5] != '5' && ValuesTabulerio[6] != '6' && ValuesTabulerio[7] != '7' && ValuesTabulerio[8] != '8' && ValuesTabulerio[9] != '9')
                return -1;
            else
                return 0;
        }
        private void bunifuFlatButton2_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Brincadeira1.BackColor = Color.Green;
        }

        private void bunifuFlatButton2_MouseLeave(object sender, EventArgs e)
        {
            Btn_Brincadeira1.BackColor = Color.Transparent;
        }
        private void bunifuFlatButton1_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Brincadeira2.BackColor = Color.Green;
        }

        private void Btn_Brincadeira2_MouseLeave(object sender, EventArgs e)
        {
            Btn_Brincadeira2.BackColor = Color.Transparent;
        }
        private void Btn_Brincadeira3_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Brincadeira3.BackColor = Color.Green;
        }

        private void Btn_Brincadeira3_MouseLeave(object sender, EventArgs e)
        {
            Btn_Brincadeira3.BackColor = Color.Transparent;
        }

        private void Btn_Brincadeira4_MouseMove(object sender, MouseEventArgs e)
        {
            Btn_Brincadeira4.BackColor = Color.Green;
        }

        private void Btn_Brincadeira4_MouseLeave(object sender, EventArgs e)
        {
            Btn_Brincadeira4.BackColor = Color.Transparent;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Timer_JogoDaVelha.Enabled)
            {
                panel1.Visible = false;
                lbl_velha.Visible = false;
                btn_enviarnumero.Visible = true;
                Btn_enviar.Visible = true;
                Brincadeira1_lbl.Visible = false;
                Timer_JogoDaVelha.Stop();
            }
            else if (Timer_MateRobô.Enabled)
            {
                btn_enviarnumero.Visible = true;
                Btn_enviar.Visible = true;
                Brincadeira2_lbl.Visible = false;
                Frutinha.Visible = false;
                Timer_MateRobô.Stop();
            }
            else if (Brincadeira1_lbl.Visible)
                Brincadeira1_lbl.Visible = false;
            Menu_Panel.Enabled = true;
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int WM_LBUTTONDOWN = 0x0201;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_LBUTTONDOWN)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
