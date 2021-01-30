using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MyRoot
{
    public static class Program
    {
        public static volatile Frm_System systemLogin;
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(systemLogin = new Frm_System());
        }
    }
}
