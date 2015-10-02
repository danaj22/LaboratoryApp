using LaboratoryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowOffice : ObservableObject
    {
        private office aboutOffice;

        public office AboutOffice
        {
            get { return aboutOffice; }
            set 
            { 
                aboutOffice = value;
                OnPropertyChanged("AboutOffice");
            }
        }

        public NewWindowOffice()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
        }




        private ICommand okCommand;

        public ICommand OKCommand
        {
            get { return okCommand; }
            set
            {
                okCommand = value;
                base.OnPropertyChanged("OKCommand");
            }
        }
        private ICommand cancelCommand;

        public ICommand CancelCommand
        {
            get { return cancelCommand; }
            set
            {
                cancelCommand = value;
                OnPropertyChanged("CancelCommand");
            }
        }

        private bool isOpen;

        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                base.OnPropertyChanged("IsOpen");
            }
        }

        private bool toConfirm;

        public bool ToConfirm
        {
            get { return toConfirm; }
            set
            {
                toConfirm = value;
                base.OnPropertyChanged("ToConfirm");
            }
        }

        public void Confirm()
        {
            if (!this.ToConfirm) ToConfirm = true;
            //if (this.AboutOffice.Name != null
            //    && this.AboutOffice.Address != null
            //    && this.AboutOffice.Email != null
            //    && this.AboutOffice.Telephone != null
            //    && this.AboutOffice.ContactPerson != null)
            //{

            //    office newOffice = new office();
            //    newOffice.name = this.AboutOffice.Name;
            //    newOffice.adress = this.AboutOffice.Address;
            //    newOffice.mail = this.AboutOffice.Email;
            //    newOffice.tel = this.AboutOffice.Telephone;
            //    newOffice.contact_person_name = this.AboutOffice.ContactPerson;
                

            //    using (LaboratoryEntities context = new LaboratoryEntities())
            //    {
            //        context.offices.Add(newOffice);
            //        context.SaveChanges();
            //    }
            //}
            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != isSelected)
                {
                    isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                if (value != isExpanded)
                {
                    isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                if (isExpanded && AboutOffice.Parent != null)
                    this.IsExpanded = true;
            }
        }
       
    }
}
