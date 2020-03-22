using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class Card
    {
        public int Id { get; set; }
        public List<Square> Squares { get; set; }
        public bool IsLine { get; set; }
        public bool IsBingo { get; set; }

        public Card()
        {
            this.IsLine = false;
            this.IsBingo = false;
            this.Squares = new List<Square>();
        }
    }
}