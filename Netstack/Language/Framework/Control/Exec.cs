using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Control
{
    class Exec : Function
    {
        public void Execute(NetStack stack)
        {
            var statement = stack.Pop() as Statement;
            statement.Evaluate(stack);
        }
    }
}
