using System;
using System.Collections.Generic;

namespace LaboratoryApp.Models
{
    public partial class certificate
    {
        public int certifacateId { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<float> cost { get; set; }
        public string authorized_by { get; set; }
        public int gauge_id { get; set; }
        public virtual gauge gauge { get; set; }
    }
}
