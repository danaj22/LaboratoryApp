using LaboratoryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.IO;

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

                        //context.calibrators.Add(CalibratorToAdd);

                        CollectionOfCalibrators.Add(CalibratorToAdd);
                        context.SaveChanges();

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


        public NewWindowModelOfGauge()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            AddUsageCommand = new SimpleRelayCommand(AddUsage);
            AddTypeCommand = new SimpleRelayCommand(AddType);
            AddCalibratorCommand = new SimpleRelayCommand(AddCalibrator);
            AddFunctionCommand = new SimpleRelayCommand(AddFunction);
            AddTableCommand = new SimpleRelayCommand(AddTable);

            CollectionOfCheckedFunction = new ObservableCollection<function>();
            LaboratoryEntities context = MainWindowViewModel.Context;
            try
            {
                List<Models.calibrator> ListOfCalibrators = context.calibrators.ToList();

                if (ListOfCalibrators.Count > 0)
                {
                    foreach (Models.calibrator item in ListOfCalibrators)
                    {
                        item.IsChecked = false;
                        CollectionOfCalibrators.Add(item);
                    }
                }

                List<Models.function> ListOfFunctions = context.functions.ToList();

                if (ListOfFunctions.Count >0)
                {
                    foreach(Models.function item in ListOfFunctions)
                    {
                        item.IsChecked = false;
                        CollectionOfCheckedFunction.Add(item);
                    }
                }
                context.SaveChanges();

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

                if (ListOfCalibrators.Count > 0)
                {
                    foreach (Models.calibrator item in ListOfCalibrators)
                    {
                        item.IsChecked = false;
                        CollectionOfCalibrators.Add(item);
                    }
                }
                
            }
            catch(Exception e)
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
        //
        public void AddTable()
        {
            MessageWindowTable = new NewWindowTable();
            MessageWindowTable.IsOpen = true;

            if (MessageWindowTable.ToConfirm)
            {
                CalibrationTable newTable;

                if (MessageWindowTable.MessageWindowTable1 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable1.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = "["+ AboutModelOfGauge.Model + "]"+ MessageWindowTable.MessageWindowTable1.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable1.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    //ListOfWindows <IEnumerableTable>
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable1);

                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }

                if (MessageWindowTable.MessageWindowTable2 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable2.NameOfFile))
                {
                    newTable = new CalibrationTable();
                    newTable.Name = MessageWindowTable.MessageWindowTable2.NameOfFile;
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
                    newTable.Name = MessageWindowTable.MessageWindowTable3.NameOfFile;
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
                    newTable.Name = MessageWindowTable.MessageWindowTable4.NameOfFile;
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
                    newTable.Name = MessageWindowTable.MessageWindowTable4a.NameOfFile;
                    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable4a.ToString();
                    ListOfNamesOfTables.Add(newTable);
                    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable4a);
                    ListOfNamesOfTables = new ObservableCollection<CalibrationTable>(ListOfNamesOfTables.OrderBy(i => i.Name));
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", newTable.TypeOfWindow + "\t" + newTable.Name);
                    File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\NamesOfTables.txt", "\n");
                }
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
