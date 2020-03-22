using BingoCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BingoCard.Controllers
{
    public class CardController : Controller
    {
        // GET: Card
        public ActionResult Index()
        {
            Square mySquare = new Square();            
            List<List<int>> rows = new List<List<int>>();

            //Create the 15 numbers of the card
            //Decide the number of squares of the columns
            int countTotalSquares = 0; // max 27
            int countNumberSquares = 0; // max 15  
            int[,] columnMargins = new int[9, 2] { { 1, 9 }, { 10, 19 } ,{ 20, 29 }, { 30, 39 }, { 40, 49 }, { 50, 59 }, { 60, 69 }, { 70, 79 }, { 80, 90 } };

            for (int i = 0; i < 9; i++)
            {
                //Go by the columns
                int blankSquares = 0;
                List<int> column = new List<int>();
                bool isANewNumber = false;                

                for (int j = 0; j < 3; j++)
                {
                    int number;
                    //Go by the rows
                    do
                    {
                        number = RndGenerator(columnMargins[i, 0], columnMargins[i, 1]);

                        //Verify no repeat number in the column

                        // Fist row in a column: skip verification
                        if (column.Count < 1) break;

                        //Verification
                        else
                        {
                            var diferentCount = 0;
                            foreach (var item in column)
                            {
                                //Verify different number in the column or zero
                                if (item != number)
                                {
                                    diferentCount++;
                                    if (diferentCount >= column.Count)
                                    {
                                        isANewNumber = true;
                                        break;
                                    }
                                }
                                //Repeated, repeat the loop for a new
                                else isANewNumber = false;
                            }
                        }
                    }
                    while (!isANewNumber);


                    //All numbers exited: number = 0
                    if (countNumberSquares >= 15)
                    {
                        number = 0;
                        blankSquares++;
                    }
                    //No 3 blanks in a column and no all blanks exited
                    else if (blankSquares < 2 && (countTotalSquares-countNumberSquares <12))
                    {
                        var zeroCount = 0;
                        var blank = 1;
                        foreach (var item in column)
                        {
                            if (item == 0)
                            {
                                zeroCount++;
                            }
                        }
                        //Shorting the possibilities of a new zero if you have one
                        switch (zeroCount)
                        {
                            case 1:
                                if (RndGenerator(1, 9) == 1)
                                    blank = RndGenerator(0, 1);
                                break;

                            default:
                                blank = RndGenerator(0, 1);
                                break;
                        }

                        if (blank == 0)
                        {
                                blankSquares++;
                        }
                        else countNumberSquares++;

                        number = number * blank;
                    }
                    else
                    {
                        //It must to be a number
                        countNumberSquares++;
                    }    
                   
                    column.Add(number);
                    countTotalSquares++;
                }
                column.Sort();
                //TODO: solve the order problem: always 0 is the first position...
                rows.Add(column);
            }

            return View();
        }

        private int RndGenerator(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }
    }
}