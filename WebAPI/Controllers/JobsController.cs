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
    public class JobsController : ApiController
    {
        private MyContext context = new MyContext();
        // GET: api/Jobs
        public async Task<IEnumerable<Jobs>> Get()
        {
            return await context.Jobs.ToListAsync();
        }

        // GET: api/Jobs/5
        public async Task<Jobs> Get(int id)
        {
            return await context.Jobs.FindAsync(id);
        }

        //getiing jobs for client
        [Route("api/Jobs/GetMyJobs/{UserId:int}")]
        [HttpGet]
        public async Task<Clients> GetMyJobs(int UserId)
        {
            return await this.context.Clients.FindAsync(11);//Bude vracet list jobu co ma urcity client podle kde to taky bude vracet list cest
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
