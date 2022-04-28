using Microsoft.AspNetCore.Mvc.Rendering;

namespace PXLSchoolManagement.Models.ViewModels
{
    public class VaklectorViewModel
    {
        public int LectorId { get; set; }
        public IEnumerable<SelectListItem>? Lectoren { get; set; }
    }
}
