using System;
using System.Windows.Forms;

namespace tubes3stima
{
    internal static class Program
    {  
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Replace Form1 with your main form class
        }
    }
}