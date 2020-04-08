using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class DAOCard
    {
        public Guid Id{ get; set; }
        public bool IsBingo { get; set; }
        public bool IsLine { get; set; }
        public int Lines { get; set; }



    }
}