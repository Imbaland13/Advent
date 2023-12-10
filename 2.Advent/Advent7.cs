﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _2.Advent
{
	internal class Advent7
	{
		public void Part1()
		{
			FileStream fs = new FileStream(@"C:\Users\Tesch\Downloads\input7.txt", FileMode.Open);
			//FileStream fs = new FileStream(@"C:\Users\Tesch\Downloads\testinput7.txt", FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			string line;
			string cards;
			int result = 0;
			string[] hands;
			var one = new List<CompleteHands>();
			var onePair = new List<CompleteHands>();
			var twoPair = new List<CompleteHands>();
			var threeOfAKind = new List<CompleteHands>();
			var fullHouse = new List<CompleteHands>();
			var fourOfAKind = new List<CompleteHands>();
			var fiveOfAKind = new List<CompleteHands>();
			var oneOrdered = new List<CompleteHands>();
			var pairOrdered = new List<CompleteHands>();
			var twoPairsOrdered = new List<CompleteHands>();
			var threeOrdered = new List<CompleteHands>();
			var fourOrdered = new List<CompleteHands>();
			var fiveOrdered = new List<CompleteHands>();
			var fullHouseOrdered = new List<CompleteHands>();
			var completeGame = new List<CompleteHands>();
			char[] cardValues = new char[] { 'A', 'K', 'Q', 'J', 'T', '9',
				'8', '7', '6', '5', '4', '3', '2' };
			int bits;
			var occurences = new int[13];
			while (!sr.EndOfStream)
			{
				line = sr.ReadLine();
				hands = line.Split(' ');
				cards = hands[0];
				bits = int.Parse(hands[1]);
				for (int j = 0; j < cardValues.Length; j++)
				{
					occurences[j] = cards.Count(c => c == cardValues[j]);
				}
				if (occurences.Max() == 1) { one.Add(new CompleteHands { Hand = cards, Bits = bits }); }
				else if (occurences.Count(x => x.Equals(2)) == 2) { twoPair.Add(new CompleteHands { Hand = cards, Bits = bits }); }
				else if (occurences.Max() == 2) { onePair.Add(new CompleteHands { Hand = cards, Bits = bits }); }
				else if (occurences.Max() == 3 && occurences.Contains(2))
				{
					fullHouse.Add(new CompleteHands { Hand = cards, Bits = bits });
				}
				else if (occurences.Max() == 3) { threeOfAKind.Add(new CompleteHands { Hand = cards, Bits = bits }); }
				else if (occurences.Max() == 4) { fourOfAKind.Add(new CompleteHands { Hand = cards, Bits = bits }); }
				else if (occurences.Max() == 5) { fiveOfAKind.Add(new CompleteHands { Hand = cards, Bits = bits }); }
			}
			oneOrdered = HandEvaluation(one);
			pairOrdered = HandEvaluation(onePair);
			twoPairsOrdered = HandEvaluation(twoPair);
			threeOrdered = HandEvaluation(threeOfAKind);
			fourOrdered = HandEvaluation(fourOfAKind);
			fullHouseOrdered = HandEvaluation(fullHouse);
			fiveOrdered = HandEvaluation(fiveOfAKind);
			completeGame = MergeLists(oneOrdered, pairOrdered, twoPairsOrdered, threeOrdered, fullHouseOrdered, fourOrdered, fiveOrdered);
			Console.WriteLine("==========================================================================");
			completeGame.ForEach(x => Console.WriteLine(x.Hand + " " + x.Bits));
			Console.WriteLine(completeGame.Count());
			for (int i = 0; i < completeGame.Count(); i++)
			{
				result += completeGame[i].Bits * (i + 1);
			}
            Console.WriteLine(result);
        }
		public List<CompleteHands>[] SortHandsIntoLists(List<CompleteHands> completeHands, StreamReader sr)
		{
			char[] cardValues = new char[] { 'A', 'K', 'Q', 'J', 'T', '9',
			'8', '7', '6', '5', '4', '3', '2' };
			int bits;
			var occurences = new int[13];
			string line;
			string cards;
			string[] hands;
			var one = new List<CompleteHands>();
			var onePair = new List<CompleteHands>();
			var twoPair = new List<CompleteHands>();
			var threeOfAKind = new List<CompleteHands>();
			var fullHouse = new List<CompleteHands>();
			var fourOfAKind = new List<CompleteHands>();
			var fiveOfAKind = new List<CompleteHands>();
			List<CompleteHands>[] arrOfLists = new List<CompleteHands>[7] {one,onePair,twoPair,threeOfAKind,fullHouse,fourOfAKind,fiveOfAKind};
			while (!sr.EndOfStream)
			{
				
				line = sr.ReadLine();
				hands = line.Split(' ');
				cards = hands[0];
				bits = int.Parse(hands[1]);
				for (int j = 0; j < cardValues.Length; j++)
				{
					occurences[j] = cards.Count(c => c == cardValues[j]);
				}
				if (occurences.Max() == 1 && occurences[3] == 0) { one.Add(new CompleteHands { Hand = cards, Bits = bits }); }
				else if (occurences.Count(x => x.Equals(2)) == 2 || ) { twoPair.Add(new CompleteHands { Hand = cards, Bits = bits }); }
				else if (occurences.Max() == 2) { onePair.Add(new CompleteHands { Hand = cards, Bits = bits }); }
				else if (occurences.Max() == 3 && occurences.Contains(2))
				{
					fullHouse.Add(new CompleteHands { Hand = cards, Bits = bits });
				}
				else if (occurences.Max() == 3) { threeOfAKind.Add(new CompleteHands { Hand = cards, Bits = bits }); }
				else if (occurences.Max() == 4 || occurences[3] + occurences.Max() == 4) 
				{ 
					fourOfAKind.Add(new CompleteHands { Hand = cards, Bits = bits }); 
				}
				else if (occurences.Max() == 5 || occurences[3] + occurences.Max() == 5) 
				{ 
					fiveOfAKind.Add(new CompleteHands { Hand = cards, Bits = bits }); 
				}
			}
			arrOfLists[0] = one;
			arrOfLists[1] = onePair;
			arrOfLists[2] = twoPair;
			arrOfLists[3] = threeOfAKind;
			arrOfLists[4] = fullHouse;
			arrOfLists[5] = fourOfAKind;
			arrOfLists[6] = fiveOfAKind;
			return arrOfLists;
		}
		public List<CompleteHands> MergeLists(List<CompleteHands> dict1, List<CompleteHands> dict2,
			List<CompleteHands> dict3, List<CompleteHands> dict4, List<CompleteHands> dict5, List<CompleteHands> dict6,
			List<CompleteHands> dict7)
		{		
			return dict1.Concat(dict2).Concat(dict3).
				Concat(dict4).Concat(dict5).Concat(dict6).Concat(dict7).ToList();
		}
		public void PrintDict(List<CompleteHands> hands)
		{
			Console.WriteLine("===========================================================================");
			foreach (CompleteHands s in hands)
			{

				Console.Write(s.Hand + " "); Console.Write(s.Bits + " ");
			}
		}
		public List<CompleteHands> HandEvaluation(List<CompleteHands> CH)
		{

			List<CompleteHands> sortedList = new List<CompleteHands>();
			char firstchar = 'A';
			char secondchar;
			char thirdchar;
			char fourthchar;
			char fifthchar;
			foreach (var obj in CH)
			{
				firstchar = obj.Hand[0];
				secondchar = obj.Hand[1];
				thirdchar = obj.Hand[2];
				fourthchar = obj.Hand[3];
				fifthchar = obj.Hand[4];
				obj.StartCardValue = CardEvaluation(firstchar);
				obj.SecondaryCardValue = CardEvaluation(secondchar);
				obj.ThirdCardValue = CardEvaluation(thirdchar);
				obj.FourthCardValue = CardEvaluation(fourthchar);
				obj.FifthCardValue = CardEvaluation(fifthchar);
				sortedList = CH.OrderBy(x => x.StartCardValue)
					.ThenBy(x => x.SecondaryCardValue).ThenBy(x => x.ThirdCardValue).
					ThenBy(x => x.FourthCardValue).ThenBy(x => x.FifthCardValue).ToList();
			}
			return sortedList;
		}
		public List<CompleteHands> HandEvaluationJoker()
		{
			var list = new List<CompleteHands>();
			return list;
		}
		public int CardEvaluation(char c)
		{
			int cardvalue = 0;
			if (Char.IsDigit(c)) cardvalue += Convert.ToInt32(c) - '0';
			else
			{
				switch (c)
				{
					case 'A':
						cardvalue += (int)CardValues.A;
						break;
					case 'K':
						cardvalue += (int)CardValues.K;
						break;
					case 'Q':
						cardvalue += (int)CardValues.Q;
						break;
					case 'J':
						cardvalue += (int)CardValues.J;
						break;
					case 'T':
						cardvalue += (int)CardValues.T;
						break;
				}
			}

			return cardvalue;
		}
		public class CompleteHands
		{
			public string Hand { get; set; }
			public int Bits { get; set; }
			public int StartCardValue { get; set; }
			public int SecondaryCardValue { get; set; }
			public int ThirdCardValue { get; set; }
			public int FourthCardValue { get; set; }
			public int FifthCardValue { get; set; }
		}
		enum CardValues
		{
			A = 14,
			K = 13,
			Q = 12,
			J = 1,
			T = 10,
		}
	}
}



