using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using System;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using EFDataApp.Models; // пространство имен моделей и контекста данных
using EFDataApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using EFDataApp.Components;

namespace EFDataApp.Controllers
{
    public class LogController : Controller
    {
        public ViewModel obj = new ViewModel();

        public ApplicationContext db;
        public LogController(ApplicationContext context)
        {
            db = context;
        }


        // Simularea BD prin clasa
        public async Task<ViewModel> transform()
        {
            obj.LogCurs = await (db.LogCurs.ToListAsync());
            obj.LogStudents = await (db.LogStudents.ToListAsync());
            obj.LogAmins = await (db.LogAmins.ToListAsync());
            return obj;
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Index()
        {
            await transform();

            return View();
        }


        // Pagina de logare ca profesor
        [HttpGet]
        public async Task<IActionResult> LoghinCurs()
        {
            await transform();
            return View(obj.LogCurs[2]);
        }

        // Pagina de logare ca admin
        [HttpGet]
        public async Task<IActionResult> LoghinAdmin()
        {
            await transform();
            return View(obj.LogAmins[0]);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoghinAdmin(LogAmin ad)
        {
            if (ModelState.IsValid)
            {
                LogAmin user = await db.LogAmins.FirstOrDefaultAsync(u => u.Login == ad.Login && u.Password == ad.Password);
                if (user != null)
                {
                    await Authenticate(ad.Login);

                    return RedirectToAction("Index", "Admin");
                }

            }
            return RedirectToAction("Index", "Log");

        }
        // Pagina de logare ca student
        [HttpGet]
        public async Task<IActionResult> LoghinStudent()
        {
            await transform();
            return View(obj.LogStudents[2]);
        }


        // Metoda de intrare in admin Mode
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoghinCurs(LogCurs ad)
        {
            if (ModelState.IsValid)
            {
                LogCurs user = await db.LogCurs.FirstOrDefaultAsync(u => u.Login == ad.Login && u.Password == ad.Password);
                if (user != null)
                {
                    await Authenticate(ad.Login);
                    ProfessorId.ID = user.CursId ;

                    return RedirectToAction("Index", "Curs", new { @id = user.CursId});
                }

            }
            return RedirectToAction("Index", "Log");

        }

        // Metoda de intrare in Student Mode
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoghinStudent(LogStudent ad)
        {
            if (ModelState.IsValid)
            {
                LogStudent user = await db.LogStudents.FirstOrDefaultAsync(u => u.Login == ad.Login && u.Password == ad.Password);
                if (user != null)
                {
                    await Authenticate(ad.Login); // аутентификация
                    StudentId.ID = user.StudentId ;
                    return RedirectToAction("Index", "Student", new { @id = user.StudentId });
                }

            }
            return RedirectToAction("Index", "Log");

        }

    }
}
