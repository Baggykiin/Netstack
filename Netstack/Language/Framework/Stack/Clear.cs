namespace Netstack.Language.Framework.Stack
{
    class Clear : Function
    {
        public override void Execute(NetStack stack)
        {
            stack.Clear();
        }
    }
}
