using EFDataApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Controllers
{
    public class AdminController : Controller
    {
        public ApplicationContext db;
        public static int StudId = 0;
        public static int CursID = 0;

        public AdminController(ApplicationContext context)
        {
            db = context;
        }

        // Pagina de baza
        public IActionResult Index()
        {
            return View();
        }
  

        // Inregistrare Student
        public IActionResult RegStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegStudent(Student student)
        { 
            if (ModelState.IsValid) { 
            db.Students.Add(student);
            db.SaveChanges();
                StudId = student.Id;
                return RedirectToAction("RegLogStudent");
            }

            return RedirectToAction("Index");
        }

        // Inregistrare signout student
        public IActionResult RegLogStudent()
        {
            ViewBag.ar = StudId;
            return View();
        }
        [HttpPost]
        public IActionResult RegLogStudent(LogStudent stud)
        {
            if (ModelState.IsValid)
            {
               
                db.LogStudents.Add(stud);
                db.SaveChanges();
                return RedirectToAction("RegisterSuccesStud");
            }

            return RedirectToAction("Index");
        }
        public IActionResult RegisterSuccesStud()
        {
            Student A = new Student();
            A = db.Students.FirstOrDefault(u => u.Id == StudId);
            return View(A);
        }

        // Inregistrare curs
        public IActionResult RegCurs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegCurs(Curs curs)
        {
            if (ModelState.IsValid)
            {
                db.Cursuri.Add(curs);
               
                db.SaveChanges();
                CursID = curs.Id;
                return RedirectToAction("RegLogCurs");
            }

            return RedirectToAction("Index");
        }
        // Inregistrare signout student
        public IActionResult RegLogCurs()
        {
            ViewBag.ID = CursID;
            return View();
        }
        [HttpPost]
        public IActionResult RegLogCurs(LogCurs stud)
        {
            if (ModelState.IsValid)
            {

                db.LogCurs.Add(stud);
                db.SaveChanges();
                return RedirectToAction("RegisterSuccesCurs");
            }

            return RedirectToAction("Index");
        }
        public IActionResult RegisterSuccesCurs()
        {
            Curs A = new Curs();
            A = db.Cursuri.FirstOrDefault(u => u.Id == CursID);
            return View(A);
        }

    }
}
