using System;
using nesting_dolls.Models;

namespace nesting_dolls
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Game game = new Game();
            game.Setup();
            System.Console.WriteLine(game.CurrentDoll);
            bool _playing = true;
            while (_playing)
            {
                System.Console.WriteLine("press (n) for next, (p) for previous, (r) to remove, (q) to quit");
                var choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case 'q':
                        _playing = false;
                        break;
                    case 'n':
                        game.Next();
                        break;
                    case 'p':
                        game.Previous();
                        break;
                    case 'r':
                        game.RemoveCurrent();
                        break;
                    default:
                        System.Console.WriteLine("invalid command");
                        break;
                }
            }
        }
    }
}
