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
    
    [Table("usage")]
    public partial class Usage
    {
        public Usage()
        {
            this.gauges = new ObservableCollection<Gauge>();
        }
    
        public int usageId { get; set; }
        public string description { get; set; }
    
        public virtual ObservableCollection<Gauge> gauges { get; set; }
    }
}
