using System;

namespace Nt
{
    public class LogManager : Singleton<LogManager>
    {
        #region Enums
        [Flags]
        public enum eOutput
        {
            CONSOLE = 0x0001,
            FILE = 0x0002,
        }
        #endregion

        #region Variables
        private eOutput _output;
        #endregion

        public eOutput Output
        {
            get { return _output;}
            set
            {
                _output |= value;
            }
        }
        
        public LogManager()
        {
            
        }
    }
}

