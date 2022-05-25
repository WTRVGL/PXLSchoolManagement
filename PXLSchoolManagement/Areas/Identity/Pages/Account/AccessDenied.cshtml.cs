using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PXLSchoolManagement.Models;

namespace PXLSchoolManagement.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class AccessDeniedModel : PageModel
    {
        private readonly UserManager<Gebruiker> _userManager;

        public AccessDeniedModel(UserManager<Gebruiker> userManager)
        {
            _userManager = userManager;
        }

        public bool IsTemporarilyAccount { get; set; }

        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            IsTemporarilyAccount = user.IsTemporarilyAccount;
        }
    }
}

