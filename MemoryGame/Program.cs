using System;
using System.IO;

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
                        Console.WriteLine($"You chose easy level.");
                        EasyLevel();
                        break;
                    case "2":
                        Console.WriteLine($"You chose hard level.");
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
            Console.Clear();
            Console.WriteLine($"Easy level started");

            string words = File.ReadAllText(@"C:\Users\Marcin\source\repos\MemoryGame\Words.txt");
            string[] wordsArray = words.Split(Environment.NewLine);
            Random randomWord = new Random();
            var wordsNumber = randomWord.Next(0, wordsArray.Length);
            var output = wordsArray[wordsNumber];
            Console.WriteLine(output, Environment.NewLine);
        }

        private static void HardLevel()
        {

        }
        private static void DisplayChoices()
        {
            Console.WriteLine($"====================");
            Console.WriteLine($"Choose difficulty level and press enter{Environment.NewLine}");
            Console.WriteLine($"1. Easy {Environment.NewLine}" +
                                $"2. Hard {Environment.NewLine}" +
                                $"3. Exit the game {Environment.NewLine}");

            Console.WriteLine($"====================");
        }
    }
}
