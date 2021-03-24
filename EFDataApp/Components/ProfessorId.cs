using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Components
{
    public class ProfessorId : ViewComponent
    {
        static public int ID = 0;
        public IViewComponentResult Invoke()
        {
            return View("menu_prof", ID);
        }

    }
}
