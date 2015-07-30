namespace Netstack.Language.Framework.Stack
{
    class Grab :Function
    {
        public override void Execute(NetStack stack)
        {
            var offset = stack.Pop<long>();
            var value = stack.Peek(offset);
            stack.Push(value);
        }
    }
}
