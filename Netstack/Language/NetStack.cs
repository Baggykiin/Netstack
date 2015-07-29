using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Netstack.Language.Exceptions;

namespace Netstack.Language
{
    public class NetStack
    {
        private Stack<object> stack = new Stack<object>();
        private Dictionary<string, Statement> boundFunctions = new Dictionary<string, Statement>(); 
        internal NetStack Push(object value)
        {
            stack.Push(value);
            return this;
        }

        internal object Pop()
        {
            try
            {
                return stack.Pop();
            }
            catch (InvalidOperationException)
            {
                throw new StackEmptyException("Attempted to pop a frame while the stack was empty.");
            }
        }

        internal void BindFunction(Statement body, string label)
        {
            boundFunctions[label] = body;
        }

        internal Statement GetFunction(string label)
        {
            return boundFunctions[label];
        }

        internal object Peek()
        {
            try
            {
                return stack.Peek();
            }
            catch (InvalidOperationException)
            {
                throw new StackEmptyException("Attempted to pop a frame while the stack was empty.");
            }
        }

        internal T Peek<T>()
        {
            var value = Peek();
            try
            {
                var cast = (T)value;
                return cast;
            }
            catch (InvalidCastException)
            {
                throw new Exception(string.Format("Type mismatch, expected {0} but got {1}", typeof(T).Name, value.GetType().Name));
            }
        }

        internal T Pop<T>()
        {
            var value = Pop();
            try
            {
                var cast = (T) value;
                return cast;
            }
            catch (InvalidCastException)
            {
                throw new Exception(string.Format("Type mismatch, expected {0} but got {1}", typeof(T).Name, value.GetType().Name));
            }
        }

        public override string ToString()
        {
            return string.Format("[ {0} ]", string.Join(", ", stack.Select(p => p is string ? "\"" + p + "\"" : p.ToString())));
        }

        public void Clear()
        {
            stack.Clear();
            boundFunctions.Clear();
        }

        public object Peek(long offset)
        {
            var tempStack = new Stack<object>();
            for (var i = 0; i < offset; i++)
            {
                tempStack.Push(stack.Pop());
            }
            var value = Peek();
            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
            return value;
        }

        public T Peek<T>(long offset)
        {
            var tempStack = new Stack<object>();
            for (var i = 0; i < offset; i++)
            {
                tempStack.Push(stack.Pop());
            }
            var value = Peek<T>();
            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
            return value;
        }
    }
}
