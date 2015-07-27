using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.View;

namespace LaboratoryApp
{
    class InformationAboutOffice: ObservableObject
    {
        public InformationAboutOffice(InformationAboutOfficeView model)
        {
            this.Model = model;
        }
        public InformationAboutOfficeView Model { get; set; }

        public string Name { 
            get 
            {
                return this.Model.Name;
            } 
            set 
            {
                this.Model.Name = value;
                this.OnPropertyChanged("Name");
            } 
        }
        public string Address
        {
            get
            {
                return this.Model.Address;
            }
            set
            {
                this.Model.Address = value;
                this.OnPropertyChanged("Address");
            }
        }
        public string ContactPerson
        {
            get
            {
                return this.Model.ContactPerson;
            }
            set
            {
                this.Model.ContactPerson = value;
                this.OnPropertyChanged("ContactPerson");
            }
        }
        public string Email
        {
            get
            {
                return this.Model.Email;
            }
            set
            {
                this.Model.Email = value;
                this.OnPropertyChanged("Email");
            }
        }
        public string Telephone
        {
            get
            {
                return this.Model.Telephone;
            }
            set
            {
                this.Model.Telephone = value;
                this.OnPropertyChanged("Telephone");
            }
        }
    }
}
