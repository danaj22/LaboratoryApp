using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowOffice:OpenNewWindow
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public override void Confirm()
        {
            laboratoryEntities context = new laboratoryEntities();
            if (Name != null && Address != null && ContactPerson != null && Email != null && Telephone != null)
            {
                office NewOffice = new office();
                NewOffice.name = Name;
                NewOffice.adress = Address;
                NewOffice.contact_person_name = ContactPerson;
                NewOffice.mail = Email;
                NewOffice.tel = Telephone;

                context.offices.Add(NewOffice);
                context.SaveChanges();
            }
        }
        
        public override void Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
