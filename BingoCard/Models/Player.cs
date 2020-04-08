using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public int Name { get; set; }
        public int BingoCount { get; set; }
        public int LineCount { get; set; }
    }
}