using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Models.ViewModels.JobSeekers
{
    public class JobSeekerDetailsViewModel
    {
        public JobSeeker JobSeeker { get; set; }
    }
}
