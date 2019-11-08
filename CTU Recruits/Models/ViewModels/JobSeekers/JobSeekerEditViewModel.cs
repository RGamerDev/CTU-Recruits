using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTU_Recruits.Models.ViewModels.JobSeekers
{
    public class JobSeekerEditViewModel : JobSeekerCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
        public string ExistingCVPath { get; set; }
    }
}
