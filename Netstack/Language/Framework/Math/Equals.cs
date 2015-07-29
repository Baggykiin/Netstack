using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Math
{
    class Equals : Function
    {
        public void Execute(NetStack stack)
        {
            var l = stack.Pop();
            var r = stack.Pop();
            stack.Push(l.Equals(r));
        }
    }
}
