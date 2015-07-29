using System;

namespace Netstack.Language.Framework.Math
{
    class Add : Function
    {
        public void Execute(NetStack stack)
        {
            var r = stack.Pop();
            var l = stack.Pop();
            if (r is long && l is long)
            {
                stack.Push((long)r + (long)l);
            }
            else if (r is string && l is string)
            {
                stack.Push((string)l + (string)r);
            }
            else
            {
                throw new ArgumentException(string.Format("Cannot add operands of type {0} and {1}", l.GetType().Name, r.GetType().Name));

            }
        }
    }
}
