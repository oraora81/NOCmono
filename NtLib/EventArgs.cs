
namespace Nt
{
    public class RenderContextInitEventArgs : System.EventArgs
    {
        public object Widget;
        public RenderContextInitEventArgs(object obj)
        {
            Widget = obj;
        }
    }
}