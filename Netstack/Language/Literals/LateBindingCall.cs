using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace Netstack.Language.Literals
{
    class LateBindingCall : Literal
    {
        private readonly string label;
        public LateBindingCall(string label)
        {
            this.label = label;
        }

        public override void Execute(NetStack stack)
        {
            Statement functionBody;
            try
            {
                functionBody = stack.GetFunction(label);
            }
            catch (KeyNotFoundException)
            {
                throw new RuntimeBinderException(string.Format("Failed to call function (no binding for \"{0}\" exists).", label));
            }
            
            functionBody.Evaluate(stack);
        }
    }
}
