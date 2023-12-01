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

            Console.WriteLine("Advent_of_Code_2023 | Day_01 | 2");
            //not proud but works
            sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for(int d1 = 0; d1 < input[i].Length; d1++)
                {
                    string _loc = input[i].Substring(d1);
                    if(_loc[0] >= 48 && _loc[0] <= 57)
                    {
                        sum += (_loc[0] - 48) * 10;
                        break;
                    }
                    else if(_loc.StartsWith("one"))
                    {
                        sum += 10;
                        break;
                    }
                    else if (_loc.StartsWith("two"))
                    {
                        sum += 20;
                        break;
                    }
                    else if (_loc.StartsWith("three"))
                    {
                        sum += 30;
                        break;
                    }
                    else if (_loc.StartsWith("four"))
                    {
                        sum += 40;
                        break;
                    }
                    else if (_loc.StartsWith("five"))
                    {
                        sum += 50;
                        break;
                    }
                    else if (_loc.StartsWith("six"))
                    {
                        sum += 60;
                        break;
                    }
                    else if (_loc.StartsWith("seven"))
                    {
                        sum += 70;
                        break;
                    }
                    else if (_loc.StartsWith("eight"))
                    {
                        sum += 80;
                        break;
                    }
                    else if (_loc.StartsWith("nine"))
                    {
                        sum += 90;
                        break;
                    }
                }
                for (int d2 = 0; d2 < input[i].Length; d2++)
                {
                    string _loc = input[i].Substring(0, input[i].Length - d2);
                    if (_loc[_loc.Length-1] >= 48 && _loc[_loc.Length - 1] <= 57)
                    {
                        sum += (_loc[_loc.Length - 1] - 48);
                        break;
                    }
                    else if (_loc.EndsWith("one"))
                    {
                        sum += 1;
                        break;
                    }
                    else if (_loc.EndsWith("two"))
                    {
                        sum += 2;
                        break;
                    }
                    else if (_loc.EndsWith("three"))
                    {
                        sum += 3;
                        break;
                    }
                    else if (_loc.EndsWith("four"))
                    {
                        sum += 4;
                        break;
                    }
                    else if (_loc.EndsWith("five"))
                    {
                        sum += 5;
                        break;
                    }
                    else if (_loc.EndsWith("six"))
                    {
                        sum += 6;
                        break;
                    }
                    else if (_loc.EndsWith("seven"))
                    {
                        sum += 7;
                        break;
                    }
                    else if (_loc.EndsWith("eight"))
                    {
                        sum += 8;
                        break;
                    }
                    else if (_loc.EndsWith("nine"))
                    {
                        sum += 9;
                        break;
                    }
                }
            }
            Console.WriteLine($"Sum: {sum}");

            Console.ReadLine();
        }
    }
}
