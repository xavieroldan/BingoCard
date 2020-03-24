using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class Card
    {
        public int Id { get; set; }

        public List<Square>[] Squares { get; set; }
        public List<Square> Line1 { get; set; }
        public List<Square> Line2 { get; set; }
        public List<Square> Line3 { get; set; }
        public bool IsLine { get; set; }
        public bool IsBingo { get; set; }

        public Card()
        {
            this.IsLine = false;
            this.IsBingo = false;
            this.Line1 = new List<Square>();
            this.Line2 = new List<Square>();
            this.Line3 = new List<Square>();
            this.Squares = new List<Square>[] { Line1 , Line2, Line3 };
        }
    }
}