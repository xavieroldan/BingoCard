using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class Room
    {
        public Room()
        {
            Id = new Guid();
            Name = String.Empty;
            Message = String.Empty;
            WinnerPlayer = Guid.Empty;
            LinePlayer = Guid.Empty;
        }
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Message { get; set; }
        public Guid WinnerPlayer { get; set; }
        public Guid LinePlayer { get; set; }
    }
}