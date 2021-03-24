using EFDataApp.Models; // пространство имен моделей и контекста данных
using EFDataApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EFDataApp.Controllers
{
    public class NoteController : Controller
    {
        public ViewModel obj = new ViewModel();

        public ApplicationContext db;
        public NoteController(ApplicationContext context)
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
        public async Task<IActionResult> Index()
        {
            await transform();

            return View(obj);
        }

    }
}
