using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _2.Advent
{
    internal class Advent6
    {
        public void Part1()
        {
            FileStream fs = new FileStream(@"C:\Users\Dan\Downloads\input6.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string timestring = sr.ReadLine();
            string[] timesplit, distancesplit;
            int[] time = new int[5];
            int[] distance = new int[5];
            timesplit = timestring.Split(':');
            time = InputParsing(timesplit[1]);
            string distancestring = sr.ReadLine();
            distancesplit = distancestring.Split(':');
            distance = InputParsing(distancesplit[1]);
            Solutionsfor4Boats(time, distance);
        }
        public void Part2()
        {
            FileStream fs = new FileStream(@"C:\Users\Dan\Downloads\input6.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            double time, distance;
            string[] timesplit, distancesplit;
            string timestring = sr.ReadLine();
            timesplit = timestring.Split(':');
            time = InputParsing2(timesplit[1]);
            string distancestring = sr.ReadLine();
            distancesplit = distancestring.Split(':');
            distance = InputParsing2(distancesplit[1]);
            SolutionForOneBoat(time, distance);
            Console.ReadLine();
        }
        public int[] InputParsing(string input)
        {
            int[] ints = new int[5];
            string[] parsedinput = new string[10];
            string[] parse = new string[5];
            parsedinput = input.Split(':');
            parse = Regex.Replace(parsedinput[0], @"\s +", " ").Trim().Split(' ');
            ints = StringToIntArr(parse);
            return ints;
        }
        public double InputParsing2(string input)
        {
            double inputasdouble;
            string parsedinput; 
            parsedinput = Regex.Replace(input, @"\s +", "").Trim();
            inputasdouble = Convert.ToInt64(parsedinput);
            Convert.ToDouble(inputasdouble);
            return inputasdouble;
        }
        public int[] StringToIntArr(string[] str)
        {
            int[] ints = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                ints[i] = int.Parse(str[i]);
            }
            return ints;
        }
        public void Solutionsfor4Boats(int[] time, int[] distance)
        {
            int speed;
            int remainingtime;
            int traveldistance;
            var results1 = new List<int>();
            var results2 = new List<int>();
            var results3 = new List<int>();
            var results4 = new List<int>();
            for (int i = 0; i < time.Length; i++)
            {
                remainingtime = time[i];
                for (int j = 0; j < time[i]; j++)
                {
                    remainingtime = time[i];
                    speed = j;
                    remainingtime -= speed;
                    traveldistance = speed * remainingtime;
                    if (traveldistance >= distance[i] && i == 0) { results1.Add(speed); }
                    if (traveldistance >= distance[i] && i == 1) { results2.Add(speed); }
                    if (traveldistance >= distance[i] && i == 2) { results3.Add(speed); }
                    if (traveldistance >= distance[i] && i == 3) { results4.Add(speed); }
                }
            }
            Console.WriteLine(results1.Count()*results2.Count()*results3.Count()*results4.Count());
        }
        public void SolutionForOneBoat(double time, double distance)
        {
            double speed;
            double remainingtime;
            double traveldistance;
            var results = new List<double>();
            for(double i = 0; i< time; i++)
            {
                remainingtime = time;
                speed = i;
                remainingtime -= speed;
                traveldistance = speed * remainingtime;
                if(traveldistance >= distance) { results.Add(speed); }
            }
            Console.WriteLine(results.Count);
        }
    }
}
