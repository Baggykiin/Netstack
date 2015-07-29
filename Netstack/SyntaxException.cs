using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack
{
    public class SyntaxException : Exception
    {
        public SyntaxException(Exception innerException)
            : base("Syntax Error.", innerException)
        {
        }
    }
}
