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
    public class AdminController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Admin
        public async Task<IEnumerable<Admin>> Get()
        {
            return await context.Admin.ToListAsync();
        }

        // GET: api/Admin/5
        public async Task<Admin> Get(int id)
        {
            return await context.Admin.FindAsync(id);
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
            current.Email = admin.Email;
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
