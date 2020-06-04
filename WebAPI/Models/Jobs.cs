using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Jobs
    {
        public int Id { get; set; }
        public string BackupType { get; set; }
        public bool ToZip { get; set; }
        public int MaxFullBackup { get; set; }
        public int MaxSecBackup { get; set; }
        public string CronTime { get; set; }
        public string Ends { get; set; }
    }

}