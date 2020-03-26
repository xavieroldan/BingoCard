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
            int[][] columnsArray = new int[9][];
            int[][] linesArray = new int[3][];
            int contColumns = 0;

            //Create the 27 numbers of the card
            //Columns generation
            for (int i = 0; i < 9; i++)
            {              
                var columnNumbers = FillCard(3, columnMargins[i, 0], columnMargins[i, 1]);
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
                new int [][,]
                { 
                    new int[,] {{ 0,1,0,0,1,1,0,1,0 },{ 1,0,1,0,1,1,1,0,1 },{ 0,1,1,1,0,1,0,1,0 }},
                    new int[,] {{ 0,1,0,1,1,0,0,1,1 },{ 0,1,1,0,0,1,1,0,0 },{ 1,1,0,1,1,0,0,1,1 }},
                    new int[,] {{ 1,0,0,0,1,0,1,0,1 },{ 1,1,0,1,1,1,1,1,0 },{ 1,0,1,0,1,0,1,0,0 }} 
                };              

            //Try one random
            var templateId = rnd.Next(0, blanksTemplates.Length - 1);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    linesArray[i][j] *= blanksTemplates[templateId][i, j];
                }
            }
            //Count the squares in a row for a line
            //Return the card  
            var output = linesArray;

            Thread.Sleep(1000);
            return View(output);
        }

        private int RndGenerator(int min, int max) //TODO: delete?
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

    }
}