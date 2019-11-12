using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CTU_Recruits.Models;
using CTU_Recruits.Data;
using CTU_Recruits.Models.ViewModels.Employers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace CTU_Recruits.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class EmployerController : Controller
    {
        private IRepository _repo;
        private readonly IWebHostEnvironment hostingEnvironment;

        public EmployerController(IRepository repository, IWebHostEnvironment hostingEnvironment)
        {
            _repo = repository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repo.GetAllEmployers());
        }

        [HttpPost]
        public IActionResult Index(string search)
        {

            var query = from employer in _repo.GetAllEmployers()
                        where (employer.CompanyName.ToLower() == search.ToLower()) || (employer.Description.ToLower() == search.ToLower())
                        select employer;
            return View(query);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_repo.GetEmployer(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName;
                uniqueFileName = ProcessPhotos(model);

                Employer newEmployer = new Employer()
                {
                    CompanyName = model.CompanyName,
                    Description = model.Description,
                    CompanyPhotoPath = uniqueFileName,
                };

                _repo.AddEmployer(newEmployer);
                return RedirectToAction("Details", new { id = newEmployer.Id });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repo.DeleteEmployer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employer employer = _repo.GetEmployer(id);
            return View(new EmployerEditViewModel()
            {
                Id = employer.Id,
                CompanyName = employer.CompanyName,
                Description = employer.Description,
                ExistingPhotoPath = employer.CompanyPhotoPath,
            });
        }

        [HttpPost]
        public IActionResult Edit(EmployerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employer employerChanges = _repo.GetEmployer(model.Id);
                employerChanges.CompanyName = model.CompanyName;
                employerChanges.Description = model.Description;

                string companyPhotoFileName = "";
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string ProfilePhotoPath = Path.Combine(hostingEnvironment.WebRootPath, model.ExistingPhotoPath.Substring(2));
                        System.IO.File.Delete(ProfilePhotoPath);
                    }
                    companyPhotoFileName = ProcessPhotos(model);
                    employerChanges.CompanyPhotoPath = companyPhotoFileName;
                }
                return RedirectToAction("Index");
            }

            return View();
        }

        private string ProcessPhotos(EmployerCreateViewModel model)
        {
            string profilePhotoFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Images\\Employers");
                profilePhotoFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, profilePhotoFileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return profilePhotoFileName;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
