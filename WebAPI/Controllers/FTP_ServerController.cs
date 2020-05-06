using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class FTP_ServerController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/FTP_Server
        public IEnumerable<FTP_Server> Get()
        {
            return this.context.FTP_Server;
        }

        // GET: api/FTP_Server/5
        public FTP_Server Get(int id)
        {
            return this.context.FTP_Server.Find(id);
        }

        // POST: api/FTP_Server
        public void Post([FromBody]FTP_Server fTP_Server)
        {
            this.context.FTP_Server.Add(fTP_Server);
            this.context.SaveChanges();
        }

        // PUT: api/FTP_Server/5
        public void Put(int id, [FromBody]FTP_Server fTP_Server)
        {
            FTP_Server current = this.context.FTP_Server.Find(id);

            current.Address = fTP_Server.Address;
            current.Port = fTP_Server.Port;
            current.Login = fTP_Server.Login;
            current.Passwd = fTP_Server.Passwd;

            this.context.SaveChanges();
        }

        // DELETE: api/FTP_Server/5
        public void Delete(int id)
        {
            FTP_Server fTP_Server = this.context.FTP_Server.Find(id);

            this.context.FTP_Server.Remove(fTP_Server);
            this.context.SaveChanges();
        }
    }
}
