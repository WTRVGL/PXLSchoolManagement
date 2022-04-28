namespace PXLSchoolManagement.Models
{
    public class Academiejaar
    {
        public int AcademiejaarId { get; set; }
        public DateTime Startdatum { get; set; }
        public List<Inschrijving> Inschrijvingen { get; set; }
    }
}
