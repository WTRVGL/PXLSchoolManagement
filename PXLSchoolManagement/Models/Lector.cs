using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Lector
    {   
        [Key]
        public int LectorId { get; set; }
        public string GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public Vaklector? Vaklector { get; set; }
    }
}
