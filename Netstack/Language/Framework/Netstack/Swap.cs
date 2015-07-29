using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Netstack
{
    class Swap :Function
    {
        public override void Execute(NetStack stack)
        {
            var top = stack.Pop();
            var bottom = stack.Pop();
            stack.Push(top).Push(bottom);
        }
    }
}
