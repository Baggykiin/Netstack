using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Netstack
{
    class Parse : Function
    {
        public override void Execute(NetStack stack)
        {
            stack.Push(new Parser().Parse(stack.Pop<string>()));
        }
    }
}
