using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Control
{
    class If : Function
    {
        public void Execute(NetStack stack)
        {
            var condition = stack.Pop() as Statement;


            var statement = stack.Pop() as Statement;
            if (condition != null)
            {
                condition.Evaluate(stack);
                var result = (bool)stack.Pop();
                stack.Flag = result ? true : false;
            }
        }
    }
}
