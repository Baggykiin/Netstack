using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netstack.Language.Literals;

namespace Netstack.Language.Framework.Control
{
    class Defn : Function
    {
        public override void Execute(NetStack stack)
        {
            var label = stack.Pop<FunctionLabel>();
            var body = stack.Pop<Statement>();
            stack.BindFunction(body, label.Label);
        }
    }
}
