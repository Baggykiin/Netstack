using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Control
{
    class Break :Function
    {
        public override void Execute(NetStack stack)
        {
            Debugger.Break();
        }
    }
}
