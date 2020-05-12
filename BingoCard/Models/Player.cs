using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BingoCard.Models
{
    public class Player
    {
        public Player()
        {
            Id = new Guid();
            BingoCount = 0;
            LineCount = 0;
            IsEnabled = true;
        }

        public Guid Id { get; set; }
        [StringLength(15, MinimumLength = 3)]
        [Required]

        public string Name { get; set; }
        public int BingoCount { get; set; }
        public int LineCount { get; set; }
        public string AvatarID { get; set; }
        public bool IsEnabled { get; set; }
        public string RoomName { get; set; }
        public bool IsEnableLine { get; set; }
    }
}