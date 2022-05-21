using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PXLSchoolManagement.Models.ViewModels
{
    public class VaklectorViewModel
    {
        public int LectorId { get; set; }
        public IEnumerable<SelectListItem>? Lectoren { get; set; }
    }
}
