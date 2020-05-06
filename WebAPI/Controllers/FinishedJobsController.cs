using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class FinishedJobsController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/FinishedJobs
        public IEnumerable<FinishedJobs> Get()
        {
            return this.context.FinishedJobs;
        }

        // GET: api/FinishedJobs/5
        public FinishedJobs Get(int id)
        {
            return this.context.FinishedJobs.Find(id);
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
            current.IdParentBackup = finishedJobs.IdParentBackup;
            current.Time = finishedJobs.Time;

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
