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
            List<int> mins = new List<int>();

            bool possible;

            int piece;
            int red;
            int green;
            int blue;

            foreach (var line in lines)
            {
                red = 0;
                green = 0;
                blue = 0;
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

                        if (color.Contains("red") && piece > red)
                        {
                            red = piece;
                        }
                        else if (color.Contains("green") && piece > green)
                        {
                            green = piece;
                        }
                        else if (color.Contains("blue") && piece > blue)
                        {
                            blue = piece;
                        }
                    }
                }

                mins.Add(red * green * blue);

                if (possible)
                {
                    ids.Add(id);
                }
            }

            Console.WriteLine(ids.Sum());
            Console.WriteLine(mins.Sum());
            Console.ReadLine();
        }
    }
}
