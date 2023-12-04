using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class DayFour
    {
        // input
        static string filepath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\inputs\input04.txt");
        static string[] input = File.ReadAllLines(filepath);

        private class Card
        {
            public int id;
            public int[] winning;
            public int[] numbers;
            public int count = 1;

            public Card(int id, int[] winning, int[] numbers)
            {
                this.id = id;
                this.winning = winning;
                this.numbers = numbers;
            }
        }

        private static int[] IntParseArray(string[] arr)
        {
            int[] result = new int[arr.Length];
            for (int j = 0; j < arr.Length; j++)
                result[j] = int.Parse(arr[j]);
            return result;
        }

        public static void SolvePartOne()
        {
            List<Card> cards = new();

            // parse input cards, add to list
            for (int i = 0; i < input.Length; i++)
            {
                string line = string.Join(' ', input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries));
                string[] data = line.Split(": ");
                string[] numbers_data = data[1].Split(" | ");

                int card_id = int.Parse(data[0].Remove(0,5));
                int[] winning = IntParseArray(numbers_data[0].Split(' '));
                int[] numbers = IntParseArray(numbers_data[1].Split(' '));

                Card temp = new(card_id, winning, numbers);
                cards.Add(temp);
            }

            double total = 0;

            for (int card_index = 0; card_index < cards.Count; card_index++)
            {
                Card temp = cards[card_index];
                int winning_numbers = CountWinningNumbers(temp);

                double currentPoints = winning_numbers == 0 ? 0 : Math.Pow(2, winning_numbers - 1);
                total += currentPoints;

            }

            Console.WriteLine($"Solution for Part 1: {total}");
        }

        private static int CountWinningNumbers(Card card)
        {
            int winningNumbers = 0;
            foreach (int number in card.numbers)
            {
                if (card.winning.Contains(number))
                    winningNumbers++;
            }
            return winningNumbers;
        }

        public static void SolvePartTwo()
        {
            List<Card> cards = new();

            // parse input cards, add to list
            for (int i = 0; i < input.Length; i++)
            {
                string line = string.Join(' ', input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries));
                string[] data = line.Split(": ");
                string[] numbers_data = data[1].Split(" | ");

                int card_id = int.Parse(data[0].Remove(0, 5));
                int[] winning = IntParseArray(numbers_data[0].Split(' '));
                int[] numbers = IntParseArray(numbers_data[1].Split(' '));

                Card temp = new(card_id, winning, numbers);
                cards.Add(temp);
            }
        }
    }
}
