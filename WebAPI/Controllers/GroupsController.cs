﻿using System;
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
    public class GroupsController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Groups
        public async Task<IEnumerable<Groups>> Get()
        {
            return await context.Groups.ToListAsync();
        }

        // GET: api/Groups/5
        public async Task<Groups> Get(int id)
        {
            return await context.Groups.FindAsync(id);
        }
        //getiing clients by groups id
        [Route("api/Groups/GetClients/{GroupsId:int}")]
        [HttpGet]
        public async Task<Clients[]> GetClients(int UserId)
        {
            Clients[] clients = this.context.Clients.SqlQuery(@"select 
            c.Id,
            c.Pc_Name,
            c.MacAddress,
            c.IpAddress,
            c.Created,
            c.Active FROM Clients c 
                inner join Groups g on g.IdKlient = c.Id
                inner join ClientsGroups cg on g.IdClientsGroups = cg.Id
            where c.Od = " + UserId).ToArray();
            return clients;
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

            current.IdClient = groups.IdClient;
            current.IdClientsGroups = groups.IdClientsGroups;
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
