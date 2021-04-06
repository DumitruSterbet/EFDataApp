using System.ComponentModel.DataAnnotations;

namespace EFDataApp.Models
{
    public class Curs
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Introdu denumirea cursului")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Descrie cursul")]
        public string About { get; set; }
        [Required(ErrorMessage = "Introduce numele profesorului")]
        public string Profesor { get; set; }
    }
}