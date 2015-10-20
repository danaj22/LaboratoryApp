using LaboratoryApp.View;
using LaboratoryApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Data.Entity;
using System.IO;
using LaboratoryApp.Models;
//using System.Windows;
//using System.Windows.Input;
//todelet 2 lib^^
namespace LaboratoryApp.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {


        public static LaboratoryEntities Context = new LaboratoryEntities();
        private ObservableCollection<string> listOfUsers = new ObservableCollection<string>();

        public ObservableCollection<string> ListOfUsers
        {
            get { return listOfUsers; }
            set
            {
                listOfUsers = value;
                OnPropertyChanged("ListOfUsers");
            }
        }

        public static string nameAndSurname;

        public string NameAndSurname
        {
            get { return nameAndSurname; }
            set
            {
                nameAndSurname = value;
                OnPropertyChanged("NameAndSurname");
            }
        }

        public static string temperature;

        public string Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        static private LoadData data;

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

        static public MenuItem rootElement = new MenuItem();

        //static public List<client> ListOfClient = new List<client>();

        public MenuItem RootElement
        {
            get { return rootElement; }
            set
            {
                rootElement = value;
                OnPropertyChanged("RootElement");
            }
        }

        static public ObservableCollection<client> allItems = new ObservableCollection<client>();

        public ObservableCollection<client> AllItems
        {
            get { return allItems; }
            set
            {
                allItems = value;
                OnPropertyChanged("AllItems");
            }
        }

        static public MenuItem selectedNode = new MenuItem();

        public MenuItem SelectedNode
        {
            get { return selectedNode; }
            set
            {
                selectedNode = value;

                if ((SelectedNode as client) != null)
                {
                    CurrentViewModel = new InformationAboutClient(SelectedNode);
                }

                if ((SelectedNode as office) != null)
                {
                    office selectedOffice = SelectedNode as office;
                    CurrentViewModel = new InformationAboutOffice(SelectedNode);
                }
                if ((SelectedNode as gauge) != null)
                {
                    gauge selectedGauge = SelectedNode as gauge;
                    CurrentViewModel = new InformationAboutGauge(SelectedNode);

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

        static public void LoadView()
        {
            data = new LoadData(rootElement);
        }

        public static StreamWriter FileLog;
        static public string path = @"C:\ProgramData\DASLSystems\LaboratoryApp\LaboratoryAppLog.txt";
        static public string usersApplication = @"C:\ProgramData\DASLSystems\LaboratoryApp\users.txt";

        public MainWindowViewModel()
        {

            //TaskCommand = new SimpleRelayCommand(TaskCom);
            Title = "Laboratorium";
            AddNewClientCommand = new SimpleRelayCommand(AddClient);
            AddNewGaugeCommand = new SimpleRelayCommand(AddGauge);
            AddNewMeasureCommand = new SimpleRelayCommand(AddNewMeasure);
            CurrentViewModel = null;
            userInput = new UserInput();
            LoadView();
            System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp");

            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {

                // Create a file to write to. 
                using (FileLog = File.CreateText(path))
                {
                    
                }
            }
            if (!File.Exists(usersApplication))
            {
                File.Create(usersApplication);
            }
            try
            {
                string[] s = File.ReadAllLines(usersApplication);
                foreach (string str in s)
                {
                    ListOfUsers.Add(str);
                }
            }
            catch(Exception e)
            {
                File.AppendAllText(path, e.ToString());
            }

        }

        private bool isCheckedName;
        public bool IsCheckedName
        {
            get { return isCheckedName; }
            set
            {
                isCheckedName = value;
                OnPropertyChanged("IsCheckedName");
            }
        }

        private bool isCheckedNip;
        public bool IsCheckedNip
        {
            get { return isCheckedNip; }
            set
            {
                isCheckedNip = value;
                OnPropertyChanged("IsCheckedNip");
            }
        }
        private bool isCheckedSerial = true;
        public bool IsCheckedSerial
        {
            get { return isCheckedSerial; }
            set
            {
                isCheckedSerial = value;
                OnPropertyChanged("IsCheckedSerial");
            }
        }
        public string SearchItem { get; set; }
        public ICommand LoadContent { get; set; }
        public ICommand SearchCommand
        {
            get { return new SimpleRelayCommand(Search); }
        }
        private ICommand addNewMeasureCommand;

        public ICommand AddNewMeasureCommand
        {
            get { return addNewMeasureCommand; }
            set 
            { 
                addNewMeasureCommand = value;
                OnPropertyChanged("AddNewMeasureCommand");
            }
        }
        private void AddNewMeasure()
        {
            MessageWindowUser = new NewWindowUser();
            MessageWindowUser.IsOpen = true;

            if (MessageWindowUser.ToConfirm)
            {
                File.AppendAllText(usersApplication, "\n");
                File.AppendAllText(usersApplication, MessageWindowUser.NameOfUser);

                ListOfUsers.Add(MessageWindowUser.NameOfUser);

            }
        }

        
        private void Search()
        {
            try
            {

                if (SearchItem != null && SearchItem != "")
                {
                    if (IsCheckedSerial)
                    {
                        var tmp = (from g in Context.gauges where g.serial_number == SearchItem select g).FirstOrDefault();

                        foreach (client cli in RootElement.Children)
                        {
                            if (tmp.client.name == cli.name)
                            {
                                cli.IsExpanded = true;
                                foreach (gauge g in tmp.client.gauges)
                                {
                                    if (g.serial_number == SearchItem)
                                    {
                                        if (g.office != null)
                                        {
                                            g.office.IsExpanded = true;
                                        }
                                        int i = cli.Children.IndexOf((MenuItem)g);
                                        g.IsSelected = true;
                                        g.IsExpanded = true;
                                    }
                                }
                            }
                             
                        }
                       
                        //}
                        //tmp.IsExpanded = true;
                        //tmp.IsSelected = true;
                        SelectedNode = tmp;

                    }
                    else if (IsCheckedNip)
                    {
                        foreach (client cli in RootElement.Children)
                        {
                            if (cli.NIP == SearchItem)
                            {

                                cli.IsSelected = true;
                            }

                        }
                        //tmp.IsSelected = true;


                    }
                    else if (IsCheckedName)
                    {
                        foreach (client cli in RootElement.Children)
                        {
                            if (cli.name.ToUpper() == SearchItem.ToUpper())
                            {

                                cli.IsSelected = true;
                            }

                        }
                        //tmp.IsExpanded = true;

                        //tmp.IsSelected = true;
                        //SelectedNode.NameOfItem = "ttttttttttttttttttt";
                        //SelectedNode.IsExpanded = true;
                        // SelectedNode = tmp;
                    }
                }
                else
                { 
                    MessageBox.Show("Nie znaleziono wyników."); 
                }

                //var tmp = (from searchedGauge in Context.model_of_gauges
                //           where SearchItem == searchedGauge.gaugeId
                //           select new { searchedGauge. }).ToList();

                //trzeba dopisać wyszukiwanie
            }
            catch (Exception e)
            {
                MessageBox.Show("Nie znaleziono wyników.");
                File.AppendAllText(path, e.ToString());
            }

        }
        private bool CanSearch()
        {
            return true;
        }

        /// <summary>
        /// command to show modal window where we can add new ModelOfGaugeItem
        /// </summary>
        /// 
        private ICommand addNewGaugeCommand;
        public ICommand AddNewGaugeCommand
        {

            get
            {
                return addNewGaugeCommand;
            }
            set
            {
                addNewGaugeCommand = value;
                OnPropertyChanged("AddNewGaugeCommand");
            }
        }

        private void AddGauge()
        {
            MessageWindowModelOfGauge = new NewWindowModelOfGauge { AboutModelOfGauge = new InformationAboutModelOfGauge() };

            MessageWindowModelOfGauge.IsOpen = true;

            if (MessageWindowModelOfGauge.ToConfirm)
            {
                if (!String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.ManufacturerName)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.Model)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType)
                    )
                {
                    model_of_gauges newGauge = new model_of_gauges();
                    newGauge.manufacturer_name = MessageWindowModelOfGauge.AboutModelOfGauge.ManufacturerName;
                    newGauge.model = MessageWindowModelOfGauge.AboutModelOfGauge.Model;
                    

                    try
                    {
                        {
                            {
                                newGauge.type = (from t in Context.types where t.name == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType select t).FirstOrDefault();
                                newGauge.usage = (from u in Context.usages where u.description == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage select u).FirstOrDefault();
                                newGauge.type_id = (from t in Context.types where t.name == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType select t.typeId).FirstOrDefault();
                                newGauge.usage_id = (from u in Context.usages where u.description == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage select u.usageId).FirstOrDefault();

                                var listOfCheckedItems = MessageWindowModelOfGauge.CollectionOfCalibrators.ToList();
                                //newGauge.calibrators_model_of_gauges = (Models.calibrators_model_of_gauges)listOfCheckedItems;
                                
                                Context.model_of_gauges.Add(newGauge);
                                Context.SaveChanges();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Nie udało się dodać modelu miernika.");
                        File.AppendAllText(path, e.ToString());
                    }
                    try
                    {

                        int LastModelId = (from m in Context.model_of_gauges orderby m.model_of_gaugeId descending select m.model_of_gaugeId).First();

                        foreach (calibrator zmienna in MessageWindowModelOfGauge.CollectionOfCalibrators)
                        {
                            if (zmienna.IsChecked)
                            {
                                try
                                {

                                    calibrators_model_of_gauges calib_gauge_model = new calibrators_model_of_gauges();
                                    calib_gauge_model.calibrator = zmienna;
                                    calib_gauge_model.calibrator_id = zmienna.calibratorId;

                                    model_of_gauges model = (from m in Context.model_of_gauges orderby m.model_of_gaugeId descending select m).First();

                                    calib_gauge_model.model_of_gauges = model;
                                    calib_gauge_model.model_of_gaug_id = model.model_of_gaugeId;



                                    Context.calibrators_model_of_gauges.Add(calib_gauge_model);
                                    Context.SaveChanges();

                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Nie udało się dodać kalibratora do modelu miernika.");
                                    File.AppendAllText(path,e.ToString());
                                }
                            }
                            //newGauge.calibrator_model_of_gauge.Add(zmienna);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd");
                        FileLog.WriteLine(ex.ToString());
                    }
                }

            }
            MessageWindowModelOfGauge.ToConfirm = false;

        }
        /// <summary>
        /// command to show modal window where we can add new Client
        /// </summary>
        /// 
        private ICommand addNewClientCommand;
        public ICommand AddNewClientCommand
        {

            get
            {
                return addNewClientCommand;
            }
            set
            {
                addNewClientCommand = value;
                OnPropertyChanged("AddNewClientCommand");
            }
        }

        //public View.ModalWindowClient NClient = new View.ModalWindowClient();

        private bool? dialogResultValue;

        public bool? DialogResultValue
        {
            get { return dialogResultValue; }
            set
            {
                dialogResultValue = value;
                OnPropertyChanged("DialogResultValue");
            }
        }


        private DialogWindowBase dialogWindow;
        public DialogWindowBase DialogWindow
        {
            get { return dialogWindow; }
            set
            {
                dialogWindow = value;
                OnPropertyChanged("DialogWindow");
            }
        }



        private void AddClient()
        {
            MessageWindowClient = new NewWindowClient { AboutClient = new client() };
            MessageWindowClient.IsOpen = true;

            if (MessageWindowClient.ToConfirm)
            {
                if (MessageWindowClient.AboutClient.name != null && MessageWindowClient.AboutClient.NIP != null)
                {

                    client newClient = new client();
                    newClient.name = MessageWindowClient.AboutClient.name;
                    newClient.adress = MessageWindowClient.AboutClient.adress;
                    newClient.mail = MessageWindowClient.AboutClient.mail;
                    newClient.tel = MessageWindowClient.AboutClient.tel;
                    newClient.NIP = MessageWindowClient.AboutClient.NIP;
                    newClient.contact_person_name = MessageWindowClient.AboutClient.contact_person_name;
                    newClient.comments = MessageWindowClient.AboutClient.comments;


                    try
                    {
                        {
                            Context.clients.Add(newClient);
                            MessageBox.Show("Dodanie użytkownika.");
                            Context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nie udało się dodać klienta do bazy.");
                        MessageBox.Show(ex.ToString());
                        File.AppendAllText(@"",ex.ToString());
                    }

                    //var index = RootElement.Items.IndexOf(RootElement.Items.Last())+1;
                    //AllItems.Remove((client)SelectedNode);
                    //Add new client to TreeView
                    RootElement.Children.Add(newClient);
                    RootElement.Children.Last().NameOfItem = newClient.name;

                    MessageBox.Show("dodanie użytkownika do bazy");

                }

            }
            MessageWindowClient.ToConfirm = false;


           

        }

        private NewWindowModelOfGauge messageWindowModelOfGauge;
        public NewWindowModelOfGauge MessageWindowModelOfGauge
        {
            get { return messageWindowModelOfGauge; }
            set
            {
                messageWindowModelOfGauge = value;
                base.OnPropertyChanged("MessageWindowModelOfGauge");
            }
        }
        private NewWindowUser messageWindowUser;

        public NewWindowUser MessageWindowUser
        {
            get { return messageWindowUser; }
            set
            {
                messageWindowUser = value;
                base.OnPropertyChanged("MessageWindowUser");
            }
        }


        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                base.OnPropertyChanged("TitleOfItem");
            }
        }

        private NewWindowClient messageWindowClient;

        public NewWindowClient MessageWindowClient
        {
            get { return messageWindowClient; }
            set
            {

                messageWindowClient = value;
                base.OnPropertyChanged("MessageWindowClient");
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                base.OnPropertyChanged("Status");
            }
        }
    }
}
