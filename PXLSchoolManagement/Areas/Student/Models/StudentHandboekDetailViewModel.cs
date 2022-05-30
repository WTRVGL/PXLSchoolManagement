using PXLSchoolManagement.Models;
using System.Collections.Generic;

namespace PXLSchoolManagement.Areas.Student.Models
{
    public class StudentHandboekDetailViewModel
    {
        public Handboek Handboek { get; set; }
        public Vaklector VaklectorBoek { get; set; }
        public bool InBezit{ get; set; }
    }
}
