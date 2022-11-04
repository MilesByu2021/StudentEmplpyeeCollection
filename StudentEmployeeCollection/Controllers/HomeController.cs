using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentEmployeeCollection.Models;

namespace StudentEmployeeCollection.Controllers
{
    public class HomeController : Controller
    {
        private IStudentRepository _repoStudent { get; set; }
        private IPositionTypeRepository _repoPositionType { get; set; }
        private IPositionRepository _repoPosition { get; set; }
        private ISupervisorRepository _repoSupervisor { get; set; }
        private IPayIncreaseRepository _repoPayIncrease { get; set; }

        public HomeController(
                                  IStudentRepository tempStudent,
                                  IPositionTypeRepository tempPT,
                                  IPositionRepository tempP,
                                  ISupervisorRepository tempSupervisor,
                                  IPayIncreaseRepository tempPI
                             )
        {
            _repoStudent = tempStudent;
            _repoPositionType = tempPT;
            _repoPosition = tempP;
            _repoSupervisor = tempSupervisor;
            _repoPayIncrease = tempPI;
        }

        public IActionResult Index()
        {
            var students = _repoStudent.Student
                .Include(s => s.Positions)
                    .ThenInclude(p => p.Supervisor)
                .Include(s => s.Positions)
                    .ThenInclude(p => p.PositionType)
                .ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Students = Student.Position.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Student s)
        {
            _repoStudent.CreateStudent(s);
            return RedirectToAction("Index");
        }   

        //Details Student
        public IActionResult Details()
        {
            return View("Details");
        }

        //Edit Student
        public IActionResult EditForm(string byuid)
        {
            var student = _repoStudent.Student
                .Include(s => s.Positions)
                    .ThenInclude(p => p.Supervisor)
                .Include(s => s.Positions)
                    .ThenInclude(p => p.PositionType)
                .FirstOrDefault(s => s.BYUID == byuid);
            return View(student);
        }

        //Edit Student
        [HttpPost]
        public IActionResult EditForm([FromForm] Student s)
        {
            _repoStudent.SaveStudent(s);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddPositionToStudent(string byuid)
        {
            Student student = _repoStudent.Student.FirstOrDefault(s => s.BYUID == byuid);
            ViewBag.Student = student;
            List<SelectListItem> positionTypes = _repoPositionType.PositionType.Select(pt => new SelectListItem { Value = pt.PositionTypeID.ToString(), Text = pt.PositionName }).ToList();
            ViewBag.PositionTypes = positionTypes;
            List<SelectListItem> supervisors = _repoSupervisor.Supervisor.Select(s => new SelectListItem { Value = s.SupervisorID.ToString(), Text = s.FirstName + " " + s.LastName }).ToList();
            ViewBag.Supervisors = supervisors;
            ViewBag.BYUID = byuid;
            return View();
        }

        [HttpPost]
        public IActionResult AddPositionToStudent([FromForm] Position position)
        {
            _repoPosition.CreatePosition(position);
            return RedirectToAction("EditForm", new RouteValueDictionary( 
                    new { controller = "Home", action = "EditForm", byuid = position.BYUID } 
                )
            );
        }

        //Delete Student
        public IActionResult Delete(Student s)
        {
            var student = _repoStudent.Student
                .Where(x => x.BYUID == s.BYUID)
                .FirstOrDefault();

            _repoStudent.DeleteStudent(student);

            return RedirectToAction("Index");
        }

        //Delete Position
        public IActionResult DeletePosition(Position p)
        {
            var position = _repoPosition.Position
                .Where(x => x.PositionID == p.PositionID)
                .FirstOrDefault();

            _repoPosition.DeletePosition(position);

            return RedirectToAction("EditForm",new RouteValueDictionary(
                    new { controller = "Home", action = "EditForm", byuid = position.BYUID }
                )
            );
        }

    }
}
