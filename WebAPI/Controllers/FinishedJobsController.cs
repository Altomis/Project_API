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
    public class FinishedJobsController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/FinishedJobs
        public async Task<IEnumerable<FinishedJobs>> Get()
        {
            return await context.FinishedJobs.ToListAsync();
        }

        // GET: api/FinishedJobs/5
        public async Task<FinishedJobs> Get(int id)
        {
            return await context.FinishedJobs.FindAsync(id);
        }

        // POST: api/FinishedJobs
        public void Post([FromBody]FinishedJobs finishedJobs)
        {
            this.context.FinishedJobs.Add(finishedJobs);
            this.context.SaveChanges();
        }

        // PUT: api/FinishedJobs/5
        public void Put(int id, [FromBody]FinishedJobs finishedJobs)
        {
            FinishedJobs current = this.context.FinishedJobs.Find(id);

            current.IdGroups = finishedJobs.IdGroups;
            current.BackupType = finishedJobs.BackupType;
            current.Time = finishedJobs.Time;
            current.IsError = finishedJobs.IsError;
            current.ErrorMsg = finishedJobs.ErrorMsg;

            this.context.SaveChanges();

        }

        // DELETE: api/FinishedJobs/5
        public void Delete(int id)
        {
            FinishedJobs finishedJobs = this.context.FinishedJobs.Find(id);

            this.context.FinishedJobs.Remove(finishedJobs);
            this.context.SaveChanges();
        }
    }
}
