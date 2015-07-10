using System;

namespace Nt
{
    public class NRect
    {
        Cairo.Rectangle _rect;

        #region Properties
        public double X
        {
            get { return _rect.X; }
        }

        public double Y
        {
            get { return _rect.Y; }
        }

        public double Width
        {
            get { return _rect.Width; }
        }

        public double Height
        {
            get { return _rect.Height; }
        }
        #endregion

        public NRect(double x, double y, double width, double height)
        {
            _rect = new Cairo.Rectangle(x, y, width, height);
        }


        #region Methods
        public override bool Equals(object obj)
        {
            NRect rect = obj as NRect;
            if (rect == null)
            {
                return false;
            }

            return _rect.Equals(rect);
        }

        public bool Equals(NRect rect)
        {
            if (rect == null)
            {
                return false;
            }

            return _rect.Equals(rect);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[NRect: X={0}, Y={1}, Width={2}, Height={3}]", X, Y, Width, Height);
        }
        #endregion
    }
}

