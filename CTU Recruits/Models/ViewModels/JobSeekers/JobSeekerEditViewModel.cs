using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Models.ViewModels.JobSeekers
{
    public class JobSeekerEditViewModel : JobSeekerCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
        public string ExistingCVPath { get; set; }

        [Display(Name = "Dream job found")]
        public bool dreamJobFound { get; set; }
    }
}
