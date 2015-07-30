using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Math
{
    class Increment : Function
    {
        public override void Execute(NetStack stack)
        {
            dynamic variable = stack.Pop();
            stack.Push(++variable);
        }
    }
}
