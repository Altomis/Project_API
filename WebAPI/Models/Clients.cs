﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public string Pc_Name { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string Created { get; set; }
    }
}