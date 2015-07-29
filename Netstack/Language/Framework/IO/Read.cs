using System;

namespace Netstack.Language.Framework.IO
{
    class Read : Function
    {
        public void Execute(NetStack stack)
        {
            Console.Write("input> ");
            stack.Push(Console.ReadLine());
        }
    }
}
