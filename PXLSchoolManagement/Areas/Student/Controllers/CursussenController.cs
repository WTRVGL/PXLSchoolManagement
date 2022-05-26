﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PXLSchoolManagement.Areas.Student.Controllers
{
    [Area("Student")]
    public class CursussenController : Controller
    {
        [Authorize(Roles ="Admin,Student")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Student")]
        public IActionResult Cursussen()
        {
            return View();
        }

    }
}
