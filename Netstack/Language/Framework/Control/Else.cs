using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Control
{
    class Else : Function
    {
        public void Execute(NetStack stack)
        {
            var call = stack.Pop() as Statement;
            switch (stack.Flag)
            {
                case true:
                    stack.Flag = null;
                    call.Evaluate(stack);
                    break;
                case false:
                    stack.Flag = null;
                    
            }
        }
    }
}
