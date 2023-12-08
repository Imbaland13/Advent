using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Advent
{
    internal class Advent7
    {
        public void Part1()
        {
            FileStream fs = new FileStream(@"C:\Users\Dan\Documents\input7.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string line;
            string cards;
            string[] hands;
            var one = new Dictionary<string, int>();
            var onePair = new Dictionary<string, int>();
            var twoPair = new Dictionary<string, int>();
            var threeOfAKind = new Dictionary<string, int>();
            var fullHouse = new Dictionary<string, int>();
            var fourOfAKind = new Dictionary<string, int>();
            var fiveOfAKind = new Dictionary<string, int>();
            char[] cardValues = new char[] { 'A', 'K', 'Q', 'J', 'T', '9',
                '8', '7', '6', '5', '4', '3', '2' };
            int bits;
            var occurences = new int[13];
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < 5; i++)
            {
                line = sr.ReadLine();
                hands = line.Split(' ');
                cards = hands[0];
                bits = int.Parse(hands[1]);
                for (int j = 0; j < cardValues.Length; j++)
                {
                    occurences[j] = cards.Count(c => c == cardValues[j]);
                    if (occurences.Sum() == 5) break;
                }
                if (occurences.Max() == 1) { one.Add(hands[0], bits); }
                else if (occurences.Max() == 2 
                    && occurences.Any(x => x.Equals(2))) { twoPair.Add(cards, bits); }
                else if (occurences.Max() == 2) { onePair.Add(cards, bits); }
                else if (occurences.Max() == 3 
                    && occurences.Any(x => x.Equals(2))) { fullHouse.Add(cards, bits); }
                else if (occurences.Max() == 3) { threeOfAKind.Add(cards, bits); }
                else if (occurences.Max() == 4) { fourOfAKind.Add(cards, bits); }
                else if (occurences.Max() == 5) { fiveOfAKind.Add(cards, bits); }         
            }
            dict = one.Concat(twoPair).ToDictionary(x=>x.Key,x=>x.Value);
            foreach (int i in occurences) { Console.WriteLine(i); }
        }
        public Dictionary<string,int> sortDict(Dictionary<string,int> unsortedDict)
        {
            Dictionary<string, int> sortedDict= new Dictionary<string, int>();
            for(int i = 0; i < unsortedDict.Count; i++)
            {
                
            }
            return sortedDict;
        }
    }
}



