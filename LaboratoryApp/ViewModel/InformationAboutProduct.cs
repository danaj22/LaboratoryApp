using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboratoryApp.ViewModel
{
    public class InformationAboutProduct : ObservableObject
    {
        public int ProductId { get; set; }
        public int SerialNumber { get; set; }
        public Nullable<int> client_id { get; set; }
        public Nullable<int> office_id { get; set; }
        public Nullable<int> gauge_id { get; set; }

        public virtual gauge Gauge { get; set; }
        public virtual office Office { get; set; }

        public InformationAboutProduct()
        { }
    }
}
