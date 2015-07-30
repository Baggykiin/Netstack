using Netstack;
using System;
using Netstack.Language;

namespace Repl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Netstack REPL.");

            var runtime = new NetstackRuntime();

            bool quitRequested = false;
            NetStack stack = new NetStack();
            while (!quitRequested)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                if(input == "quit")
                {
                    quitRequested = true;
                }else
                {
                    try
                    {
                        stack = runtime.Evaluate(stack.Clear(), input);
                        var previousColour = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("--> ");
                        Console.WriteLine(stack.ToString());
                        Console.ForegroundColor = previousColour;
                    }
                    catch (RuntimeException e)
                    {
                        var previousColour = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Execution halted: " + e.InnerException.Message);
                        Console.ForegroundColor = previousColour;
                    }
                    catch (SyntaxException e)
                    {
                        var previousColour = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Parsing fail: " + e.InnerException.Message);
                        Console.ForegroundColor = previousColour;
                    }
                }
            }
            Console.WriteLine("Goodbye");
        }
    }
}
