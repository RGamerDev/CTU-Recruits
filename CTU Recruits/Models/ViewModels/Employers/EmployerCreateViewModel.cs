using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Models.ViewModels.Employers
{
    public class EmployerCreateViewModel
    {

        [Required, Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string PhotoPath { get; set; }

        public IFormFile Photo { get; set; }
    }
}
