using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class JobsController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Jobs
        public IEnumerable<Jobs> Get()
        {
            return this.context.Jobs;
        }

        // GET: api/Jobs/5
        public Jobs Get(int id)
        {
            return this.context.Jobs.Find(id);
        }

        // POST: api/Jobs
        public void Post([FromBody]Jobs jobs)
        {
            this.context.Jobs.Add(jobs);
            this.context.SaveChanges();
        }

        // PUT: api/Jobs/5
        public void Put(int id, [FromBody]Jobs jobs)
        {
            Jobs current = this.context.Jobs.Find(id);

            current.BackupType = jobs.BackupType;
            current.IdPath = jobs.IdPath;
            current.MaxFullBackup = jobs.MaxFullBackup;
            current.MaxSecBackup = jobs.MaxSecBackup;
            current.CronTime = jobs.CronTime;
            current.Ends = jobs.Ends;

            this.context.SaveChanges();
        }

        // DELETE: api/Jobs/5
        public void Delete(int id)
        {
            Jobs jobs = this.context.Jobs.Find(id);

            this.context.Jobs.Remove(jobs);
            this.context.SaveChanges();
        }
    }
}
