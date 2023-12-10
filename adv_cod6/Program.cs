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

            long speed;

            long remTime;

            long newDist;

            int point = 1;

            int idx = -1;

            //1
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

            //2
            int time2 = 41667266;

            long distance2 = 244104712281040;

            long win2 = 0;

            bool firstWin = false;

            int j = 0;

            while (firstWin == false)
            {
                j++;

                speed = j;

                remTime = time2 - speed;

                newDist = remTime * speed;

                if (newDist > distance2)
                {
                    firstWin = true;
                    win2 = time2 - (j * 2) + 1;
                }
            }

            Console.WriteLine(point);
            Console.WriteLine(win2);
            Console.ReadLine();
        }
    }
}
