using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.Advent
{
	internal class Advent4
	{
		public void Filter()
		{
			FileStream fs = new FileStream(@"C:\Users\Tesch\Downloads\input2.txt", FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			string currentString;
			string[] splitString, Draw;
			currentString = sr.ReadLine();
			splitString = currentString.Split(':', ';');
			//while (!sr.EndOfStream)
			//{
			//	currentString = sr.ReadLine();
			//	currentString.Split(':',';');
			//}
			Console.WriteLine(currentString);
			foreach (string s in splitString)
			{
				Draw = s.Split(',');
				Console.WriteLine(s);
			}
		}
		public void Part1()
		{
			FileStream fs = new FileStream(@"C:\Users\Tesch\Downloads\input4.txt", FileMode.Open);
			StreamReader sr = new StreamReader(fs);
			string currentline;
			string[] splitString, drawSplit, playerdraw, winningnumbers;
			int[] winningCardNumbers = new int[10];
			int[] playerdrawNumbers = new int[26];
			int[] testwinning = new int[10];
			int[] testplayer = new int[26];
			int cardworth = 0;
			int currentGamePoints = 0;
			int sum = 0;
			for(int i =0; i < 10; i++)
			{
				string currentlinetest;
				currentlinetest = sr.ReadLine();
				testwinning = SplitterWinningNumbers(currentlinetest);
				testplayer = SplitterPLayerNumbers(currentlinetest);
				foreach(int k in testwinning)
				{
                    Console.Write(k + " ");
                }
                Console.WriteLine();
                foreach (int j in testplayer)
				{
                    Console.Write(j + " ");
                }
				CardsValue(testwinning, testplayer);
			}
			//while (!sr.EndOfStream)
			//{
			//	currentline = sr.ReadLine();
			//	winningCardNumbers = SplitterWinningNumbers(currentline);
			//	playerdrawNumbers = SplitterPLayerNumbers(currentline);
			//	Console.WriteLine("WinningNumbers");
			//	foreach (int i in winningCardNumbers)
			//	{
			//		Console.WriteLine(i);
			//	}
			//	Console.WriteLine("=======================================");
			//             Console.WriteLine("PlayerDraw");

			//             foreach (int i in playerdrawNumbers)
			//	{
			//		Console.WriteLine(i);
			//	}
			//	CardsValue(winningCardNumbers, playerdrawNumbers);
			//         }
			int[] SplitterWinningNumbers(string line)
			{
				splitString = line.Split(':');
				drawSplit = splitString[1].Split('|');
				winningnumbers = Regex.Replace(drawSplit[0], @"\s+", " ").Trim().Split(' ');
				for (int i = 0; i < winningnumbers.Length; i++)
				{
					winningCardNumbers[i] = int.Parse(winningnumbers[i]);
				}
				return winningCardNumbers;

			}
			int[] SplitterPLayerNumbers(string line)
			{
				splitString = line.Split(':');
				drawSplit = splitString[1].Split('|');
				playerdraw = Regex.Replace(drawSplit[1], @"\s+", " ").Trim().Split(' ');
				for (int i = 0; i < playerdraw.Length; i++)
				{
					playerdrawNumbers[i] = int.Parse(playerdraw[i]);
				}
				return playerdrawNumbers;
			}
			int CardsValue(int[] winning, int[] player)
			{
				for (int i = 0; i < winning.Length; i++)
				{
					for (int j = 0; j < player.Length; j++)
					{
						if (player[j] == winning[i])
						{
							currentGamePoints++;
						}
					}
				}
				if (currentGamePoints > 1)
				{
					cardworth = 1;
					for (int i = 1; i < currentGamePoints; i++)
					{
						cardworth *= 2;
					}
					cardworth--;
				}
				else if (currentGamePoints == 1)
				{
					cardworth = 1;
				}
				sum += cardworth;
				currentGamePoints = 0;
                Console.WriteLine();
                Console.WriteLine("KartPunkte");
                Console.WriteLine(cardworth);
                cardworth = 0;
                Console.WriteLine("Punkte");
				Console.WriteLine(sum);
				return sum;
			}
		}
	}
}
