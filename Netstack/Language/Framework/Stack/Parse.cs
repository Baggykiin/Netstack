namespace Netstack.Language.Framework.Stack
{
    class Parse : Function
    {
        public override void Execute(NetStack stack)
        {
            stack.Push(new Parser().Parse(stack.Pop<string>()));
        }
    }
}
