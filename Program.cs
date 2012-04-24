using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ga1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Trace.Listeners.Add(new TextWriterTraceListener(System.Console.Out));
            Application.Run(new Form1());
        }

        public static Random rnd = new Random();
    }
}