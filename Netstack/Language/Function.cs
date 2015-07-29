namespace Netstack.Language
{
    abstract class Function
    {
        public abstract void Execute(NetStack stack);

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
