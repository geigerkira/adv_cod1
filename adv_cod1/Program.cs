using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adv_cod1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input.txt");

            List<int> numbers = new List<int>();
            List<int> numbers2 = new List<int>();

            foreach (var line in lines)
            {
                numbers.Add(searchNumber(line, false));
                numbers2.Add(searchNumber(line, true));
            }

            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers2.Sum());
            Console.ReadLine();
        }

        static int searchNumber(string line, bool replace)
        {
            string[] twoNum = new string[2];
            bool firstNumber = true;
            int chN = 0;

            if (replace)
            {
                line = line.Replace("one", "one1one").Replace("two", "two2two").Replace("three", "three3three").Replace("four", "four4four").Replace("five", "five5five")
                    .Replace("six", "six6six").Replace("seven", "seven7seven").Replace("eight", "eight8eight").Replace("nine", "nine9nine");
            }

            char[] chars = line.ToCharArray();

            foreach (var ch in chars)
            {
                bool isNumber = int.TryParse(ch.ToString(), out chN);
                if (isNumber)
                {
                    if (firstNumber)
                    {
                        twoNum[0] = ch.ToString();
                        firstNumber = false;
                    }
                    else
                    {
                        twoNum[1] = ch.ToString();
                    }
                }
            }

            if (twoNum[1] == null)
            {
                twoNum[1] = twoNum[0];
            }

            int output = int.Parse((twoNum[0] + twoNum[1]));

            return output;
        }

    }
}
