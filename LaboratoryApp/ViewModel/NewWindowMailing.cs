using LaboratoryApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowMailing: ObservableObject
    {
        public NewWindowMailing()
        {
            Start = DateTime.Now;
            Start = Change(Start.Date, 0,0,0,0);
            End = Change(Start.Date, 23,0,0,0);
            OpenSaveFolderCommand = new SimpleRelayCommand(OpenSaveFolder);
            SaveCommand = new SimpleRelayCommand(Save);
        }

        private DateTime start;

        public DateTime Start
        {
            get { return start; }
            set { start = value; OnPropertyChanged("Start"); }
        }
        private DateTime end;

        public DateTime End
        {
            get { return end; }
            set { end = value; OnPropertyChanged("End"); }
        }

        Stream stream;
        BinaryFormatter bformatter = new BinaryFormatter();

        private string mailPath;

        public string MailPath
        {
            get { return mailPath; }
            set
            {
                mailPath = value;
                OnPropertyChanged("MailPath");

                MainWindowViewModel.Settings.PathToMailing = mailPath;
                if (File.Exists(MainWindowViewModel.settingsPath))
                {
                    stream = File.Open(MainWindowViewModel.settingsPath, FileMode.OpenOrCreate);
                    bformatter.Serialize(stream, MainWindowViewModel.Settings);
                    stream.Close();
                }
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
        private ICommand openSaveFolderCommand;

        public ICommand OpenSaveFolderCommand
        {
            get { return openSaveFolderCommand; }
            set { openSaveFolderCommand = value; OnPropertyChanged("OpenSaveFolderCommand"); }
        }
        private void Save()
        {
            

            try {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {

                    List<certificate> certificates = (from c in context.certificates select c).ToList();
                    if (!string.IsNullOrEmpty(MailPath))
                    {
                        File.WriteAllText(MailPath + "\\informacje o klientach.txt", String.Empty);
                        File.WriteAllText(MailPath + "\\maile.txt", String.Empty);

                        string content = "";
                        string content2 = "";

                        foreach (certificate cert in certificates)
                        {
                            if (cert.date <= End && cert.date >= Start)
                            {
                                content += "Klient: " + cert.gauge.client.name + " Adres: " + cert.gauge.client.adress + " Tel: " + cert.gauge.client.tel + " NIP:" + cert.gauge.client.NIP + "\nProducent:" + cert.gauge.model_of_gauges.manufacturer_name + "\nModel:" + cert.gauge.model_of_gauges.model + "\nKoszt:" + cert.cost + " zł\n";

                                if (!String.IsNullOrEmpty(cert.gauge.client.mail) && !content2.Contains(cert.gauge.client.mail))
                                {
                                    content2 += cert.gauge.client.mail + "\n";
                                }

                            }
                        }
                        File.AppendAllText(MailPath + "\\informacje o klientach.txt", content);
                        File.AppendAllText(MailPath + "\\maile.txt", content2);
                        this.IsOpen = false;
                        //MessageBox.Show("Zapisano pliki w wybranej lokalizacji.");
                    }
                    else
                    {
                        MessageBox.Show("Podaj najpierw folder do zapisu.");
                    }
                }
            }
            catch(Exception e)
            {
                File.AppendAllText(MainWindowViewModel.path, e.ToString());
            }
        }

        public DateTime Change(DateTime dateTime, int hours, int minutes, int seconds, int milliseconds)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                seconds,
                milliseconds,
                dateTime.Kind);
        }

        private ICommand saveCommand;

        public ICommand SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; OnPropertyChanged("SaveCommand"); }
        }

        private void OpenSaveFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                MailPath = fbd.SelectedPath;
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


    }
}
