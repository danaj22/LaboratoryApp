using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowModelOfGauge : ObservableObject

    {
        private InformationAboutModelOfGauge aboutModelOfGauge;

        public InformationAboutModelOfGauge AboutModelOfGauge
        {
            get { return aboutModelOfGauge; }
            set 
            { 
                aboutModelOfGauge = value;
                OnPropertyChanged("AboutModelOfGauge");
            }
        }

        private NewWindowType messageWindowType;

        public NewWindowType MessageWindowType
        {
            get { return messageWindowType; }
            set 
            { 
                messageWindowType = value;
                OnPropertyChanged("MessageWindowType");
            }
        }
        private NewWindowUsage messageWindowUsage;

        public NewWindowUsage MessageWindowUsage
        {
            get { return messageWindowUsage; }
            set 
            { 
                messageWindowUsage = value;
                OnPropertyChanged("MessageWindowUsage");
            }
        }
       
        public NewWindowModelOfGauge()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            AddUsageCommand = new SimpleRelayCommand(AddUsage);
            AddTypeCommand = new SimpleRelayCommand(AddType);
        }

        public NewWindowModelOfGauge(Window window) //: base (window)
        {
            //LaboratoryEntities context = new LaboratoryEntities();
            //MWindow = window;
            //MWindow.infoGauge = AboutModelOfGauge = new InformationAboutModelOfGauge();

            //foreach(var tmp in context.usages)
            //{

            //    AboutModelOfGauge.CollectionOfUsage.Add(tmp);
            //}
            //AboutModelOfGauge = new InformationAboutModelOfGauge();
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
                base.OnPropertyChanged("CancelCommand");
            }
        }

        private ICommand addUsageCommand;
        public ICommand AddUsageCommand
        {
            get { return addUsageCommand; }
            set 
            { 
                addUsageCommand = value;
                base.OnPropertyChanged("AddUsageCommand");
            }
        }

        private ICommand addTypeCommand;
        public ICommand AddTypeCommand
        {
            get { return addTypeCommand; }
            set 
            {
                addTypeCommand = value;
                base.OnPropertyChanged("AddTypeCommand");
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
            if (!ToConfirm) ToConfirm = true;
            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }
        public void AddType()
        {
            MessageWindowType = new NewWindowType();
            MessageWindowType.IsOpen = true;
        }
        public void AddUsage()
        {
            MessageWindowUsage = new NewWindowUsage();
            MessageWindowUsage.IsOpen = true;
        }

    }
}
