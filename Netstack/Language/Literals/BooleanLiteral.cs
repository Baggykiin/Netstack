using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Literals
{
    class BooleanLiteral : Literal
    {
        private bool value;
        public BooleanLiteral(bool value)
        {
            this.value = value;
        }
        public override void Execute(NetStack stack)
        {
            stack.Push(value);
        }
    }
}
