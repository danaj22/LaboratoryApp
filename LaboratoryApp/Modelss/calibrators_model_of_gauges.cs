using System;
using System.Collections.Generic;

namespace LaboratoryApp.Models
{
    public partial class calibrators_model_of_gauges
    {
        public int calibrator_modelId { get; set; }
        public Nullable<int> calibrator_id { get; set; }
        public Nullable<int> model_of_gaug_id { get; set; }
        public virtual calibrator calibrator { get; set; }
        public virtual model_of_gauges model_of_gauges { get; set; }
    }
}
