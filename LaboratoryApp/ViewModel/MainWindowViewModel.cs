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
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Windows;
//using System.Windows.Input;
//todelet 2 lib^^
namespace LaboratoryApp.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {

        #region fields
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
        private ICommand editMeasureCommand;
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
        private ICommand mailingCommand;

        public ICommand MailingCommand
        {
            get { return mailingCommand; }
            set { mailingCommand = value; }
        }
        public ICommand AddValuesToTable11Command { get; set; }

        //public static LaboratoryEntities Context = new LaboratoryEntities();
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
        Stream stream;
        BinaryFormatter bformatter = new BinaryFormatter();

        public static string nameAndSurname;

        public string NameAndSurname
        {
            get { return nameAndSurname; }
            set
            {
                nameAndSurname = value;
                OnPropertyChanged("NameAndSurname");

                Settings.SelectedUser = nameAndSurname;
                if (File.Exists(settingsPath))
                {
                    stream = File.Open(settingsPath, FileMode.OpenOrCreate);
                    bformatter.Serialize(stream, Settings);
                    stream.Close();
                }

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
        private NewWindowMailing messageWindowMailing;

        public NewWindowMailing MessageWindowMailing
        {
            get { return messageWindowMailing; }
            set { messageWindowMailing = value; OnPropertyChanged("MessageWindowMailing"); }
        }

        private ObservableCollection<string> collectionOfFilters;

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

        private ValuesToTable11 newWindowValuesToTable11;
        public ValuesToTable11 NewWindowValuesToTable11
        {
            get { return newWindowValuesToTable11; }
            set
            {
                newWindowValuesToTable11 = value;
                this.OnPropertyChanged("NewWindowValuesToTable11");
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
        public static bool isStampPrint;
        #endregion

        static public void LoadView()
        {
            data = new LoadData(rootElement);
        }

        public static Settings Settings = new Settings();
        static public string settingsPath = @"C:\ProgramData\DASLSystems\LaboratoryApp\settings.stg";
        private string certPath;
        public string CertPath
        {
            get { return certPath; }
            set {
                certPath = value;
                OnPropertyChanged("CertPath");
            }
        }
        private string selectedFilter;

        public static StreamWriter FileLog;
        static public string path = @"C:\ProgramData\DASLSystems\LaboratoryApp\LaboratoryAppLog.txt";
        static public string usersApplication = @"C:\ProgramData\DASLSystems\LaboratoryApp\users.txt";
        static public string certificatesPath = @"C:\ProgramData\DASLSystems\LaboratoryApp\cert.txt";

        #region constructor

        public MainWindowViewModel()
        {

            //TaskCommand = new SimpleRelayCommand(TaskCom);
            Title = "Laboratorium";
            AddNewClientCommand = new SimpleRelayCommand(AddClient);
            AddNewGaugeCommand = new SimpleRelayCommand(AddGauge);
            AddNewMeasureCommand = new SimpleRelayCommand(AddNewMeasure);
            EditMeasureCommand = new SimpleRelayCommand(EditMeasure);
            ChangePathCommand = new SimpleRelayCommand(ChangePath);
            MailingCommand = new SimpleRelayCommand(Mailing);
            EditGaugeCommand = new SimpleRelayCommand(EditGauge);
            AddValuesToTable11Command = new SimpleRelayCommand(AddValuesToTable11);
            CurrentViewModel = null;
            userInput = new UserInput();
            LoadView();

            CollectionOfFilters = new ObservableCollection<string>();
            CollectionOfFilters.Add("nr seryjny");
            CollectionOfFilters.Add("NIP");
            CollectionOfFilters.Add("Nazwa klienta");
            CollectionOfFilters.Add("model");

            SelectedFilter = CollectionOfFilters[0];

            System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp");


            if(!File.Exists(settingsPath))
            {
                using (File.Create(settingsPath)) { }
            }
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
                
            }

            if (!File.Exists(usersApplication))
            {
                File.Create(usersApplication);
            }
            if (!File.Exists(certificatesPath))
            {
                File.Create(certificatesPath);
            }

            string line;

            try
            {
                string[] s = File.ReadAllLines(usersApplication);
                
                foreach (string str in s)
                {
                    line = str;
                    if(str.Contains("PATH"))
                    {
                        int index = str.IndexOf("PATH");
                        line = str.Substring(0, index);
                    }
                    ListOfUsers.Add(line);
                }
            }
            catch(Exception e)
            {
                File.AppendAllText(path, e.ToString());
            }

            try
            {
                string[] s = File.ReadAllLines(certificatesPath);
                CertPath = s[0];
            }
            catch(Exception e)
            {
                File.AppendAllText(path, e.ToString());
            }

           

            try
            {
                if (File.Exists(settingsPath))
                {

                    using (stream = File.Open(settingsPath, FileMode.Open))
                    {
                        if (stream.Length != 0)
                        {
                            stream.Position = 0;
                            Settings = (Settings)bformatter.Deserialize(stream);

                            stream.Close();

                            NameAndSurname = Settings.SelectedUser;
                            IsStampPrint = Settings.IsStampPrint;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(path, e.ToString());
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }


        }
        #endregion


        private void AddValuesToTable11()
        {
            NewWindowValuesToTable11 = new ValuesToTable11();

            //tworzy plik z zapisanymi danymi z tabeli z głównego okna
            //aktualizowane wyniki są wstawiane do tabeli 11
            if (!File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\Val.Values11"))
            {
                for (int i = 0; i < 15; i++)
                {
                    NewWindowValuesToTable11.CollectionOfValuesToTable11.Add(new ResistanceImpedanceReactance());
                }
                NewWindowValuesToTable11.CollectionOfValuesToTable11[9].IdealValueTab11Rezystancja = "xxxx";
                NewWindowValuesToTable11.CollectionOfValuesToTable11[10].IdealValueTab11Rezystancja = "xxxx";
                NewWindowValuesToTable11.CollectionOfValuesToTable11[11].IdealValueTab11Rezystancja = "xxxx";
                NewWindowValuesToTable11.CollectionOfValuesToTable11[12].IdealValueTab11Rezystancja = "xxxx";
                NewWindowValuesToTable11.CollectionOfValuesToTable11[9].IdealValueTab11Reaktancja = "xxxx";
                NewWindowValuesToTable11.CollectionOfValuesToTable11[10].IdealValueTab11Reaktancja = "xxxx";
                NewWindowValuesToTable11.CollectionOfValuesToTable11[11].IdealValueTab11Reaktancja = "xxxx";
                NewWindowValuesToTable11.CollectionOfValuesToTable11[12].IdealValueTab11Reaktancja = "xxxx";
            }
            NewWindowValuesToTable11.IsOpen = true;
            if(NewWindowValuesToTable11.ToConfirm)
            {
                Stream stream;
                BinaryFormatter bformatter = new BinaryFormatter();

                
                {
                    stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\Val.Values11", FileMode.Create);

                    bformatter.Serialize(stream, NewWindowValuesToTable11.CollectionOfValuesToTable11);

                    stream.Close();
                }
            }
        }

        private void EditMeasure()
        {
            MessageWindowUser = new NewWindowUser();
            MessageWindowUser.NameOfUser = nameAndSurname;
            MessageWindowUser.IsOpen = true;

            if (MessageWindowUser.ToConfirm)
            {
                string[] users = File.ReadAllLines(usersApplication);
                List <string> temporaryUsers = new List<string>();
                if (users != null)
                {
                    foreach (string user in users)
                    {
                        if(!user.Contains(nameAndSurname))
                        {
                            temporaryUsers.Add(user);
                        }
                    }
                }
                File.WriteAllLines(usersApplication, temporaryUsers.ToArray());

                File.AppendAllText(usersApplication, MessageWindowUser.NameOfUser);

                if (!string.IsNullOrEmpty(MessageWindowUser.PathOfStamp))
                {
                    File.AppendAllText(usersApplication, "PATH=");
                    File.AppendAllText(usersApplication, MessageWindowUser.PathOfStamp);
                }
                File.AppendAllText(usersApplication, "\n");

                ListOfUsers.Remove(nameAndSurname);
                ListOfUsers.Add(MessageWindowUser.NameOfUser);

            }
        }
        private void Mailing()
        {
            MessageWindowMailing = new NewWindowMailing() { MailPath = Settings.PathToMailing };
            MessageWindowMailing.IsOpen = true;
            if(MessageWindowMailing.ToConfirm)
            {

            }
        }
        
        private void AddNewMeasure()
        {
            MessageWindowUser = new NewWindowUser();
            MessageWindowUser.IsOpen = true;

            if (MessageWindowUser.ToConfirm)
            {
                
                File.AppendAllText(usersApplication, MessageWindowUser.NameOfUser);
                
                if (!string.IsNullOrEmpty(MessageWindowUser.PathOfStamp))
                {
                    File.AppendAllText(usersApplication, "PATH=");
                    File.AppendAllText(usersApplication, MessageWindowUser.PathOfStamp);
                }
                File.AppendAllText(usersApplication, "\n");

                ListOfUsers.Add(MessageWindowUser.NameOfUser);

            }
        }
        private List<MenuItem> SearchingItemsList = new List<MenuItem>();
        private List<MenuItem> SearchingItemsListName = new List<MenuItem>();
        private string previousSearchItem;
        
        private void Search()
        {

            try
            {
                if(previousSearchItem != SearchItem)
                {
                    SearchingItemsList = new List<MenuItem>();
                    SearchingItemsListName = new List<MenuItem>();
                }
                if (SearchItem != null && SearchItem != "")
                {
                    previousSearchItem = SearchItem;

                    if (SelectedFilter == "nr seryjny")
                    {
                        if (!SearchingItemsList.Any() || SearchingItemsList.Last() is client)
                        {
                            using (LaboratoryEntities context = new LaboratoryEntities())
                            {
                                var tmp2 = (from g in context.gauges where g.serial_number.Contains(SearchItem) select g).ToList();
                                if (tmp2.Count() == 0)
                                {
                                    System.Windows.MessageBox.Show("Brak elementów.");
                                    return;
                                }

                                else
                                {
                                    SearchingItemsList = new List<MenuItem>();
                                    foreach (gauge gaug in tmp2)
                                    {
                                        SearchingItemsList.Add(gaug);
                                    }

                                    gauge g2 = new gauge();
                                    gauge g = (gauge)SearchingItemsList.Last();
                                    client c = new client();
                                    office o = new office();


                                    foreach (client cli in RootElement.Children)
                                    {
                                        if (cli.clientId == g.client_id)
                                        {
                                            c = cli;
                                        }
                                    }

                                    c.IsExpanded = true;

                                    if (g.office != null)
                                    {
                                        o = c.offices.Where(x => x.officeId == g.office_id).First();
                                        o.IsExpanded = true;
                                        g2 = (gauge)o.gauges.Where(x => x.serial_number == g.serial_number);
                                    }
                                    else
                                    {
                                        g2 = c.gauges.Where(x => x.serial_number == g.serial_number).First();
                                        g2.Parent.IsExpanded = true;
                                        g2.IsSelected = true;
                                    }

                                    SelectedNode = g2;

                                    SearchingItemsList.Remove(SearchingItemsList.Last());

                                }
                            }
                        }
                        else if(SearchingItemsList.Count()>0)
                        {
                            gauge g2 = new gauge();
                            gauge g = (gauge) SearchingItemsList.Last();
                            client c = new client();
                            office o = new office();
                            

                            foreach(client cli in RootElement.Children)
                            {
                                if(cli.clientId == g.client_id)
                                {
                                    c = cli;
                                }
                            }

                            c.IsExpanded = true;

                            if (g.office != null)
                            {
                                o = c.offices.Where(x => x.officeId == g.office_id).First();
                                o.IsExpanded = true;
                                g2 = (gauge)o.gauges.Where(x => x.serial_number == g.serial_number);
                            }
                            else
                            {
                                g2 = c.gauges.Where(x => x.serial_number == g.serial_number).First();
                                g2.IsSelected = true;
                            }

                            SelectedNode = g2;

                            SearchingItemsList.Remove(SearchingItemsList.Last());

                        }


                    }
                    else if (SelectedFilter =="NIP")
                    {
                        if (!SearchingItemsList.Any() || SearchingItemsList.Last() is gauge)
                        {
                            SearchingItemsList = new List<MenuItem>();
                            foreach (client cli in RootElement.Children)
                            {
                                if (cli.NIP.ToUpper().Contains(SearchItem.ToUpper()))
                                {
                                    SearchingItemsList.Add(cli);
                                }
                            }
                            if (SearchingItemsList.Count() > 0)
                            {
                                client c = new client();
                                c = (client) SearchingItemsList.Last();
                                c.IsSelected = true;
                                SelectedNode = c;
                                SearchingItemsList.Remove(SearchingItemsList.Last());
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Brak wyników.");
                            }

                        }
                        else if (SearchingItemsList.Count()>0)
                        {
                            client c = new client();
                            c = (client) SearchingItemsList.Last();

                            c.IsSelected = true;
                            SelectedNode = c;

                            SearchingItemsList.Remove(SearchingItemsList.Last());

                        }
                    }

                    else if (SelectedFilter == "Nazwa klienta")
                    {
                        if (!SearchingItemsListName.Any())
                        {
                            SearchingItemsListName = new List<MenuItem>();

                            foreach (client cli in RootElement.Children)
                            {
                                if (cli.name.ToUpper().Contains(SearchItem.ToUpper()))
                                {
                                    SearchingItemsListName.Add(cli);
                                }
                            }
                            if (SearchingItemsListName.Count() > 0)
                            {
                                client c = new client();
                                c = (client)SearchingItemsListName.Last();
                                c.IsSelected = true;
                                SelectedNode = c;
                                SearchingItemsListName.Remove(SearchingItemsListName.Last());
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Brak wyników.");
                            }
                        }
                        else if (SearchingItemsListName.Count() > 0)
                        {
                            client c = new client();
                            c = (client)SearchingItemsListName.Last();

                            c.IsSelected = true;
                            SelectedNode = c;

                            SearchingItemsListName.Remove(SearchingItemsListName.Last());

                        }
                    }
                    else if (SelectedFilter == "model")
                    {
                        if (!SearchingItemsListName.Any())
                        {
                            SearchingItemsListName = new List<MenuItem>();

                           foreach (client cli in RootElement.Children)
                            {
                                foreach(gauge gaug in cli.gauges)
                                {
                                    if(gaug.model_of_gauges.model.ToUpper().Contains(SearchItem.ToUpper()))
                                    {
                                        SearchingItemsListName.Add(gaug);
                                    }
                                }
                            }
                            if (SearchingItemsListName.Count() > 0)
                            {
                                gauge c = new gauge();
                                c = (gauge)SearchingItemsListName.Last();
                                c.Parent.IsExpanded = true;
                                c.IsSelected = true;
                                SelectedNode = c;
                                SearchingItemsListName.Remove(SearchingItemsListName.Last());
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Brak wyników.");
                            }
                        }
                        else if (SearchingItemsListName.Count() > 0)
                        {
                            gauge c = new gauge();
                            c = (gauge)SearchingItemsListName.Last();

                            c.IsSelected = true;
                            SelectedNode = c;

                            SearchingItemsListName.Remove(SearchingItemsListName.Last());

                        }
                    }
                }
                else
                { 
                    System.Windows.MessageBox.Show("Nie znaleziono wyników."); 
                }

                //var tmp = (from searchedGauge in Context.model_of_gauges
                //           where SearchItem == searchedGauge.gaugeId
                //           select new { searchedGauge. }).ToList();

                //trzeba dopisać wyszukiwanie
            }
            catch (Exception e)
            {
                File.AppendAllText(path, e.ToString());
            }

        }
        private bool CanSearch()
        {
            return true;
        }

        private ICommand changePathCommand;
        public ICommand ChangePathCommand
        {
            get { return changePathCommand; }
            set
            {
                changePathCommand = value;
                OnPropertyChanged("ChangePathCommand");
            }
        }
        private void ChangePath()
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(certificatesPath, String.Empty);
                File.AppendAllText(certificatesPath,folderBrowserDialog1.SelectedPath);

                CertPath = folderBrowserDialog1.SelectedPath;
            }
        }
        /// <summary>
        /// command to show modal window where we can add new ModelOfGaugeItem
        /// </summary>
        /// 
        private ICommand editGaugeCommand;
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
                if (!String.IsNullOrEmpty(MessageWindowModelOfGauge.SelectedManufacturer)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.Model)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType)
                    )
                {
                    MessageWindowModelOfGauge.SelectedManufacturer = MessageWindowModelOfGauge.SelectedManufacturer.First().ToString().ToUpper() + MessageWindowModelOfGauge.SelectedManufacturer.Substring(1);
                    System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp\models");

                    if (!File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\"+ MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt"))
                    {
                        foreach(CalibrationTable str in MessageWindowModelOfGauge.ListOfNamesOfTables)
                        {
                            if (str.IsChecked)
                            {
                                File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt",str.TypeOfWindow + "\t" + str.Name);
                                File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt", "\n");
                            }
                        }
                    }

                    //if (!File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + "$.txt"))
                    //{
                    //    //foreach(IEnumerableTable str in MessageWindowModelOfGauge.MessageWindowTable.ListOfWindows)
                    //    {
                    //            File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + "$.txt", str.ToString()+"$"+ str/*.NameOfFile*/);
                    //            File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + "$.txt", "\n");
                    //    }
                    //}
                    

                    model_of_gauges newGauge = new model_of_gauges();
                    newGauge.manufacturer_name = MessageWindowModelOfGauge.SelectedManufacturer;
                    newGauge.model = MessageWindowModelOfGauge.AboutModelOfGauge.Model;
                    

                    try
                    {
                        using (LaboratoryEntities context = new LaboratoryEntities())

                        { 
                            {
                                newGauge.type = (from t in context.types where t.name == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType select t).FirstOrDefault();
                                newGauge.usage = (from u in context.usages where u.description == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage select u).FirstOrDefault();
                                newGauge.type_id = (from t in context.types where t.name == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType select t.typeId).FirstOrDefault();
                                newGauge.usage_id = (from u in context.usages where u.description == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage select u.usageId).FirstOrDefault();

                                var listOfCheckedItems = MessageWindowModelOfGauge.CollectionOfCalibrators.ToList();
                                //newGauge.calibrators_model_of_gauges = (Models.calibrators_model_of_gauges)listOfCheckedItems;

                                context.model_of_gauges.Add(newGauge);
                                context.SaveChanges();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        System.Windows.MessageBox.Show("Nie udało się dodać modelu miernika.");
                        File.AppendAllText(path, e.ToString());
                    }
                    try
                    {
                        using (LaboratoryEntities context = new LaboratoryEntities())
                        {
                            int LastModelId = (from m in context.model_of_gauges orderby m.model_of_gaugeId descending select m.model_of_gaugeId).First();

                            foreach (calibrator zmienna in MessageWindowModelOfGauge.CollectionOfCalibrators)
                            {

                                if (zmienna.IsChecked)
                                {
                                    try
                                    {

                                        calibrators_model_of_gauges calib_gauge_model = new calibrators_model_of_gauges();
                                        //calib_gauge_model.calibrator = zmienna;
                                        calib_gauge_model.calibrator_id = zmienna.calibratorId;

                                        model_of_gauges model = (from m in context.model_of_gauges orderby m.model_of_gaugeId descending select m).First();

                                        calib_gauge_model.model_of_gauges = model;
                                        calib_gauge_model.model_of_gaug_id = model.model_of_gaugeId;



                                        context.calibrators_model_of_gauges.Add(calib_gauge_model);
                                        context.SaveChanges();

                                    }
                                    catch (Exception e)
                                    {
                                        System.Windows.MessageBox.Show("Nie udało się dodać kalibratora do modelu miernika.");
                                        File.AppendAllText(path, e.ToString());
                                    }
                                }
                                //newGauge.calibrator_model_of_gauge.Add(zmienna);
                            }
                        }
                        using (LaboratoryEntities context = new LaboratoryEntities())
                        {
                            foreach (function zmienna in MessageWindowModelOfGauge.CollectionOfCheckedFunction)
                            {
                                try
                                {
                                    //System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model");
                                    if (zmienna.IsChecked)
                                    {
                                        model_of_gauges_functions mod_of_gaug_fun = new model_of_gauges_functions();
                                        mod_of_gaug_fun.function_Id = zmienna.functionId;
                                        model_of_gauges model = (from m in context.model_of_gauges orderby m.model_of_gaugeId descending select m).First();

                                        mod_of_gaug_fun.model_of_gauges = model;
                                        mod_of_gaug_fun.model_of_gauge_id = model.model_of_gaugeId;

                                        context.model_of_gauges_functions.Add(mod_of_gaug_fun);
                                        context.SaveChanges();

                                        //File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt", zmienna.functionId + "\n");

                                        zmienna.IsChecked = false;
                                    }
                                }
                                catch (Exception e)
                                {
                                    File.AppendAllText(path, e.ToString());
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(path,ex.ToString());
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
                        using(LaboratoryEntities context = new LaboratoryEntities())
                        {
                            context.clients.Add(newClient);
                            context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Nie udało się dodać klienta do bazy.");
                        File.AppendAllText(@"",ex.ToString());
                    }

                    //var index = RootElement.Items.IndexOf(RootElement.Items.Last())+1;
                    //AllItems.Remove((client)SelectedNode);
                    //Add new client to TreeView
                    newClient.IsSelected = true;
                    SelectedNode = newClient;
                    RootElement.Children.Add(newClient);
                    RootElement.Children.Last().NameOfItem = newClient.name;

                    RootElement.Children = new ObservableCollection<MenuItem>(RootElement.Children.OrderBy(i => i.NameOfItem));
                    System.Windows.MessageBox.Show("dodanie użytkownika do bazy");

                }

            }
            MessageWindowClient.ToConfirm = false;


           

        }
        private void EditGauge()
        {
            MessageWindowEditGauge = new NewWindowEditGauge();
            MessageWindowEditGauge.IsOpen = true;

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

        public ICommand EditGaugeCommand
        {
            get
            {
                return editGaugeCommand;
            }

            set
            {
                editGaugeCommand = value;
            }
        }

        public NewWindowEditGauge MessageWindowEditGauge
        {
            get
            {
                return messageWindowEditGauge;
            }

            set
            {
                messageWindowEditGauge = value;
                OnPropertyChanged("MessageWindowEditGauge");
            }
        }

        public ICommand EditMeasureCommand
        {
            get
            {
                return editMeasureCommand;
            }

            set
            {
                editMeasureCommand = value;
                OnPropertyChanged("EditMeasureCommand");
            }
        }

        public bool IsStampPrint
        {
            get
            {
                return isStampPrint;
            }

            set
            {
                isStampPrint = value;
                OnPropertyChanged("IsStampPrint");

                Settings.IsStampPrint = isStampPrint;
                if (File.Exists(settingsPath))
                {
                    stream = File.Open(settingsPath, FileMode.OpenOrCreate);
                    bformatter.Serialize(stream, Settings);
                    stream.Close();
                }


            }
        }

        public ObservableCollection<string> CollectionOfFilters
        {
            get
            {
                return collectionOfFilters;
            }

            set
            {
                collectionOfFilters = value;
                OnPropertyChanged("CollectionOfFilters");
            }
        }

        public string SelectedFilter
        {
            get
            {
                return selectedFilter;
            }

            set
            {
                selectedFilter = value;
                OnPropertyChanged("SelctedFilter");
            }
        }

        private NewWindowEditGauge messageWindowEditGauge;
    }
}
