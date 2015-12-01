﻿using LaboratoryApp.Models;
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
                    CollectionOfCalibrators = new ObservableCollection<calibrator>();
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

                //if (MessageWindowTable.MessageWindowTable19 != null && !string.IsNullOrEmpty(MessageWindowTable.MessageWindowTable19.NameOfFile))
                //{
                //    newTable = new CalibrationTable();
                //    newTable.Name = MessageWindowTable.MessageWindowTable19.NameOfFile;
                //    newTable.TypeOfWindow = MessageWindowTable.MessageWindowTable19.ToString();
                //    ListOfNamesOfTables.Add(newTable);
                //    //MessageWindowTable.ListOfWindows.Add(MessageWindowTable.MessageWindowTable19);
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
