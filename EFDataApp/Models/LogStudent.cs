using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
    public class LogStudent
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
