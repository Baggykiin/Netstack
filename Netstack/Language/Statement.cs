using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language
{
    class Statement : Function
    {
        public List<Function> Tokens { get; set; }

        public Statement()
        {
            Tokens = new List<Function>();
        }

        /// <summary>
        /// This doesn't actually execute the statement, it only pushes it
        /// to the top of the stack. To evaluate the statement, call the
        /// Evaluate() method instead.
        /// </summary>
        /// <param name="stack"></param>
        public void Execute(NetStack stack)
        {
            stack.Push(this);
        }

        public void Evaluate(NetStack stack)
        {
            foreach(var token in Tokens)
            {
                token.Execute(stack);
            }
        }
    }
}
