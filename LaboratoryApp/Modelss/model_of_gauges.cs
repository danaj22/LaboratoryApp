using System;
using System.Collections.Generic;

namespace LaboratoryApp.Models
{
    public partial class model_of_gauges
    {
        public model_of_gauges()
        {
            this.calibrators_model_of_gauges = new List<calibrators_model_of_gauges>();
            this.gauges = new List<gauge>();
        }

        public int model_of_gaugeId { get; set; }
        public string manufacturer_name { get; set; }
        public string model { get; set; }
        public int usage_id { get; set; }
        public int type_id { get; set; }
        public virtual ICollection<calibrators_model_of_gauges> calibrators_model_of_gauges { get; set; }
        public virtual ICollection<gauge> gauges { get; set; }
        public virtual type type { get; set; }
        public virtual usage usage { get; set; }
    }
}
