using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MyRoot
{
    public partial class Frm_System : Form
    {
        public List<Login> Pontuação = new List<Login>();
        public Frm_System()
        {
            InitializeComponent();
        }
        private void bunifuMetroTextbox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (bunifuMetroTextbox2.Text == "nickname...")
                bunifuMetroTextbox2.Text = "";
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Login login = new Login
                {
                    Nome = bunifuMetroTextbox2.Text,
                };
                if (!Pontuação.Contains(login))
                    Pontuação.Add(login);
                if(bunifuMetroTextbox2.Text.Length >= 4 && bunifuMetroTextbox2.Text != "nickname..." )
                {
                    new Thread(new ThreadStart(OpenRoot)).Start();
                    Close();
                }
                else
                {
                    MessageBox.Show("[Sistema Error] Dados Impossivel de se registrar.", "Simon", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("[Sistema Error] foi encontrado um erro ao criar sua conta.", "Simon", MessageBoxButtons.OK);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void OpenRoot()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Root());
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
