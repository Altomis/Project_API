using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class FTP_Server
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Passwd { get; set; }

    }
}