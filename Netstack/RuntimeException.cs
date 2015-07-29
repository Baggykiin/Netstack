using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netstack
{
    public class RuntimeException : Exception
    {
        public RuntimeException(Exception innerException)
            : base("An exception occurred while trying to evaluate a statement.", innerException)
        {
        }
    }
}
