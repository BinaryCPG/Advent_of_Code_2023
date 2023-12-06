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

            /*
            List<Tuple<Int64, Int64>> seedRanges = new List<Tuple<long, long>>();
            {
                string[] seedLine = input[0].Split(new char[] { ':' })[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < seedLine.Length; i += 2)
                {
                    seedRanges.Add(new Tuple<Int64, Int64>(Int64.Parse(seedLine[i]), Int64.Parse(seedLine[i+1])));
                }
            }
            seedRanges.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            /
            A-to-B map:
                [offset value]
                    [
                        [lower range],[length]
                    ]
             /
            List<Dictionary<Int64, List<Tuple<Int64, Int64>>>> offsetMatrix = new List<Dictionary<long, List<Tuple<long, long>>>>();
            Dictionary<Int64, List<Tuple<Int64, Int64>>> newOffsetBlock = null;
            for (Int64 i = 1; i < input.Length; i++)
            {
                if (input[i].Length > 0)
                {
                    if (48 <= input[i][0] && input[i][0] <= 57)
                    {
                        if(newOffsetBlock == null)
                        {
                            newOffsetBlock = new Dictionary<long, List<Tuple<long, long>>>();
                        }

                        string[] line = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (line.Length != 3)
                            throw new ArgumentOutOfRangeException($"Expected line.Length==3 but line.Length=={line.Length} ({line})");
                        Int64 destOffset = Int64.Parse(line[0].Trim());
                        Int64 srcOffset = Int64.Parse(line[1].Trim());
                        Int64 rngLength = Int64.Parse(line[2].Trim());
                        Int64 offset = destOffset - srcOffset;

                        if (!newOffsetBlock.ContainsKey(offset))
                        {
                            newOffsetBlock.Add(offset, new List<Tuple<long, long>>());
                        }
                        newOffsetBlock[offset].Add(new Tuple<long, long>(srcOffset, rngLength));
                    }
                }
                else
                {
                    if (newOffsetBlock != null)
                    {
                        offsetMatrix.Add(newOffsetBlock);
                        newOffsetBlock = null;
                    }
                }
            }
            if (newOffsetBlock != null)
            {
                offsetMatrix.Add(newOffsetBlock);
                newOffsetBlock = null;
            }

            List<List<Int64>> offsetsSorted = new List<List<long>>();
            foreach(var offsetBlock in offsetMatrix)
            {
                List<Int64> offsets = new List<Int64>(offsetBlock.Keys);
                offsets.Sort((a, b) => a.CompareTo(b));
                offsetsSorted.Add(offsets);
            }

            sum = seedRanges.First().Item1;
            foreach(var sr in seedRanges)
            {
                var start = DateTime.Now;
                Console.WriteLine($"Starting range ({sr.Item1}|{sr.Item1 + sr.Item2-1})");
                for(Int64 i = sr.Item1; i < sr.Item1 + sr.Item2; i++)
                {
                    Int64 calcVal = i;
                    for (Int64 j = 0; j < offsetMatrix.Count; j++)
                    {
                        Int64 offset = 0;
                        foreach (var offsetBlockOffset in offsetMatrix[(int)j])
                        {
                            foreach(var offsetRange in offsetBlockOffset.Value)
                            {
                                if(offsetRange.Item1 <= calcVal && calcVal < offsetRange.Item1 + offsetRange.Item2)
                                {
                                    offset = offsetBlockOffset.Key;
                                    break;
                                }
                            }

                            if (offset != 0)
                            {
                                break;
                            }
                        }
                        calcVal += offset;
                    }
                    if(calcVal < sum)
                    {
                        sum = calcVal;
                        Console.WriteLine($"Newest lowest vaslue:{sum}");
                    }
                }
                Console.WriteLine($"Finished range ({sr.Item1}|{sr.Item1 + sr.Item2 - 1}) [{DateTime.Now-start}]");
            }
            */
            Console.WriteLine($"Sum: {sum}");

            Console.ReadLine();
        }
    }
}
