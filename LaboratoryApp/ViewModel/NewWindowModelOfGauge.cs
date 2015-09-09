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

        private NewWindowCalibrator messageWindowCalibrator;

        public NewWindowCalibrator MessageWindowCalibrator
        {
            get { return messageWindowCalibrator; }
            set
            {
                messageWindowCalibrator = value;
                OnPropertyChanged("MessageWindowCalibrator");
            }
        }

        public void AddCalibrator()
        {
            MessageWindowCalibrator = new NewWindowCalibrator();
            MessageWindowCalibrator.IsOpen = true;

            if (MessageWindowCalibrator.ToConfirm)
            {
                if (!string.IsNullOrEmpty(MessageWindowCalibrator.NameOfCalibrator))
                {
                    using (LaboratoryEntities context = new LaboratoryEntities())
                    {
                        calibrator CalibratorToAdd = new calibrator();
                        CalibratorToAdd.name = MessageWindowCalibrator.NameOfCalibrator;

                        context.calibrators.Add(CalibratorToAdd);
                        context.SaveChanges();

                        CollectionOfCalibrators.Add(CalibratorToAdd);
                    }
                }
            }
            MessageWindowCalibrator.ToConfirm = false;
        }
        private ObservableCollection<calibrator> collectionOfCalibrators = new ObservableCollection<calibrator>();

        public ObservableCollection<calibrator> CollectionOfCalibrators
        {
            get { return collectionOfCalibrators; }
            set
            {
                collectionOfCalibrators = value;
                OnPropertyChanged("collectionOfCalibrators");
            }
        }

        private ICommand addCalibratorCommand;
        public ICommand AddCalibratorCommand
        {
            get { return addCalibratorCommand; }
            set
            {
                addCalibratorCommand = value;
                base.OnPropertyChanged("AddCalibratorCommand");
            }
        }


        public NewWindowModelOfGauge()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            AddUsageCommand = new SimpleRelayCommand(AddUsage);
            AddTypeCommand = new SimpleRelayCommand(AddType);
            AddCalibratorCommand = new SimpleRelayCommand(AddCalibrator);

            LaboratoryEntities context = MainWindowViewModel.Context;
            var ListOfCalibrators = (from c in context.calibrators select c).ToList();

            foreach (var item in ListOfCalibrators)
            {
                item.IsChecked = false;
                CollectionOfCalibrators.Add(item);
            }
        }

        public NewWindowModelOfGauge(Window window) //: base (window)
        {
            //LaboratoryEntities Context = new LaboratoryEntities();
            //MWindow = window;
            //MWindow.infoGauge = AboutModelOfGauge = new InformationAboutModelOfGauge();

            //foreach(var tmp in Context.usages)
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

            if (MessageWindowType.ToConfirm)
            {
                if (!string.IsNullOrEmpty(MessageWindowType.NameOfType))
                {
                    using (LaboratoryEntities context = new LaboratoryEntities())
                    {
                        type TypeToAdd = new type();
                        TypeToAdd.name = MessageWindowType.NameOfType;

                        context.types.Add(TypeToAdd);
                        context.SaveChanges();
                        AboutModelOfGauge.CollectionOfType.Add(TypeToAdd.name);
                    }
                }
                else
                {
                    MessageBox.Show("Nie wpisano typu.");
                }
            }
            MessageWindowType.ToConfirm = false;
        }
        public void AddUsage()
        {
            MessageWindowUsage = new NewWindowUsage();
            MessageWindowUsage.IsOpen = true;

            if (MessageWindowUsage.ToConfirm)
            {
                if (!string.IsNullOrEmpty(MessageWindowUsage.NameOfUsage))
                {

                    using (LaboratoryEntities context = new LaboratoryEntities())
                    {
                        usage UsageToAdd = new usage();
                        UsageToAdd.description = MessageWindowUsage.NameOfUsage;

                        context.usages.Add(UsageToAdd);
                        context.SaveChanges();
                        AboutModelOfGauge.CollectionOfUsage.Add(UsageToAdd.description);
                    }
                }
                else
                { MessageBox.Show("Nie wpisano zastosowania."); }
            }
            MessageWindowUsage.ToConfirm = false;


        }

    }
}
