namespace Netstack.Language.Literals
{
    class IntegerLiteral : Function
    {
        private long value;

        public IntegerLiteral(long value)
        {
            this.value = value;
        }
        
        public void Execute(NetStack stack)
        {
            stack.Push(value);
        }
    }
}
