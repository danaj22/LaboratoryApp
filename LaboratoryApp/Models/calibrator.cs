using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LaboratoryApp.Models
{
    public partial class calibrator : ViewModel.ObservableObject
    {
        public calibrator()
        {
            this.calibrators_model_of_gauges = new ObservableCollection<calibrators_model_of_gauges>();
            this.calibrators_functions = new ObservableCollection<calibrators_functions>();
        }

        public int calibratorId { get; set; }
        public string name { get; set; }
        public Nullable<int> model_of_gauge_id { get; set; }
        public Nullable<int> function_id { get; set; }
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

        public virtual ObservableCollection<calibrators_model_of_gauges> calibrators_model_of_gauges { get; set; }
        public virtual ObservableCollection<calibrators_functions> calibrators_functions { get; set; }
    }
}
