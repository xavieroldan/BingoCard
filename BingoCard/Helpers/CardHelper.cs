using BingoCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Helpers
{
    public class CardHelper
    {
        private static readonly Random rnd;
        static CardHelper()
        {
            rnd = new Random();
        }
        private static int[] RndNumbersCardgenerator(int squares, int min = 1, int max = 90)
        {
            int[] listNum = new int[squares];
            int num = 0;
            bool isEqualExist = false;
            bool isExiting = false;

            for (int i = 0; i < squares; i++)
            {
                while (!isExiting)
                {
                    num = rnd.Next(min, max);
                    foreach (var item in listNum)
                    {
                        if (item == num)
                        {
                            isEqualExist = true;
                            break;
                        }
                    }
                    if (!isEqualExist) isExiting = true;
                    else isEqualExist = false;
                }
                listNum[i] = num;
                isExiting = false;
            }
            return listNum;
        }
        public static Card CreateCard()
        {
            int[,] columnMargins = new int[9, 2] { { 1, 9 }, { 10, 19 }, { 20, 29 }, { 30, 39 }, { 40, 49 }, { 50, 59 }, { 60, 69 }, { 70, 79 }, { 80, 90 } };
            int[][] columnsArray = new int[9][];
            int[][] linesArray = new int[3][];
            int contColumns = 0;

            //Create the 27 numbers of the card
            //Columns generation
            for (int i = 0; i < 9; i++)
            {
                var columnNumbers = RndNumbersCardgenerator(3, columnMargins[i, 0], columnMargins[i, 1]);
                columnsArray[contColumns] = columnNumbers;
                contColumns++;
            }

            //Lines generation
            for (int i = 0; i < 3; i++)
            {
                int[] line = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    line[j] = columnsArray[j][i];
                }
                linesArray[i] = line;
            }

            //Add the blank spaces
            //Blanks template generation 

            int[][,] blanksTemplates =
                new int[][,]
                {
                    new int[,] {{ 0, 1, 0, 0, 1, 1, 0, 1, 1 },{ 0, 1, 0, 0, 1, 1, 0, 1, 1 },{ 1, 1, 1, 1, 0, 1, 0, 0, 0 } },
                    new int[,] {{ 0, 1, 0, 1, 1, 0, 0, 1, 1 },{ 0, 1, 1, 0, 0, 1, 1, 0, 1 },{ 1, 1, 0, 1, 1, 0, 0, 1, 0 } },
                    new int[,] {{ 1, 0, 0, 0, 1, 1, 1, 0, 1 },{ 1, 1, 0, 1, 1, 0, 0, 1, 0 },{ 1, 0, 1, 0, 1, 0, 1, 0, 1 } }
                };

            //Try one random
            var templateId = rnd.Next(0, blanksTemplates.Length - 1);

            //Apply changes
            //Random lines order

            int[][] rndLines = new int[][]
                {
                    new int [] { 0, 1, 2 },
                    new int [] { 1, 0, 2 },
                    new int [] { 1, 2, 0 },
                    new int [] { 2, 1, 0 },
                    new int [] { 2, 0, 1 },
                    new int [] { 0, 2, 1 }
                };

            var order = rndLines[rnd.Next(0, 6)];

            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j < 9; j++)
                {
                    linesArray[order[k]][j] *= blanksTemplates[templateId][order[k], j];
                }
            }

            //Return an object Card

            Card myCard = new Card();

            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    Square mySquare = new Square
                    {
                        Row = i,
                        Column = j
                    };
                    int number = linesArray[i][j];
                    if (number == 0) { mySquare.IsBlank = true; }
                    else
                    {
                        mySquare.IsBlank = false;
                        mySquare.Number = number;
                    }
                    myCard.Lines[i, j] = mySquare;
                }
            }
            return myCard;
        }
    }
}