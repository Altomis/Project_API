using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Path
    {
        public int Id { get; set; }
        public int IdJob { get; set; }
        public string Source { get; set; }
        public int IdFTP { get; set; }
        public bool Which { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}