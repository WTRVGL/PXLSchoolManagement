namespace PXLSchoolManagement.Models.ViewModels
{
    public class VaklectorDropdown
    {
        public int LectorId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string VolledigeNaam => Voornaam + " " + Naam;
    }
}
