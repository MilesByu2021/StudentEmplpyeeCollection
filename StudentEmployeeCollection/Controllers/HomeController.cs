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
        private IStudentRepository _repoStudent { get; set; }

        private IPositionTypeRepository _repoPositionType { get; set; }

        private IQualtricsSentRepository _repoQualtricsSent { get; set; }

        private IStudent_SupervisorRepository _repoStudentSupervisor { get; set; }

        private IStudentPositionTypeRepository _repoStudentPositionType { get; set; }

        private ISupervisorRepository _repoSupervisor { get; set; }

        public HomeController(
                                  IStudentRepository tempStudent,
                                  IPositionTypeRepository tempPT,
                                  IQualtricsSentRepository tempQS,
                                  IStudent_SupervisorRepository tempSS,
                                  IStudentPositionTypeRepository tempSPT,
                                  ISupervisorRepository tempSupervisor
                             )
        {
            _repoStudent = tempStudent;

            _repoPositionType = tempPT;

            _repoQualtricsSent = tempQS;

            _repoStudentSupervisor = tempSS;

            _repoStudentPositionType = tempSPT;

            _repoSupervisor = tempSupervisor;
        }

        //Read Student
        public IActionResult Index()
        {
            var student = _repoStudent.Student.ToList();

            return View(student);
        }

        //Create StudentlClient.MySqlException has been thrown
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
