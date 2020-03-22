using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class Square
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool IsMarked { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsNotNumber { get; set; }
    }
}