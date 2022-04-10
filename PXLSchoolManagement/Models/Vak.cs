using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Vak
    {
        [Key]
        public int Id { get; set; }
        public string VakNaam { get; set; }
        public int Studiepunten { get; set; }
        public List<Inschrijving> Inschrijvingen { get; set; }
        public List<Handboek> Handboeken { get; set; }
    }
}
