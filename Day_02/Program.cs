using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent_of_Code_2023 | Day_02 | 1");
            string[] input = File.ReadAllLines("input.txt");
            Dictionary<string, int> limits = new Dictionary<string, int>() { { "red", 12 }, {"green", 13 }, {"blue", 14 } };

            int sum = 0;
            for (int i = 0; i< input.Length; i++)
            {
                string[] lineParts = input[i].Split(new char[] { ':' });
                int limitsOkCount = 0;
                int currentIndex = int.Parse(lineParts[0].Replace("Game", "").Trim());
                string[] gameContent = lineParts[1].Split(new char[] {',', ';'});
                Dictionary<string, int> maxColorCount = new Dictionary<string, int>();

                for(int gp = 0; gp < gameContent.Length; gp++)
                {
                    string[] cleanPart = gameContent[gp].Trim().Split(new char[] { ' ' });
                    string color = cleanPart[1].Trim();
                    int count = int.Parse(cleanPart[0].Trim());

                    if (maxColorCount.Keys.Contains(color))
                    {
                        if(maxColorCount[color] < count)
                        {
                            maxColorCount[color] = count;
                        }
                    }
                    else
                    {
                        maxColorCount.Add(color, count);
                    }
                }

                foreach(string c in limits.Keys)
                {
                    if (maxColorCount.Keys.Contains(c))
                    {
                        if(maxColorCount[c] <= limits[c])
                        {
                            limitsOkCount++;
                        }
                    }
                    else
                    {
                        limitsOkCount++;
                    }
                }

                if(limitsOkCount == limits.Keys.Count)
                {
                    sum += currentIndex;
                }
            }

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("Advent_of_Code_2023 | Day_02 | 2");

            Console.ReadLine();
        }
    }
}
