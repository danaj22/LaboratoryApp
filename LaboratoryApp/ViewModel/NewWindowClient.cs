using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.ViewModel;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowClient: OpenNewWindow
    {
        protected string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string NIP { get; set; }
        public string Comment { get; set; }

        public override void Confirm()
        {
            laboratoryEntities context = new laboratoryEntities();
            if(Name!=null && Address!=null && ContactPerson != null && Email != null && Telephone != null && NIP != null && Comment != null)
            {
                client NewClient = new client();
                NewClient.name = Name;
                NewClient.adress = Address;
                NewClient.contact_person_name = ContactPerson;
                NewClient.mail = Email;
                NewClient.tel = Telephone;
                NewClient.NIP = NIP;
                NewClient.comments = Comment;

                context.clients.Add(NewClient);
                context.SaveChanges();
            }
        }
        public override void Cancel()
        {
            
        }
    }
}
