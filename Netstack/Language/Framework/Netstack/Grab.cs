using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Netstack
{
    class Grab :Function
    {
        public override void Execute(NetStack stack)
        {
            var offset = stack.Pop<long>();
            var value = stack.Peek(offset);
            stack.Push(value);
        }
    }
}
