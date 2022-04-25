using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Patient
    {
        public Patient() { }

        public int PId { get; set; }
        public int UserId { get; set; }
    }
}
