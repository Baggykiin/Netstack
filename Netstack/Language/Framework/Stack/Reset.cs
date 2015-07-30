namespace Netstack.Language.Framework.Stack
{
    class Reset :Function
    {
        public override void Execute(NetStack stack)
        {
            stack.Reset();
        }
    }
}
