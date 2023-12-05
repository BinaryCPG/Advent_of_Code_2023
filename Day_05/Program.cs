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
            Int64 sum = 0;

            Console.WriteLine("Advent_of_Code_2023 | Day_05 | 1");
            sum = 0;

            List<Int64> seeds_tmp = new List<Int64>();
            foreach (string n in input[0].Split(new char[] {':'})[1].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)) { seeds_tmp.Add(Int64.Parse(n)); }
            Int64[] seeds = seeds_tmp.ToArray();

#if DEBUG
            Dictionary<Int64, Dictionary<Int64, Int64>> seedHistory = new Dictionary<Int64, Dictionary<Int64, Int64>>();
            for(Int64 k = 0; k < seeds.Length; k++) 
            {
                seedHistory.Add(k, new Dictionary<Int64, Int64>());
                seedHistory[k].Add(0, seeds[k]);
            }
#endif

            Int64[] seeds_new = null;
            for(Int64 i = 1; i < input.Length; i++)
            {
                if (input[i].Length > 0)
                {

                    if (48 <= input[i][0] && input[i][0] <= 57)
                    {
                        if(seeds_new == null)
                        {
                            seeds_new = (new List<Int64>(seeds)).ToArray(); ;
                        }

                        string[] line = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (line.Length != 3)
                            throw new ArgumentOutOfRangeException($"Expected line.Length==3 but line.Length=={line.Length} ({line})");
                        Int64 destOffset = Int64.Parse(line[0].Trim());
                        Int64 srcOffset = Int64.Parse(line[1].Trim());
                        Int64 rngLength = Int64.Parse(line[2].Trim());

                        for (Int64 j = 0; j < seeds.Length; j++)
                        {
                            if (0 <= seeds[j] - srcOffset && seeds[j] - srcOffset < rngLength)
                            {
                                seeds_new[j] = (seeds[j] - srcOffset) + destOffset;
                            }
                        }

                    }
                }
                else
                {
                    if (seeds_new != null)
                    {
                        for (Int64 j = 0; j < seeds.Length; j++)
                        {
                            seeds[j] = seeds_new[j];
                        }
#if DEBUG
                        for (Int64 k = 0; k < seeds.Length; k++) { seedHistory[k].Add(i, seeds[k]); }
#endif
                        seeds_new = null;
                    }
                }
            }

            if (seeds_new != null)
            {
                for (Int64 j = 0; j < seeds.Length; j++)
                {
                    seeds[j] = seeds_new[j];
                }
#if DEBUG
                for (Int64 k = 0; k < seeds.Length; k++) { seedHistory[k].Add(input.Length, seeds[k]); }
#endif
                seeds_new = null;
            }

            sum = seeds[0];
            foreach(Int64 v in seeds)
            {
                if(sum > v)
                {
                    sum = v;
                }
            }

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("Advent_of_Code_2023 | Day_05 | 2");
            sum = 0;



            Console.WriteLine($"Sum: {sum}");

            Console.ReadLine();
        }
    }
}
