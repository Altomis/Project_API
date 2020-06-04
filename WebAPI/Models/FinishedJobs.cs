using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class FinishedJobs
    {
        public int Id { get; set; }
        public int IdGroups { get; set; }
        public string BackupType { get; set; }
        public string Time { get; set; }
        public bool IsError { get; set; }
        public string ErrorMsg { get; set; }
    }
}