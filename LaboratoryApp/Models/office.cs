using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LaboratoryApp.Models
{
    public partial class office : ViewModel.MenuItem
    {
        public office()
        {
            this.gauges = new ObservableCollection<gauge>();
        }
        [Key]
        public int officeId { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public string contact_person_name { get; set; }
        public string mail { get; set; }
        public string tel { get; set; }
        public string is_default { get; set; }
        public int client_id { get; set; }

        public virtual client client { get; set; }
        public virtual ObservableCollection<gauge> gauges { get; set; }

        protected override string displayImagePath
        {
            get
            {
                return @"office-building-icon.png";
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
        //    get { return isExpanded; }
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
