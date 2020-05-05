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
            Color = String.Empty;
        }

        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Color { get; set; }
    }
}