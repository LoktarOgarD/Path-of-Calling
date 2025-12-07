using System;

namespace PathOfCalling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Path of Calling";
            var game = new Game();
            game.Run();
        }
    }
}
