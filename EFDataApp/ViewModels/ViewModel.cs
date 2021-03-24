using EFDataApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.ViewModels
{
    public class ViewModel
    {
        public List<Student> Students { get; set; }
        public List<Curs>Cursuri { get; set; }
        public List<Note>Notes { get; set; }
        public List<LogStudent>LogStudents { get; set; }
        public List<LogCurs> LogCurs { get; set; }
    }
}
