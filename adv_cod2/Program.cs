using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adv_cod2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input.txt");

            List<int> ids = new List<int>();

            bool possible;

            int piece;

            foreach (var line in lines)
            {
                possible = true;

                int id = int.Parse((line.Split(':')[0]).Split(' ')[1]);
                string gameInput = line.Split(':')[1];
                string[] rounds = gameInput.Split(';');

                foreach (var round in rounds)
                {
                    string[] colors = round.Split(',');

                    foreach (var color in colors)
                    {
                        piece = int.Parse(color.Split(' ')[1]);

                        if ((color.Contains("red") && piece > 12) || (color.Contains("green") && piece > 13)
                            || (color.Contains("blue") && piece > 14))
                        {
                            possible = false;
                        }
                    }
                }

                if (possible)
                {
                    ids.Add(id);
                }
            }

            Console.WriteLine(ids.Sum());
            Console.ReadLine();
        }
    }
}
