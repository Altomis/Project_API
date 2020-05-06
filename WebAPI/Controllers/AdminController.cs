using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AdminController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Admin
        public IEnumerable<Admin> Get()
        {
            return this.context.Admin;
        }

        // GET: api/Admin/5
        public Admin Get(int id)
        {
            return this.context.Admin.Find(id);
        }

        // POST: api/Admin
        public void Post([FromBody]Admin admin)
        {
            this.context.Admin.Add(admin);
            this.context.SaveChanges();
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]Admin admin)
        {
            Admin current = this.context.Admin.Find(id);

            current.Firstname = admin.Firstname;
            current.Surname = admin.Surname;
            current.Login = admin.Login;
            current.Passwd = admin.Passwd;

            this.context.SaveChanges();

        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
            Admin admin = this.context.Admin.Find(id);

            this.context.Admin.Remove(admin);
            this.context.SaveChanges();
        }
    }
}
