using System;
using System.Collections.Generic;
namespace LaboratoryApp.Models
{
    public partial class calibrators_functions
    {
        
        public int calibrator_functionId { get; set; }
        public Nullable<int> calibrator_id { get; set; }
        public Nullable<int> function_id { get; set; }
        public virtual calibrator calibrator { get; set; }
        public virtual function function { get; set; }
    }
}
