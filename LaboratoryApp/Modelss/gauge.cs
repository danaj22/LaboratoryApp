using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LaboratoryApp.Models
{
    public partial class gauge : ViewModel.MenuItem
    {
        public gauge()
        {
            this.certificates = new ObservableCollection<certificate>();
        }
        [Key]
        public int gaugeId { get; set; }
        public string serial_number { get; set; }
        public int client_id { get; set; }
        public Nullable<int> office_id { get; set; }
        public int model_of_gauge_id { get; set; }

        public virtual client client { get; set; }
        public virtual model_of_gauges model_of_gauges { get; set; }
        public virtual ObservableCollection<certificate> certificates { get; set; }
        public virtual office office { get; set; }

        protected override string displayImagePath
        {
            get
            {
                return @"Computer-2-icon.png";
            }
        }
        //private bool isSelected;
        //public bool IsSelected
        //{
        //    get { return isSelected; }
        //    set
        //    {
        //        if (value != isSelected)
        //        {
        //            isSelected = value;
        //            this.OnPropertyChanged("IsSelected");
        //        }
        //    }
        //}

        //private bool isExpanded;
        //public bool IsExpanded
        //{
        //    get { return true; }
        //    set
        //    {
        //        if (value != isExpanded)
        //        {
        //            isExpanded = value;
        //            OnPropertyChanged("IsExpanded");
        //        }
        //    }
        //}
    }
}
