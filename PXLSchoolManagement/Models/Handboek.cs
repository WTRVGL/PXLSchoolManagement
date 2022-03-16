using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Handboek
    {
        [Key]
        public int HandboekId { get; set; }
        public string Titel { get; set; }
        public decimal Kostprijs { get; set; }
        public DateTime UitgifteDatum { get; set; }
        public string Afbeelding { get; set; }
        public int VakId { get; set; }
        public Vak Vak { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }



    }
}
