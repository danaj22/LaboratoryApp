using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.ViewModel;
using System.Windows.Input;
using System.Windows;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowClient :ObservableObject//:DialogWindowBase
    {
        

        //public View.ModalWindowClient MWindow;

        private InformationAboutClient aboutClient;

        public InformationAboutClient AboutClient
        {
            get { return aboutClient; }
            set 
            { 
                aboutClient = value;
                OnPropertyChanged("AboutClient");
            }
        }
        //public View.ModalWindowClient MWindow;
        public NewWindowClient()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
        }

        public NewWindowClient(View.ModalWindowClient window)// : base(window)
        {
        //    //LaboratoryEntities context = new LaboratoryEntities();
        //    //MWindow = window;
        //    //MWindow.infoClient = AboutClient = new InformationAboutClient();

        //    //AboutModelOfGauge = new InformationAboutModelOfGauge();
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
            if (this.AboutClient.Name != null
                && this.AboutClient.Address != null
                && this.AboutClient.Email != null
                && this.AboutClient.Telephone != null
                && this.AboutClient.NIP != null
                && this.AboutClient.ContactPerson != null)

            {

                client newClient = new client();
                newClient.name = this.AboutClient.Name;
                newClient.adress = this.AboutClient.Address;
                newClient.mail = this.AboutClient.Email;
                newClient.tel = this.AboutClient.Telephone;
                newClient.NIP = this.AboutClient.NIP;
                newClient.contact_person_name = this.AboutClient.ContactPerson;
                newClient.comments = this.AboutClient.Comment;

                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    context.clients.Add(newClient);
                    context.SaveChanges();
                }
                IsOpen = false;

            }
            IsOpen = false;
 
        }
        public void Close()
        {
            IsOpen = false;
        }

        
    }
}
