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
                    int lastnumber = matches.Count > 1 ? int.Parse(matches[matches.Count - 1].Value) : firstnumber;
                    
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
            Regex numbers_and_figures = new(@"\d|one|two|three|four|five|six|seven|eight|nine");
            int total = 0;

            foreach (string line in input)
            {
                MatchCollection matches = numbers_and_figures.Matches(line);

                // if => more than 0 numbers in line
                if (matches.Count > 0)
                {
                    // Use a list to store the individual digits
                    List<int> numbers = new List<int>();

                    foreach (Match match in matches)
                    {
                        numbers.Add(GetNumber(match.Value));
                    }

                    // The first number is the first element in the list
                    int firstnumber = numbers[0];

                    // The last number is the last element in the list
                    int lastnumber = numbers[numbers.Count - 1];

                    // calculate sum of line and add to total
                    int sum = (firstnumber * 10) + lastnumber;
                    total += sum;
                }
            }

            // 54533
            Console.WriteLine($"Solution for Part 2: {total}");
        }

        // Get Number from spelled out value
        static int GetNumber(string num)
        {
            // if - Input = Integer ==> return input
            if (int.TryParse(num, out int result))
            {
                return result;
            }
            
            // else - return number from figures
            else
            {
                switch (num)
                {
                    case "one": return 1;
                    case "two": return 2;
                    case "three": return 3;
                    case "four": return 4;
                    case "five": return 5;
                    case "six": return 6;
                    case "seven": return 7;
                    case "eight": return 8;
                    case "nine": return 9;
                    default: return 0;
                }
            }
        }
    }
}
