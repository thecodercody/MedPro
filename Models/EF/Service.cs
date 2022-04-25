using System;
using System.Collections.Generic;

namespace MedPro.Models.EF
{
    public partial class Service
    {
        public Service()
        {
            
        }

        public int SId { get; set; }
        public string? SName { get; set; }
        public int TimeNeeded { get; set; }


    }
}
