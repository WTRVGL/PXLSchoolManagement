using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Inschrijving
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<Student> Studenten { get; set; }
        public List<Vaklector> Vaklectors{ get; set; }
        [Required]
        public int VakId { get; set; }
        public Vak Vak { get; set; }
        public int AcademiejaarId { get; set; }
        public Academiejaar Academiejaar { get; set; }
    }
}
