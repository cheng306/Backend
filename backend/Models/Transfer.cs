﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Transfer
    {
        public string Id { get; set; }
        public string Sender { get; set; }
        public int Amount { get; set; }
    }
}
