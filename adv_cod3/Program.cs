using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adv_cod3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input.txt");

            List<int> numbers = new List<int>();

            string previousLine;
            string currentLine;
            string nextLine;

            char[] symbols = { '*', '+', '/', '#', '=', '%', '&', '-', '@', '$' };

            int num;
            string number;
            int idx;
            bool isNumber;
            bool partNumber;


            for (int i = 0; i < lines.Length; i++)
            {

                if (i == 0)
                {
                    previousLine = null;
                    nextLine = '.' + lines[i + 1] + '.';
                }
                else if (i == lines.Length - 1)
                {
                    previousLine = '.' + lines[i - 1] + '.';
                    nextLine = null;
                }
                else
                {
                    previousLine = '.' + lines[i - 1] + '.';
                    nextLine = '.' + lines[i + 1] + '.';
                }
                currentLine = '.' + lines[i] + '.';

                idx = 0;

                while (idx < currentLine.Length)
                {
                    partNumber = false;
                    number = "";
                    isNumber = int.TryParse(currentLine[idx].ToString(), out num);
                    if (isNumber)
                    {
                        //legalább 1 szám van
                        number += num.ToString();

                        isNumber = int.TryParse(currentLine[idx + 1].ToString(), out num);
                        if (isNumber)
                        {
                            //legalább 2 szám van
                            number += num.ToString();

                            isNumber = int.TryParse(currentLine[idx + 2].ToString(), out num);
                            if (isNumber)
                            {
                                //legalább 3 szám van
                                number += num.ToString();

                                if (previousLine != null)
                                {
                                    if (symbols.Contains(previousLine[idx - 1]) || symbols.Contains(previousLine[idx]) || symbols.Contains(previousLine[idx + 1])
                                        || symbols.Contains(previousLine[idx + 2]) || symbols.Contains(previousLine[idx + 3]))
                                    {
                                        partNumber = true;
                                    }
                                }
                                if (symbols.Contains(currentLine[idx - 1]) || symbols.Contains(currentLine[idx + 3]))
                                {
                                    partNumber = true;
                                }
                                if (nextLine != null)
                                {
                                    if (symbols.Contains(nextLine[idx - 1]) || symbols.Contains(nextLine[idx]) || symbols.Contains(nextLine[idx + 1])
                                        || symbols.Contains(nextLine[idx + 2]) || symbols.Contains(nextLine[idx + 3]))
                                    {
                                        partNumber = true;
                                    }
                                }

                                idx += 3;
                            }
                            else
                            {
                                //csak 2 szám van

                                if (symbols.Contains(currentLine[idx - 1]) || symbols.Contains(currentLine[idx + 2]))
                                {
                                    partNumber = true;
                                }
                                if (previousLine != null)
                                {
                                    if (symbols.Contains(previousLine[idx - 1]) || symbols.Contains(previousLine[idx]) || symbols.Contains(previousLine[idx + 1])
                                        || symbols.Contains(previousLine[idx + 2]))
                                    {
                                        partNumber = true;
                                    }
                                }
                                if (nextLine != null)
                                {
                                    if (symbols.Contains(nextLine[idx - 1]) || symbols.Contains(nextLine[idx]) || symbols.Contains(nextLine[idx + 1])
                                        || symbols.Contains(nextLine[idx + 2]))
                                    {
                                        partNumber = true;
                                    }
                                }

                                idx += 2;
                            }
                        }
                        else
                        {
                            //csak 1 szám van
                            if (previousLine != null)
                            {
                                if (symbols.Contains(previousLine[idx - 1]) || symbols.Contains(previousLine[idx]) || symbols.Contains(previousLine[idx + 1]))
                                {
                                    partNumber = true;
                                }
                            }
                            if (symbols.Contains(currentLine[idx - 1]) || symbols.Contains(currentLine[idx + 1]))
                            {
                                partNumber = true;
                            }
                            if (nextLine != null)
                            {
                                if (symbols.Contains(nextLine[idx - 1]) || symbols.Contains(nextLine[idx]) || symbols.Contains(nextLine[idx + 1]))
                                {
                                    partNumber = true;
                                }
                            }
                            idx += 1;
                        }

                        if (partNumber)
                        {
                            numbers.Add(int.Parse(number));
                        }
                    }
                    else
                    {
                        idx += 1;
                    }
                }


            }

            Console.WriteLine(numbers.Sum());
            Console.ReadLine();
        }
    }
}
