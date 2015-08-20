﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.View;
using System.Windows.Input;
using LaboratoryApp;
using System.Windows;
using System.Collections.ObjectModel;

namespace LaboratoryApp.ViewModel
{
    public class InformationAboutModelOfGauge : ObservableObject
    {
        public InformationAboutModelOfGauge()
        {
            this.Products = new ObservableCollection<gauge>();
            InitializeCollectionOfUsage();
            InitializeCollectionOfType();
        }

        private void InitializeCollectionOfType()
        {
            LaboratoryEntities context = new LaboratoryEntities();
            CollectionOfType = (from t in context.types select t.name).Distinct().ToList();
            SelectedType = CollectionOfType[0];
        }

        private void InitializeCollectionOfUsage()
        {
            LaboratoryEntities context = new LaboratoryEntities();
            //var t = (from u in context.usages select u.description).Count();
            List<usage> t = (from u in context.usages select u).ToList();

            foreach(var element in t)
            {
                CollectionOfUsage.Add(element.description);
            }
                //(from u in context.usages select u.usageId.ToString()).Distinct().ToList();
            SelectedUsage = t[0].description;
        }

        private int modelOfGaugeId;

        public int ModelOfGaugeId
        {
            get { return modelOfGaugeId; }
            set 
            {
                modelOfGaugeId = value;
                OnPropertyChanged("ModelOfGaugeId");
            }
        }

        private string manufacturerName;
        public string ManufacturerName
        {
            get { return manufacturerName; }
            set 
            { 
                manufacturerName = value;
                OnPropertyChanged("ManufacturerName");
            }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set 
            { 
                model = value;
                OnPropertyChanged("Model");
            }
        }

        private int usageId;
        public int UsageId
        {
            get { return usageId; }
            set 
            {
                usageId = value;
                OnPropertyChanged("UsageId");
            }
        }

        private int typeId;
        public int TypeId
        {
            get { return typeId; }
            set 
            { 
                typeId = value;
                OnPropertyChanged("TypeId");
            }
        }

        private type typeOfGauge;
        public type TypeOfGauge
        {
            get { return typeOfGauge; }
            set 
            {
                typeOfGauge = value;
                OnPropertyChanged("TypeOfGauge");
            }
        }


        private ObservableCollection<gauge> gauges;
        public ObservableCollection<gauge> Products
        {
            get { return gauges; }
            set 
            {
                gauges = value;
                OnPropertyChanged("Products");
            }
        }

        private usage usageOfGauge;
        public usage UsageOfGauge
        {
            get { return usageOfGauge; }
            set
            {
                usageOfGauge = value;
                OnPropertyChanged("UsageOfGauge");
            }
        }


        private List<string> collectionOfusage = new List<string>();
        public List<string> CollectionOfUsage
        {
            get { return collectionOfusage; }
            set
            {
                collectionOfusage = CollectionOfUsage;
                OnPropertyChanged("CollectionOfUsage");
            }
        }

        private string selectedUsage;
        public string SelectedUsage
        {
            get { return selectedUsage; }
            set
            {
                selectedUsage = value;
                OnPropertyChanged("SelectedUsage");
            }
        }

        private List<string> collectionOfType = new List<string>();
        public List<string> CollectionOfType
        {
            get { return collectionOfType; }
            set 
            {
                collectionOfType = value;
                OnPropertyChanged("CollectionOfType");
            }
        }

        private string selectedType;
        public string SelectedType
        {
            get { return selectedType; }
            set
            { 
                selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }


        public ICommand DeleteCommand
        { get { return new SimpleRelayCommand(DeleteGaugeExecute); } }

        private void DeleteGaugeExecute()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten miernik?", "aaaaa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                LaboratoryEntities context = new LaboratoryEntities();
                //delete selected client
                var gaugeToDelete = (from g in context.gauges
                                      where g.gaugeId == this.ModelOfGaugeId
                                      select g).FirstOrDefault();

                context.gauges.Remove(gaugeToDelete);
                context.SaveChanges();
                MainWindowViewModel.LoadView();
            }
        }

        public ICommand EditCommand
        { get { return new SimpleRelayCommand(EditGaugeExecute); } }

        private void EditGaugeExecute()
        {
            //create a new modal window

            //if (newModal.DialogResult == true)
            //{
            //    using (LaboratoryEntities context = new LaboratoryEntities())
            //    {
            //        var gaugeToEdit = (from g in context.gauges
            //                            where g.gaugeId == this.ModelOfGaugeId
            //                            select g).FirstOrDefault();

            //        if (ManufacturerName != "" && Address != "" && ContactPerson != "" && Email != "" && Telephone != "" && NIP != "" && Comment != "")
            //        {
            //            gaugeToEdit.name = Name;
            //            gaugeToEdit.adress = Address;
            //            gaugeToEdit.contact_person_name = ContactPerson;
            //            gaugeToEdit.mail = Email;
            //            gaugeToEdit.tel = Telephone;
            //            gaugeToEdit.NIP = NIP;
            //            gaugeToEdit.comments = Comment;

            //            context.SaveChanges();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Wypełnij wszystkie pola");
            //        }

            //    }
            //}
            MainWindowViewModel.LoadView();

        }
        
    }
}
