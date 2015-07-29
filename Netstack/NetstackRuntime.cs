using System;
using Netstack.Language;
using Netstack.Language.Framework.Math;
using System.Collections.Generic;

namespace Netstack
{
    public class NetstackRuntime
    {
        private Parser parser = new Parser();

        public NetStack Evaluate(NetStack stack, string input)
        {
            var statement = parser.Parse(input);
            try
            {
                statement.Evaluate(stack);
            }
            catch (Exception e)
            {
                throw new RuntimeException(e);
            }
            return stack;
        }

        public NetStack Evaluate(string input)
        {
            var stack = new NetStack();
            return Evaluate(stack, input);
        }
    }
}
