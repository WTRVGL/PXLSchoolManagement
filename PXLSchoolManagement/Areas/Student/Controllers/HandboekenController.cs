using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PXLSchoolManagement.Areas.Student.Controllers
{
    [Area("Student")]
    public class HandboekenController : Controller
    {
        [Authorize(Roles ="Admin,Student")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
