using System;
using Gtk;
using Pango;

namespace NOCmono
{
    public class MainWindow_Pango : Gtk.Window
    {
        private enum Column
        {
            FontName
        }
        
        private ListStore _store;
        private FontFamily[] _fonts;
        private Label _label;

        public MainWindow_Pango()
        : base("pango + unicode + font")
        {
            SetPosition(WindowPosition.Center);
            DeleteEvent += delegate
            {
                    Application.Quit();
            };

            ScrolledWindow sw = new ScrolledWindow();
            sw.ShadowType = ShadowType.EtchedIn;
            sw.SetPolicy(PolicyType.Automatic, PolicyType.Automatic);

            Context context = this.CreatePangoContext();
            _fonts = context.Families;

            _store = CreateModel();

            TreeView view = new TreeView();
            view.RulesHint = true;
            sw.Add(view);

            CreateColumn(view);


            string text = @"하늘과 바람과 별과 시 - 윤동주\n1821 года в Москве.Был вторым из 7 детей. Отец, Михаил Андреевич";

            _label = new Label(text);

            Pango.FontDescription fontDesc = Pango.FontDescription.FromString("SignPainter 20");
            _label.ModifyFont(fontDesc);

            Fixed fix = new Fixed();

            fix.Put(_label, 5, 5);
            Add(fix);
            //Add(sw);
            ShowAll();
        }

        private ListStore CreateModel()
        {
            ListStore s = new ListStore(typeof(string));

            foreach (var item in _fonts)
            {
                s.AppendValues(item.Name);
            }

            return s;
        }

        private void CreateColumn(TreeView view)
        {
            CellRendererText renderText = new CellRendererText();
            TreeViewColumn column = new TreeViewColumn("FontName", renderText, "text", Column.FontName);

            column.SortColumnId = (int)Column.FontName;
            view.AppendColumn(column);
        }
    }
}

