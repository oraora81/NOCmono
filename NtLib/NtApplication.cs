using System;

namespace Nt
{
    public class NtApplication
    {
        private int _width;
        private int _height;

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }


        public NtApplication()
        {
            
        }

        public virtual bool Initialize()
        {
            return true;
        }

        public virtual void Release()
        {
            
        }

        public virtual void MainLoop()
        {
            
        }
    }
}

