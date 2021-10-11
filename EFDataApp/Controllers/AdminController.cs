using EFDataApp.Models;
using EFDataApp.Validations;
using EFDataApp.Validations.Students;
using EFDataApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult ListStudents()
        {
            ViewModel obj = new ViewModel();
            obj.Students = db.Students.ToList();
            return View(obj.Students);
        }
        public IActionResult DelStudent(int id)
        {
            Student obj = new Student();
            LogStudent obv = new LogStudent();
            obj = db.Students.FirstOrDefault(u => u.Id == id);
            obv = db.LogStudents.FirstOrDefault(u => u.StudentId == id);
            db.Students.Remove(obj);
            db.LogStudents.Remove(obv);
            db.SaveChanges();
            return RedirectToAction("ListStudents");
        }
        public IActionResult ListCurs()
        {
            ViewModel obj = new ViewModel();
            obj.Cursuri = db.Cursuri.ToList();
            return View(obj.Cursuri);
        }
        public IActionResult DelCurs(int id)
        {
            Curs obj = new Curs();
            LogCurs obv = new LogCurs();
            obj = db.Cursuri.FirstOrDefault(u=>u.Id==id);
            obv = db.LogCurs.FirstOrDefault(u => u.CursId == id);
            db.Cursuri.Remove(obj);
            db.LogCurs.Remove(obv);
            db.SaveChanges();
            return RedirectToAction("ListCurs");
        }




        // Inregistrare Student
        public IActionResult RegStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegStudent(Student student)
        {
            if (!nullValid(student))
            {
                if (!lenghtValid(student))
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    StudId = student.Id;
                    return RedirectToAction("RegLogStudent");
                }
            }

            return View();
        }

        // Inregistrare log student
        public IActionResult RegLogStudent()
        {
            ViewBag.ar = StudId;
            return View();
        }
        [HttpPost]
        public IActionResult RegLogStudent(LogStudent stud)
        {
            ViewBag.ar = StudId;
            if (!nullValid(stud))
                if (!lenghtValid(stud))
                {
                    LogStudent user =  db.LogStudents.FirstOrDefault(u => u.Login == stud.Login && u.Password == stud.Password);
                    if (user == null)
                    {
                       
                        db.LogStudents.Add(stud);
                        db.SaveChanges();
                        return RedirectToAction("RegisterSuccesStud", new { id = stud.StudentId });
                    }
                    ViewBag.ErrExist = "Asa combinatie login-parola exista, incearca alta";

            }

            return View();
        }
        public IActionResult RegisterSuccesStud(int id)
        {
            LogStudent A = new LogStudent();
            A = db.LogStudents.FirstOrDefault(u => u.StudentId == id);
            return View(A);
        }

        // Inregistrare curs
        public IActionResult RegCurs()
        {
            return View();
        }
        [HttpPost]
        //Inregistrarea cursului
        public IActionResult RegCurs(Curs curs)
        {
            if (!nullValid(curs))
                if (!lenghtValid(curs))

                {
                    Curs user = db.Cursuri.FirstOrDefault(u => u.Name == curs.Name);
                    if (user == null)
                    {
                        db.Cursuri.Add(curs);

                        db.SaveChanges();
                        CursID = curs.Id;
                        return RedirectToAction("RegLogCurs");
                    }
                    ViewBag.ErrExist = "Asa curs exista, adauga altul";
            }

            return View();
        }
        
        public IActionResult RegLogCurs()
        {
            ViewBag.ID = CursID;
            return View();
        }
        [HttpPost]
        public IActionResult RegLogCurs(LogCurs stud)
        {
            ViewBag.ID = CursID;
            if (!nullValid(stud))
                if(!lenghtValid(stud))
            {
                    LogCurs user = db.LogCurs.FirstOrDefault(u => u.Login == stud.Login && u.Password == stud.Password);                   
                        if (user == null)
                    {
                        db.LogCurs.Add(stud);
                        db.SaveChanges();
                        return RedirectToAction("RegisterSuccesCurs",new { id = stud.CursId });
                    }
                    ViewBag.ErrExist = "Asa combinatie login-parola exista, adauga alta";
            }

            return View();
        }
        public IActionResult RegisterSuccesCurs(int id)
        {
            LogCurs A = new LogCurs();
            A = db.LogCurs.FirstOrDefault(u => u.CursId == id);
            return View(A);
        }
        public bool nullValid(Object obj2)
        {
            NullErr nullErr = new NullErr();
            string k = "";
            if (obj2 is LogStudent)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.LoginErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.PasswordErr = nullErr.errMess;
                }

            }
            if (obj2 is LogCurs)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.LoginErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.PasswordErr = nullErr.errMess;
                }

            }
            if (obj2 is LogAmin)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.LoginErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.PasswordErr = nullErr.errMess;
                }

            }
            if (obj2 is Student)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.FirstNameErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.LastNameErr = nullErr.errMess;
                }
                if (k.Contains("3"))
                {
                    ViewBag.TelefonErr = nullErr.errMess;
                }
                if (k.Contains("4"))
                {
                    ViewBag.AgeErr = nullErr.errMess;
                }
                if (k.Contains("5"))
                {
                    ViewBag.AboutErr = nullErr.errMess;
                }
                if (k.Contains("6"))
                {
                    ViewBag.EmailErr = nullErr.errMess;
                }

            }
            if (obj2 is Curs)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.NameErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.ProfessorErr = nullErr.errMess;
                }
                if (k.Contains("3"))
                {
                    ViewBag.AboutErr = nullErr.errMess;
                }
               

            }
            if (k == "")
                return false;
            return true;
        }
        public bool lenghtValid(Object obj2)
        {
            LenghtErr nullErr = new LenghtErr();
            string k = "";
            if (obj2 is LogStudent)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.LoginErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.PasswordErr = nullErr.errMess;
                }

            }
            if (obj2 is LogCurs)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.LoginErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.PasswordErr = nullErr.errMess;
                }

            }
            if (obj2 is LogAmin)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.LoginErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.PasswordErr = nullErr.errMess;
                }

            }
            if (obj2 is Student)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.FirstNameErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.LastNameErr = nullErr.errMess;
                }
                if (k.Contains("3"))
                {
                    ViewBag.TelefonErr = nullErr.errMess;
                }
                if (k.Contains("4"))
                {
                    ViewBag.AgeErr = nullErr.errMessAge;
                }
                if (k.Contains("5"))
                {
                    ViewBag.AboutErr = nullErr.errMess;
                }
                if (k.Contains("6"))
                {
                    ViewBag.EmailErr = nullErr.errMess;
                }
                if (k.Contains("7"))
                {
                    ViewBag.EmailErr = nullErr.errMessEm;
                }

            }
            if (obj2 is Curs)
            {
                k = nullErr.nullValidation(obj2);
                if (k.Contains("1"))
                {
                    ViewBag.NameErr = nullErr.errMess;
                }
                if (k.Contains("2"))
                {
                    ViewBag.ProfessorErr = nullErr.errMess;
                }
                if (k.Contains("3"))
                {
                    ViewBag.AboutErr = nullErr.errMess;
                }


            }
            if (k == "")
                return false;
            return true;
        }
    }
}
