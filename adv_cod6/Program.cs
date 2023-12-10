using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adv_cod6
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] times = { 41, 66, 72, 66 };

            int[] distances = { 244, 1047, 1228, 1040 };

            int win;

            int speed;

            int remTime;

            int newDist;

            int point = 1;

            int idx = -1;

            foreach (var time in times)
            {
                idx++;
                win = 0;

                for (int i = 1; i < time; i++)
                {
                    speed = i;

                    remTime = time - speed;

                    newDist = remTime * speed;

                    if (newDist > distances[idx])
                    {
                        win++;
                    }
                }

                if (win != 0)
                {
                    point = point * win;
                }

            }

            Console.WriteLine(point);
            Console.ReadLine();
        }
    }
}
