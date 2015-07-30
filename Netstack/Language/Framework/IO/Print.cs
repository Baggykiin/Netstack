using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netstack.Language.Exceptions;

namespace Netstack.Language.Framework.IO
{
    class Print:Function
    {
        public override void Execute(NetStack stack)
        {
            try
            {
                dynamic variable = stack.Pop();
                Console.WriteLine(variable);
            }
            catch (StackEmptyException)
            {
                Console.WriteLine("[ ]");
            }
            
        }
    }
}
