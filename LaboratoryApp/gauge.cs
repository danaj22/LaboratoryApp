//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaboratoryApp
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("gauges")]
    public partial class Gauge
    {
        public int gaugeId { get; set; }
        public string manufacturer_name { get; set; }
        public string model { get; set; }
        public int serial_number { get; set; }
        public string checked_function { get; set; }
        public int usage_id { get; set; }
        public int client_id { get; set; }
        public int type_id { get; set; }
    
        public virtual Client client { get; set; }
        public virtual Type type { get; set; }
        public virtual Usage usage { get; set; }
    }
}
