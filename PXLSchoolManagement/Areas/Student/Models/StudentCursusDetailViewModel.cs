using PXLSchoolManagement.Models;
using System.Collections.Generic;

namespace PXLSchoolManagement.Areas.Student.Models
{
    public class StudentCursusDetailViewModel
    {
        public Inschrijving Cursus { get; set; }
        public bool IsIngeschreven { get; set; }
    }
}
