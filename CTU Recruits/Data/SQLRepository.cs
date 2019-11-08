using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTU_Recruits.Models;

namespace CTU_Recruits.Data
{
    public class SQLRepository : IRepository
    {
        private readonly AppDbContext context;

        public SQLRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Employer AddEmployer(Employer employer)
        {
            context.employers.Add(employer);
            context.SaveChanges();
            return employer;
        }

        public JobSeeker AddJobSeeker(JobSeeker jobSeeker)
        {
            context.jobSeekers.Add(jobSeeker);
            context.SaveChanges();
            return jobSeeker;
        }

        public Employer DeleteEmployer(int id)
        {
            Employer employer = context.employers.Find(id);

            if (employer != null)
            {
                context.employers.Remove(employer);
                context.SaveChanges();
            }
            return employer;
        }

        public JobSeeker DeleteJobSeeker(int id)
        {
            JobSeeker jobSeeker = context.jobSeekers.Find(id);

            if (jobSeeker != null)
            {
                context.jobSeekers.Remove(jobSeeker);
                context.SaveChanges();
            }
            return jobSeeker;
        }

        public IEnumerable<Employer> GetAllEmployers()
        {
            return context.employers;
        }

        public IEnumerable<JobSeeker> GetAllJobSeekers()
        {
            return context.jobSeekers;
        }

        public Employer GetEmployer(int id)
        {
            return context.employers.Find(id);
        }

        public JobSeeker GetJobSeeker(int id)
        {
            return context.jobSeekers.Find(id);
        }

        public Employer UpdateEmployer(Employer employerChanges)
        {
            var employer = context.employers.Attach(employerChanges);
            employer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employerChanges;
        }

        public JobSeeker UpdateJobSeeker(JobSeeker jobSeekerChanges)
        {
            var jobSeeker = context.jobSeekers.Attach(jobSeekerChanges);
            jobSeeker.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return jobSeekerChanges;
        }
    }
}
