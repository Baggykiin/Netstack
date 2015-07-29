using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Framework.Control
{
    class If : Function
    {
        public override void Execute(NetStack stack)
        {
            var condition = stack.Pop<Statement>();
            var falseStmt = stack.Pop<Statement>();
            var trueStmt = stack.Pop<Statement>();

            condition.Evaluate(stack);
            var result = stack.Pop<bool>();
            if (result)
            {
                trueStmt.Evaluate(stack);
            }
            else
            {
                falseStmt.Evaluate(stack);
            }
        }
    }
}
