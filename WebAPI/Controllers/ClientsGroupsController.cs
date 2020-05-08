using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient.Memcached;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ClientsGroupsController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/ClientsGroups
        public async Task<IEnumerable<ClientsGroups>> Get()
        {
            return await context.ClientsGroups.ToListAsync();
        }

        // GET: api/ClientsGroups/5
        public async Task<ClientsGroups> Get(int id)
        {
            return await context.ClientsGroups.FindAsync(id);
        }

        // POST: api/ClientsGroups
        public void Post([FromBody]ClientsGroups clientsGroups)
        {
            this.context.ClientsGroups.Add(clientsGroups);
            this.context.SaveChanges();
        }

        // PUT: api/ClientsGroups/5
        public void Put(int id, [FromBody]ClientsGroups clients)
        {
            ClientsGroups current = this.context.ClientsGroups.Find(id);

            current.Name = clients.Name;

            this.context.SaveChanges();

        }

        // DELETE: api/ClientsGroups/5
        public void Delete(int id)
        {
            ClientsGroups clientsGroups = this.context.ClientsGroups.Find(id);

            this.context.ClientsGroups.Remove(clientsGroups);
            this.context.SaveChanges();
        }
    }
}
