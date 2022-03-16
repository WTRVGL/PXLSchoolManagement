using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public int GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public List<Handboek> Handboeken { get; set; }
        public List<Inschrijving> Inschrijvingen{ get; set; }

    }
}
