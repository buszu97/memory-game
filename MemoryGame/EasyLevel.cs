using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MemoryGame
{
    class EasyLevel
    {
        private static readonly Random rnd = new Random();
        public static void StartGame()
        {
            {
                List<string> randomWords = new List<string>();
                var chances = 10;
                Console.Clear();
                Console.WriteLine($"—-----------------------------------{Environment.NewLine}" +
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
                        randomWords.Add(output);
                        i++;
                    }
                }
                randomWords = randomWords.OrderBy(x => rnd.Next()).ToList();

                string[,] gameTab = new string[3, 5];
                gameTab[0, 0] = " ";
                gameTab[0, 1] = "1";
                gameTab[0, 2] = "2";
                gameTab[0, 3] = "3";
                gameTab[0, 4] = "4";
                gameTab[1, 0] = "A";
                gameTab[2, 0] = "B";
                var randomWordsIndex = 0;
                for (int i = 1; i < gameTab.GetLength(0); i++)
                {
                    for (int j = 1; j < gameTab.GetLength(1); j++)
                    {
                        gameTab[i, j] = randomWords[randomWordsIndex];
                        randomWordsIndex++;
                    }
                }

                string[,] gameTabCovered = new string[3, 5];
                gameTabCovered[0, 0] = " ";
                gameTabCovered[0, 1] = "1";
                gameTabCovered[0, 2] = "2";
                gameTabCovered[0, 3] = "3";
                gameTabCovered[0, 4] = "4";
                gameTabCovered[1, 0] = "A";
                gameTabCovered[2, 0] = "B";
                for (int i = 1; i < gameTabCovered.GetLength(0); i++)
                {
                    for (int j = 1; j < gameTabCovered.GetLength(1); j++)
                    {
                        gameTabCovered[i, j] = "X";
                    }
                }
                for (int i = 0; i < gameTabCovered.GetLength(0); i++)
                {
                    for (int j = 0; j < gameTabCovered.GetLength(1); j++)
                    {
                        Console.Write($"{gameTabCovered[i, j]} ");
                    }
                    Console.WriteLine();
                }
                do
                {
                    Console.WriteLine("Give coordinates (eg. A3): ");
                    var coordinates = Console.ReadLine();
                    if (coordinates.Length != 2 )
                    {
                        Console.WriteLine($"Wrong coordinates, try again");
                        continue;
                    }
                    var x = coordinates.First().ToString();
                    int xTab = 0;
                    var y = coordinates.Last();
                    var yTab = Int32.Parse(y.ToString());
                    if (Regex.IsMatch(x.ToString(), "[c-zC-Z]") || yTab > 4)
                    {
                        Console.WriteLine($"Wrong coordinates, try again");
                        continue;
                    }
                    
                    if (x == "A" || x == "a")
                        xTab = 1;
                    else
                        xTab = 2;

                    gameTabCovered[xTab, yTab] = gameTab[xTab, yTab];
                    for (int i = 0; i < gameTabCovered.GetLength(0); i++)
                    {
                        for (int j = 0; j < gameTabCovered.GetLength(1); j++)
                        {
                            Console.Write($"{gameTabCovered[i, j]} ");
                        }
                        Console.WriteLine();
                    }
                } while (chances > 0);


                Console.WriteLine($"—-----------------------------------");
            }
        }
    }
}
