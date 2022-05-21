using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PXLSchoolManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }

        public List<Handboek> Handboeken { get; set; }
        public List<Inschrijving> Inschrijvingen{ get; set; }

    }
}
