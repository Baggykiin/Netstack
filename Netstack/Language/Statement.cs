using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netstack.Language.Exceptions;

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
        public override void Execute(NetStack stack)
        {
            stack.Push(this);
        }

        public void Evaluate(NetStack stack)
        {
            foreach(var token in Tokens)
            {
                try
                {
                    token.Execute(stack);
                }
                catch (StackEmptyException)
                {
                    throw new StackEmptyException(string.Format("\"{0}\" attempted to pop a frame while the stack was empty.", token.GetType().FullName));
                }
            }
        }

        public override string ToString()
        {
            return string.Format("({0})", string.Join(" ", Tokens.Select(t => t.ToString())));
;        }
    }
}
