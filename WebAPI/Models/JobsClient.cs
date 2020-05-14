﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class JobsClient
    {
        public int Id { get; set; }
        public string BackupType { get; set; }
        public int MaxFullBackup { get; set; }
        public int MaxSecBackup { get; set; }
        public DateTime[] CronTime { get; set; }
        public string Ends { get; set; }
        public List<string> Source { get; set; }
        public List<string> Destination { get; set; }
    }
}