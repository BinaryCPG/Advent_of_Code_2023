using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_05
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int sum = 0;

            Console.WriteLine("Advent_of_Code_2023 | Day_04 | 1");
            sum = 0;

            List<int> seeds = new List<int>();
            List<Dictionary<int, int>> transformMap = new List<Dictionary<int, int>>();

            //Parse
            foreach(string n in input[0].Split(new char[] {':'})[1].Split(new char[] {' ' })) { seeds.Add(int.Parse(n)); }
            for(int i = 1; i < input.Length; i++)
            {
                Dictionary<int, int> localMap = new Dictionary<int, int>();
                if (input[i].Length == 0)
                {
                    if (localMap != null)
                    {
                        if (localMap.Keys.Count > 0)
                        {
                            transformMap.Add(localMap);
                        }
                    }
                }
                else if(48 <= input[i][0] && input[i][0] <= 57)
                {
                    string[] rawTransform = input[i].Split(new char[] { ' ' });
                    if (rawTransform.Length != 3)
                        throw new ArgumentOutOfRangeException($"Array has not 3 values: {rawTransform}({rawTransform.Length})");

                    for(int j = 0; j < int.Parse(rawTransform[2]); j++)
                    {
                        localMap.Add(int.Parse(rawTransform[1]) + j, int.Parse(rawTransform[0]) + j);
                    }
                }
                else //text
                {
                    localMap = new Dictionary<int, int>();
                }
            }

            //Calc

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("Advent_of_Code_2023 | Day_04 | 2");
            sum = 0;



            Console.WriteLine($"Sum: {sum}");
        }
    }
}
