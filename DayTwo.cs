using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace AdventOfCode
{
    internal class DayTwo
    {
        // input
        static string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\inputs\input02.txt");
        static string[] input = File.ReadAllLines(filepath);

        public static void SolvePartOne()
        {
            int total = 0;
            
            foreach (string line in input)
            {
                Match match_line = Regex.Match(line, @"Game (\d+): (.*)");
                
                // get id of current game
                int current_game_id = int.Parse(match_line.Groups[1].Value);
                
                // if => Split inputs by semicolon
                if (TestStoneCountPerColor(match_line.Groups[2].Value.Split(";")) == true)
                {
                    // add game ids for solution
                    total += current_game_id;
                }
            }

            Console.WriteLine($"Solution for Part 1: {total}");
        }

        public static bool TestStoneCountPerColor(string[] inputs)
        {
            // loop through all inputs
            foreach (string input in inputs)
            {
                // split input by comma
                foreach (string n in input.Split(','))
                {
                    // get count of rocks and color
                    Match match = Regex.Match(n.Trim(), @"(\d+) (.*)");
                    int rock_count = int.Parse(match.Groups[1].Value);
                    string rock_color = match.Groups[2].Value;

                    // switch by color, check count against max given
                    bool isOK = rock_color switch
                    {
                        "blue" => rock_count <= 14,
                        "green" => rock_count <= 13,
                        "red" => rock_count <= 12,
                        _ => true
                    };

                    if (!isOK) return false;
                }
            }

            return true;
        }

        public static void SolvePartTwo()
        {
            int total = 0;

            // loop through every line and find power of rock count
            foreach (string line in DayTwo.input)
            {
                Match line_match = Regex.Match(line.Trim(), @"Game \d+: (.*)");
                total += FindRockCountPower(line_match.Groups[1].Value.Split(";"));
            }

            Console.WriteLine($"Solution for Part 2: {total}");

        }

        public static int FindRockCountPower(string[] inputs)
        {
            int red = 0;
            int green = 0;
            int blue = 0;

            // loop through all inputs
            foreach (string input in inputs)
            {
                // split input by comma
                foreach (string n in input.Split(','))
                {
                    // get count of rocks and color
                    Match match = Regex.Match(n.Trim(), @"(\d+) (.*)");
                    int rock_count = int.Parse(match.Groups[1].Value);
                    string rock_color = match.Groups[2].Value;

                    // find lowest rock count per color
                    switch (rock_color)
                    {
                        case "red":
                            if (rock_count > red) red = rock_count; break;
                        case "green":
                            if (rock_count > green) green = rock_count; break;
                        case "blue":
                            if (rock_count > blue) blue = rock_count; break;
                    }
                }
            }

            // return power
            return red * green * blue;
        }
    }
}
