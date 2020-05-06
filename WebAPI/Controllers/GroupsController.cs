using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class GroupsController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Groups
        public IEnumerable<Groups> Get()
        {
            return this.context.Groups;
        }

        // GET: api/Groups/5
        public Groups Get(int id)
        {
            return this.context.Groups.Find(id);
        }

        // POST: api/Groups
        public void Post([FromBody]Groups groups)
        {
            this.context.Groups.Add(groups);
            this.context.SaveChanges();
        }

        // PUT: api/Groups/5
        public void Put(int id, [FromBody]Groups groups)
        {
            Groups current = this.context.Groups.Find(id);

            current.Name = groups.Name;
            current.IdClient = groups.IdClient;
            current.IdJob = groups.IdJob;

            this.context.SaveChanges();
        }

        // DELETE: api/Groups/5
        public void Delete(int id)
        {
            Groups groups = this.context.Groups.Find(id);

            this.context.Groups.Remove(groups);
            this.context.SaveChanges();

        }
    }
}
