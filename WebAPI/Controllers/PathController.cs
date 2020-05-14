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
    public class PathController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Path
        public async Task<IEnumerable<Path>> Get()
        {
            return await context.Path.ToListAsync();
        }

        // GET: api/Path/5
        public async Task<Path> Get(int id)
        {
            return await context.Path.FindAsync(id);
        }

        // POST: api/Path
        public void Post([FromBody]Path path)
        {
            this.context.Path.Add(path);
            this.context.SaveChanges();
        }

        // PUT: api/Path/5
        public void Put(int id, [FromBody]Path path)
        {
            Path current = this.context.Path.Find(id);

            current.IdJob = path.IdJob;
            current.Source = path.Source;
            current.IdFTP = path.IdFTP;
            current.Which = path.Which;
            current.Login = path.Login;
            current.Password = path.Password;
        }

        // DELETE: api/Path/5
        public void Delete(int id)
        {
            Path path = this.context.Path.Find(id);

            this.context.Path.Remove(path);
            this.context.SaveChanges();


        }
    }
}
