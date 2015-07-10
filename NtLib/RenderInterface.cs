using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nt
{
    public class RenderInterface: Singleton<RenderInterface>
    {
        #region Variables
        private Nt.RenderContext _renderContext;
        #endregion

        #region Properties
        public bool AntiAlias { get; set; }
        public int StrokeSize { get; set; }
        #endregion

        EventHandler<Nt.RenderContextInitEventArgs> ContextInitialize;

        public RenderInterface()
        {
            
        }

        public void Initialize(int width, int height)
        {
            //_renderContext = new NOCmono.RenderContext();
        }

        public void DrawRectangle(int x, int y)
        {
//            Graphics drawingGraphics = Graphics.FromImage(_backBitmap);
//            _rect.X = x - StrokeSize / 2;
//            _rect.Y = y - StrokeSize / 2;
//            _rect.Width = StrokeSize;
//            _rect.Height = StrokeSize;
//            drawingGraphics.DrawRectangle(_pen, _rect);
        }

        public void DrawEllipse(int x, int y)
        {
//            Graphics drawingGraphics = Graphics.FromImage(_backBitmap);
//            _rect.X = x - StrokeSize / 2;
//            _rect.Y = y - StrokeSize / 2;
//            _rect.Width = StrokeSize;
//            _rect.Height = StrokeSize;
//            drawingGraphics.DrawEllipse(_pen, _rect);
        }

        public void DrawPoint(int x, int y)
        {
//            Graphics drawingGraphics = Graphics.FromImage(_backBitmap);
//            _rect.X = x - StrokeSize / 2;
//            _rect.Y = y - StrokeSize / 2;
//            _rect.Width = 1;
//            _rect.Height = 1;
//            drawingGraphics.DrawRectangle(_pen, _rect);
        }
    }
}
