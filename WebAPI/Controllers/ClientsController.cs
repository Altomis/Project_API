using MySql.Data.MySqlClient.Memcached;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ClientsController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Clients
        public async Task<IEnumerable<Clients>> Get()
        {
            return await context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        public async Task<Clients> Get(int id)
        {
            return await context.Clients.FindAsync(id);
        }
        //getiing groups by client id
        [Route("api/Clients/GetGroups/{UserId:int}")]
        [HttpGet]
        public async Task<ClientsGroups[]> GetGroups(int UserId)
        {
            ClientsGroups[] clientsGroups = this.context.ClientsGroups.SqlQuery(@"select * from ClientsGroups cg
            inner join Groups g on g.IdClientsGroups = cg.Id
            inner join Clients c on g.IdKlient = c.Id
            where c.id = " + UserId).ToArray();
            return clientsGroups;
        }
            // Put: api/Clients/5
        public void Put(int id, [FromBody]Clients clients)
        {
            Clients current = this.context.Clients.Find(id);

            current.Pc_Name = clients.Pc_Name;
            current.MacAddress = clients.MacAddress;
            current.IpAddress = clients.IpAddress;
            current.Created = clients.Created;
            current.Active = clients.Active;

            this.context.SaveChanges();
        }

        // Post: api/Clients
        public void Post([FromBody]Clients clients)
        {
            string temp = clients.MacAddress;
            this.context.Clients.Add(clients);
            this.context.SaveChanges();
            var tepp = new List<Clients>(context.Clients.ToList());
            this.context.Groups.Add(new Groups() { IdClient =tepp.Last().Id, IdClientsGroups = 1 ,IdJob = 1});
            this.context.SaveChanges();
            ClientsReporting cr = new ClientsReporting();
            cr.Id = tepp.Last().Id;
            //cr.ClientId = tepp.Last().Id;
            cr.LastSeen = DateTime.UtcNow.ToString();
            this.context.ClientsReporting.Add(cr);
            this.context.SaveChanges();
        }

        // DELETE: api/Clients/5
        public void Delete(int id)
        {
            Clients clients = this.context.Clients.Find(id);

            this.context.Clients.Remove(clients);
            this.context.SaveChanges();
        }
    }
}
