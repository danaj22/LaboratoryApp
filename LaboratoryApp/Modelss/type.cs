using System;
using System.Collections.Generic;

namespace LaboratoryApp.Models
{
    public partial class type
    {
        public type()
        {
            this.model_of_gauges = new List<model_of_gauges>();
        }

        public int typeId { get; set; }
        public string name { get; set; }
        public virtual ICollection<model_of_gauges> model_of_gauges { get; set; }
    }
}
