﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Groups
    {
        public int Id { get; set; }
        public int IdClientsGroups { get; set; }
        public int IdClient { get; set; }
        public int IdJob { get; set; }
    }
}