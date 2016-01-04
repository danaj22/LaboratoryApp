namespace LaboratoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class gauge : ViewModel.MenuItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gauge()
        {
            certificates = new ObservableCollection<certificate>();
        }

        public int gaugeId { get; set; }

        [Required]
        [StringLength(100)]
        public string serial_number { get; set; }

        public int client_id { get; set; }

        public int? office_id { get; set; }

        public int model_of_gauge_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<certificate> certificates { get; set; }

        public virtual client client { get; set; }

        public virtual model_of_gauges model_of_gauges { get; set; }

        public virtual office office { get; set; }
        protected override string displayImagePath
        {
            get
            {
                return @"Computer-2-icon.png";
            }
        }
    }
}
