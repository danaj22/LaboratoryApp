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
    
    [Table ("certificates")]
    public partial class Certificate
    {
        public int certifacateId { get; set; }
        public string name { get; set; }
        public System.DateTime date { get; set; }
        public float cost { get; set; }
        public string authorized_by { get; set; }
    }
}
