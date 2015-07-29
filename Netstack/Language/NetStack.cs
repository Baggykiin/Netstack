using System.Collections.Generic;
using System.Linq;

namespace Netstack.Language
{
    public class NetStack
    {
        private Stack<object> stack = new Stack<object>();
        
        public bool? Flag { get; set; }

        internal void Push(object value)
        {
            stack.Push(value);
        }

        internal object Pop()
        {
            return stack.Pop();
        }

        public override string ToString()
        {
            return string.Format("[ {0} ]", string.Join(", ", stack.Select(p => p is string ? "\"" + p + "\"" : p.ToString())));
        }
    }
}
