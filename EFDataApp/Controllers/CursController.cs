using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFDataApp.Models; // пространство имен моделей и контекста данных
using EFDataApp.ViewModels;
using System.Collections.Generic;
using EFDataApp.JoinModels;
using EFDataApp.Validations;

namespace EFDataApp.Controllers
{
    public class CursController : Controller
    {
        public ViewModel obj = new ViewModel();
        public static int CoursID;

        public ApplicationContext db;
        public static int studentId = 0;
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

            return View(obj.Cursuri.FirstOrDefault(u=>u.Id==id));
        }

        // Notele studentilor la curs
        public async Task<IActionResult> NoteStudent()
        {
            await transform();
            ViewModel A = new ViewModel();
            A.Notes = db.Notes.Where(u => u.CursId == CoursID).ToList();
            List<StudentNota> B = new List<StudentNota>();
            B = A.Notes.Join(db.Students,
                u => u.StudentId,
                p => p.Id,
                (u, p) => new StudentNota
                { FirstName = p.FirstName, LastName = p.LastName, Nota = u.Nota }
                ).ToList();

            return View(B);
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
            Curs p = obj.Cursuri.FirstOrDefault(u => u.Id == CoursID);
            ViewBag.CName = p.Name;
            ViewBag.Curs = CoursID;
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
            studentId = (int)id;
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
        {  if (validNote(user.Nota))
            {
                await transform();
                int p = user.Nota;
                
                Curs Login = obj.Cursuri.FirstOrDefault(u => u.Id == CoursID);
                int loginId = Login.Id;


                Note user1 = await db.Notes.FirstOrDefaultAsync(p => p.StudentId == user.Id && p.CursId == loginId);
                user = user1;

                user.Nota = p;
                db.Notes.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("StudentList");
            }
            Note user2 = await db.Notes.FirstOrDefaultAsync(p => p.StudentId == studentId);
            return View(user2);
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

        public bool validNote(int nota)
        {
            NoteErr err = new NoteErr();
            string k = "";
            k = err.noteValid(nota);
            if (k.Contains("1"))
            {
                ViewBag.NoteErr = err.errNote;
            }
            if(k=="")
            return true;

            return false;
        }
     
    }
}