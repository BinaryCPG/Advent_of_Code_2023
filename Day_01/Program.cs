using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent_of_Code_2023 | Day_01 | 1");
            string[] input = File.ReadAllLines("input.txt");
            int sum = 0;
            for(int i = 0; i < input.Length; i++)
            {
                char[] digits = input[i].ToCharArray().Where(x => x >= 48 && x <= 57).ToArray();
                sum += (((digits[0] - 48) * 10) + (digits[digits.Length - 1]-48));
            }
            Console.WriteLine($"Sum: {sum}");
            Console.ReadLine();
        }
    }
}
