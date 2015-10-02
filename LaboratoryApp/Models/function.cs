using System;
using System.Collections.Generic;

namespace LaboratoryApp.Models
{
    public partial class function : ViewModel.ObservableObject
    {
        public int functionId { get; set; }
        public string name { get; set; }

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
    }
}
