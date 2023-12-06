using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int sum = 0;

            Console.WriteLine("Advent_of_Code_2023 | Day_06 | 1");
            sum = 1;

            string[] times = input[0].Substring(10).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] distances = input[1].Substring(10).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < times.Length; i++)
            {
                int t_max = int.Parse(times[i]);
                int d_lim = int.Parse(distances[i]);
                double fA = t_max / 2.0;
                double fB = Math.Sqrt( ( Math.Pow(t_max,2) / 4.0) - (double)d_lim );
                sum *= ( ((int)Math.Ceiling(fA+fB) - 1) - ((int)Math.Floor(fA-fB) + 1) + 1);
            }

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("Advent_of_Code_2023 | Day_06 | 2");
            sum = 0;
            {
                Int64 t_max = Int64.Parse(input[0].Substring(10).Replace(" ", ""));
                Int64 d_lim = Int64.Parse(input[1].Substring(10).Replace(" ", ""));
                double fA = t_max / 2.0;
                double fB = Math.Sqrt((Math.Pow(t_max, 2) / 4.0) - (double)d_lim);
                sum = (((int)Math.Ceiling(fA + fB) - 1) - ((int)Math.Floor(fA - fB) + 1) + 1);
            }

            Console.WriteLine($"Sum: {sum}");

            Console.ReadLine();
        }
    }
}
