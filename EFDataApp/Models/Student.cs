using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introdu prenumele")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Introdu numele")]
        public string LastName { get; set; }
        public int Age { get; set; }
        
        public string About { get; set; }
        public int Telefon { get; set; }
        [Required(ErrorMessage = "Introdu adresa email")]
        public string Email { get; set; }
    }
}
