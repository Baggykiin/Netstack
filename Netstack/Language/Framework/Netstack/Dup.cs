using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Netstack
{
    class Dup : Function
    {
        public override void Execute(NetStack stack)
        {
            var val = stack.Pop();
            stack.Push(val).Push(val);
        }
    }
}
