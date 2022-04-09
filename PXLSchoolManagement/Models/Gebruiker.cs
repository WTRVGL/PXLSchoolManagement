using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Gebruiker
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public string VolledigeNaam => Voornaam + "" + Naam;
    }
}
