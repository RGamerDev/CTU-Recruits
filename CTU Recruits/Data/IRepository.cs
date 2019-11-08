using CTU_Recruits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Data
{
    public interface IRepository
    {
        Employer GetEmployer(int id);
        JobSeeker GetJobSeeker(int id);

        Employer AddEmployer(Employer employer);
        JobSeeker AddJobSeeker(JobSeeker jobSeeker);

        Employer DeleteEmployer(int id);
        JobSeeker DeleteJobSeeker(int id);

        Employer UpdateEmployer(Employer employerChanges);
        JobSeeker UpdateJobSeeker(JobSeeker jobSeekerChanges);

        IEnumerable<Employer> GetAllEmployers();
        IEnumerable<JobSeeker> GetAllJobSeekers();
    }
}
