using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PXLSchoolManagement.Models
{
    public class Gebruiker : IdentityUser
    {
        [Key]
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string VolledigeNaam => Voornaam + " " + Naam;
        public List<IdentityRole> Roles { get; set; }

    }
}