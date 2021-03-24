using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
    public class LogCurs
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int CursId { get; set; }
        public Curs Curs { get; set; }
    }
}
