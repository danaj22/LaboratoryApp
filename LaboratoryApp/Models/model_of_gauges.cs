namespace LaboratoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class model_of_gauges
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public model_of_gauges()
        {
            calibrators_model_of_gauges = new ObservableCollection<calibrators_model_of_gauges>();
            gauges = new ObservableCollection<gauge>();
            model_of_gauges_functions = new ObservableCollection<model_of_gauges_functions>();
        }

        [Key]
        public int model_of_gaugeId { get; set; }

        [Required]
        [StringLength(50)]
        public string manufacturer_name { get; set; }

        [Required]
        [StringLength(50)]
        public string model { get; set; }

        public int usage_id { get; set; }

        public int type_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<calibrators_model_of_gauges> calibrators_model_of_gauges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<gauge> gauges { get; set; }

        public virtual type type { get; set; }

        public virtual usage usage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<model_of_gauges_functions> model_of_gauges_functions { get; set; }
    }
}
