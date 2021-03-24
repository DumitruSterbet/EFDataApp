using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public int CursId { get; set; }
        public Curs Curs { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
