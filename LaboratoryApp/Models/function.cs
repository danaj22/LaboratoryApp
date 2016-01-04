namespace LaboratoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class function
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public function()
        {
            model_of_gauges_functions = new ObservableCollection<model_of_gauges_functions>();
        }

        public int functionId { get; set; }

        [StringLength(150)]
        public string name { get; set; }

        public bool IsChecked { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<model_of_gauges_functions> model_of_gauges_functions { get; set; }
    }
}
