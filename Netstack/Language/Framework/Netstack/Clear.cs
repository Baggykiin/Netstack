using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Netstack
{
    class Clear : Function
    {
        public override void Execute(NetStack stack)
        {
            stack.Clear();
        }
    }
}
