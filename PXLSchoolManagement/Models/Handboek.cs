using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PXLSchoolManagement.Models
{
    public class Handboek
    {
        [Key]
        public int HandboekId { get; set; }
        public string Titel { get; set; }
        public decimal Kostprijs { get; set; }
        public DateTime UitgifteDatum { get; set; }
        public string Afbeelding { get; set; }
        public int VakId { get; set; }
        public Vak Vak { get; set; }
        public List<Student> Studenten { get; set; }



    }
}
