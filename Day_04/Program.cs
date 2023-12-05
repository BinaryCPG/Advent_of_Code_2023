using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_04
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int sum = 0;

            Console.WriteLine("Advent_of_Code_2023 | Day_04 | 1");
            sum = 0;

            // 2
            Dictionary<int, int> numWonNumbers = new Dictionary<int, int>();

            for(int i = 0; i < input.Length; i++)
            {
                List<int> winningNumbers = new List<int>();
                List<int> myNumbers = new List<int>();
                int points = 0;

                // 2
                if (!numWonNumbers.ContainsKey(i))
                {
                    numWonNumbers.Add(i, 0);
                }

                string[] numbers = input[i].Split(new char[] { ':' })[1].Split(new char[] { '|' });
                foreach(string n in numbers[0].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries))
                {
                    winningNumbers.Add(int.Parse(n.Trim()));
                }
                foreach (string n in numbers[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    myNumbers.Add(int.Parse(n.Trim()));
                }
                foreach(int mn in myNumbers)
                {
                    if (winningNumbers.Contains(mn))
                    {
                        if (points == 0)
                        {
                            points = 1;
                        }
                        else
                        {
                            points *= 2;
                        }

                        // 2
                        numWonNumbers[i]++;
                    }
                }
                sum += points;
            }

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("Advent_of_Code_2023 | Day_04 | 2");
            sum = 0;

            Queue<int> cardsToProcess = new Queue<int>();
            for(int i = 0; i < input.Length; i++) { cardsToProcess.Enqueue(i); }

            while(cardsToProcess.Count>0){
                int cardIndex = cardsToProcess.Dequeue();
                if (numWonNumbers.ContainsKey(cardIndex))
                {
                    sum++;

                    for (int i = cardIndex + 1; i < numWonNumbers[cardIndex] + cardIndex + 1; i++)
                    {
                        cardsToProcess.Enqueue(i);
                    }
                }
            }

            Console.WriteLine($"Sum: {sum}");

            Console.ReadLine();
        }
    }
}
