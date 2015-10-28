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
        private string tablesPath = @"C:\ProgramData\DASLSystems\LaboratoryApp\tables";
        public NewWindowTable()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            AddTable1Command = new SimpleRelayCommand(AddTable1);


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
    }
}