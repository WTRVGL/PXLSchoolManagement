using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Lector
    {   
        [Key]
        public int LectorId { get; set; }
        public int GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
    }
}
