using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI.Models;
using MySql.Data.EntityFramework;

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
        public async Task<JobsClientModel[]> GetMyJobs(int UserId)
        {
            Jobs[] jobs = this.context.Jobs.SqlQuery(@"select 
              j.Id,
              j.BackupType,
              j.MaxFullBackup,
              j.MaxSecBackup,
              j.ToZip,
              j.CronTime,
              j.Ends from Jobs j
              inner join 3b2_kalpakcisismael_db1.Groups g on j.Id = g.IdJob
              where g.IdClient = " + UserId).ToArray();

            JobsClientModel[] cjobs = new JobsClientModel[jobs.Length];
            for (int i = 0; i < jobs.Length; i++)
            {
                cjobs[i] = FillList(jobs[i]);
                Path[] paths = this.context.Path.SqlQuery(@"select
                * from Path p where IdJob = " + jobs[i].Id).ToArray();
                cjobs[i].Id = jobs[i].Id;
                cjobs[i].ToZip = jobs[i].ToZip;
                cjobs[i].MaxFullBackup = jobs[i].MaxFullBackup;
                cjobs[i].MaxSecBackup = jobs[i].MaxSecBackup;
                cjobs[i].CronTime = CroneConvert.ConvertCrone(jobs[i].CronTime);
                cjobs[i].Ends = jobs[i].Ends;
                cjobs[i].BackupType = jobs[i].BackupType;

                foreach (Path path in paths)
                {
                    if (path.Which)
                        cjobs[i].Destination.Add(path.Source);
                    else
                        cjobs[i].Source.Add(path.Source);
                }
            }

            //zapise ze klient byl online
            ClientsReporting cr = this.context.ClientsReporting.Find(UserId);
            cr.LastSeen = DateTime.UtcNow.ToString();
            this.context.SaveChanges();
            return cjobs; //Bude vracet list jobu co ma urcity client podle kde to taky bude vracet list cest
        }

        private JobsClientModel FillList(Jobs jobs)
        {
            JobsClientModel cjobs = new JobsClientModel();
            cjobs.Id = jobs.Id;
            cjobs.MaxFullBackup = jobs.MaxFullBackup;
            cjobs.MaxSecBackup = jobs.MaxSecBackup;
            cjobs.CronTime = new DateTime[10];
            cjobs.Ends = jobs.Ends;
            cjobs.BackupType = jobs.BackupType;
            cjobs.Destination = new List<string>();
            cjobs.Source = new List<string>();
            return cjobs;
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
            current.ToZip = jobs.ToZip;
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
