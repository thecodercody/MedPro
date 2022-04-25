using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Time
    {
        public Time()
        {
      
        }

        public int TimeId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

    }
}
