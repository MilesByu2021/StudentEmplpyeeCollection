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

        [HttpGet]
        public IActionResult Index()
        {
            var students = _repoStudent.Student
            .Include(s => s.Positions)
                .ThenInclude(p => p.Supervisor)
            .Include(s => s.Positions)
                .ThenInclude(p => p.PositionType);

            return View(students);
        }

        [HttpPost]
        public IActionResult Index([FromForm] string filter)
        {
    //        select sp.firstname, sp.lastname from student s

    //inner join position p on s.BYUID = p.BYUID

    //inner join supervisor sp on p.SupervisorId = sp.supervisorId

            IQueryable<Student> bigQuery;

            //bigQuery = from student in _repoStudent.Student where (student.Semester == filter) select student;

            //bigQuery = from student in _repoStudent.Student
            //           join pos in _repoPosition.Position on student.BYUID equals pos.BYUID
            //         join sup in _repoSupervisor.Supervisor on pos.SupervisorID equals sup.SupervisorID
            //       where student.Semester == filter select student;
            bigQuery = _repoStudent.Student
                .Include(s => s.Positions)
                    .ThenInclude(p => p.Supervisor)
                .Include(s => s.Positions)
                    .ThenInclude(p => p.PositionType)
                .Where(s => s.Semester == filter || s.Positions.First().Supervisor.LastName == filter);

            return View(bigQuery);
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
