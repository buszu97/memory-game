using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayChoices();
                switch (Console.ReadLine())
                {
                    case "1":
                        EasyLevel.StartGame();
                        break;
                    case "2":
                        HardLevel.StartGame();
                        break;
                    case "3":
                        Console.WriteLine($"Exiting application. Thank you!");
                        return;
                    default:
                        Console.WriteLine($"It's not valid value. Try again.");
                        break;
                }

            }    
        }
        private static void DisplayChoices()
        {
            Console.WriteLine($" ====================");
            Console.WriteLine($"Choose difficulty level and press enter{Environment.NewLine}");
            Console.WriteLine($"1. Easy {Environment.NewLine}" +
                                $"2. Hard {Environment.NewLine}" +
                                $"3. Exit the game {Environment.NewLine}");

            Console.WriteLine($"====================");
        }
    }
}
