namespace Netstack.Language.Literals
{
    class IntegerLiteral : Literal
    {
        private long value;

        public IntegerLiteral(long value)
        {
            this.value = value;
        }
        
        public override void Execute(NetStack stack)
        {
            stack.Push(value);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
