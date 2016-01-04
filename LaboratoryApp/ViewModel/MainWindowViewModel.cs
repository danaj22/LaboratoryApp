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
        private NewWindowMailing messageWindowMailing;

        public NewWindowMailing MessageWindowMailing
        {
            get { return messageWindowMailing; }
            set { messageWindowMailing = value; OnPropertyChanged("MessageWindowMailing"); }
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
        #endregion

        static public void LoadView()
        {
            data = new LoadData(rootElement);
        }
        private string certPath;

        public string CertPath
        {
            get { return certPath; }
            set {
                certPath = value;
                OnPropertyChanged("CertPath");
            }
        }

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
            ChangePathCommand = new SimpleRelayCommand(ChangePath);
            MailingCommand = new SimpleRelayCommand(Mailing);
            EditGaugeCommand = new SimpleRelayCommand(EditGauge);
            CurrentViewModel = null;
            userInput = new UserInput();
            LoadView();
            System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp");

            if (!File.Exists(path))
            {
                File.Create(path);
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


        }
        #endregion


        private void Mailing()
        {
            MessageWindowMailing = new NewWindowMailing();
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

        
        private void Search()
        {
            gauge gg = new gauge();
            try
            {
                if (SearchItem != null && SearchItem != "")
                {
                    if (IsCheckedSerial)
                    {
                        var tmp = (from g in Context.gauges where g.serial_number.Contains(SearchItem) select g).FirstOrDefault();

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


                                        g.IsSelected = true;
                                        g.IsExpanded = true;
                                    }
                                }
                                foreach(var gaugeInClient in cli.Children)
                                {
                                    if(tmp.office == null)
                                    {
                                        if (gaugeInClient.NameOfItem == tmp.model_of_gauges.model + " [" + tmp.serial_number + "]")
                                        {
                                            gaugeInClient.IsSelected = true;
                                        }
                                    }
                                    else
                                    {
                                        foreach(var gaugeInOffice in gaugeInClient.Children)
                                        {
                                            if (gaugeInOffice.NameOfItem == tmp.model_of_gauges.model + " [" + tmp.serial_number + "]")
                                            {
                                                gaugeInOffice.IsSelected = true;
                                            }
                                        }
                                    }
                                    
                                }
                            }
                        }
                       
                        SelectedNode = tmp;

                    }
                    else if (IsCheckedNip)
                    {
                        foreach (client cli in RootElement.Children)
                        {
                            if (cli.NIP.Contains( SearchItem))
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
                            if (cli.name.ToUpper().Contains(SearchItem.ToUpper()))
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
                if (!String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.ManufacturerName)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.Model)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage)
                    && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType)
                    )
                {
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
                        System.Windows.MessageBox.Show("Nie udało się dodać modelu miernika.");
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
                                    //calib_gauge_model.calibrator = zmienna;
                                    calib_gauge_model.calibrator_id = zmienna.calibratorId;

                                    model_of_gauges model = (from m in Context.model_of_gauges orderby m.model_of_gaugeId descending select m).First();

                                    calib_gauge_model.model_of_gauges = model;
                                    calib_gauge_model.model_of_gaug_id = model.model_of_gaugeId;



                                    Context.calibrators_model_of_gauges.Add(calib_gauge_model);
                                    Context.SaveChanges();

                                }
                                catch (Exception e)
                                {
                                    System.Windows.MessageBox.Show("Nie udało się dodać kalibratora do modelu miernika.");
                                    File.AppendAllText(path,e.ToString());
                                }
                            }
                            //newGauge.calibrator_model_of_gauge.Add(zmienna);
                        }
                        foreach(function zmienna in MessageWindowModelOfGauge.CollectionOfCheckedFunction)
                        {
                            try
                            {
                                //System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model");
                                if(zmienna.IsChecked)
                                {
                                    model_of_gauges_functions mod_of_gaug_fun = new model_of_gauges_functions();
                                    mod_of_gaug_fun.function_Id = zmienna.functionId;
                                    model_of_gauges model = (from m in Context.model_of_gauges orderby m.model_of_gaugeId descending select m).First();

                                    mod_of_gaug_fun.model_of_gauges = model;
                                    mod_of_gaug_fun.model_of_gauge_id = model.model_of_gaugeId;

                                    Context.model_of_gauges_functions.Add(mod_of_gaug_fun);
                                    Context.SaveChanges();

                                    //File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt", zmienna.functionId + "\n");

                                    zmienna.IsChecked = false;
                                }
                            }
                            catch(Exception e)
                            {
                                File.AppendAllText(path, e.ToString());
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
                        {
                            Context.clients.Add(newClient);
                            Context.SaveChanges();
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

        private NewWindowEditGauge messageWindowEditGauge;
    }
}
