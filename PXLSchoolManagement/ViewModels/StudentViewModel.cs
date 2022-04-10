using Microsoft.AspNetCore.Mvc.Rendering;

namespace PXLSchoolManagement.ViewModels
{
    public class StudentViewModel
    {
        public int GebruikerId { get; set; }
        public IEnumerable<SelectListItem>? Studenten { get; set; }
    }
}
