using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Vaklector
    {
        [Key]
        public int VakLectorId { get; set; }
        public int LectorId { get; set; }
        public Lector Lector { get; set; }
        public List<Inschrijving> Inschrijvingen { get; set; }
    }
}
