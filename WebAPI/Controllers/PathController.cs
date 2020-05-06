using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PathController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Path
        public IEnumerable<Path> Get()
        {
            return this.context.Path;
        }

        // GET: api/Path/5
        public Path Get(int id)
        {
            return this.context.Path.Find(id);
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

            current.Source = path.Source;
            current.IdFTP = path.IdFTP;
            current.Destination = path.Destination;
        }

        // DELETE: api/Path/5
        public void Delete(int id)
        {
        }
    }
}
