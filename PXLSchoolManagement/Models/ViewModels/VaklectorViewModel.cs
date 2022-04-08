using Microsoft.AspNetCore.Mvc.Rendering;

namespace PXLSchoolManagement.Models.ViewModels
{
    public class VaklectorViewModel
    {
        public int LectorId { get; set; }
        public List<VaklectorDropdown> VaklectorDropdownList { get; set; }
    }
}
