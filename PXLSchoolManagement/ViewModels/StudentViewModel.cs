using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PXLSchoolManagement.ViewModels
{
    public class StudentViewModel
    {
        public int GebruikerId { get; set; }
        public IEnumerable<SelectListItem>? Studenten { get; set; }
    }
}
