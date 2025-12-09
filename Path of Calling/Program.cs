using System;
using PathOfCalling.Domain;

namespace PathOfCalling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Path of Calling";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var game = new Game();
            game.Run();
        }
    }
}
