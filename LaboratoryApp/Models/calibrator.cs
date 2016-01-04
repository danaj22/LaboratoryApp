namespace LaboratoryApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class calibrator : ViewModel.ObservableObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public calibrator()
        {
            calibrators_model_of_gauges = new ObservableCollection<calibrators_model_of_gauges>();
        }
        public bool isChecked;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public int calibratorId { get; set; }

        [Required]
        [StringLength(300)]
        public string name { get; set; }

        public int? model_of_gauge_id { get; set; }

        public int? function_id { get; set; }
        

        public int? function_functionId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<calibrators_model_of_gauges> calibrators_model_of_gauges { get; set; }
    }
}
