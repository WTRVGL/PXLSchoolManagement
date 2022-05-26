using Microsoft.AspNetCore.Mvc;

namespace PXLSchoolManagement.Controllers
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
