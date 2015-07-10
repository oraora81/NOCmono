using System;
using Gtk;

namespace NOCmono
{
    public class NocApplication : Nt.NtApplication
    {
        public NocApplication()
            : base()
        {
            
        }

        public override bool Initialize()
        {
            Application.Init();

            //MainWindow win = new MainWindow();
            //MainWindow_Event win = new MainWindow_Event();
            //MainWindow_Widget2 win = new MainWindow_Widget2();
            //MainWindow_Pango win = new MainWindow_Pango();
            MainWindow_Cairo2 win = new MainWindow_Cairo2();
            win.Show();
            Application.Run();

            return base.Initialize();
        }

        public override void Release()
        {
            base.Release();

            Application.Quit();
        }

        public override void MainLoop()
        {
            
        }
    }
}

