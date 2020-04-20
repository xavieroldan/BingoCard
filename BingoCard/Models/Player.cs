﻿using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public int BingoCount { get; set; }
        public int LineCount { get; set; }
        public int AvatarID { get; set; }
        public bool IsEnabled { get; set; }
    }
}