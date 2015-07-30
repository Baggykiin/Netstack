using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netstack.Language.Literals;

namespace Netstack.Language.Framework.Control
{
    class Label : Function
    {
        public override void Execute(NetStack stack)
        {
            var label = stack.Pop<string>();
            stack.Push(new FunctionLabel(label));
        }
    }
}
