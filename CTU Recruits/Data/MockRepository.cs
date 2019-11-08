using CTU_Recruits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Data
{
    public class MockRepository : IRepository
    {
        public List<Employer> employers { get; set; }
        public List<JobSeeker> jobSeekers { get; set; }

        public MockRepository()
        {
            employers = new List<Employer>()
            {
                new Employer(){ Id = 1, Name = "Mary", CompanyName = "Techer", Description = "jfkdlsahjkdasghsdjka"},
                new Employer(){ Id = 2, Name = "John", CompanyName = "ITD", Description = "jfkdlsahjkdasghsdjka"},
                new Employer(){ Id = 3, Name = "Sam", CompanyName = "UMC", Description = "jfkdlsahjkdasghsdjka"},
            };

            jobSeekers = new List<JobSeeker>()
            {
                new JobSeeker(){ Id = 1, Name = "Mary", Skills = "abc", YearsOfExperience = 1,
                    Description = "jkfld;ajskgl;ag", PhotoPath = @"Mary.jpg",
                    CVPath = "CV.png", PublicCV = true},
                new JobSeeker(){ Id = 2, Name = "John", Skills = "def", YearsOfExperience = 1,
                    Description = "jkfld;ajskgl;ag", PhotoPath = @"John.jpg",
                    CVPath = "CV.png", PublicCV = true },
                new JobSeeker(){ Id = 3, Name = "Sam", Skills = "ghi", YearsOfExperience = 1,
                    Description = "jkfld;ajskgl;ag", PhotoPath = @"Sam.jpg",
                    CVPath = "CV.png", PublicCV = true },
            };
        }

        public Employer AddEmployer(Employer employer)
        {
            employer.Id = employers.Max(e => e.Id) + 1;
            employers.Add(employer);
            return employer;
        }

        public JobSeeker AddJobSeeker(JobSeeker jobSeeker)
        {
            if (jobSeekers.Count <= 0)
            {
                jobSeeker.Id = 1;
            }
            else
            {
                jobSeeker.Id = jobSeekers.Max(j => j.Id) + 1;
            }

            jobSeekers.Add(jobSeeker);
            return jobSeeker;
        }

        public Employer DeleteEmployer(int id)
        {
            Employer employer = employers.FirstOrDefault(e => e.Id == id);
            if (employer != null)
            {
                employers.Remove(employer);
            }
            return employer;
        }

        public JobSeeker DeleteJobSeeker(int id)
        {
            JobSeeker jobSeeker = jobSeekers.FirstOrDefault(j => j.Id == id);
            if (jobSeeker != null)
            {
                jobSeekers.Remove(jobSeeker);
            }
            return jobSeeker;
        }

        public IEnumerable<Employer> GetAllEmployers()
        {
            return employers;
        }

        public IEnumerable<JobSeeker> GetAllJobSeekers()
        {
            return jobSeekers;
        }

        public Employer GetEmployer(int id)
        {
            return employers.FirstOrDefault(e => e.Id == id);
        }

        public JobSeeker GetJobSeeker(int id)
        {
            return jobSeekers.FirstOrDefault(j => j.Id == id);
        }

        public Employer UpdateEmployer(Employer employerChanges)
        {
            Employer employer = employers.FirstOrDefault(j => j.Id == employerChanges.Id);
            if (employer != null)
            {
                employer.Name = employerChanges.Name;
                employer.CompanyName = employerChanges.CompanyName;
                employer.Description = employerChanges.Description;
            }
            return employer;
        }

        public JobSeeker UpdateJobSeeker(JobSeeker jobSeekerChanges)
        {
            JobSeeker jobSeeker = jobSeekers.FirstOrDefault(j => j.Id == jobSeekerChanges.Id);
            if (jobSeeker != null)
            {
                jobSeeker.Name = jobSeekerChanges.Name;
                jobSeeker.Skills = jobSeekerChanges.Skills;
                jobSeeker.YearsOfExperience = jobSeekerChanges.YearsOfExperience;
                jobSeeker.Description = jobSeekerChanges.Description;
                jobSeeker.PublicCV = jobSeekerChanges.PublicCV;
                jobSeeker.PhotoPath = jobSeekerChanges.PhotoPath;
                jobSeeker.CVPath = jobSeekerChanges.CVPath;
            }
            return jobSeeker;
        }
    }
}
