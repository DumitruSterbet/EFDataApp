using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Components
{
    public class StudentId : ViewComponent
    {
        static public int ID = 0;
        public IViewComponentResult Invoke()
        {
            return View("_Menu_bar",ID);
        }
        
    }
}

