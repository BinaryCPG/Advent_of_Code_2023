using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_08
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int sum = 0;

            string instructions = input[0];
            Dictionary<int, Tuple<int, int>> map = new Dictionary<int, Tuple<int, int>>();
            for(int i = 2; i < input.Length; i++)
            {
                map.Add(GetNodeValue(input[i].Substring(0, 3)), new Tuple<int, int>(GetNodeValue(input[i].Substring(7, 3)), GetNodeValue(input[i].Substring(12, 3))));
            }

            Console.WriteLine("Advent_of_Code_2023 | Day_08 | 1");
            sum = 0;
            int currentNode = 0;
            Queue<char> currentInst = new Queue<char>();
            while(currentNode != GetNodeValue("ZZZ"))
            {
                if (currentInst.Count == 0)
                {
                    foreach(char c in instructions)
                    {
                        currentInst.Enqueue(c);
                    }
                }

                char inst = currentInst.Dequeue();
                currentNode = inst == 'L' ? map[currentNode].Item1 : map[currentNode].Item2;
                sum++;
            }

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("Advent_of_Code_2023 | Day_08 | 2");
            sum = 0;

            Dictionary<int, Tuple<int, int>> nodeFinishLoopInfo = new Dictionary<int, Tuple<int, int>>();
            foreach (int n in map.Keys)
            {
                if (n == 0 || n.ToString().EndsWith("00"))
                {
                    int stepsToFininsh = 0;
                    currentNode = n;
                    currentInst = new Queue<char>();
                    while (!IsEndNode(currentNode))
                    {
                        if (currentInst.Count == 0)
                        {
                            foreach (char c in instructions)
                            {
                                currentInst.Enqueue(c);
                            }
                        }

                        char inst = currentInst.Dequeue();
                        currentNode = inst == 'L' ? map[currentNode].Item1 : map[currentNode].Item2;
                        stepsToFininsh++;
                    }

                    int finishLoopSteps = 0;
                    int stopNode = currentNode;
                    while (currentNode!=stopNode || finishLoopSteps==0)
                    {
                        if(IsEndNode(currentNode) && currentNode != stopNode)
                        {
                            Console.WriteLine($"Run '{n}' hit non-expected End Node: {currentNode}");
                        }
                        if (currentInst.Count == 0)
                        {
                            foreach (char c in instructions)
                            {
                                currentInst.Enqueue(c);
                            }
                        }

                        char inst = currentInst.Dequeue();
                        currentNode = inst == 'L' ? map[currentNode].Item1 : map[currentNode].Item2;
                        finishLoopSteps++;
                    }

                    nodeFinishLoopInfo.Add(n, new Tuple<int, int>(stepsToFininsh, finishLoopSteps));
                }
            }

            long sum2 = nodeFinishLoopInfo.First().Value.Item1;
            for(int i = 1; i < nodeFinishLoopInfo.Count; i++)
            {
                sum2 = lcm(sum2, (long)nodeFinishLoopInfo.ElementAt(i).Value.Item1);
            }


            Console.WriteLine($"Sum: {sum2}");

            Console.ReadLine();
        }

        static int GetNodeValue(string inp)
        {
            if (inp.Length != 3)
                throw new ArgumentException();

            return (inp[0] - 65) * 10000 + (inp[1] - 65) * 100 + (inp[2] - 65);
        }

        static bool IsEndNode(int nodeVal)
        {
            return nodeVal.ToString().EndsWith("25");
        }

        // https://stackoverflow.com/a/20824923/8205453
        static long gcf(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static long lcm(long a, long b)
        {
            return (a / gcf(a, b)) * b;
        }
    }
}
