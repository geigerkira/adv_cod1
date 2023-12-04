using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adv_cod4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input.txt");

            List<int> points = new List<int>();

            int[] cardNumber = new int[lines.Length];

            for (int i = 0; i < cardNumber.Length; i++)
            {
                cardNumber[i] = 1;
            }

            string inputs;

            foreach (var line in lines)
            {
                inputs = line.Split(':')[1];
                points.Add(countPoints(inputs));
            }

            for (int i = 0; i < lines.Length; i++)
            {
                cardNumber = addCards(cardNumber, i, lines[i]);
            }

            Console.WriteLine(points.Sum());
            Console.WriteLine(cardNumber.Sum());
            Console.ReadLine();
        }

        static int countPoints(string inputs)
        {
            int point = 0;
            bool firstMatch = true;
            string[] winningNums = (inputs.Split('|')[0]).Split(' ');
            string[] ownNums = (inputs.Split('|')[1]).Split(' ');

            foreach (var wNum in winningNums)
            {
                if (ownNums.Contains(wNum) && wNum != "")
                {
                    if (firstMatch)
                    {
                        point += 1;
                        firstMatch = false;
                    }
                    else
                    {
                        point = point * 2;
                    }
                }
            }

            return point;
        }

        static int[] addCards(int[] cardNumber, int idx, string inputs)
        {
            int matches = 0;
            string[] winningNums = (inputs.Split('|')[0]).Split(' ');
            string[] ownNums = (inputs.Split('|')[1]).Split(' ');

            foreach (var wNum in winningNums)
            {
                if (ownNums.Contains(wNum) && wNum != "")
                {
                    matches++;
                }
            }

            for (int i = 1; i < matches + 1; i++)
            {
                cardNumber[idx + i] += 1 * cardNumber[idx];
            }

            return cardNumber;
        }
    }
}
