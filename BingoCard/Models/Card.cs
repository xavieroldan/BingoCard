using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class Card
    {
        private Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public List<Square> Squares { get; set; }
        //public Square[] Line1 { get; set; }
        //public Square[] Line2 { get; set; }
        //public Square[] Line3 { get; set; }
        public Square [,] Lines { get; set; }
        public bool IsLine { get; set; }
        public bool IsBingo { get; set; }

        public Card()
        {
            this.Id = Guid.NewGuid();
            //this.Line1 = new Square[9];
            //this.Line2 = new Square[9];
            //this.Line3 = new Square[9];
            this.Squares = new List<Square>();
            this.Lines = new Square[3,9]
                        {
                            { new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square() },
                            { new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square() },
                            { new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square() }
                        };
            this.IsLine = false;
            this.IsBingo = false;
        }
    }
}