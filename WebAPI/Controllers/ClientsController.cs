using MySql.Data.MySqlClient.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ClientsController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Clients
        public IEnumerable<Clients> Get()
        {
            return this.context.Clients;
        }

        // GET: api/Clients/5
        public Clients Get(int id)
        {
            return this.context.Clients.Find(id);
        }

        // Put: api/Clients/5
        public void Put(int id, [FromBody]Clients clients)
        {
            Clients current = this.context.Clients.Find(id);

            current.Pc_Name = clients.Pc_Name;
            current.MacAddress = clients.MacAddress;
            current.IpAddress = clients.IpAddress;
            current.Created = clients.Created;

            this.context.SaveChanges();

        }

        // Post: api/Clients
        public void Post([FromBody]Clients clients)
        {
            this.context.Clients.Add(clients);
            this.context.SaveChanges();
        }

        // DELETE: api/Clients/5
        public void Delete(int id)
        {
            Clients clients = this.context.Clients.Find(id);

            this.context.People.Remove(clients);
            this.context.SaveChanges();
        }
    }
}
