using System;
using Gtk;
using Cairo;

namespace NOCmono
{
    public class MainWindow_Cairo2 : Gtk.Window
    {

        private double [,] trs = new double[,] {
            { 0.0, 0.15, 0.30, 0.5, 0.65, 0.80, 0.9, 1.0 },
            { 1.0, 0.0,  0.15, 0.30, 0.5, 0.65, 0.8, 0.9 },
            { 0.9, 1.0,  0.0,  0.15, 0.3, 0.5, 0.65, 0.8 },
            { 0.8, 0.9,  1.0,  0.0,  0.15, 0.3, 0.5, 0.65},
            { 0.65, 0.8, 0.9,  1.0,  0.0,  0.15, 0.3, 0.5 },
            { 0.5, 0.65, 0.8, 0.9, 1.0,  0.0,  0.15, 0.3 },
            { 0.3, 0.5, 0.65, 0.8, 0.9, 1.0,  0.0,  0.15 },
            { 0.15, 0.3, 0.5, 0.65, 0.8, 0.9, 1.0,  0.0, }
        };


        private short count = 0;
        private DrawingArea _area;

        public MainWindow_Cairo2()
            : base("Cairo2")
        {
            SetDefaultSize(350, 250);
            SetPosition(WindowPosition.Center);
            DeleteEvent += delegate
            {
                    Application.Quit();
            };

            GLib.Timeout.Add(100, new GLib.TimeoutHandler(OnTimer));

            _area = new DrawingArea();
            _area.ExposeEvent += OnExpose;

            Add(_area);

            ShowAll();
        }


        bool OnTimer()
        {
            count += 1;
            _area.QueueDraw();
            return true;
        }

        void OnExpose(object sender, ExposeEventArgs args)
        {
            DrawingArea area = (DrawingArea)sender;
            Cairo.Context cr = Gdk.CairoHelper.Create(area.GdkWindow);


            int width = Allocation.Width;
            int height = Allocation.Height;
            cr.Translate(width / 2, height / 2);

            //
            {
                cr.LineWidth = 3;
                cr.LineCap = LineCap.Round;

                const int MAX_ROT = 8;
                for (int i = 0; i < MAX_ROT; i++)
                {
                    cr.SetSourceRGBA(0, 0, 0, trs[count%MAX_ROT, i]);
                    cr.MoveTo(0.0, -10.0);
                    cr.LineTo(0.0, -40.0);
                    cr.Rotate(Math.PI / 4);
                    cr.Stroke();
                }
            }

            // draw donut
            {

                //cr.SetSourceRGBA(0, 0, 0, 1);
                cr.LineWidth = 0.5;

                cr.Arc(0, 0, 120, 0, 2 * Math.PI);
                cr.Stroke();

                cr.Save();
                    
                const int MAX_ROT = 36;
                for (int i = 0; i < MAX_ROT; i++)
                {
                    //cr.SetSourceRGBA(0, 0, 0, 1);
                    cr.Rotate(i * Math.PI / MAX_ROT);
                    cr.Scale(0.3, 1);
                    cr.Arc(0, 0, 120, 0, 2 * Math.PI);
                    cr.Restore();
                    cr.Stroke();
                    cr.Save();
                }
                    
            }

            ((IDisposable) cr.GetTarget()).Dispose();                                      
            ((IDisposable) cr).Dispose();
        }
    }
}

