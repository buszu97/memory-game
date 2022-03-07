using System;
using System.Collections.Generic;
using System.IO;

namespace MemoryGame
{
    class Program
    {
        private static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayChoices();
                switch (Console.ReadLine())
                {
                    case "1":
                        EasyLevel();
                        break;
                    case "2":
                        HardLevel();
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
        private static void EasyLevel()
        {
            List<string> randomWords = new List<string>();
            var chances = 10;
            Console.Clear();
            Console.WriteLine($"—-----------------------------------{Environment.NewLine}"+
                                $"Level: easy{Environment.NewLine}" +
                                $"Guess chances: {chances}{Environment.NewLine}");

            List<string> words = new List<string>(File.ReadAllLines(@"C:\Users\Marcin\source\repos\MemoryGame\Words.txt"));
            for (var i = 0; i < 4;)
            {
                var wordNumber = rnd.Next(0, words.Count);
                var output = words[wordNumber];
                if (randomWords.Contains(output))
                    continue;
                else
                {
                    randomWords.Add(output);
                    i++;
                }
            }
        }

        private static void HardLevel()
        {

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
