using System;
using System.Collections.Generic;
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

        public NewWindowTable()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            AddTable1Command = new SimpleRelayCommand(AddTable1);
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

        public void AddTable1()
        {
            MessageWindowTable1 = new NewWindowTable1();
            MessageWindowTable1.IsOpen = true;

            if (MessageWindowTable1.ToConfirm)
            {
                //if (!string.IsNullOrEmpty(MessageWindowTable1.Title))
                {

                    foreach (var row in MessageWindowTable1.Tab)
                    {
                        File.AppendAllText(NewWindowTable1.table1Path, row.IdealValue.ToString());
                        File.AppendAllText(NewWindowTable1.table1Path, "\t");
                        File.AppendAllText(NewWindowTable1.table1Path, row.Percent.ToString());
                        File.AppendAllText(NewWindowTable1.table1Path, "\t");
                        File.AppendAllText(NewWindowTable1.table1Path, row.ImportantNumber.ToString());
                        File.AppendAllText(NewWindowTable1.table1Path, "\t");
                        File.AppendAllText(NewWindowTable1.table1Path, row.Constant.ToString());
                        File.AppendAllText(NewWindowTable1.table1Path, "\n");
                    }
                    //using (LaboratoryEntities context = new LaboratoryEntities())
                    //{
                    //    //type TypeToAdd = new type();
                    //    //TypeToAdd.name = MessageWindowType.NameOfType;

                    //    //context.types.Add(TypeToAdd);
                    //    //context.SaveChanges();
                    //    //AboutModelOfGauge.CollectionOfType.Add(TypeToAdd.name);
                    //}
                }
                //else
                {
                    //MessageBox.Show("Nie wpisano tytułu.");
                }
            }
            MessageWindowTable1.ToConfirm = false;
        }
    }
}
