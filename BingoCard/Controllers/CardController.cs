using BingoCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BingoCard.Controllers
{    
    public class CardController : Controller
    {
        private static Random rnd;
        static CardController()
        {
            rnd = new Random();
        }
        
        // GET: Card  
        public ActionResult Index()
        {
            int[,] columnMargins = new int[9, 2] { { 1, 9 }, { 10, 19 }, { 20, 29 }, { 30, 39 }, { 40, 49 }, { 50, 59 }, { 60, 69 }, { 70, 79 }, { 80, 90 } };
            List<int[]> columnList = new List<int[]>();

            //Create the 27 numbers of the card

            //Columns generation
            for (int i = 0; i < 9; i++)
            {
                int[] columnNumbers = new int[3]; 
                columnNumbers = FillCard(3, columnMargins[i, 0], columnMargins[i, 1]);                
                columnList.Add(columnNumbers);
            }


            





            //Add the blank spaces

            //Count the squares in a row for a line

            //Return the card      



            Thread.Sleep(1000);
            return View();
        }

        private int RndGenerator(int min, int max)
        {            
            return rnd.Next(min, max);
        }


        private int[] FillCard(int squares, int min = 1, int max = 90)
        {
            int[] listNum = new int[squares];
            //var listNum = input;
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
                listNum [i] = num;
                isExiting = false;
            }
            return listNum;
        }

        //    public ActionResult Index()
        //{                       
        //    List<List<int>> rows = new List<List<int>>();
        //    Card MyCard = new Card();

        //    //Create the 15 numbers of the card
        //    //Decide the number of squares of the columns
        //    int countTotalSquares = 0; // max 27
        //    int countNumberSquares = 0; // max 15  
        //    int[,] columnMargins = new int[9, 2] { { 1, 9 }, { 10, 19 } ,{ 20, 29 }, { 30, 39 }, { 40, 49 }, { 50, 59 }, { 60, 69 }, { 70, 79 }, { 80, 90 } };

        //    List<int> toDelete = new List<int>();
        //    toDelete = MyFunction(toDelete);

        //    for (int i = 0; i < 9; i++)
        //    {
        //        //Go by the columns
        //        int blankSquares = 0;
        //        List<int> column = new List<int>();
        //        bool isANewNumber = false;
        //        List<Square> mySquareList = new List<Square>();

        //        for (int j = 0; j < 3; j++)
        //        {
        //            int number;                    
        //            //Go by the rows
        //            do
        //            {
        //                number = RndGenerator(columnMargins[i, 0], columnMargins[i, 1]);
        //                //Verify no repeat number in the column
        //                // Fist row in a column: skip verification
        //                if (column.Count < 1) break;

        //                //Verification
        //                else
        //                {
        //                    var diferentCount = 0;
        //                    foreach (var item in column)
        //                    {
        //                        //Verify different number in the column or zero
        //                        if (item != number)
        //                        {
        //                            diferentCount++;
        //                            if (diferentCount >= column.Count)
        //                            {
        //                                isANewNumber = true;
        //                                break;
        //                            }
        //                        }
        //                        //Repeated, repeat the loop for a new
        //                        else isANewNumber = false;
        //                    }
        //                }
        //            }
        //            while (!isANewNumber);

        //            //TODO: add condition  to jump 3 zero at finals rows
        //            //if (countTotalSquares == 24 && (countTotalSquares - countNumberSquares == 13))
        //            //{
        //            //    number = 0;
        //            //    blankSquares++;
        //            //}

        //            //All numbers exited: number = 0
        //            if (countNumberSquares >= 15)
        //            {
        //                number = 0;
        //                blankSquares++;
        //            }
        //            //No 3 blanks in a column and no all blanks exited
        //            else if (blankSquares < 2 && (countTotalSquares-countNumberSquares <12))
        //            {
        //                var zeroCount = 0;
        //                var blank = 1;
        //                foreach (var item in column)
        //                {
        //                    if (item == 0)
        //                    {
        //                        zeroCount++;
        //                    }
        //                }
        //                //Shorting the possibilities of a new zero if you have one
        //                switch (zeroCount)
        //                {
        //                    //One blank
        //                    case 1:
        //                        blank = RndGenerator(0, 1);
        //                        break;
        //                    //No blank
        //                    default:
        //                        if (RndGenerator(0, 10) > 5) blank = 0;
        //                        break;
        //                }

        //                if (blank == 0)
        //                {
        //                        blankSquares++;
        //                }
        //                else countNumberSquares++;

        //                number = number * blank;
        //            }
        //            else
        //            {
        //                //It must to be a number
        //                countNumberSquares++;
        //            }    

        //            column.Add(number);                    
        //            countTotalSquares++;

        //        }        
        //        rows.Add(column);                
        //    }

        //    //Model tasks
        //    Card myCard = new Card();
        //    foreach (var values in rows)
        //    {
        //        foreach (var item in values)
        //        {
        //            Square mySquare = new Square();
        //            if (item == 0) mySquare.IsBlank = true;
        //            else mySquare.Number = item;

        //            myCard.Squares.Add(mySquare);
        //        }
        //    }
        //    return View(rows);
        //}
    }
}