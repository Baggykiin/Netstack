using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Literals
{
    class StringLiteral : Function
    {
        private string value;

        public StringLiteral(string value)
        {
            this.value = value;
        }

        public void Execute(NetStack stack)
        {
            stack.Push(value);
        }
    }
}
