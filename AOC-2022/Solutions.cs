using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC_2022
{
    internal class Solutions
    {
        /// <summary>
        /// Day 1 
        /// </summary>
        internal static void day1()
        {
            int total = 0;
            int highest = 0;
            int cnt = 0;
            int[] top3 = new int[3];
            string[] lines = File.ReadAllLines("calories.txt");

            int amnt = Functions.setArrayLength(lines);

            int[] all = new int[amnt];

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    total = total + int.Parse(lines[i]);
                }
                else
                {
                    all[cnt] = total;
                    cnt++;
                    if (total > highest)
                    {
                        highest = total;
                    }
                    total = 0;
                }
            }

            for (int i = 0; i < top3.Length; i++)
            {
                for (int j = 0; j < all.Length; j++)
                {
                    if (all[j] > top3[i] && !top3.Contains(all[j]))
                    {
                        top3[i] = all[j];
                    }
                }
            }
            Console.WriteLine(highest); //first answer
            Console.WriteLine(top3[0] + top3[1] + top3[2]); //second answer
        }

        /// <summary>
        /// Day 2
        /// </summary>
        /// <algo>
        /// A & X = rock
        /// B & Y = paper
        /// C & Z= siscors
        /// </algo>
        internal static void day2()
        {
            int pointsMe = 0;
            char[] game = new char[2];
            int cnt = 0;
            string[] lines = File.ReadAllLines("RPS.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] != ' ')
                    {
                        game[cnt] = lines[i][j];
                        cnt++;
                    }
                }
                cnt = 0;

                switch (game[1])
                {
                    case 'X':
                        switch (game[0])
                        {
                            case 'C':
                                pointsMe = pointsMe + 6;
                                break;
                            case 'A':
                                pointsMe = pointsMe + 3;
                                break;
                            default:
                                break;
                        }
                        pointsMe += 1;
                        break;
                    case 'Y':
                        switch (game[0])
                        {
                            case 'A':
                                pointsMe = pointsMe + 6;
                                break;
                            case 'B':
                                pointsMe = pointsMe + 3;
                                break;
                            default:
                                break;
                        }
                        pointsMe = pointsMe + 2;
                        break;
                    default:
                        switch (game[0])
                        {
                            case 'B':
                                pointsMe = pointsMe + 6;
                                break;
                            case 'C':
                                pointsMe = pointsMe + 3;
                                break;
                            default:
                                break;
                        }
                        pointsMe = pointsMe + 3;
                        break;
                }          
            }
            Console.WriteLine("Total points for me: " + pointsMe);
        }
    }

    internal class Functions
    {
        internal static int setArrayLength(string[] lines)
        {
            int amnt = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    amnt++;
                }
            }
            return amnt;
        }
    }
}
