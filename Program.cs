using System;
using Gtk;

namespace NOCmono
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            //MainWindow win = new MainWindow();
            //MainWindow_Event win = new MainWindow_Event();
            //MainWindow_Widget2 win = new MainWindow_Widget2();
            //MainWindow_Pango win = new MainWindow_Pango();
            MainWindow_Cairo win = new MainWindow_Cairo();
            win.Show();
            Application.Run();
        }
    }
}
