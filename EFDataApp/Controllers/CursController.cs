using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFDataApp.Models; // пространство имен моделей и контекста данных
using EFDataApp.ViewModels;
using System.Collections.Generic;

namespace EFDataApp.Controllers
{
    public class CursController : Controller
    {
        public ViewModel obj = new ViewModel();
        public static int CoursID = 0;

        public ApplicationContext db;
        public CursController(ApplicationContext context)
        {
            db = context;
        }


        // Simularea BD prin clasa
        public async Task<ViewModel> transform()
        {
            obj.Students = await (db.Students.ToListAsync());
            obj.Cursuri = await (db.Cursuri.ToListAsync());
            obj.Notes = await (db.Notes.ToListAsync());
            return obj;
        }


        //Pagina cu datele despre curs
        public async Task<IActionResult> Index(int id)
        {
            await transform();
            CoursID = id;

            return View(obj.Cursuri[id]);
        }
        // Adaugarea studentului la curs
        public async Task<IActionResult> Add(int id)
        {
            await transform();
            Note stud = new Note() { CursId = CoursID, StudentId = id, Nota = 0 };
            db.Notes.Add(stud);
            db.SaveChanges();

            return RedirectToAction("FreeStudent");
        }

        // Lista studentilor de la curs
        public async Task<IActionResult> StudentList()
        {
            await transform();
            ViewBag.Object = CoursID;
            ViewModel A = new ViewModel();
            A.Notes = obj.Notes.Where(u=>u.CursId==CoursID).ToList();
            A.Students = A.Notes.Join(obj.Students,
                u => u.StudentId,
                p => p.Id,
                (u, p) => new Student
                {
                    Id = p.Id,
                    About = p.About,
                    Age = p.Age,
                    Email = p.Email,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Telefon = p.Telefon
                }).ToList();
            return View(A.Students);
        }

        // Studentii ce nu apartin cursului
        public async Task<IActionResult> FreeStudent()
        {
            await transform();
            ViewBag.Object = CoursID;
            ViewModel A = new ViewModel();
            A.Notes = obj.Notes.Where(u => u.CursId == CoursID).ToList();
            A.Students = A.Notes.Join(obj.Students,
                u => u.StudentId,
                p => p.Id,
                (u, p) => new Student
                {
                    Id = p.Id,
                    About = p.About,
                    Age = p.Age,
                    Email = p.Email,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Telefon = p.Telefon
                }).ToList();
            
            ViewModel B = new ViewModel();
            B.Students = new List<Student>();
            for(int i=0;i<obj.Students.Count;i++)
            {
                bool c = false;
                for (int j=0;j<A.Students.Count;j++)
                {
                    
                    if (obj.Students[i].Id== A.Students[j].Id)
                    {
                        c = true;
                    }

                }
                if (!c)
                {
                    B.Students.Add(obj.Students[i]);
                }
            }

            return View(B.Students.ToList()) ;
        }
        // Modificarea notei la student
        public async Task<IActionResult> Change(int? id)
        {
            if (id != null)
            {
                Note user = await db.Notes.FirstOrDefaultAsync(p => p.StudentId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Change(Note user)
        {
            await transform();
            int p = user.Nota;
            string login = HttpContext.User.Identity.Name;
            Curs Login = obj.Cursuri.FirstOrDefault(u => u.Name == login);
            int loginId = Login.Id;


            Note user1 = await db.Notes.FirstOrDefaultAsync(p => p.StudentId == user.Id && p.CursId==loginId );
            user = user1;
            
            user.Nota = p;
            db.Notes.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("StudentList");
        }

        //Stergerea studentului de la curs
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Note user = await db.Notes.FirstOrDefaultAsync(p => p.StudentId == id && p.CursId==CoursID);
                if (user != null)
                {
                    db.Notes.Remove(user);
                    db.SaveChanges();
                    return RedirectToAction("StudentList");
                }
            }
            return NotFound();
        }
     
    }
}