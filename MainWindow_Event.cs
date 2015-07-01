using System;
using Gtk;

namespace NOCmono
{
    public class MainWindow_Event : Gtk.Window
    {
        private Button _quit;
        
        public MainWindow_Event()
            : base("")
        {
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);

            DeleteEvent += delegate { Application.Quit(); };

            Fixed fix = new Fixed();

            Button btn = new Button("Enter");
            btn.EnterNotifyEvent += OnEnter;

            _quit = new Button("Quit");
            //_quit.Clicked += OnClick;
            _quit.SetSizeRequest(80, 35);

            CheckButton cb = new CheckButton("connect");
            cb.Toggled += OnToggled;

            fix.Put(btn, 50, 20);
            fix.Put(_quit, 50, 50);
            fix.Put(cb, 120, 20);
            Add(fix);
            ShowAll();
        }

        protected override bool OnConfigureEvent(Gdk.EventConfigure args)
        {
            base.OnConfigureEvent(args);

            Title = args.X + ", " + args.Y;
            return true;
        }
        
        private void OnClick(object sender, EventArgs arg)
        {
            Application.Quit();
        }

        private void OnEnter(object sender, EnterNotifyEventArgs args)
        {
            Button btn = (Button)sender;
            btn.ModifyBg(StateType.Prelight, new Gdk.Color(40, 20, 40));
        }

        private void OnToggled(object sender, EventArgs args)
        {
            CheckButton cb = sender as CheckButton;
            if (cb.Active)
            {
                _quit.Clicked += OnClick;
            }
            else
            {
                _quit.Clicked -= OnClick;
            }
        }
    }
}

