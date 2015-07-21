using System;

namespace Nt
{
    public class RenderContextInitEventArgs : EventArgs
    {
        public object Widget;
        public RenderContextInitEventArgs(object obj)
        {
            Widget = obj;
        }
    }


    public class CloseEventArgs : EventArgs
    {
        public MessageResponse Response
        {
            get;
            set;
        }

        public CloseEventArgs(MessageResponse res)
        {
            Response = res;
        }
    }
}