using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFDataApp.Models; 
using EFDataApp.ViewModels;
using EFDataApp.JoinModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace EFDataApp.Controllers
{
    public class StudentController : Controller
    {
        public ViewModel obj = new ViewModel();
        // Id studentului de pe pagina personala
        public static int IdStud = 0;
        public ApplicationContext db;
        public StudentController(ApplicationContext context)
        {
            db = context;
            IdStud = 1;
        }


        // Simularea BD prin clasa
        public async Task<ViewModel> transform()
        {
            obj.Students = await (db.Students.ToListAsync());
            obj.Cursuri = await (db.Cursuri.ToListAsync());
            obj.Notes = await (db.Notes.ToListAsync());
            return obj;
        }

        //Pagina de baza a studentului
        public async Task<IActionResult> Index(int id)
        {   
            await transform();
            IdStud = id;
            Student A = new Student();
            A = obj.Students.FirstOrDefault(u => u.Id == IdStud);
            
            return View(A);
        }
      
        //Notele studentului la toate cursurile prezente
        public async Task<IActionResult> MyCurs(int id)
        {
            await transform();
            ViewModel SelectedObj = new ViewModel();
            SelectedObj.Notes = db.Notes.Where(u=>u.StudentId==id).ToList();
            var result = SelectedObj.Notes.Join(
                db.Cursuri.ToList(), // второй набор
             p => p.CursId, // свойство-селектор объекта из первого набора
             t => t.Id, // свойство-селектор объекта из второго набора
             (p, t) => new NotaCurs{  Nota = p.Nota, Curs = t.Name });
            //ViewBag.Media = result.Average(u => u.Nota);
            ViewBag.Media = SelectedObj.Notes.Average(u => u.Nota);
            ViewBag.name = id;
            return View(result);
        }
         
        // Creeaza studentul
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student user)
        {
            db.Students.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Delogare
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Log");
            
        }
        // Datele despre student
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Student user = await db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        // Modifica datele despre student
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Student user = await db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student user)
        {
            db.Students.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Sterge studentul
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Student user = await db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Student user = await db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.Students.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

    }
}