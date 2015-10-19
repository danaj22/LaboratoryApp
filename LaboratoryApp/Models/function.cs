using System;
using System.Collections.Generic;

namespace LaboratoryApp.Models
{
    public partial class function : ViewModel.ObservableObject
    {
        public int functionId { get; set; }
        public string name { get; set; }
        public virtual ICollection<calibrator> calibrators { get; set; }
        
        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public virtual ICollection<calibrators_functions> calibrators_functions { get; set; }
        
        public function()
        {
            this.calibrators_functions = new List<calibrators_functions>();
            this.calibrators = new List<calibrator>();
        }
            
    }
}
