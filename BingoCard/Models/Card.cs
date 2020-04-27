using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public Player Player { get; set; }
        public Square [,] Lines { get; set; }
        public bool IsLine { get; set; }
        public bool IsBingo { get; set; }
        public int [] MarkedSquares { get; set; }

        public Card()
        {
            this.Id = Guid.NewGuid();
            this.Lines = new Square[3,9]
                        {
                            { new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square() },
                            { new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square() },
                            { new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square() }
                        };
            this.IsLine = false;
            this.IsBingo = false;
            this.MarkedSquares = new int[] { 0, 0, 0 };
        }
    }
}