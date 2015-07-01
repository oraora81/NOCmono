using System;
using Gtk;

namespace NOCmono
{
    public class MainWindow_Widget : Gtk.Window
    {
        private Label lyrics;

        string text = @"Meet you downstairs in the bar and heard
your rolled up sleeves and your skull t-shirt
You say why did you do it with him today?
and sniff me out like I was Tanqueray

cause you're my fella, my guy
hand me your stella and fly
by the time I'm out the door
you tear men down like Roger Moore

I cheated myself
like I knew I would
I told ya, I was trouble
you know that I'm no good";

        string[] distros = new string[]
            {
                "Ubuntu", "Mandriva",
                "Red Hat", "Fedora",
                "Gentoo"
            };
        
        public MainWindow_Widget()
            : base("You know I'm no good")
        {
            SetDefaultSize(800, 600);
            
            BorderWidth = 8;
            SetPosition(WindowPosition.Center);

            // Title
            Title = "Widget Test";

            // Label
            DeleteEvent += delegate
            {
                    Application.Quit();
            };

            Fixed fix = new Fixed();

            ComboBox combo = new ComboBox(distros);
            combo.Changed += OnChanged;

            lyrics = new Label(text);


            fix.Put(combo, 50, 30);
            fix.Put(lyrics, 50, 150);

            Add(fix);

            ShowAll();
        }

        void OnChanged(object sender, EventArgs args)
        {
            ComboBox cb = sender as ComboBox;
            lyrics.Text = cb.ActiveText;
        }
    }
}

