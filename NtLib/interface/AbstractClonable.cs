using System;

namespace Nt
{
    public abstract class AbstractClonable : ICloneable
    {
        public object Clone()
        {
            return null;
        }

        protected virtual void HandleCloned(AbstractClonable cloneObj)
        {
            // do something derived class
        }
    }

    /*
    public class ConcreteClass : AbstractClonable
    {
        protected override void HandleCloned(AbstractClonable cloneObj)
        {
            base.HandleCloned(cloneObj);

            ConcreteClass obj = cloneObj as ConcreteClass;
            if (obj == null)
            {
                return;
            }

            // here you have something special chance for detail clone.
        }
    }
    */
}

