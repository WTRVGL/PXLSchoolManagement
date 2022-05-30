using Microsoft.AspNetCore.Mvc;

namespace PXLSchoolManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HandboekenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
