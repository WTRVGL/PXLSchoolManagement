using System;
using System.Collections.Generic;

namespace PXLSchoolManagement.Models
{
    public class Academiejaar
    {
        public int AcademiejaarId { get; set; }
        public DateTime Startdatum { get; set; }
        public string JarenGeformatteerd { get; set; }
        public List<Inschrijving> Inschrijvingen { get; set; }
    }
}
