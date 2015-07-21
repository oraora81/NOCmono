using System;

namespace Nt
{
    public class NtApplication
    {
        #region Variables
        private int _width;
        private int _height;
        private string[] _Args;
        #endregion


        #region EventHandler
        private EventHandler<RenderContextInitEventArgs> _render2dInitHandler;
        #endregion


        #region Properties
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        #endregion


        public NtApplication(string[] args)
        {
            _Args = args;
        }

        public virtual bool Initialize()
        {
            // Load


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

