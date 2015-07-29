using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Math
{
    class Decrement :Function
    {
        public override void Execute(NetStack stack)
        {
            stack.Push(stack.Pop<long>() - 1);
        }
    }
}
