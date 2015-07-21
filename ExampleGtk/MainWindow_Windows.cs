using System;
using Gtk;

namespace NOCmono
{
    public class MainWindow_Windows : Gtk.Window
    {
        TextView wins;
        Button help;
        public MainWindow_Windows()
            : base("Windows")
        {
            SetDefaultSize(300, 250);
            SetPosition(WindowPosition.Center);
            BorderWidth = 15;
            DeleteEvent += delegate 
                {
                    if (help != null)
                        help.Clicked -= OnClickedHelpButton;
                    Application.Quit(); 
                };

            Table table = new Table(8, 4, false);
            table.ColumnSpacing = 3;

            Label title = new Label("Windows");

            Alignment halign = new Alignment(0, 0, 0, 0);
            halign.Add(title);

            table.Attach(halign, 0, 1, 0, 1, AttachOptions.Fill, 
                AttachOptions.Fill, 0, 0);

            wins = new TextView();
            wins.ModifyFg(StateType.Normal, new Gdk.Color(20, 20, 20));
            wins.CursorVisible = false;
            table.Attach(wins, 0, 2, 1, 3, AttachOptions.Fill | AttachOptions.Expand,
                AttachOptions.Fill | AttachOptions.Expand, 1, 1);

            Button activate = new Button("Activate");
            activate.SetSizeRequest(50, 30);
            table.Attach(activate, 3, 4, 1, 2, AttachOptions.Fill, 
                AttachOptions.Shrink, 1, 1);

            Alignment valign = new Alignment(0, 0, 0, 0);
            Button close = new Button("Close");
            close.SetSizeRequest(70, 30);
            valign.Add(close);
            table.SetRowSpacing(1, 3);
            table.Attach(valign, 3, 4, 2, 3, AttachOptions.Fill,
                AttachOptions.Fill | AttachOptions.Expand, 1, 1);

            Alignment halign2 = new Alignment(0, 1, 0, 0);
            help = new Button("Help");
            help.SetSizeRequest(70, 30);

            help.Clicked += OnClickedHelpButton;

            halign2.Add(help);
            table.SetRowSpacing(3, 6);
            table.Attach(halign2, 0, 1, 4, 5, AttachOptions.Fill, 
                AttachOptions.Fill, 0, 0);

            Button ok = new Button("OK");
            ok.SetSizeRequest(70, 30);
            table.Attach(ok, 3, 4, 4, 5, AttachOptions.Fill, 
                AttachOptions.Fill, 0, 0);

            Add(table);
            ShowAll();
        }

        private void OnClickedHelpButton(object sender, EventArgs e)
        {
            Nt.MessageBox msgbox = new Nt.MessageBox("test", Nt.MessageResponse.Ok, OnCloseMsgBox);
            msgbox.Open();
        }

        private void on_dialog_response(object sender, ResponseArgs e)
        {
            Dialog d = sender as Dialog;
            
            TextBuffer buffer = wins.Buffer;
            buffer.Text = e.ResponseId.ToString();
        }

        private void OnCloseMsgBox(object sender, Nt.CloseEventArgs args)
        {
            wins.Buffer.Text = args.Response.ToString();
        }
    }
}

