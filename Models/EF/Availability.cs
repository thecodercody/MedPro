using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Availability
    {
        public int AvailId { get; set; }
        public int DocId { get; set; }
        public int TimeId { get; set; }

    }
}
