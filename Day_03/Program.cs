using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int sum = 0;

            Console.WriteLine("Advent_of_Code_2023 | Day_03 | 1");
            sum = 0;

            Dictionary<int, Dictionary<int, PseudoNum>> partNumbers = new Dictionary<int, Dictionary<int, PseudoNum>>();
            List<Tuple<int, int>> symbols = new List<Tuple<int, int>>();

            StringBuilder numBuffer = new StringBuilder();
            List<Tuple<int, int>> numCoordBuffer = new List<Tuple<int, int>>();

            List<PseudoNum> toAdd = new List<PseudoNum>();

            //Parse partNumbers & symbols
            for (int i = 0; i < input.Length; i++)
            {
                numBuffer.Clear();
                numCoordBuffer.Clear();

                char[] line = input[i].ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] >= 48 && line[j] <= 57)
                    {
                        numBuffer.Append(line[j]);
                        numCoordBuffer.Add(new Tuple<int, int>(i, j));
                    }
                    else 
                    {
                        if (line[j] != '.')
                        {
                            symbols.Add(new Tuple<int, int>(i, j));
                        }
                        
                        if (numBuffer.Length > 0)
                        {
                            PseudoNum p = new PseudoNum(int.Parse(numBuffer.ToString()));
                            foreach (var cSet in numCoordBuffer)
                            {
                                if (!partNumbers.Keys.Contains(cSet.Item1))
                                {
                                    partNumbers.Add(cSet.Item1, new Dictionary<int, PseudoNum>());
                                }
                                partNumbers[cSet.Item1].Add(cSet.Item2, p);
                            }
                            numBuffer.Clear();
                            numCoordBuffer.Clear();
                        }
                    }
                    
                }

                if (numBuffer.Length > 0)
                {
                    PseudoNum p = new PseudoNum(int.Parse(numBuffer.ToString()));
                    foreach (var cSet in numCoordBuffer)
                    {
                        if (!partNumbers.Keys.Contains(cSet.Item1))
                        {
                            partNumbers.Add(cSet.Item1, new Dictionary<int, PseudoNum>());
                        }
                        partNumbers[cSet.Item1].Add(cSet.Item2, p);
                    }
                    numBuffer.Clear();
                    numCoordBuffer.Clear();
                }
            }

            //Locate partNumbers toAdd
            foreach (var sCord in symbols)
            {
                for(int i = sCord.Item1-1; i <= sCord.Item1+1; i++)
                {
                    for (int j = sCord.Item2 - 1; j <= sCord.Item2 + 1; j++)
                    {
                        if (partNumbers.ContainsKey(i))
                        {
                            if (partNumbers[i].ContainsKey(j))
                            {
                                if (!toAdd.Contains(partNumbers[i][j]))
                                {
                                    toAdd.Add(partNumbers[i][j]);
                                }
                            }
                        }
                    }
                }
            }

            foreach(var p in toAdd)
            {
                sum += p.value;
            }

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("Advent_of_Code_2023 | Day_03 | 2");
            sum = 0;

            foreach (var sCord in symbols)
            {
                List<PseudoNum> adjParts = new List<PseudoNum>();
                if (input[sCord.Item1].ToCharArray()[sCord.Item2] == '*')
                {
                    for (int i = sCord.Item1 - 1; i <= sCord.Item1 + 1; i++)
                    {
                        for (int j = sCord.Item2 - 1; j <= sCord.Item2 + 1; j++)
                        {
                            if (partNumbers.ContainsKey(i))
                            {
                                if (partNumbers[i].ContainsKey(j))
                                {
                                    if (!adjParts.Contains(partNumbers[i][j]))
                                    {
                                        adjParts.Add(partNumbers[i][j]);
                                    }
                                }
                            }

                            if(adjParts.Count > 2)
                            {
                                break;
                            }
                        }

                        if (adjParts.Count > 2)
                        {
                            break;
                        }
                    }

                    if(adjParts.Count == 2)
                    {
                        sum += (adjParts.First().value* adjParts.Last().value);
                    }
                }
            }

            Console.WriteLine($"Sum: {sum}");

            Console.ReadLine();
        }

        private class PseudoNum
        {
            public int value;

            public PseudoNum(int v)
            {
                value = v;
            }
        }
    }
}
