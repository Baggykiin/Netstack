using Netstack;
using System;

namespace Repl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Netstack REPL.");

            var runtime = new NetstackRuntime();

            bool quitRequested = false;
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
                        var result = runtime.Evaluate(input);
                        Console.Write("--> ");
                        var previousColour = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(result.ToString());
                        Console.ForegroundColor = previousColour;
                    }
                    catch(RuntimeException e)
                    {
                        var previousColour = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Execution halted: " + e.InnerException.Message);
                        Console.ForegroundColor = previousColour;
                    }
                }
            }
            Console.WriteLine("Goodbye");
        }
    }
}
