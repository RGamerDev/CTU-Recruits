using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Models.ViewModels.JobSeekers
{
    public class JobSeekerCreateViewModel
    {
        [Required, MaxLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string Skills { get; set; }

        [Required(ErrorMessage = "Please enter a number between 0 and 50"), Display(Name = "Years Of Experience"),
            Range(0, 50, ErrorMessage = "Please select a value between 0 and 50")]
        public int? YearsOfExperience { get; set; }

        [Display(Name = "Make CV public")]
        public bool PublicCV { get; set; }

        public IFormFile CV { get; set; }

        public IFormFile Photo { get; set; }
    }
}
