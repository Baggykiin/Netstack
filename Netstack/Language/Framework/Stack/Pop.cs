namespace Netstack.Language.Framework.Stack
{
    class Pop : Function
    {
        public override void Execute(NetStack stack)
        {
            stack.Pop();
        }
    }
}
