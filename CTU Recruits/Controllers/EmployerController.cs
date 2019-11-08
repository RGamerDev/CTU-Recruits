using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CTU_Recruits.Models;
using CTU_Recruits.Data;

namespace CTU_Recruits.Controllers
{
    public class EmployerController : Controller
    {
        private IRepository _repo;

        public EmployerController(IRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repo.GetAllEmployers());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
