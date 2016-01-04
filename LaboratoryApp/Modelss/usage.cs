using System;
using System.Collections.Generic;

namespace LaboratoryApp.Models
{
    public partial class usage
    {
        public usage()
        {
            this.model_of_gauges = new List<model_of_gauges>();
        }

        public int usageId { get; set; }
        public string description { get; set; }
        public virtual ICollection<model_of_gauges> model_of_gauges { get; set; }
    }
}
