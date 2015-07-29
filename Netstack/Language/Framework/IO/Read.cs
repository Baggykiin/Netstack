using System;

namespace Netstack.Language.Framework.IO
{
    class Read : Function
    {
        public override void Execute(NetStack stack)
        {
            Console.Write("input> ");
            stack.Push(Console.ReadLine());
        }
    }
}
