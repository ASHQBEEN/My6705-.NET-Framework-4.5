using System;
using System.Windows.Forms;

namespace My6705.NET_Framework_4._5
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var keyboardControl = new KeyboardControl();
            keyboardControl.PreInitialize();

            Application.Run(new Main());

            keyboardControl.Initialize();
        }
    }
}
