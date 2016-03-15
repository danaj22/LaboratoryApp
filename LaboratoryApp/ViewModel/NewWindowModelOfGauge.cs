using LaboratoryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

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

        private NewWindowTable messageWindowTable;
        public NewWindowTable MessageWindowTable
        {
            get { return messageWindowTable; }
            set 
            {
                messageWindowTable = value;
                OnPropertyChanged("MessageWindowTable");
            }
        }
        
        private ObservableCollection<calibrator> collectionOfCalibrators;
        public ObservableCollection<calibrator> CollectionOfCalibrators
        {
            get { return collectionOfCalibrators; }
            set
            {
                collectionOfCalibrators = value;
                OnPropertyChanged("CollectionOfCalibrators");
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
                    try {
                        using (LaboratoryEntities context = new LaboratoryEntities())
                        {
                            calibrator CalibratorToAdd = new calibrator();
                            CalibratorToAdd.name = MessageWindowCalibrator.NameOfCalibrator;
                            CalibratorToAdd.isChecked = false;
                           
                            CollectionOfCalibrators.Add(CalibratorToAdd);
                            context.calibrators.Add(CalibratorToAdd);
                            context.SaveChanges();

                        }
                    }
                    catch(Exception e)
                    {
                        File.AppendAllText(MainWindowViewModel.path, e.ToString());
                    }
                }
            }
            MessageWindowCalibrator.ToConfirm = false;
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

        private ICommand addFunctionCommand;
        public ICommand AddFunctionCommand
        {
            get { return addFunctionCommand; }
            set
            {
                addFunctionCommand = value;
                base.OnPropertyChanged("AddFunctionCommand");
            }
        }

        private NewWindowFunction messageWindowFunction;
        public NewWindowFunction MessageWindowFunction
        {
            get { return messageWindowFunction; }
            set
            {
                messageWindowFunction = value;
                OnPropertyChanged("MessageWindowFunction");
            }
        }

        private ObservableCollection<function> collectionOfCheckedFunction;
        public ObservableCollection<function> CollectionOfCheckedFunction
        {
            get { return collectionOfCheckedFunction; }
            set
            {
                collectionOfCheckedFunction = value;
                OnPropertyChanged("CollectionOfCheckedFunction");
            }
        }
        private string checkedFunction;
        public string CheckedFunction
        {
            get { return checkedFunction; }
            set
            {
                checkedFunction = value;
                OnPropertyChanged("CheckedFunction");
            }
        }

        private ICommand editTableCommand;
        private CalibrationTable selectedTable;

        private ObservableCollection<CalibrationTable> listOfNamesOfTables = new ObservableCollection<CalibrationTable>();
        public ObservableCollection<CalibrationTable> ListOfNamesOfTables
        {
            get { return listOfNamesOfTables; }
            set 
            { 
                listOfNamesOfTables = value;
                OnPropertyChanged("ListOfNamesOfTables");
            }
        }

        public void AddFunction()
        {
            MessageWindowFunction = new NewWindowFunction();
            MessageWindowFunction.IsOpen = true;

            if (MessageWindowFunction.ToConfirm)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    function FunctionToAdd = new function();
                    FunctionToAdd.name = MessageWindowFunction.NameOfFunction;

                    context.functions.Add(FunctionToAdd);
                    context.SaveChanges();

                    CollectionOfCheckedFunction.Add(FunctionToAdd);
                }
            }
            MessageWindowFunction.ToConfirm = false;
        }

        ObservableCollection<string> collectionOfManufacturers;
        public ObservableCollection<string> CollectionOfManufacturers
        {
            get { return this.collectionOfManufacturers; }
            set
            {
                collectionOfManufacturers = value;
                OnPropertyChanged("CollectionOfManufacturers");
            }
        }
        private string selectedManufacturer;
        public string SelectedManufacturer
        {
            get { return selectedManufacturer; }
            set
            {
                selectedManufacturer = value;
                OnPropertyChanged("SelectedManufacturer");
            }
        }
        private NewWindowManufacturer messageWindowManufacturer;

        private void InitializeCollectionOfManufacturers()
        {
            using (LaboratoryEntities context = new LaboratoryEntities())
            {
                List<string> manufacturers = (from m in context.model_of_gauges select m.manufacturer_name).Distinct().ToList();

                CollectionOfManufacturers = new ObservableCollection<string>();
                foreach (string element in manufacturers)
                {
                    CollectionOfManufacturers.Add(element);
                }
            }

        }

        public ICommand AddManufacturerCommand { get; set; }
        
        public void AddManufacturer()
        {
            MessageWindowManufacturer = new NewWindowManufacturer();
            MessageWindowManufacturer.IsOpen = true;

            if(MessageWindowManufacturer.ToConfirm)
            {
                CollectionOfManufacturers.Add(MessageWindowManufacturer.NameOfManufacturer);
            }
        }



        public NewWindowModelOfGauge()
        {
            InitializeCollectionOfManufacturers();

            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            AddUsageCommand = new SimpleRelayCommand(AddUsage);
            AddTypeCommand = new SimpleRelayCommand(AddType);
            AddCalibratorCommand = new SimpleRelayCommand(AddCalibrator);
            AddFunctionCommand = new SimpleRelayCommand(AddFunction);
            AddTableCommand = new SimpleRelayCommand(AddTable);
            AddManufacturerCommand = new SimpleRelayCommand(AddManufacturer);

            EditTableCommand = new SimpleRelayCommand(EditTable);
            DeleteTableCommand = new SimpleRelayCommand(DeleteTable);


            CollectionOfCalibrators = new ObservableCollection<calibrator>();
            CollectionOfCheckedFunction = new ObservableCollection<function>();

            
                try
                {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    List<Models.calibrator> ListOfCalibrators = context.calibrators.ToList();

                    if (ListOfCalibrators.Count > 0)
                    {
                        CollectionOfCalibrators = new ObservableCollection<calibrator>();
                        foreach (Models.calibrator item in ListOfCalibrators)
                        {
                            item.IsChecked = false;
                            CollectionOfCalibrators.Add(item);
                        }
                    }

                    List<Models.function> ListOfFunctions = context.functions.ToList();

                    if (ListOfFunctions.Count > 0)
                    {
                        foreach (Models.function item in ListOfFunctions)
                        {
                            item.IsChecked = false;
                            CollectionOfCheckedFunction.Add(item);
                        }
                    }
                    context.SaveChanges();
                }

                    if (!File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt"))
                    {
                        File.Create(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt").Dispose();
                    }
                    else
                    {
                        string[] s = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt");

                        foreach (string str in s)
                        {
                            CalibrationTable newTable = new CalibrationTable();

                            int indexStart = str.IndexOf("\t");
                            //int indexEnd = str.IndexOf("|");
                            newTable.Name = str.Substring(indexStart + 1);
                            newTable.TypeOfWindow = str.Substring(0, indexStart);
                            ListOfNamesOfTables.Add(newTable);
                        }
                        ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));



                    }
                }
                catch (Exception e)
                {
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\LaboratoryAppLog.txt", e.ToString());
                }
            
            
        }

        public NewWindowModelOfGauge(Window window) //: base (window)
        {
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

        private ICommand addTableCommand;
        public ICommand AddTableCommand
        {
            get { return addTableCommand; }
            set
            {
                addTableCommand = value;
                base.OnPropertyChanged("AddTableCommand");
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

        public CalibrationTable SelectedTable
        {
            get
            {
                return selectedTable;
            }

            set
            {
                selectedTable = value;
                OnPropertyChanged("SelectedTable");
            }
        }
        private ICommand deleteTableCommand;

        public ICommand EditTableCommand
        {
            get
            {
                return editTableCommand;
            }

            set
            {
                editTableCommand = value;
                OnPropertyChanged("EditTableCommand");

            }
        }

        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public ICommand DeleteTableCommand
        {
            get
            {
                return deleteTableCommand;
            }

            set
            {
                deleteTableCommand = value;
                OnPropertyChanged("DeleteTableCommand");
            }
        }
        #region tables
        private NewWindowTable1 messageWindowTable1;
        public NewWindowTable1 MessageWindowTable1
        {
            get { return messageWindowTable1; }
            set
            {
                messageWindowTable1 = value;
                OnPropertyChanged("MessageWindowTable1");
            }
        }

        private NewWindowTable2 messageWindowTable2;
        public NewWindowTable2 MessageWindowTable2
        {
            get { return messageWindowTable2; }
            set
            {
                messageWindowTable2 = value;
                OnPropertyChanged("MessageWindowTable2");
            }
        }

        private NewWindowTable3 messageWindowTable3;
        public NewWindowTable3 MessageWindowTable3
        {
            get { return messageWindowTable3; }
            set
            {
                messageWindowTable3 = value;
                OnPropertyChanged("MessageWindowTable3");
            }
        }

        private NewWindowTable4 messageWindowTable4;
        public NewWindowTable4 MessageWindowTable4
        {
            get { return messageWindowTable4; }
            set
            {
                messageWindowTable4 = value;
                OnPropertyChanged("MessageWindowTable4");
            }
        }

        private NewWindowTable4a messageWindowTable4a;
        public NewWindowTable4a MessageWindowTable4a
        {
            get { return messageWindowTable4a; }
            set
            {
                messageWindowTable4a = value;
                OnPropertyChanged("MessageWindowTable4a");
            }
        }

        private NewWindowTable5 messageWindowTable5;
        public NewWindowTable5 MessageWindowTable5
        {
            get { return messageWindowTable5; }
            set
            {
                messageWindowTable5 = value;
                OnPropertyChanged("MessageWindowTable5");
            }
        }

        private NewWindowTable6 messageWindowTable6;
        public NewWindowTable6 MessageWindowTable6
        {
            get { return messageWindowTable6; }
            set
            {
                messageWindowTable6 = value;
                OnPropertyChanged("MessageWindowTable6");
            }
        }


        private NewWindowTable7 messageWindowTable7;
        public NewWindowTable7 MessageWindowTable7
        {
            get { return messageWindowTable7; }
            set
            {
                messageWindowTable7 = value;
                OnPropertyChanged("MessageWindowTable7");
            }
        }

        private NewWindowTable8 messageWindowTable8;
        public NewWindowTable8 MessageWindowTable8
        {
            get { return messageWindowTable8; }
            set
            {
                messageWindowTable8 = value;
                OnPropertyChanged("MessageWindowTable8");
            }
        }

        private NewWindowTable9 messageWindowTable9;
        public NewWindowTable9 MessageWindowTable9
        {
            get { return messageWindowTable9; }
            set
            {
                messageWindowTable9 = value;
                OnPropertyChanged("MessageWindowTable9");
            }
        }

        private NewWindowTable10 messageWindowTable10;
        public NewWindowTable10 MessageWindowTable10
        {
            get { return messageWindowTable10; }
            set
            {
                messageWindowTable10 = value;
                OnPropertyChanged("MessageWindowTable10");
            }
        }

        private NewWindowTable11 messageWindowTable11;
        public NewWindowTable11 MessageWindowTable11
        {
            get { return messageWindowTable11; }
            set
            {
                messageWindowTable11 = value;
                OnPropertyChanged("MessageWindowTable11");
            }
        }

        private NewWindowTable12 messageWindowTable12;
        public NewWindowTable12 MessageWindowTable12
        {
            get { return messageWindowTable12; }
            set
            {
                messageWindowTable12 = value;
                OnPropertyChanged("MessageWindowTable12");
            }
        }

        private NewWindowTable13 messageWindowTable13;
        public NewWindowTable13 MessageWindowTable13
        {
            get { return messageWindowTable13; }
            set
            {
                messageWindowTable13 = value;
                OnPropertyChanged("MessageWindowTable13");
            }
        }

        private NewWindowTable14 messageWindowTable14;
        public NewWindowTable14 MessageWindowTable14
        {
            get { return messageWindowTable14; }
            set
            {
                messageWindowTable14 = value;
                OnPropertyChanged("MessageWindowTable14");
            }
        }

        private NewWindowTable15 messageWindowTable15;
        public NewWindowTable15 MessageWindowTable15
        {
            get { return messageWindowTable15; }
            set
            {
                messageWindowTable15 = value;
                OnPropertyChanged("MessageWindowTable15");
            }
        }
        private NewWindowTable16 messageWindowTable16;
        public NewWindowTable16 MessageWindowTable16
        {
            get { return messageWindowTable16; }
            set
            {
                messageWindowTable16 = value;
                OnPropertyChanged("MessageWindowTable16");
            }
        }
        private NewWindowTable17 messageWindowTable17;
        public NewWindowTable17 MessageWindowTable17
        {
            get { return messageWindowTable17; }
            set
            {
                messageWindowTable17 = value;
                OnPropertyChanged("MessageWindowTable17");
            }
        }
        private NewWindowTable18 messageWindowTable18;
        public NewWindowTable18 MessageWindowTable18
        {
            get { return messageWindowTable18; }
            set
            {
                messageWindowTable18 = value;
                OnPropertyChanged("MessageWindowTable18");
            }
        }

        public NewWindowManufacturer MessageWindowManufacturer
        {
            get
            {
                return messageWindowManufacturer;
            }

            set
            {
                messageWindowManufacturer = value;
                OnPropertyChanged("MessageWindowManufacturer");
            }
        }
        #endregion


        public void Confirm()
        {
            if (!ToConfirm) ToConfirm = true;
            IsOpen = false;

        }
        public void Close()
        {
            IsOpen = false;
        }
        Stream stream;
        BinaryFormatter bformatter = new BinaryFormatter();
        CalibrationTable newTable;

        private string text;

        private void FillTable(NewWindowTableTemplate table)
        {

            int index = SelectedTable.Name.IndexOf("]");
            Text = SelectedTable.Name.Substring(index + 1);
            table.NameOfFile = Text;

            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + Text + ".lab"))
            {
                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + Text + ".lab", FileMode.Open);

                table.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);

                stream.Close();

            }
        }

        private void OverridingTable( NewWindowTableTemplate table)
        {
            int index = SelectedTable.Name.IndexOf("]");
            string str = SelectedTable.Name.Substring(index + 1);

            MessageBoxResult message = MessageBox.Show("Czy nadpisać nową tabelę? Jeśli nie zostanie utworzona nowa tabela.", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (message == MessageBoxResult.Yes)
            {
                if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + str + ".lab"))
                {
                    stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + str + ".lab", FileMode.Create);
                    bformatter.Serialize(stream, table.Tab);
                    stream.Close();
                }

            }
            else if (message == MessageBoxResult.No)
            {
                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + table.NameOfFile + ".lab", FileMode.Create);
                bformatter.Serialize(stream, table.Tab);
                stream.Close();

                newTable = new CalibrationTable();
                newTable.Name = "[" + AboutModelOfGauge.Model + "]" + table.NameOfFile;
                newTable.TypeOfWindow = table.ToString();
                ListOfNamesOfTables.Add(newTable);
                ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));

                File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
            }
        }

        public void DeleteTable()
        {
           if(MessageBoxResult.Yes == MessageBox.Show("Czy usunąć tabele?","Pytanie",MessageBoxButton.YesNo))
            {
                string[] s = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt");
                List<string> tempS = new List<string>();

                foreach (string line in s)
                {
                    tempS.Add(line);
                }
            
                foreach (CalibrationTable calib in ListOfNamesOfTables)
                {
                    if(calib.IsChecked)
                    {
                        foreach(string line in s)
                        {
                            if(line.Contains(calib.Name))
                            {
                                tempS.Remove(line);
                            }
                        }
                    }
                }
                //s = tempS.ToArray();

                File.WriteAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt","");
                File.AppendAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", tempS);


                ListOfNamesOfTables = new ObservableCollection<CalibrationTable>();
                    foreach (string str in tempS)
                    {
                        CalibrationTable newTable = new CalibrationTable();

                        int indexStart = str.IndexOf("\t");
                        //int indexEnd = str.IndexOf("|");
                        newTable.Name = str.Substring(indexStart + 1);
                        newTable.TypeOfWindow = str.Substring(0, indexStart);
                        ListOfNamesOfTables.Add(newTable);
                    }
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                
            }
        }
        public void EditTable()
        {
            int count = 0;
            int selectedTab = 0;
            foreach(CalibrationTable ct in ListOfNamesOfTables)
            {
                if(ct.IsChecked)
                {
                    count++;
                    selectedTab = ListOfNamesOfTables.IndexOf(ct);
                }
            }
            if(count > 1)
            {
                MessageBox.Show("Zaznacz tylko jedną tabelę.");
                return;
            }

            SelectedTable = ListOfNamesOfTables[selectedTab];

            int index = SelectedTable.Name.IndexOf("]");
            string str = SelectedTable.Name.Substring(index+1);
            
            Type t = Type.GetType(SelectedTable.TypeOfWindow);

            if(t.Name == "NewWindowTable18")////zmiana nr tabeli

            {
                MessageWindowTable18 = new NewWindowTable18();
                FillTable(MessageWindowTable18);

                MessageWindowTable18.IsOpen = true;
                if(MessageWindowTable18.ToConfirm)
                {

                    this.OverridingTable(MessageWindowTable18);
                }

                
            }
            if (t.Name == "NewWindowTable17")
            {
                MessageWindowTable17 = new NewWindowTable17();
                FillTable(MessageWindowTable17);

                MessageWindowTable17.IsOpen = true;
                if (MessageWindowTable17.ToConfirm)
                {

                    this.OverridingTable(MessageWindowTable17);
                }

            }
            if (t.Name == "NewWindowTable16")
            {
                MessageWindowTable16 = new NewWindowTable16();
                FillTable(MessageWindowTable16);
                MessageWindowTable16.IsOpen = true;
                if (MessageWindowTable16.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable16);
                }

            }
            if (t.Name == "NewWindowTable15")
            {
                MessageWindowTable15 = new NewWindowTable15();
                FillTable(MessageWindowTable15);
                MessageWindowTable15.IsOpen = true;
                if (MessageWindowTable15.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable15);
                }

            }
            if (t.Name == "NewWindowTable14")
            {
                MessageWindowTable14 = new NewWindowTable14();
                FillTable(MessageWindowTable14);
                MessageWindowTable14.IsOpen = true;
                if (MessageWindowTable14.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable14);
                }

            }
            if (t.Name == "NewWindowTable13")
            {
                MessageWindowTable13 = new NewWindowTable13();
                FillTable(MessageWindowTable13);
                MessageWindowTable13.IsOpen = true;
                if (MessageWindowTable13.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable13);
                }

            }
            if (t.Name == "NewWindowTable12")
            {
                MessageWindowTable12 = new NewWindowTable12();
                FillTable(MessageWindowTable12);
                MessageWindowTable12.IsOpen = true;
                if (MessageWindowTable12.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable12);
                }

            }
            if (t.Name == "NewWindowTable11")
            {
                MessageWindowTable11 = new NewWindowTable11();
                FillTable(MessageWindowTable11);
                MessageWindowTable11.IsOpen = true;
                if (MessageWindowTable11.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable11);
                }

            }
            if (t.Name == "NewWindowTable10")
            {
                MessageWindowTable10 = new NewWindowTable10();
                FillTable(MessageWindowTable10);
                MessageWindowTable10.IsOpen = true;
                if (MessageWindowTable10.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable10);
                }

            }
            if (t.Name == "NewWindowTable9")
            {
                MessageWindowTable9 = new NewWindowTable9();
                FillTable(MessageWindowTable9);
                MessageWindowTable9.IsOpen = true;
                if (MessageWindowTable9.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable9);
                }

            }
            if (t.Name == "NewWindowTable8")
            {
                MessageWindowTable8 = new NewWindowTable8();
                FillTable(MessageWindowTable8);
                MessageWindowTable8.IsOpen = true;
                if (MessageWindowTable8.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable8);
                }

            }
            if (t.Name == "NewWindowTable7")
            {
                MessageWindowTable7 = new NewWindowTable7();
                FillTable(MessageWindowTable7);
                MessageWindowTable7.IsOpen = true;
                if (MessageWindowTable7.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable7);
                }

            }
            if (t.Name == "NewWindowTable6")
            {
                MessageWindowTable6 = new NewWindowTable6();
                FillTable(MessageWindowTable6);
                MessageWindowTable6.IsOpen = true;
                if (MessageWindowTable6.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable6);
                }

            }
            if (t.Name == "NewWindowTable5")
            {
                MessageWindowTable5 = new NewWindowTable5();
                FillTable(MessageWindowTable5);
                MessageWindowTable5.IsOpen = true;
                if (MessageWindowTable5.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable5);
                }

            }

            if (t.Name == "NewWindowTable4")
            {
                MessageWindowTable4 = new NewWindowTable4();
                FillTable(MessageWindowTable4);
                MessageWindowTable4.IsOpen = true;
                if (MessageWindowTable4.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable4);
                }

            }
            if (t.Name == "NewWindowTable3")
            {
                MessageWindowTable3 = new NewWindowTable3();
                FillTable(MessageWindowTable3);
                MessageWindowTable3.IsOpen = true;
                if (MessageWindowTable3.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable3);
                }

            }
            if (t.Name == "NewWindowTable2")
            {
                MessageWindowTable2 = new NewWindowTable2();
                FillTable(MessageWindowTable2);
                MessageWindowTable2.IsOpen = true;
                if (MessageWindowTable2.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable2);
                }

            }
            if (t.Name == "NewWindowTable1")
            {
                MessageWindowTable1 = new NewWindowTable1();
                FillTable(MessageWindowTable1);
                MessageWindowTable1.IsOpen = true;
                if (MessageWindowTable1.ToConfirm)
                {
                    this.OverridingTable(MessageWindowTable1);
                }

            }


            ////do skończenia//chyba już skończone
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
        //
        public void AddTable()
        {
            MessageWindowTable = new NewWindowTable();
            MessageWindowTable.IsOpen = true;

            if (MessageWindowTable.ToConfirm || (MessageBoxResult.No == MessageBox.Show("Czy chcesz porzucić niedawno dodane tabele?","Pytanie",MessageBoxButton.YesNo)))
            {
                CalibrationTable newTable;

                if (MessageWindowTable.MessageWindowTable1 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable1.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "["+ AboutModelOfGauge.Model + "]"+ MessageWindowTable.MessageWindowTable1.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable1.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));

                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable2 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable2.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable2.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable2.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable2);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable3 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable3.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable3.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable3.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable3);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }
                if (MessageWindowTable.MessageWindowTable4 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable4.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable4.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable4.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable4);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow  + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }
                if (MessageWindowTable.MessageWindowTable4a != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable4a.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable4a.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable4a.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable4a);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable5 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable5.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable5.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable5.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable5);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable6 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable6.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable6.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable6.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable6);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable7 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable7.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable7.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable7.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable7);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable8 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable8.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable8.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable8.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable8);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }
                if (MessageWindowTable.MessageWindowTable9 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable9.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable9.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable9.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable9);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }
                if (MessageWindowTable.MessageWindowTable10 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable10.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable10.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable10.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable10);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }
                if (MessageWindowTable.MessageWindowTable11 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable11.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable11.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable11.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable11);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }
                if (MessageWindowTable.MessageWindowTable12 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable12.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable12.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable12.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable12);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }
                if (MessageWindowTable.MessageWindowTable13 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable13.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable13.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable13.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable13);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }
                if (MessageWindowTable.MessageWindowTable14 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable14.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable14.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable14.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable14);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable15 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable15.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable15.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable15.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable15);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable16 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable16.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable16.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable16.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable16);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable17 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable17.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable17.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable17.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable17);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable18 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable18.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable18.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable18.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable18);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable20 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable20.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "[" + AboutModelOfGauge.Model + "]" + MessageWindowTable.MessageWindowTable20.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable20.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable20);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                //if (MessageWindowTable.MessageWindowTable20 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable20.NameOfFile))
                //{
                //    newTable = new CalibrationTable();
                //    newTable.Name = MessageWindowTable.MessageWindowTable20.NameOfFile;
                //    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable20.ToString();
                //    ListOfNamesOfTables.Add(newTable);
                //    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable20);
                //    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                //    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                //    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                //}

                //if (MessageWindowTable.MessageWindowTable20 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable20.NameOfFile))
                //{
                //    newTable = new CalibrationTable();
                //    newTable.Name = MessageWindowTable.MessageWindowTable20.NameOfFile;
                //    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable20.ToString();
                //    ListOfNamesOfTables.Add(newTable);
                //    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable20);
                //    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                //    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                //    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                //}
                //if (!string.IsNullOrEmpty(MessageWindowTable.Title))
                {
                   // using (LaboratoryEntities context = new LaboratoryEntities())
                    {
                        //type TypeToAdd = new type();
                        //TypeToAdd.name = MessageWindowType.NameOfType;

                        //context.types.Add(TypeToAdd);
                        //context.SaveChanges();
                        //AboutModelOfGauge.CollectionOfType.Add(TypeToAdd.name);
                    }
                }
                //else
                {
                //    MessageBox.Show("Nie wpisano tytułu.");
                }
            }
            MessageWindowTable.ToConfirm = false;
        }

    }
}
