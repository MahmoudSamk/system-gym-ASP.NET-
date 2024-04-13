using GymSystem.Data;
using GymSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Controllers
{
    public class EmployeesController : Controller
    {

        ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetIndexView(string? search)
        {
            ViewBag.Branches = new string[] { "Alexandria", "Cairo", "Giza" };
            ViewBag.Countries = new string[] { "Egypt", "Kuwait", "Oman", "Bahrain" };
            ViewBag.Descount = 0.15;
            ViewBag.Search = search;

            if (search == null)
            {
                return View("Index", _context.Employees);

            }
            else
            {
                return View("Index", _context.Employees.Where(e => e.FullName.Contains(search) ||
                e.Position.Contains(search)));
            }
        }




        [HttpGet]
        public IActionResult GetDetailsView(int id)
        {
            EmployeeGYM employee = _context.Employees.Include(e => e.Department).FirstOrDefault(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", employee);
            }


        }
        [HttpGet]
        public IActionResult GetCreateView()
        {
            ViewBag.AllDepartments = _context.Departments.ToList();
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew([Bind("Id,FullName,Position,Salary,Appraisal,BirthDate,JoinDateTime,AttendanceTime,NationalNumber,PhoneNumber,SecretCode,ConfirmSecretCode,IsActive,AttendanceTime,DepartmentId")
            ]EmployeeGYM emp)
        {

            if (((emp.JoinDateTime - emp.BirthDate).Days / 365) < 18)
            {
                ModelState.AddModelError("", "Illegal hiring age (Under 18 years old).");


            }

            if (_context.Employees.Any(e => e.NationalNumber == emp.NationalNumber) == true)
            {

                ModelState.AddModelError("", "This Employee national number is registered to another employee");
            }

            if (ModelState.IsValid == true)
            {

                _context.Employees.Add(emp);
                _context.SaveChanges();

                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllDepartments = _context.Departments.ToList();

                return View("Create");
            }

        }

        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            EmployeeGYM employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) { return NotFound(); }
            else
            {
                ViewBag.AllDepartments = _context.Departments.ToList();

                return View("Edit", employee);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCurrent([Bind
           ("Id, FullName,Position, Salary, Appraisal, BirthDate, JoinDateTime, AttendanceTime, NationalNumber, PhoneNumber, SecretCode, ConfirmSecretCode, IsActive,AttendanceTime,DepartmentId"
            )] EmployeeGYM emp)
        {

            if (((emp.JoinDateTime - emp.BirthDate).Days / 365) < 18)
            {
                ModelState.AddModelError("", "Illegal hiring age (Under 18 years old).");
            }
            if (_context.Employees.Any(e => e.NationalNumber == emp.NationalNumber && e.Id != emp.Id) == true)

            {
                ModelState.AddModelError("", "This employee national number is registered to another employee.");
            }
            if (ModelState.IsValid == true)
            {
                _context.Employees.Update(emp);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.AllDepartments = _context.Departments.ToList();

                return View("Edit");

            }

        }

        public IActionResult GetDeleteView(int id)///////////////////////////////////////////////////////////////
        {
            EmployeeGYM employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {

                return View("Delete", employee);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCurrent(int id)///////////////////////////////////////////////////////////////////
        {

            EmployeeGYM employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("GetIndexView");
        }




    }

}

