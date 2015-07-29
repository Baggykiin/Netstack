using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack.Language.Exceptions
{
    public class StackEmptyException : Exception
    {
        public StackEmptyException(string message) : base(message)
        {
        }
    }
}
