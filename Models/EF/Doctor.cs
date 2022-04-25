using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Doctor
    {
        public Doctor() { }

        public int DocId { get; set; }
        public int UserId { get; set; }

    }
}
