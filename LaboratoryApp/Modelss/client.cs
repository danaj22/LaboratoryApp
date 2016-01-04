using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LaboratoryApp.Models
{
    public partial class client:ViewModel.MenuItem
    {
        public client()
        {
            this.gauges = new ObservableCollection<gauge>();
            this.offices = new ObservableCollection<office>();
        }
        [Key]
        public int clientId { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public string contact_person_name { get; set; }
        public string mail { get; set; }
        public string tel { get; set; }
        public string NIP { get; set; }
        public string comments { get; set; }

        public virtual ObservableCollection<gauge> gauges { get; set; }
        public virtual ObservableCollection<office> offices { get; set; }

        protected override string displayImagePath
        {
            get
            {
                return @"Office-Customer-Male-Light-icon.png";
            }
        }

        //protected override bool isSelected;
        //public override bool IsSelected
        //{
        //    get;
        //    set;
        //    //get { return isSelected; }
        //    //set
        //    //{
        //    //    if (value != isSelected)
        //    //    {
        //    //        isSelected = value;
        //    //        this.OnPropertyChanged("IsSelected");
        //    //    }
        //    //}
        //}

        ////private bool isExpanded;
        //public override bool IsExpanded
        //{
        //    get;
        //    set;
        //    //get { return isExpanded; }
        //    //set
        //    //{
        //    //    if (value != isExpanded)
        //    //    {
        //    //        isExpanded = value;
        //    //        OnPropertyChanged("IsExpanded");
        //    //    }
        //    //}
        //}
    }
}
