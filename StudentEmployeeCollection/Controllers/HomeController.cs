using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentEmployeeCollection.Models;
using StudentEmployeeCollection.Models.ViewModels;

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
            List<string> semesters = _repoStudent.GetSemesters();
            ViewBag.Semesters = semesters.Select(s =>
                new SelectListItem()
                {
                    Text = s,
                    Value = s,
                });
            List<int> years = _repoStudent.GetYears();
            ViewBag.Years = years.Select(y =>
                new SelectListItem()
                {
                    Text = y.ToString(),
                    Value = y.ToString(),
                });
            List<Supervisor> supervisors = _repoSupervisor.Supervisor.ToList();
            ViewBag.Supervisors = supervisors.Select(s =>
                new SelectListItem()
                {
                    Text = s.FirstName + " " + s.LastName,
                    Value = s.SupervisorID.ToString()
                });
            List<Position> positions = _repoPosition.GetPositionsQuery().ToList();
            ViewBag.Filters = new PositionsFilterForm();

            return View(positions);
        }



        public IActionResult ExportToCSVStudent()
        {
            var builder = new StringBuilder();
            builder.AppendLine("BYUID, First Name, Last Name, International, Gender, Email, Semester, Year, Program Year, Phone Number, Pay Grad Tuition?, Submitted E-Form, Submission Date, Notes");
            foreach (var student in _repoStudent.Student)
            // OR change it to just say 'Student'
            {
                builder.AppendLine($"{student.BYUID}, {student.FirstName}, {student.LastName}, {student.International}, {student.Gender}, {student.EmailAddress}, {student.Semester}, {student.Year}, {student.ProgramYear}, {student.Phone}, {student.PayGradTuition}, {student.SubmittedEForm}, {student.SubmissionDate}, {student.Notes},  ");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "users.csv");
        }

        public class PositionsFilterForm
        {
            public string SemesterFilter { get; set; }
            public string YearFilter { get; set; }
            public string SupervisorFilter { get; set; }
            public string GroupByFilter { get; set; }
        }

        [HttpPost]
        public IActionResult Index([FromForm] PositionsFilterForm form)
        {
            List<string> semesters = _repoStudent.GetSemesters();
            ViewBag.Semesters = semesters.Select(s =>
                new SelectListItem()
                {
                    Text = s,
                    Value = s,
                    Selected = form.SemesterFilter == s
                });
            List<int> years = _repoStudent.GetYears();
            ViewBag.Years = years.Select(y =>
                new SelectListItem()
                {
                    Text = y.ToString(),
                    Value = y.ToString(),
                    Selected = form.YearFilter == y.ToString()
                });
            List<Supervisor> supervisors = _repoSupervisor.Supervisor.ToList();
            ViewBag.Supervisors = supervisors.Select(s =>
                new SelectListItem()
                {
                    Text = s.FirstName + " " + s.LastName,
                    Value = s.SupervisorID.ToString(),
                    Selected = form.SupervisorFilter == s.SupervisorID.ToString()
                });

            IQueryable<Position> query = _repoPosition.GetPositionsQuery();
            if (!string.IsNullOrEmpty(form.SemesterFilter))
                query = query.Where(p => p.Student.Semester == form.SemesterFilter);
            if (!string.IsNullOrEmpty(form.YearFilter))
                query = query.Where(p => p.Student.Year == int.Parse(form.YearFilter));
            if (!string.IsNullOrEmpty(form.SupervisorFilter))
                query = query.Where(p => p.SupervisorID == int.Parse(form.SupervisorFilter));
            List<Position> positions = query.ToList();
            ViewBag.Filters = form;

            // if a group by filter is set, then render the GroupBy View instead of the this index one
            if (!string.IsNullOrEmpty(form.GroupByFilter))
            {
                List<PositionListViewModel> vms = new List<PositionListViewModel>();
                if (form.GroupByFilter == "Semester")
                {
                    foreach (Position p in positions)
                    {
                        PositionListViewModel alreadyContainsGroup = vms.FirstOrDefault(vm => vm.Group == p.Student.Semester);
                        if (alreadyContainsGroup != null)
                        {
                            alreadyContainsGroup.Positions.Add(p);
                        }
                        else
                        {
                            PositionListViewModel newVm = new PositionListViewModel(p.Student.Semester, p);
                            vms.Add(newVm);
                        }
                    }
                }

                if (form.GroupByFilter == "Year")
                {
                    foreach (Position p in positions)
                    {
                        PositionListViewModel alreadyContainsGroup = vms.FirstOrDefault(vm => vm.Group == p.Student.Year.ToString());
                        if (alreadyContainsGroup != null)
                        {
                            alreadyContainsGroup.Positions.Add(p);
                        }
                        else
                        {
                            PositionListViewModel newVm = new PositionListViewModel(p.Student.Year.ToString(), p);
                            vms.Add(newVm);
                        }
                    }
                }

                if (form.GroupByFilter == "Supervisor")
                {
                    foreach (Position p in positions)
                    {
                        PositionListViewModel alreadyContainsGroup = vms.FirstOrDefault(vm => vm.Group == p.Supervisor.FirstName + " " + p.Supervisor.LastName);
                        if (alreadyContainsGroup != null)
                        {
                            alreadyContainsGroup.Positions.Add(p);
                        }
                        else
                        {
                            PositionListViewModel newVm = new PositionListViewModel(p.Supervisor.FirstName + " " + p.Supervisor.LastName, p);
                            vms.Add(newVm);
                        }
                    }
                }

                return View("GroupBy", vms);
            }

            return View(positions);
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
