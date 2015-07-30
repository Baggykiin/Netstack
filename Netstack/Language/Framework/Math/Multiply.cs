using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Math
{
    class Multiply : Function
    {
        public override void Execute(NetStack stack)
        {
            dynamic r = stack.Pop();
            dynamic l = stack.Pop();
            stack.Push(l * r);
        }

        public override string ToString()
        {
            return "+";
        }
    }
}
