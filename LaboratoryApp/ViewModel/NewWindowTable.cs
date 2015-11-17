using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable : ObservableObject
    {
        private List<IEnumerableTable> listOfWindows = new List<IEnumerableTable>();
        public List<IEnumerableTable> ListOfWindows
        {
            get { return listOfWindows; }
            set
            {
                listOfWindows = value;
                OnPropertyChanged("ListOfWindows");
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
        #endregion

        private string tablesPath = @"C:\ProgramData\DASLSystems\LaboratoryApp\tables";
        public NewWindowTable()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            AddTable1Command = new SimpleRelayCommand(AddTable1);
            AddTable2Command = new SimpleRelayCommand(AddTable2);
            AddTable3Command = new SimpleRelayCommand(AddTable3);
            AddTable4Command = new SimpleRelayCommand(AddTable4);
            AddTable4aCommand = new SimpleRelayCommand(AddTable4a);
            AddTable5Command = new SimpleRelayCommand(AddTable5);
            AddTable6Command = new SimpleRelayCommand(AddTable6);
            AddTable7Command = new SimpleRelayCommand(AddTable7);
            AddTable8Command = new SimpleRelayCommand(AddTable8);
            AddTable9Command = new SimpleRelayCommand(AddTable9);
            AddTable10Command = new SimpleRelayCommand(AddTable10);
            AddTable11Command = new SimpleRelayCommand(AddTable11);
            AddTable12Command = new SimpleRelayCommand(AddTable12);
            AddTable13Command = new SimpleRelayCommand(AddTable13);
            AddTable14Command = new SimpleRelayCommand(AddTable14);
            AddTable15Command = new SimpleRelayCommand(AddTable15);
            AddTable16Command = new SimpleRelayCommand(AddTable16);
            AddTable17Command = new SimpleRelayCommand(AddTable17);
            AddTable18Command = new SimpleRelayCommand(AddTable18);

            System.IO.Directory.CreateDirectory(tablesPath);
        }
        #region commands
        private ICommand addTable1Command;
        public ICommand AddTable1Command
        {
            get { return addTable1Command; }
            set
            {
                addTable1Command = value;
                base.OnPropertyChanged("AddTable1Command");
            }
        }

        private ICommand addTable2Command;
        public ICommand AddTable2Command
        {
            get { return addTable2Command; }
            set
            {
                addTable2Command = value;
                base.OnPropertyChanged("AddTable2Command");
            }
        }

        private ICommand addTable3Command;
        public ICommand AddTable3Command
        {
            get { return addTable3Command; }
            set
            {
                addTable3Command = value;
                base.OnPropertyChanged("AddTable3Command");
            }
        }

        private ICommand addTable4Command;
        public ICommand AddTable4Command
        {
            get { return addTable4Command; }
            set
            {
                addTable4Command = value;
                base.OnPropertyChanged("AddTable4Command");
            }
        }

        private ICommand addTable4aCommand;
        public ICommand AddTable4aCommand
        {
            get { return addTable4aCommand; }
            set
            {
                addTable4aCommand = value;
                base.OnPropertyChanged("AddTable4aCommand");
            }
        }
        private ICommand addTable5Command;

        public ICommand AddTable5Command
        {
            get { return addTable5Command; }
            set { addTable5Command = value; OnPropertyChanged("AddTable5Command"); }
        }
        private ICommand addTable6Command;
        public ICommand AddTable6Command
        {
            get { return addTable6Command; }
            set { addTable6Command = value; OnPropertyChanged("AddTable6Command"); }
        }

        private ICommand addTable7Command;
        public ICommand AddTable7Command
        {
            get { return addTable7Command; }
            set
            {
                addTable7Command = value;
                base.OnPropertyChanged("AddTable7Command");
            }
        }

        private ICommand addTable8Command;
        public ICommand AddTable8Command
        {
            get { return addTable8Command; }
            set
            {
                addTable8Command = value;
                base.OnPropertyChanged("AddTable8Command");
            }
        }

        private ICommand addTable9Command;
        public ICommand AddTable9Command
        {
            get { return addTable9Command; }
            set
            {
                addTable9Command = value;
                base.OnPropertyChanged("AddTable9Command");
            }
        }

        private ICommand addTable10Command;
        public ICommand AddTable10Command
        {
            get { return addTable10Command; }
            set
            {
                addTable10Command = value;
                base.OnPropertyChanged("AddTable10Command");
            }
        }

        private ICommand addTable11Command;
        public ICommand AddTable11Command
        {
            get { return addTable11Command; }
            set
            {
                addTable11Command = value;
                base.OnPropertyChanged("AddTable11Command");
            }
        }

        private ICommand addTable12Command;
        public ICommand AddTable12Command
        {
            get { return addTable12Command; }
            set
            {
                addTable12Command = value;
                base.OnPropertyChanged("AddTable12Command");
            }
        }

        private ICommand addTable13Command;
        public ICommand AddTable13Command
        {
            get { return addTable13Command; }
            set
            {
                addTable13Command = value;
                base.OnPropertyChanged("AddTable13Command");
            }
        }
        private ICommand addTable14Command;
        public ICommand AddTable14Command
        {
            get { return addTable14Command; }
            set
            {
                addTable14Command = value;
                base.OnPropertyChanged("AddTable14Command");
            }
        }

        private ICommand addTable15Command;
        public ICommand AddTable15Command
        {
            get { return addTable15Command; }
            set
            {
                addTable15Command = value;
                base.OnPropertyChanged("AddTable15Command");
            }
        }
        private ICommand addTable16Command;
        public ICommand AddTable16Command
        {
            get { return addTable16Command; }
            set
            {
                addTable16Command = value;
                base.OnPropertyChanged("AddTable16Command");
            }
        }
        private ICommand addTable17Command;
        public ICommand AddTable17Command
        {
            get { return addTable17Command; }
            set
            {
                addTable17Command = value;
                base.OnPropertyChanged("AddTable17Command");
            }
        }
        private ICommand addTable18Command;
        public ICommand AddTable18Command
        {
            get { return addTable18Command; }
            set
            {
                addTable18Command = value;
                base.OnPropertyChanged("AddTable18Command");
            }
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
        #endregion

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
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private ObservableCollection<string> collectionOfTable = new ObservableCollection<string>();
        public ObservableCollection<string> CollectionOfTable
        {
            get { return collectionOfTable; }
            set
            {
                collectionOfTable = value;
                OnPropertyChanged("CollectionOfTable");
            }
        }

        public void AddTable1()
        {
            MessageWindowTable1 = new NewWindowTable1();
            MessageWindowTable1.IsOpen = true;

            if (MessageWindowTable1.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable1.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable1.NameOfFile);

                        foreach (var row in MessageWindowTable1.Tab)
                        {

                            if (!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", "\t");

                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", "\n");
                        }

                    }
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable1.NameOfFile + "$.txt"))
                    {
                        foreach (var row in MessageWindowTable1.Tab)
                        {
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + "$.txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + "$.txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + "$.txt", "\n");
                        }

                    }

                }
                //catch { }
                MessageWindowTable1.ToConfirm = false;
            }
        }

        public void AddTable2()
        {
            MessageWindowTable2 = new NewWindowTable2();
            MessageWindowTable2.IsOpen = true;

            if (MessageWindowTable2.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable2.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable2.NameOfFile);

                        foreach (var row in MessageWindowTable2.Tab)
                        {
                            if (!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable2.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable2.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable2.ToConfirm = false;
            }
        }

        public void AddTable3()
        {
            MessageWindowTable3 = new NewWindowTable3();
            MessageWindowTable3.IsOpen = true;

            if (MessageWindowTable3.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable3.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable3.NameOfFile);

                        foreach (var row in MessageWindowTable3.Tab)
                        {
                            if(!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", "\n");
                        }
                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable3.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable3.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable3.ToConfirm = false;
            }
        }

        public void AddTable4()
        {
            MessageWindowTable4 = new NewWindowTable4();
            MessageWindowTable4.IsOpen = true;

            if (MessageWindowTable4.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable4.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable4.NameOfFile);

                        foreach (var row in MessageWindowTable4.Tab)
                        
                        {
                            if (!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\t");
                            //different in this window
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.ValueOfIsolation.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\t");
                           
                            //the same...
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\n");
                        }
                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable4.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable4.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable4.ToConfirm = false;
            }
        }

        public void AddTable4a()
        {
            MessageWindowTable4a = new NewWindowTable4a();
            MessageWindowTable4a.IsOpen = true;

            if (MessageWindowTable4a.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable4a.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable4a.NameOfFile);

                        foreach (var row in MessageWindowTable4a.Tab)
                        {
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable4a.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable4a.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable4a.ToConfirm = false;
            }
        }

        public void AddTable5()
        {
            MessageWindowTable5 = new NewWindowTable5();
            MessageWindowTable5.IsOpen = true;

            if (MessageWindowTable5.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable5.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable5.NameOfFile);

                        foreach (var row in MessageWindowTable5.Tab)
                        {
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + ".txt", "\n");
                        }
                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable5.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable5.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable5.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable5.ToConfirm = false;
            }
        }

        public void AddTable6()
        {
            MessageWindowTable6 = new NewWindowTable6();
            MessageWindowTable6.IsOpen = true;

            if (MessageWindowTable6.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable6.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable6.NameOfFile);

                        foreach (var row in MessageWindowTable6.Tab)
                        {
                            //diffrent line...
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", row.Multiples.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", "\t");

                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable6.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable6.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable6.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable6.ToConfirm = false;
            }
        }

        public void AddTable7()
        {
            MessageWindowTable7 = new NewWindowTable7();
            MessageWindowTable7.IsOpen = true;

            if (MessageWindowTable7.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable7.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable7.NameOfFile);

                        foreach (var row in MessageWindowTable7.Tab)
                        {
                            if (!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable7.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable7.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable7.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable7.ToConfirm = false;
            }
        }

        public void AddTable8()
        {
            MessageWindowTable8 = new NewWindowTable8();
            MessageWindowTable8.IsOpen = true;

            if (MessageWindowTable8.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable8.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable8.NameOfFile);

                        foreach (var row in MessageWindowTable8.Tab)
                        {
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable8.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable8.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable8.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable8.ToConfirm = false;
            }
        }

        public void AddTable9()
        {
            MessageWindowTable9 = new NewWindowTable9();
            MessageWindowTable9.IsOpen = true;

            if (MessageWindowTable9.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable9.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable9.NameOfFile);

                        foreach (var row in MessageWindowTable9.Tab)
                        {
                            //diffrent line...
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", row.Multiples.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", "\t");

                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable9.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable9.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable9.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable9.ToConfirm = false;
            }
        }

        public void AddTable10()
        {
            MessageWindowTable10 = new NewWindowTable10();
            MessageWindowTable10.IsOpen = true;

            if (MessageWindowTable10.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable10.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable10.NameOfFile);

                        foreach (var row in MessageWindowTable10.Tab)
                        {
                            if (!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", "\t");
                            //diffrent lines...
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", row.Multiples.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", row.SymulatedResistance.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", row.ResistanceMeasure.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", "\t");

                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + ".txt", "\n");
                        }
                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable10.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable10.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable10.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable10.ToConfirm = false;
            }
        }

        public void AddTable11()
        {
            MessageWindowTable11 = new NewWindowTable11();
            MessageWindowTable11.IsOpen = true;

            if (MessageWindowTable11.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable11.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable11.NameOfFile);

                        foreach (var row in MessageWindowTable11.Tab)
                        {
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + ".txt", "\n");
                        }
                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable11.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable11.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable11.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable11.ToConfirm = false;
            }
        }

        public void AddTable12()
        {
            MessageWindowTable12 = new NewWindowTable12();
            MessageWindowTable12.IsOpen = true;

            if (MessageWindowTable12.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable12.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable12.NameOfFile);

                        foreach (var row in MessageWindowTable12.Tab)
                        {
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + ".txt", "\n");
                        }
                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable12.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable12.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable12.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable12.ToConfirm = false;
            }
        }

        public void AddTable13()
        {
            MessageWindowTable13 = new NewWindowTable13();
            MessageWindowTable13.IsOpen = true;

            if (MessageWindowTable13.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable13.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable13.NameOfFile);

                        foreach (var row in MessageWindowTable13.Tab)
                        {
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable13.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable13.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable13.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable13.ToConfirm = false;
            }
        }

        public void AddTable14()
        {
            MessageWindowTable14 = new NewWindowTable14();
            MessageWindowTable14.IsOpen = true;

            if (MessageWindowTable14.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable14.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable14.NameOfFile);

                        foreach (var row in MessageWindowTable14.Tab)
                        {
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable14.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable14.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable14.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable14.ToConfirm = false;
            }
        }

        public void AddTable15()
        {
            MessageWindowTable15 = new NewWindowTable15();
            MessageWindowTable15.IsOpen = true;

            if (MessageWindowTable15.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable15.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable15.NameOfFile);

                        foreach (var row in MessageWindowTable15.Tab)
                        {
                            if (!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", "\t");

                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", row.Multiples.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable15.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable15.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable15.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable15.ToConfirm = false;
            }
        }

        public void AddTable16()
        {
            MessageWindowTable16 = new NewWindowTable16();
            MessageWindowTable16.IsOpen = true;

            if (MessageWindowTable16.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable16.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable16.NameOfFile);

                        foreach (var row in MessageWindowTable16.Tab)
                        {
                            if (!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", row.Multiples.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + ".txt", "\n");
                        }
                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable16.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable16.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable16.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable16.ToConfirm = false;
            }
        }

        public void AddTable17()
        {
            MessageWindowTable17 = new NewWindowTable17();
            MessageWindowTable17.IsOpen = true;

            if (MessageWindowTable17.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable17.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable17.NameOfFile);

                        foreach (var row in MessageWindowTable17.Tab)
                        {
                            if (!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", "\t");

                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + ".txt", "\n");
                        }

                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable17.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable17.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable17.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable17.ToConfirm = false;
            }
        }

        public void AddTable18()
        {
            MessageWindowTable18 = new NewWindowTable18();
            MessageWindowTable18.IsOpen = true;

            if (MessageWindowTable18.ToConfirm)
            {
                //try
                {
                    //if (!string.IsNullOrEmpty(MessageWindowTable18.Title))
                    if (!File.Exists(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt"))
                    {
                        //File.Create(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt");

                        CollectionOfTable.Add(MessageWindowTable18.NameOfFile);

                        foreach (var row in MessageWindowTable18.Tab)
                        {
                            if (!string.IsNullOrEmpty(row.Prefix))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", row.Prefix.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", "\t");

                            if (!string.IsNullOrEmpty(row.Prefix2))
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", row.Prefix2.ToString());
                            }
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", "\t");

                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", row.Multiples.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", row.ReferenceVoltage.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + ".txt", "\n");
                        }
                        if (!File.Exists(tablesPath + "\\" + MessageWindowTable18.NameOfFile + "$.txt"))
                        {
                            foreach (var row in MessageWindowTable18.Tab)
                            {
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + "$.txt", row.PercentIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + "$.txt", row.ImportantNumberIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + "$.txt", "\t");
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + "$.txt", row.ConstantIdeal.ToString());
                                File.AppendAllText(tablesPath + "\\" + MessageWindowTable18.NameOfFile + "$.txt", "\n");
                            }

                        }
                    }
                }
                //catch { }
                MessageWindowTable18.ToConfirm = false;
            }
        }
    }
}