using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentEmployeeCollection.Models;

namespace StudentEmployeeCollection.Controllers
{
    public class HomeController : Controller
    {
        private IStudentEmpRepository _repoStudentEmp { get; set; }

        public HomeController(IStudentEmpRepository tempStudentEmp)
        {
            _repoStudentEmp = tempStudentEmp;
        }

        //Read Student
        public IActionResult Index()
        {
            return View();
        }

        //Create Student
        public IActionResult Create()
        {
            return View("Create");
        }

        //Details Student
        public IActionResult Details()
        {
            return View("Details");
        }

        //Edit Student
        public IActionResult Edit()
        {
            return View("EditForm");
        }

        //Delete Student
        public IActionResult Delete()
        {
            return View();
        }

    }
}
