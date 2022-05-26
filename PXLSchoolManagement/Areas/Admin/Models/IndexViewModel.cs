using PXLSchoolManagement.Models;
using System.Collections.Generic;

namespace PXLSchoolManagement.Areas.Admin.Models
{
    public class IndexViewModel
    {
        public List<Student> Studenten { get; set; }
        public List<Handboek> Handboeken { get; set; }
        public List<Vaklector> Vaklectoren { get; set; }
        public List<Inschrijving> Inschrijvingen { get; set; }
        public int TemporarilyAccountCount { get; set; }
    }
}
