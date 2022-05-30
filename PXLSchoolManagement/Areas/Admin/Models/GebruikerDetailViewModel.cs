using Microsoft.AspNetCore.Identity;

namespace PXLSchoolManagement.Areas.Admin.Models
{
    public class GebruikerDetailViewModel
    {
        public string GebruikerId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public IdentityRole Role { get; set; }
        public IdentityRole? RequestedRole { get; set; }
        public string? RequestedRoleId { get; set; }
        public bool IsTemporarilyAccount { get; set; }
    }
}
