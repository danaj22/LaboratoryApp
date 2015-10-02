using LaboratoryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowCalibrator:ObservableObject
    {

        public NewWindowCalibrator()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);

        }

        private ObservableCollection<calibrator> collectionOfCalibrators;

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

            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }

        private string nameOfCalibrator;

        public string NameOfCalibrator
        {
            get { return nameOfCalibrator; }
            set
            {
                nameOfCalibrator = value;
                OnPropertyChanged("NameOfCalibrator");
            }
        }
    }
}
