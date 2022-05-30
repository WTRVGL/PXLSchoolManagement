using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PXLSchoolManagement.Areas.Admin.Models
{
    public class StudentViewModel
    {
        public int GebruikerId { get; set; }
        public IEnumerable<SelectListItem>? Studenten { get; set; }
    }
}
