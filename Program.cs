using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace ga1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Trace.Listeners.Add(new TextWriterTraceListener(System.Console.Out));
            Application.Run(new Form1());
        }
        public static Random rnd = new Random();
    }
}
