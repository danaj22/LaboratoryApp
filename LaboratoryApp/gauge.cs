//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaboratoryApp
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public partial class gauge : ViewModel.MenuItem
    {
        public gauge()
        
        {
        }

        public int gaugeId { get; set; }
        public int serial_number { get; set; }
        public int client_id { get; set; }
        public Nullable<int> office_id { get; set; }
        public int model_of_gauge_id { get; set; }
    
        public virtual client client { get; set; }
        public virtual model_of_gauges model_of_gauges { get; set; }
        public virtual office office { get; set; }

       

        protected override string nameOfItem
        {
            get
            {
                return base.nameOfItem;
            }
            set
            {
                base.nameOfItem = value;
                OnPropertyChanged("nameOfItem");
            }
        }
        protected override ObservableCollection<ViewModel.MenuItem> children
        {
            get
            {
                return base.children;
            }
            set
            {
                base.children = value;
                OnPropertyChanged("children");
            }
        }


        
    }
}
