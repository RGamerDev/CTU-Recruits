using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Models.ViewModels.Employers
{
    public class EmployerCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required, Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string Description { get; set; }
    }
}
