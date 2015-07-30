namespace Netstack.Language.Framework.Stack
{
    class Swap :Function
    {
        public override void Execute(NetStack stack)
        {
            var top = stack.Pop();
            var bottom = stack.Pop();
            stack.Push(top).Push(bottom);
        }
    }
}
