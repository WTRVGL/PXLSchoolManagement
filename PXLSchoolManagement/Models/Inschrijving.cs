using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Inschrijving
    {
        [Key]
        public int Id { get; set; }
        public List<Student> Studenten { get; set; }
        public List<Vaklector> Vaklectors{ get; set; }
        public Academiejaar Academiejaar { get; set; }
    }
}
