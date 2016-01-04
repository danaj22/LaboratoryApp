namespace LaboratoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class model_of_gauges_functions
    {
        [Key]
        public int model_of_gauge_functionId { get; set; }

        public int? function_Id { get; set; }

        public int? model_of_gauge_id { get; set; }

        public virtual function function { get; set; }

        public virtual model_of_gauges model_of_gauges { get; set; }
    }
}
