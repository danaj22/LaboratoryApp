using LaboratoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowGauge : ObservableObject
    {
        //public View.ModalWindowProduct MWindow;
        private gauge aboutGauge;

        public gauge AboutGauge
        {
            get { return aboutGauge; }
            set 
            { 
                aboutGauge = value;
                OnPropertyChanged("AboutGauge");
            }
        }


        public NewWindowGauge()
        {
            //InitializeCollectionOfManufacturers();
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            InitializeCollectionOfManufacturers();
            
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
            if (!ToConfirm) ToConfirm = true;
            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }



        List<string> collectionOfManufacturers;
        public List<string> CollectionOfManufacturers
        {
            get { return this.collectionOfManufacturers; }
            set
            {
                collectionOfManufacturers = value;
                OnPropertyChanged("CollectionOfManufacturers");
            }

        }
        List<string> collectionOfModels;
        public List<string> CollectionOfModels
        {
            get { return collectionOfModels; }
            set
            {
                collectionOfModels = value;
                OnPropertyChanged("CollectionOfModels");
            }
        }

        private void InitializeCollectionOfManufacturers()
        {
            LaboratoryEntities context = new LaboratoryEntities();
            CollectionOfManufacturers = (from m in context.model_of_gauges select m.manufacturer_name).Distinct().ToList();
        }


        private string selectedManufacturer;
        public string SelectedManufacturer
        {
            get { return selectedManufacturer; }
            set
            {
                selectedManufacturer = value;
                InitializeCollectionOfModels();
                OnPropertyChanged("SelectedManufacturer");
            }
        }
        private string selectedModel;
        public string SelectedModel
        {
            get { return selectedModel; }
            set
            {
                selectedModel = value;
                OnPropertyChanged("SelectedModel");
            }

        }

        private void InitializeCollectionOfModels()
        {
            if (SelectedManufacturer != null)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    CollectionOfModels = (from g in context.model_of_gauges where g.manufacturer_name == SelectedManufacturer select g.model).ToList();

                }
            }
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
                if (isExpanded && AboutGauge.Parent != null)
                    this.IsExpanded = true;
            }
        }
    }


}
