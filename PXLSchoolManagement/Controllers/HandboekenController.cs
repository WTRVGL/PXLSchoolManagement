using Microsoft.AspNetCore.Mvc;

namespace PXLSchoolManagement.Controllers
{
    public class HandboekenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
