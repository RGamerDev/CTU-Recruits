using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Models
{
    public class Employer
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string CompanyPhotoPath { get; set; }
    }
}
