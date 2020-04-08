using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class Player
    {
        public Player(Guid id, string name, int bingoCount, int lineCount, Guid cardId)
        {
            Id = Guid.NewGuid();
            Name = "";
            BingoCount = 0;
            LineCount = 0;
        }
        public Guid Id { get; }
        public string Name { get; set; }
        public int BingoCount { get; set; }
        public int LineCount { get; set; }
        public Guid CardId { get; set; }    
    }
}