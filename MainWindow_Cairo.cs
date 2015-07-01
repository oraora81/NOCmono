using System;
using Gtk;
using Cairo;

namespace NOCmono
{
    public class MainWindow_Cairo : Gtk.Window
    {
        public MainWindow_Cairo()
            : base("Simple Drawing")
        {
            SetDefaultSize(800, 600);
            SetPosition(WindowPosition.Center);
            DeleteEvent += delegate { Application.Quit(); };

            DrawingArea draw = new DrawingArea();

            draw.ExposeEvent += OnExpose;

            Add(draw);

            ShowAll();  
        }

        private void OnExpose(object sender, ExposeEventArgs args)
        {
            DrawingArea area = sender as DrawingArea;
            Cairo.Context cr = Gdk.CairoHelper.Create(area.GdkWindow);


            int width = Allocation.Width;
            int height = Allocation.Height;


            // Draw Rectangle
            {
                cr.SetSourceRGB(0.2, 0.23, 0.9);
                cr.LineWidth = 1;

                cr.Rectangle(20, 20, 120, 80);
                cr.Rectangle(180, 20, 80, 80);
                cr.StrokePreserve();
                cr.SetSourceRGB(1, 1, 1);
                cr.Fill();
            }

            // Draw general Circle
            {
                cr.SetSourceRGB(0.2, 0.23, 0.9);
                cr.Arc(330, 60, 40, 0, 2 * Math.PI);
                cr.StrokePreserve();
                cr.SetSourceRGB(1, 1, 1);
                cr.Fill();
            }

            // draw circular sector (부채꼴)
            {
                cr.SetSourceRGB(0.2, 0.23, 0.9);
                cr.Arc(90, 160, 40, Math.PI / 4, Math.PI);
                cr.ClosePath();
                cr.StrokePreserve();
                cr.SetSourceRGB(1, 1, 1);
                cr.Fill();
            }

            {
                cr.SetSourceRGB(0.2, 0.23, 0.9);
                cr.Translate(220, 180);
                cr.Scale(1, 0.7);
                cr.Arc(0, 0, 50, 0, 2 * Math.PI);
                cr.StrokePreserve();
                cr.SetSourceRGB(1, 1, 1);
                cr.Fill();
            }

            // Draw Filled Circle
            {
                cr.LineWidth = 9;
                cr.SetSourceRGB(0.7, 0.2, 0.0);


                // 중심점을 정중앙으로.
                cr.Translate(width / 2, height / 2);
                //cr.Arc(0, 0, (width < height ? width : height) / 2 - 10, 0, 2 * Math.PI);
                cr.Arc(0, 0, 50, 0, 2*Math.PI);
                cr.StrokePreserve();

                cr.SetSourceRGB(0.3, 0.4, 0.6);
                cr.Fill();    
            }


            ((IDisposable)cr.GetTarget()).Dispose();
            ((IDisposable)cr).Dispose();
        }
    }
}

