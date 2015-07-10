using System;
using Gtk;

namespace NOCmono
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            NocApplication app = new NocApplication();

            if (app.Initialize() == false)
            {
                app.Release();
                return;
            }
        }
    }
}
