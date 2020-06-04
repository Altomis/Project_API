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
    public class ClientsReportingController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Admin
        public async Task<IEnumerable<ClientsReporting>> Get()
        {
            return await context.ClientsReporting.ToListAsync();
        }

        // GET: api/Admin/5
        public async Task<ClientsReporting> Get(int id)
        {
            return await context.ClientsReporting.FindAsync(id);
        }

        // POST: api/Admin
        public void Post([FromBody]ClientsReporting clientsReporting)
        {
            this.context.ClientsReporting.Add(clientsReporting);
            this.context.SaveChanges();
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]ClientsReporting clientsReporting)
        {
            //ClientsReporting current = this.context.ClientsReporting.Find(id);
            //this.context.SaveChanges();

        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
            ClientsReporting clientsReporting = this.context.ClientsReporting.Find(id);

            this.context.ClientsReporting.Remove(clientsReporting);
            this.context.SaveChanges();
        }
    }
}
