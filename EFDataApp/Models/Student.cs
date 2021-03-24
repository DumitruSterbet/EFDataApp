using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public int Age { get; set; }
        public string About { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
    }
}
