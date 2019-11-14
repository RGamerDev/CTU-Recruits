using System;
using System.IO;
using System.Linq;
using CTU_Recruits.Data;
using CTU_Recruits.Models;
using CTU_Recruits.Models.ViewModels.JobSeekers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CTU_Recruits.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly IRepository _repo;
        private readonly IWebHostEnvironment hostingEnvironment;

        public JobSeekerController(IRepository repository, IWebHostEnvironment hostingEnvironment)
        {
            _repo = repository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repo.GetAllJobSeekers());
        }

        [HttpPost]
        public IActionResult Index(string search)
        {

            var query = from jobseeker in _repo.GetAllJobSeekers()
                        where (jobseeker.Name.ToLower() == search.ToLower()) 
                        || (jobseeker.Skills.ToLower() == search.ToLower()) 
                        || (jobseeker.YearsOfExperience.ToString().ToLower() == search.ToLower())
                        select jobseeker;
            return View(query);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_repo.GetJobSeeker(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JobSeekerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName, CVuniqueFileName;
                (uniqueFileName, CVuniqueFileName) = ProcessPhotos(model);

                JobSeeker newjobseeker = new JobSeeker()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Skills = model.Skills,
                    YearsOfExperience = model.YearsOfExperience,
                    PhotoPath = uniqueFileName,
                    PublicCV = model.PublicCV,
                    CVPath = CVuniqueFileName
                };

                _repo.AddJobSeeker(newjobseeker);
                return RedirectToAction("Details", new { id = newjobseeker.Id });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repo.DeleteJobSeeker(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            JobSeeker jobSeeker = _repo.GetJobSeeker(id);
            return View(new JobSeekerEditViewModel()
            {
                Id = jobSeeker.Id,
                Name = jobSeeker.Name,
                Description = jobSeeker.Description,
                Skills = jobSeeker.Skills,
                YearsOfExperience = jobSeeker.YearsOfExperience,
                ExistingPhotoPath = jobSeeker.PhotoPath,
                PublicCV = jobSeeker.PublicCV,
                dreamJobFound = jobSeeker.dreamJobFound,
                ExistingCVPath = jobSeeker.CVPath,
            });
        }

        [HttpPost]
        public IActionResult Edit(JobSeekerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                JobSeeker jobSeekerChanges = _repo.GetJobSeeker(model.Id);
                jobSeekerChanges.Name = model.Name;
                jobSeekerChanges.YearsOfExperience = model.YearsOfExperience;
                jobSeekerChanges.Skills = model.Skills;
                jobSeekerChanges.Description = model.Description;
                jobSeekerChanges.PublicCV = model.PublicCV;
                jobSeekerChanges.dreamJobFound = model.dreamJobFound;

                string profilePhotoFileName = "", CVuniqueFileName = "";
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string ProfilePhotoPath = Path.Combine(hostingEnvironment.WebRootPath, model.ExistingPhotoPath.Substring(2));
                        System.IO.File.Delete(ProfilePhotoPath);
                    }
                    (profilePhotoFileName, CVuniqueFileName) = ProcessPhotos(model);
                    jobSeekerChanges.PhotoPath = profilePhotoFileName;
                }
                if (model.CV != null)
                {
                    if (model.ExistingCVPath != null)
                    {
                        string CVPath = Path.Combine(hostingEnvironment.WebRootPath, model.ExistingCVPath.Substring(2));
                        System.IO.File.Delete(CVPath);
                    }
                    (profilePhotoFileName, CVuniqueFileName) = ProcessPhotos(model);
                    jobSeekerChanges.CVPath = CVuniqueFileName;
                }


                return RedirectToAction("Index");
            }

            return View();
        }

        private (string, string) ProcessPhotos(JobSeekerCreateViewModel model)
        {
            string profilePhotoFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images\\JobSeekers");
                profilePhotoFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, profilePhotoFileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream); 
                }
            }
            string CVuniqueFileName = null;
            if (model.CV != null)
            {
                string CVuploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images\\JobSeekers");
                CVuniqueFileName = Guid.NewGuid().ToString() + "_" + model.CV.FileName;
                string CVfilePath = Path.Combine(CVuploadsFolder, CVuniqueFileName);
                using (FileStream filestream = new FileStream(CVfilePath, FileMode.Create))
                {
                    model.CV.CopyTo(filestream); 
                }
            }

            return (profilePhotoFileName, CVuniqueFileName);
        }
    }
}