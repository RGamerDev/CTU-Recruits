using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTU_Recruits.Data;
using Microsoft.AspNetCore.Mvc;

namespace CTU_Recruits.Controllers
{
    public class SuccessController : Controller
    {
        private readonly IRepository repository;

        public SuccessController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var query = from jobseeker in repository.GetAllJobSeekers()
                        where jobseeker.dreamJobFound
                        select jobseeker;
            return View(query);
        }
    }
}