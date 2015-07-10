using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
    private Gdk.Pixbuf _image1;

    public MainWindow()
        : base("Icon")
    {
        SetDefaultSize(250, 160);
        SetPosition(WindowPosition.Center);

        //DeleteEvent += new DeleteEventHandler(OnDeleteEvent);
        DeleteEvent += delegate
        {
                Application.Quit();
        };

        ModifyBg(StateType.Normal, new Gdk.Color(40, 40, 40));

        try
        {
            _image1 = new Gdk.Pixbuf("evolution.png");
        }
        catch (Exception ex)
        {
            // 
            MessageDialog box = new MessageDialog(this, DialogFlags.Modal, MessageType.Warning, ButtonsType.Ok, ex.Data.ToString());
            box.Show();
        }

        Image img1 = new Image(_image1);

        Fixed fix = new Fixed();

//        Button btn1 = new Button("Button1");
//        btn1.Sensitive = false;
//        Button btn2 = new Button("Button2");
//        Button btn3 = new Button(Stock.Close);
//        Button btn4 = new Button();
//        btn4.SetSizeRequest(80, 40);

        fix.Put(img1, 0, 0);

//        fix.Put(btn1, 20, 30);
//        fix.Put(btn2, 100, 30);
//        fix.Put(btn3, 20, 80);
//        fix.Put(btn4, 100, 80);


        Add(fix);

        ShowAll();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
