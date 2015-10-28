﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable1Generate:ObservableObject
    {

        public NewWindowTable1Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);

        }

        private string nameOfFile;
        public string NameOfFile
        {
            get { return nameOfFile; }
            set
            {
                nameOfFile = value;
                OnPropertyChanged("NameOfFile");
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

        public static string table1Path;
        public string Table1Path
        {
            get { return table1Path; }
            set
            {
                table1Path = value;
                OnPropertyChanged("Table1Path");
            }
        }

        public static double constant;
        public double Constant
        {
            get { return constant; }
            set
            {
                constant = value;
                OnPropertyChanged("Constant");
            }
        }
        
        public static double importantNumber;
        public double ImportantNumber
        {
            get { return importantNumber; }
            set
            {
                importantNumber = value;
                OnPropertyChanged("ImportantNumber");

            }
        }

        public static double percent;
        public double Percent
        {
            get { return percent; }
            set
            {
                percent = value;
                OnPropertyChanged("Percent");

            }
        }

        private ObservableCollection<Measure1> tab = new ObservableCollection<Measure1>();
        public ObservableCollection<Measure1> Tab
        {
            get { return tab; }
            set
            {
                tab = value;
                OnPropertyChanged("Tab");
            }
        }
    }
    }

