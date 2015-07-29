using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Literals
{
    class FunctionLabel :Literal
    {
        public string Label { get; private set; }
        public FunctionLabel(string label)
        {
            Label = label;
        }

        public override string ToString()
        {
            return "." + Label;
        }

        public override void Execute(NetStack stack)
        {
            stack.Push(this);
        }
    }
}
