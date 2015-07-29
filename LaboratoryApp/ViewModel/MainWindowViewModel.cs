﻿using LaboratoryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp
{
    public class MainWindowViewModel : ObservableObject
    {
        
        
        private LoadData data;

        public LoadData Data
        {
            get { return data; }
            set 
            { 
                data = value;
                OnPropertyChanged("Data");
            }
        }
        
        private UserInput userInput;

        public UserInput UserInput
        {
            get { return userInput; }
            set { userInput = value; }
        }

        private ObservableCollection<client> allItems = new ObservableCollection<client>();

        public ObservableCollection<client> AllItems
        {
            get { return allItems; }
            set { allItems = value; }
        }

        private object selectedNode = 0;

        public object SelectedNode
        {
            get { return selectedNode; }
            set
            {
                selectedNode = value;

                if ((SelectedNode as client) != null)
                {
                    client selectedClient = selectedNode as client;
                    CurrentViewModel = new InformationAboutClient(new View.InformationAboutClientView 
                                                                    { Name = selectedClient.name, 
                                                                      Address = selectedClient.adress, 
                                                                      NIP = selectedClient.NIP, 
                                                                      Telephone = selectedClient.tel,
                                                                      ContactPerson = selectedClient.contact_person_name,
                                                                      Comment = selectedClient.comments,
                                                                      Email = selectedClient.mail});
                }
                if((SelectedNode as office)!=null)
                {
                    office selectedOffice = selectedNode as office;
                    CurrentViewModel = new InformationAboutOffice(new View.InformationAboutOfficeView 
                                                                    { Name = selectedOffice.name,
                                                                      Address = selectedOffice.adress,
                                                                      Telephone = selectedOffice.tel,
                                                                      ContactPerson = selectedOffice.contact_person_name,
                                                                      Email = selectedOffice.mail});
                }
                if ((SelectedNode as gauge) != null)
                {
                    gauge selectedGauge = selectedNode as gauge;
                    CurrentViewModel = new InformationAboutGauge(new View.InformationAboutGaugeView 
                                                                    { ModelName = selectedGauge.model,
                                                                      ManufacturerName = selectedGauge.manufacturer_name,
                                                                      SerialNumber = selectedGauge.serial_number });
                }
                OnPropertyChanged("SelectedNode");
            }
        }

        private ObservableObject currentViewModel;

        public ObservableObject CurrentViewModel
        {
            get { return currentViewModel; }
            set 
            {
                currentViewModel = value;
                this.OnPropertyChanged("CurrentViewModel");
            }
        }
      
        private void LoadView()
        {
            
            data = new LoadData(AllItems);
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = null;
            userInput = new UserInput();
            LoadView();
           
        }
       
        public int SearchItem { get; set; }
        public ICommand LoadContent { get; set; }
        public ICommand SearchCommand 
        {
            get { return new SimpleRelayCommand(SearchGauge); }
        }
        private void SearchGauge()
        {
            laboratoryEntities context = new laboratoryEntities();

            var tmp = (from searchedGauge in context.gauges
                       where SearchItem == searchedGauge.serial_number
                       select new { searchedGauge.model }).ToList();

            //trzeba dopisać wyszukiwanie
            
        }
        private bool CanSearchGauge()
        {
            return true; 
        }

        public ICommand AddNewClientCommand
        {
            get
            {
                return new SimpleRelayCommand(AddClient);
            }
        }

        //public View.ModalWindowAddClient NClient = new View.ModalWindowAddClient();
        
        private void changeResult(View.ModalWindowAddClient cli)
        {
            cli.DialogResult = true;
        }

        public View.ModalWindowAddClient newModal;
        private void AddClient()
        {
            //newModal = new View.ModalWindowAddClient();
            View.ModalWindowAddClient newModal = new View.ModalWindowAddClient();
            newModal.Owner = Application.Current.MainWindow;
           
            newModal.ShowDialog();

            if (newModal.DialogResult == true)
            {
                MessageBox.Show(newModal.DialogResult.ToString());
            }
            //OpenNewWindow NewWindow = new OpenNewWindow() { MWindow = newModal };
            
            //newModal.ShowDialog();

            
            //OpenedWindow.CancelDialog();

            //if (NClient.DialogResult == true)
            //{
            //    //some tests....
            //}
            //else
            //{
            //    System.Windows.MessageBox.Show(NClient.DialogResult.ToString());
            //    //something when cancel was clicked...
            //}

            //ViewModel.OpenNewWindow NewWindow = new OpenNewWindow();

            //if (NClient.ShowDialog() == true)
            //    System.Windows.MessageBox.Show(NClient.ShowDialog().ToString());

            //DialogResult = NClient.DialogResult;
            //if (DialogResult == false)
            //   NClient.Close();
        }

        private bool CanAddClient()
        { 
            return true; 
        }

        public bool? DialogResult
        { get; set; }
   
    }
}
