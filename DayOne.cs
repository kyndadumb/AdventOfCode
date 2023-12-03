using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode
{
    internal class DayOne
    {
        // input
        static string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\inputs\input01.txt");
        static string[] input = File.ReadAllLines(filepath);

        // solution for part 1
        public static void SolvePartOne()
        {
            // regex => only decimals 
            Regex numbers_regex = new(@"\d");
            int total = 0;
            
            // foreach => line in inputs
            foreach (string line in DayOne.input)
            {
                MatchCollection matches = numbers_regex.Matches(line);
                
                // if => more than 0 numbers in line
                if (matches.Count > 0)
                {
                    int firstnumber = int.Parse(matches[0].Value);
                    
                    // parse second number if found, else take first number again
                    int lastnumber = matches.Count > 1 ? int.Parse(matches[^1].Value) : firstnumber;
                    
                    // calculate sum of line and add to total
                    int sum = (firstnumber * 10) + lastnumber;
                    total += sum;
                }
            }

            // 54331
            Console.WriteLine($"Solution for Part 1: {total}");
        }

        // solution for part 2
        public static void SolvePartTwo()
        {
            // replace missing letters in input and replace numbers
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Replace("one", "o1e");
                input[i] = input[i].Replace("two", "t2o");
                input[i] = input[i].Replace("three", "th3e");
                input[i] = input[i].Replace("four", "4");
                input[i] = input[i].Replace("five", "5e");
                input[i] = input[i].Replace("six", "6");
                input[i] = input[i].Replace("seven", "7n");
                input[i] = input[i].Replace("eight", "e8t");
                input[i] = input[i].Replace("nine", "n9e");
            }

            Regex numbers_regex = new(@"\d");
            int total = 0;

            foreach (string line in input)
            {
                MatchCollection matches = numbers_regex.Matches(line);

                // if => more than 0 numbers in line
                if (matches.Count > 0)
                {
                    List<int> numbers = new();

                    foreach (Match match in matches)
                    {
                        numbers.Add(int.Parse(match.Value));
                    }

                    int firstnumber = numbers[0];

                    // last element of list
                    int lastnumber = numbers[^1];

                    // calculate sum of line and add to total
                    int sum = (firstnumber * 10) + lastnumber;
                    total += sum;
                }
            }
            // 54518
            Console.WriteLine($"Solution for Part 2: {total}");
        }
    }
}
