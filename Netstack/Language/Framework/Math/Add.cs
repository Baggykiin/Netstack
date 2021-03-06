﻿using System;

namespace Netstack.Language.Framework.Math
{
    class Add : Function
    {
        public override void Execute(NetStack stack)
        {
            dynamic r = stack.Pop();
            dynamic l = stack.Pop();
            stack.Push(l + r);
            //throw new ArgumentException(string.Format("Cannot add operands of type {0} and {1}", l.GetType().Name, r.GetType().Name));
        }

        public override string ToString()
        {
            return "+";
        }
    }
}
