using System;
using Gtk;

namespace Nt
{
    public class RenderContext : IDisposable
    {
        #region Variables
        bool disposed = false;
        Cairo.Context _context;
        #endregion

        #region Properties
        public Cairo.Context Context
        {
            get
            {
                return _context;
            }
        }
        #endregion

        public void OnContextInitialize(RenderContextInitEventArgs args)
        {
            DrawingArea area = args.Widget as DrawingArea;
            if (area != null)
            {
                _context = Gdk.CairoHelper.Create(area.GdkWindow);
            }
        }

        public RenderContext()
        {
            //_context = Gdk.CairoHelper.Create(area.GdkWindow);
        }

        public void Dispose()
        { 
            Dispose(true);
            GC.SuppressFinalize(this);           
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return; 

            if (disposing)
            {
                ((IDisposable)_context.GetTarget()).Dispose();
                ((IDisposable)_context).Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~RenderContext()
        {
            Dispose(false);
        }

        public void SetColor(float r, float g, float b)
        {
            _context.SetSourceRGB(r, g, b);
        }

        public void SetColorA(float r, float g, float b, float a)
        {
            _context.SetSourceRGBA(r, g, b, a);
        }

        public void DrawBox(NRect rect)
        {
            _context.Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            _context.StrokePreserve();
        }
    }
}

