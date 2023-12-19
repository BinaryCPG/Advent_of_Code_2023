using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_07
{
    class Program
    {
        static List<char> cards = new List<char>(new char[] { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' });
        enum HandType
        {
            ERR = -1,
            HIGH_CARD = 0,
            ONE_PAIR = 1,
            TWO_PAIR = 2,
            THREE_KIND = 3,
            FULL_HOUSE = 4,
            FOUR_KIND = 5,
            FIVE_KIND = 6
        };
        class CardHand : IComparable<CardHand>
        {
            HandType type;
            char[] hand = new char[5];

            public CardHand(string shand, bool jokerRule = false)
            {
                if (shand.Length != 5)
                    throw new ArgumentException();

                Dictionary<int, int> handCountByValue = new Dictionary<int, int>();
                for(int i = 0; i < 5; i++)
                {
                    hand[i] = shand[i];
                    if (!handCountByValue.ContainsKey(cards.IndexOf(hand[i])))
                    {
                        handCountByValue.Add(cards.IndexOf(hand[i]), 0);
                    }
                    handCountByValue[cards.IndexOf(hand[i])]++;
                }

                type = HandType.ERR;

                if(jokerRule && handCountByValue.Keys.Contains(cards.IndexOf('J')))
                {
                    Dictionary<char, CardHand> tmpHands = new Dictionary<char, CardHand>();
                    foreach (char otherCard in shand)
                    {
                        if (!tmpHands.ContainsKey(otherCard))
                        {
                            tmpHands.Add(otherCard, new CardHand(shand.Replace('J', otherCard)));
                        }
                    }
                    List<CardHand> tmpCardRank = new List<CardHand>(tmpHands.Values);
                    tmpCardRank.Sort();
                    type = tmpCardRank.Last().type;                    
                }
                else
                {
                    switch (handCountByValue.Keys.Count)
                    {
                        case 1:
                            type = HandType.FIVE_KIND;
                            break;
                        case 2:
                            if (handCountByValue.Values.First() == 4 || handCountByValue.Values.First() == 1)
                            {
                                type = HandType.FOUR_KIND;
                            }
                            //else if (handCountByValue.Values.First() == 3 && handCountByValue.Values.Last() == 2)
                            else
                            {
                                type = HandType.FULL_HOUSE;
                            }
                            break;
                        case 3:
                            if(handCountByValue.Values.First() == 3 || handCountByValue.Values.Last()==3 || (handCountByValue.Values.First()==1 && handCountByValue.Values.Last() == 1))
                            {
                                type = HandType.THREE_KIND;
                            }
                            else
                            /*else if (
                                (handCountByValue.Values.First()==1 && handCountByValue.Values.Last()==2) ||
                                (handCountByValue.Values.First() == 2 && handCountByValue.Values.Last() == 1) ||
                                (handCountByValue.Values.First() == 2 && handCountByValue.Values.Last() == 2)
                                )*/
                            {
                                type = HandType.TWO_PAIR;
                            }
                            break;
                        case 4:
                            type = HandType.ONE_PAIR;
                            break;
                        case 5:
                            type = HandType.HIGH_CARD;
                            break;
                        default:
                            type = HandType.HIGH_CARD;
                            break;
                    }
                }


                if (type == HandType.ERR)
                    throw new Exception("Unknown hand type!");
            }

            public int CompareTo(CardHand other)
            {
                if(this.type != other.type)
                {
                    return this.type - other.type;
                }
                else
                {
                    for(int i = 0; i < 5; i++)
                    {
                        if (this.hand[i] != other.hand[i])
                        {
                            return cards.IndexOf(this.hand[i]) - cards.IndexOf(other.hand[i]);
                        }
                    }
                    return 0;
                }
            }
        }

        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int sum = 0;

            cards.Reverse(); // so indexof return can be used as value

            Console.WriteLine("Advent_of_Code_2023 | Day_07 | 1");
            sum = 0;

            Dictionary<CardHand, int> handToBids = new Dictionary<CardHand, int>();
            foreach(string line in input)
            {
                string[] lineComps = line.Split(new char[] { ' ' });
                handToBids.Add(new CardHand(lineComps[0]), int.Parse(lineComps[1]));
            }
            List<CardHand> handsSorted = new List<CardHand>(handToBids.Keys);
            handsSorted.Sort();

            for(int i = 0; i < handsSorted.Count; i++)
            {
                sum += (i + 1) * handToBids[handsSorted[i]];
            }

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("Advent_of_Code_2023 | Day_07 | 2");
            sum = 0;

            cards = new List<char>(new char[] { 'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J' });
            cards.Reverse();

            handToBids = new Dictionary<CardHand, int>();
            foreach (string line in input)
            {
                string[] lineComps = line.Split(new char[] { ' ' });
                handToBids.Add(new CardHand(lineComps[0], true), int.Parse(lineComps[1]));
            }
            handsSorted = new List<CardHand>(handToBids.Keys);
            handsSorted.Sort();

            for (int i = 0; i < handsSorted.Count; i++)
            {
                sum += (i + 1) * handToBids[handsSorted[i]];
            }

            Console.WriteLine($"Sum: {sum}");

            Console.ReadLine();
        }
    }
}
