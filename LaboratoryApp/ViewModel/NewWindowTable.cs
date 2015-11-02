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

        //private NewWindowTable5 messageWindowTable5;
        //public NewWindowTable5 MessageWindowTable5
        //{
        //    get { return messageWindowTable5; }
        //    set
        //    {
        //        messageWindowTable5 = value;
        //        OnPropertyChanged("MessageWindowTable5");
        //    }
        //}

        //private NewWindowTable6 messageWindowTable6;
        //public NewWindowTable6 MessageWindowTable6
        //{
        //    get { return messageWindowTable6; }
        //    set
        //    {
        //        messageWindowTable6 = value;
        //        OnPropertyChanged("MessageWindowTable6");
        //    }
        //}


        //private NewWindowTable7 messageWindowTable7;
        //public NewWindowTable7 MessageWindowTable7
        //{
        //    get { return messageWindowTable7; }
        //    set
        //    {
        //        messageWindowTable7 = value;
        //        OnPropertyChanged("MessageWindowTable7");
        //    }
        //}

        //private NewWindowTable8 messageWindowTable8;
        //public NewWindowTable8 MessageWindowTable8
        //{
        //    get { return messageWindowTable8; }
        //    set
        //    {
        //        messageWindowTable8 = value;
        //        OnPropertyChanged("MessageWindowTable8");
        //    }
        //}

        //private NewWindowTable9 messageWindowTable9;
        //public NewWindowTable9 MessageWindowTable9
        //{
        //    get { return messageWindowTable9; }
        //    set
        //    {
        //        messageWindowTable9 = value;
        //        OnPropertyChanged("MessageWindowTable9");
        //    }
        //}

        //private NewWindowTable10 messageWindowTable10;
        //public NewWindowTable10 MessageWindowTable10
        //{
        //    get { return messageWindowTable10; }
        //    set
        //    {
        //        messageWindowTable10 = value;
        //        OnPropertyChanged("MessageWindowTable10");
        //    }
        //}

        //private NewWindowTable11 messageWindowTable11;
        //public NewWindowTable11 MessageWindowTable11
        //{
        //    get { return messageWindowTable11; }
        //    set
        //    {
        //        messageWindowTable11 = value;
        //        OnPropertyChanged("MessageWindowTable11");
        //    }
        //}

        //private NewWindowTable12 messageWindowTable12;
        //public NewWindowTable12 MessageWindowTable12
        //{
        //    get { return messageWindowTable12; }
        //    set
        //    {
        //        messageWindowTable12 = value;
        //        OnPropertyChanged("MessageWindowTable12");
        //    }
        //}

        //private NewWindowTable13 messageWindowTable13;
        //public NewWindowTable13 MessageWindowTable13
        //{
        //    get { return messageWindowTable13; }
        //    set
        //    {
        //        messageWindowTable13 = value;
        //        OnPropertyChanged("MessageWindowTable13");
        //    }
        //}

        //private NewWindowTable14 messageWindowTable14;
        //public NewWindowTable14 MessageWindowTable14
        //{
        //    get { return messageWindowTable14; }
        //    set
        //    {
        //        messageWindowTable14 = value;
        //        OnPropertyChanged("MessageWindowTable14");
        //    }
        //}

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

            System.IO.Directory.CreateDirectory(tablesPath);
        }
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
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable1.NameOfFile + ".txt", "\n");
                        }

                        //using (LaboratoryEntities context = new LaboratoryEntities())
                        //{
                        //    //type TypeToAdd = new type();
                        //    //TypeToAdd.name = MessageWindowType.NameOfType;

                        //    //context.types.Add(TypeToAdd);
                        //    //context.SaveChanges();
                        //    //AboutModelOfGauge.CollectionOfType.Add(TypeToAdd.name);
                        //}

                        //else
                        {
                            //MessageBox.Show("Nie wpisano tytułu.");
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
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable2.NameOfFile + ".txt", "\n");
                        }

                        //using (LaboratoryEntities context = new LaboratoryEntities())
                        //{
                        //    //type TypeToAdd = new type();
                        //    //TypeToAdd.name = MessageWindowType.NameOfType;

                        //    //context.types.Add(TypeToAdd);
                        //    //context.SaveChanges();
                        //    //AboutModelOfGauge.CollectionOfType.Add(TypeToAdd.name);
                        //}

                        //else
                        {
                            //MessageBox.Show("Nie wpisano tytułu.");
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
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable3.NameOfFile + ".txt", "\n");
                        }

                        //using (LaboratoryEntities context = new LaboratoryEntities())
                        //{
                        //    //type TypeToAdd = new type();
                        //    //TypeToAdd.name = MessageWindowType.NameOfType;

                        //    //context.types.Add(TypeToAdd);
                        //    //context.SaveChanges();
                        //    //AboutModelOfGauge.CollectionOfType.Add(TypeToAdd.name);
                        //}

                        //else
                        {
                            //MessageBox.Show("Nie wpisano tytułu.");
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
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.IdealValue.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.Percent.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.ImportantNumber.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\t");
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", row.Constant.ToString());
                            File.AppendAllText(tablesPath + "\\" + MessageWindowTable4.NameOfFile + ".txt", "\n");
                        }

                        //using (LaboratoryEntities context = new LaboratoryEntities())
                        //{
                        //    //type TypeToAdd = new type();
                        //    //TypeToAdd.name = MessageWindowType.NameOfType;

                        //    //context.types.Add(TypeToAdd);
                        //    //context.SaveChanges();
                        //    //AboutModelOfGauge.CollectionOfType.Add(TypeToAdd.name);
                        //}

                        //else
                        {
                            //MessageBox.Show("Nie wpisano tytułu.");
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

                        //using (LaboratoryEntities context = new LaboratoryEntities())
                        //{
                        //    //type TypeToAdd = new type();
                        //    //TypeToAdd.name = MessageWindowType.NameOfType;

                        //    //context.types.Add(TypeToAdd);
                        //    //context.SaveChanges();
                        //    //AboutModelOfGauge.CollectionOfType.Add(TypeToAdd.name);
                        //}

                        //else
                        {
                            //MessageBox.Show("Nie wpisano tytułu.");
                        }
                    }
                }
                //catch { }
                MessageWindowTable4a.ToConfirm = false;
            }
        }
    }
}