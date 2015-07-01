using System;
using Gtk;

namespace NOCmono
{
    public class MainWindow_Widget2 : Gtk.Window
    {
        Label _label;
        Image _image;
        Gdk.Pixbuf img1;
        Gdk.Pixbuf img2;
        Gdk.Color _color;
        DrawingArea _area;


        public MainWindow_Widget2()
            : base("Widget2")
        {
            SetDefaultSize(800, 600);
            SetPosition(WindowPosition.Center);

            BorderWidth = 7;
            DeleteEvent += delegate
            {
                    Application.Quit();
            };

            _label = new Label("...");

            Entry entry = new Entry();
            entry.Changed += OnChangedEntry;


            // scale and image
            HScale scale = new HScale(0, 100, 1);
            {
                scale.SetSizeRequest(160, 35);
                scale.ValueChanged += OnChangeScale;

                LoadImage();

                _image = new Image(img1);
            }

            // Color
            ToggleButton red = new ToggleButton("red");
            {
                red.SetSizeRequest(80, 35);
                red.Clicked += OnRed;
                
                _area = new DrawingArea();
                _area.SetSizeRequest(150, 150);
            }

            Calendar calendar = new Calendar();
            {
                calendar.DaySelected += OnDaySelected;
            }

            Fixed fix = new Fixed();
            fix.Put(entry, 60, 100);
            fix.Put(_label, 60, 40);
            fix.Put(scale, 60, 200);
            fix.Put(_image, 10, 240);
            fix.Put(red, 300, 250);
            fix.Put(_area, 300, 500);
            fix.Put(calendar, 500, 300);
           
            Add(fix);

            ShowAll();
        }

        private void OnDaySelected(object sender, EventArgs args)
        {
            Calendar cal = sender as Calendar;
            _label.Text = cal.Month + "/" + cal.Day + "/" + cal.Year;
        }

        private void OnRed(object sender, EventArgs args)
        {
            ToggleButton t = sender as ToggleButton;
            if (t.Active)
            {
                _color.Red = 65535;
            }
            else
            {
                _color.Red = 0;
            }

            _area.ModifyBg(StateType.Normal, _color);
        }

        private void OnChangedEntry(object sender, EventArgs args)
        {
            Entry entry = sender as Entry;
            _label.Text = entry.Text;
        }

        private void OnChangeScale(object sender, EventArgs args)
        {
            HScale scale = sender as HScale;
            double v = scale.Value;

            if (v == 0)
            {
                _image.Pixbuf = img1;
            }
            else if (v >= 100)
            {
                _image.Pixbuf = img2;
            }
        }

        private void LoadImage()
        {
            try
            {
                img1 = new Gdk.Pixbuf("cat.gif");
                img2 = new Gdk.Pixbuf("sakura.gif");
            }
            catch (Exception ex)
            {
                Environment.Exit(1);
            }
        }
    }
}

