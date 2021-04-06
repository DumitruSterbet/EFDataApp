using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Components
{
    public class MenuManager: ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            return View("menu_admin");
        }

    }
}
