namespace Netstack.Language.Framework.Stack
{
    class Dup : Function
    {
        public override void Execute(NetStack stack)
        {
            var val = stack.Pop();
            stack.Push(val).Push(val);
        }
    }
}
