﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLMBiowillBusinessEntities.Master
{
    public class LevelInfo
    {
        public int Id { get; set; }
        public string LevelName { get; set; }
        public decimal TurnOverLimit { get; set; }
        public bool Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
