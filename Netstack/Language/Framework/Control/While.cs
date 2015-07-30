using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Control
{
    class While : Function
    {
        public override void Execute(NetStack stack)
        {
            var condition = stack.Pop<Statement>();
            var body = stack.Pop<Statement>();

            condition.Evaluate(stack);
            var result = stack.Pop<bool>();
            while (result)
            {
                body.Evaluate(stack);
                condition.Evaluate(stack);
                result = stack.Pop<bool>();
            }


        }
    }
}
