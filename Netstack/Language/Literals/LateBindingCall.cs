using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Literals
{
    class LateBindingCall :Literal
    {
        private string label;
        public LateBindingCall(string label)
        {
            this.label = label;
        }

        public override void Execute(NetStack stack)
        {
            stack.GetFunction(label).Evaluate(stack);
        }
    }
}
