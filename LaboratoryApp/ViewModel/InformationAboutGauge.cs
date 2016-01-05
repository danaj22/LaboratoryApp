using LaboratoryApp.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Xml.XPath;

namespace LaboratoryApp.ViewModel
{
    public class InformationAboutGauge : ObservableObject
    {
        #region fields
        private int gaugeId;
        public int GaugeId
        {
            get { return gaugeId; }
            set
            {
                gaugeId = value;
                OnPropertyChanged("GaugeId");
            }
        }

        private static NewWindowRaport temporaryRaport;

        private ObservableCollection<NewWindowTableGenerate> tablesToGenerate = new ObservableCollection<NewWindowTableGenerate>();

        public ObservableCollection<NewWindowTableGenerate> TablesToGenerate
        {
            get { return tablesToGenerate; }
            set { tablesToGenerate = value; OnPropertyChanged("TablesToGenerate"); }
        }
        private string serialNumber;
        public string SerialNumber
        {
            get { return serialNumber; }
            set
            {
                serialNumber = value;
                OnPropertyChanged("SerialNumber");
            }
        }

        private Nullable<int> clientId;
        public Nullable<int> ClientId
        {
            get { return clientId; }
            set
            {
                clientId = value;
                OnPropertyChanged("ClientId");
            }
        }

        private Nullable<int> officeId;
        public Nullable<int> OfficeId
        {
            get { return officeId; }
            set
            {
                officeId = value;
                OnPropertyChanged("OfficeId");
            }
        }

        private Nullable<int> modelOfGaugeId;
        public Nullable<int> ModelOfGaugeId
        {
            get { return modelOfGaugeId; }
            set
            {
                modelOfGaugeId = value;
                OnPropertyChanged("ModelOfGaugeId");
            }
        }

        private model_of_gauges modelOfGaugeItem;
        public virtual model_of_gauges ModelOfGaugeItem
        {
            get { return modelOfGaugeItem; }
            set
            {
                modelOfGaugeItem = value;
                OnPropertyChanged("ModelOfGaugeItem");
            }
        }

        private NewWindowGauge messageWindowGauge;
        public NewWindowGauge MessageWindowGauge
        {
            get { return messageWindowGauge; }
            set
            {
                messageWindowGauge = value;
                OnPropertyChanged("MessageWindowGauge");
            }
        }

        private NewWindowRaport messageWindowRaport;
        public NewWindowRaport MessageWindowRaport
        {
            get { return messageWindowRaport; }
            set
            {
                messageWindowRaport = value;
                OnPropertyChanged("MessageWindowRaport");
            }
        }

        private NewWindowTable1Generate messageWindowTable1;

        public NewWindowTable1Generate MessageWindowTable1
        {
            get { return messageWindowTable1; }
            set 
            { 
                messageWindowTable1 = value;
                OnPropertyChanged("MessageWindowTable1");
            }
        }

        private NewWindowTable2Generate messageWindowTable2;

        public NewWindowTable2Generate MessageWindowTable2
        {
            get { return messageWindowTable2; }
            set
            {
                messageWindowTable2 = value;
                OnPropertyChanged("MessageWindowTable2");
            }
        }
        private NewWindowTable18Generate messageWindowTable18;

        public NewWindowTable18Generate MessageWindowTable18
        {
            get { return messageWindowTable18; }
            set { messageWindowTable18 = value; OnPropertyChanged("MessageWindowTable18"); }
        }
        private NewWindowTable3Generate messageWindowTable3;

        public NewWindowTable3Generate MessageWindowTable3
        {
            get { return messageWindowTable3; }
            set { messageWindowTable3 = value; OnPropertyChanged("MessageWindowTable3"); }
        }
        private NewWindowTable4Generate messageWindowTable4;

        public NewWindowTable4Generate MessageWindowTable4
        {
            get { return messageWindowTable4; }
            set { messageWindowTable4 = value; OnPropertyChanged("MessageWindowTable4"); }
        }
        private NewWindowTable5Generate messageWindowTable5;

        public NewWindowTable5Generate MessageWindowTable5
        {
            get { return messageWindowTable5; }
            set { messageWindowTable5 = value; OnPropertyChanged("MessageWindowTable5"); }
        }
        private NewWindowTable6Generate messageWindowTable6;
        public NewWindowTable6Generate MessageWindowTable6
        {
            get { return messageWindowTable6; }
            set { messageWindowTable6 = value; OnPropertyChanged("MessageWindowTable6"); }
        }

        private NewWindowTable7Generate messageWindowTable7;
        public NewWindowTable7Generate MessageWindowTable7
        {
            get { return messageWindowTable7; }
            set { messageWindowTable7 = value; OnPropertyChanged("MessageWindowTable7"); }
        }
        private NewWindowTable9Generate messageWindowTable9;

        public NewWindowTable9Generate MessageWindowTable9
        {
            get { return messageWindowTable9; }
            set { messageWindowTable9 = value; OnPropertyChanged("MessageWindowTable9"); }
        }
        private NewWindowTable10Generate messageWindowTable10;

        public NewWindowTable10Generate MessageWindowTable10
        {
            get { return messageWindowTable10; }
            set { messageWindowTable10 = value; OnPropertyChanged("MessageWindowTable10"); }
        }

        private NewWindowTable15Generate messageWindowTable15;

        public NewWindowTable15Generate MessageWindowTable15
        {
            get { return messageWindowTable15; }
            set { messageWindowTable15 = value; OnPropertyChanged("MessageWindowTable15"); }
        }
        private NewWindowTable16Generate messageWindowTable16;

        public NewWindowTable16Generate MessageWindowTable16
        {
            get { return messageWindowTable16; }
            set { messageWindowTable16 = value; OnPropertyChanged("MessageWindowTable16"); }
        }

        private NewWindowTable17Generate messageWindowTable17;
        public NewWindowTable17Generate MessageWindowTable17
        {
            get { return messageWindowTable17; }
            set { messageWindowTable17 = value; OnPropertyChanged("MessageWindowTable17"); }
        }

        private string manufacturer;
        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("model");
            }

        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }

        }

        private int gaugeIdToAdd;
        public int GaugeIdToAdd
        {
            get { return gaugeIdToAdd; }
            set
            {
                gaugeIdToAdd = value;
                OnPropertyChanged("GaugeIdToAdd");
            }
        }

        private gauge selectedGauge;
        public gauge SelectedGauge
        {
            get { return selectedGauge; }
            set
            {
                selectedGauge = value;
                OnPropertyChanged("SelectedGauge");
            }
        }

        private ObservableCollection<certificate> collectionOfCertificate;

        public ObservableCollection<certificate> CollectionOfCertificate
        {
            get { return collectionOfCertificate; }
            set
            {
                collectionOfCertificate = value;
                OnPropertyChanged("CollectionOfCertificate");
            }
        }

        #endregion


        public InformationAboutGauge(object SelectedNode)
        {
            SelectedGauge = (gauge)SelectedNode;
            //InitializeCollectionOfManufacturers();

            //ModelOfGaugeItem = new model_of_gauges();
            SerialNumber = SelectedGauge.serial_number;
            Manufacturer = SelectedGauge.model_of_gauges.manufacturer_name;
            Model = SelectedGauge.model_of_gauges.model;
            Description = SelectedGauge.model_of_gauges.usage.description;

            CollectionOfCertificate = new ObservableCollection<certificate>();
            LaboratoryEntities context = MainWindowViewModel.Context;
            var CertificatesOfSelectedGauge = (from c in context.certificates where c.gauge_id == SelectedGauge.gaugeId select c).ToList();

            foreach (var certificate in CertificatesOfSelectedGauge)
            {
                CollectionOfCertificate.Add(certificate);
            }

        }

        public ICommand DeleteGaugeCommand
        { get { return new SimpleRelayCommand(DeleteGaugeExecute); } }

        private void DeleteGaugeExecute()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten miernik?", "Usuwanie miernika", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    try
                    {
                        //delete selected client
                        var gaugeToDelete = //(gauge)MainWindowViewModel.selectedNode;
                                             (from g in context.gauges
                                              where g.gaugeId == SelectedGauge.gaugeId
                                              select g).FirstOrDefault();


                        MenuItem Node = SelectedGauge.Parent;
                        int IndexNode = MainWindowViewModel.rootElement.Children.IndexOf(SelectedGauge.Parent);

                        if (SelectedGauge.Parent.Parent != null)
                        {
                            int IndexClient = MainWindowViewModel.rootElement.Children.IndexOf(Node.Parent);
                            int IndexOffice = MainWindowViewModel.rootElement.Children[IndexClient].Children.IndexOf(Node);

                            //int IndexRoot = MainWindowViewModel.rootElement.Children[index].Children.IndexOf(Node.Parent);


                            MainWindowViewModel.rootElement.Children[IndexClient].Children[IndexOffice].Children.Remove(SelectedGauge);
                        }
                        else
                        {
                            MainWindowViewModel.rootElement.Children[IndexNode].Children.Remove(SelectedGauge);
                        }
                        context.gauges.Remove(gaugeToDelete);
                        context.SaveChanges();

                        // gauge gau = (gauge)MainWindowViewModel.selectedNode;
                        // int index_client = gau.client_id;
                        // int? index_office = gau.office_id;
                        //int
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            MainWindowViewModel.FileLog.WriteLine(String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State));
                            foreach (var ve in eve.ValidationErrors)
                            {
                                MainWindowViewModel.FileLog.WriteLine(String.Format("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        MainWindowViewModel.FileLog.WriteLine(e.ToString());
                    }


                    //MainWindowViewModel.rootElement.Children[MainWindowViewModel.selectedNode]
                    //MainWindowViewModel.LoadView();
                    //gauge MainWindowViewModel.selectedNode;
                }

            }
        }
        public ICommand EditGaugeCommand
        { get { return new SimpleRelayCommand(EditGaugeExecute); } }

        public ICommand GenerateTablesCommand
        { get { return new SimpleRelayCommand(GenerateTables); } }

        #region create raport pdf
        public ICommand GenerateRaportCommand
        { get { return new SimpleRelayCommand(GenerateRaportExecute); } }

        string line, ValueOfCell,pref2, pref;
        double cons, percnt, impNum, idealVal, consIdeal, percntIdeal, impNumIdeal, valOfIsolation, multi, resistMeasure, symResist,refVolt;

        Stream stream;
        BinaryFormatter bformatter = new BinaryFormatter();

        private void GenerateTables()
        {
            string q = "";

            {

                
                    string[] nameOfData = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + Model + ".txt");
                    TablesToGenerate = new ObservableCollection<NewWindowTableGenerate>();

                    foreach (string nameOfTable in nameOfData)
                    {
                    #region table1
                    if (nameOfTable.Substring(33, 7) == "Table1\t")
                    {
                        MessageWindowTable1 = new NewWindowTable1Generate();

                        int indexStart = nameOfTable.IndexOf("]");

                        q = nameOfTable.Substring(indexStart + 1);

                        if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                        {
                            stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                            MessageWindowTable1.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                            
                            stream.Close();

                            MessageWindowTable1.NameOfFile = q;
                        }



                        MessageWindowTable1.IsOpen = true;
                        if (MessageWindowTable1.ToConfirm)
                        {

                            TablesToGenerate.Add(MessageWindowTable1);
                        }
                        MessageWindowTable1.ToConfirm = false;
                    }
                        #endregion
                        #region table2
                        if (nameOfTable.Substring(33, 7) == "Table2\t")
                        {
                            {
                                MessageWindowTable2 = new NewWindowTable2Generate();

                                int indexStart = nameOfTable.IndexOf("]");

                                q = nameOfTable.Substring(indexStart + 1);

                                if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                                {
                                    stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                    MessageWindowTable2.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                    stream.Close();
                                MessageWindowTable2.NameOfFile = q;
                            }
                            }
                            MessageWindowTable2.IsOpen = true;
                            if (MessageWindowTable2.ToConfirm)
                            {

                                TablesToGenerate.Add(MessageWindowTable2);
                            }
                            MessageWindowTable2.ToConfirm = false;
                        }

                        #endregion
                        #region table3
                        if (nameOfTable.Substring(33, 7) == "Table3\t")
                        {
                            MessageWindowTable3 = new NewWindowTable3Generate();
                            int indexStart = nameOfTable.IndexOf("]");

                            q = nameOfTable.Substring(indexStart + 1);

                            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                            {
                                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                MessageWindowTable3.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                stream.Close();
                            MessageWindowTable3.NameOfFile = q;
                        }

                        MessageWindowTable3.IsOpen = true;
                            if (MessageWindowTable3.ToConfirm)
                            {

                                TablesToGenerate.Add(MessageWindowTable3);
                            }
                            MessageWindowTable3.ToConfirm = false;
                        }
                        #endregion
                        #region table4
                        if (nameOfTable.Substring(33, 7) == "Table4\t")
                        {
                            MessageWindowTable4 = new NewWindowTable4Generate();

                        int indexStart = nameOfTable.IndexOf("]");

                        q = nameOfTable.Substring(indexStart + 1);

                        if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                        {
                            stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                            MessageWindowTable4.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                            stream.Close();
                            MessageWindowTable4.NameOfFile = q;
                        }

                        MessageWindowTable4.IsOpen = true;
                            if (MessageWindowTable4.ToConfirm)
                            {

                                TablesToGenerate.Add(MessageWindowTable4);
                            }
                            MessageWindowTable4.ToConfirm = false;
                        }
                        #endregion
                        #region table 5
                        if (nameOfTable.Substring(33, 7) == "Table5\t")
                        {
                            MessageWindowTable5 = new NewWindowTable5Generate();
                            int indexStart = nameOfTable.IndexOf("]");

                            q = nameOfTable.Substring(indexStart + 1);

                            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                            {
                                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                MessageWindowTable5.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                stream.Close();
                                MessageWindowTable5.NameOfFile = q;
                        }
                            MessageWindowTable5.IsOpen = true;
                            if (MessageWindowTable5.ToConfirm)
                            {

                                TablesToGenerate.Add(MessageWindowTable5);
                            }
                            MessageWindowTable5.ToConfirm = false;
                        }
                        #endregion
                        #region table 6
                        if (nameOfTable.Substring(33, 7) == "Table6\t")
                        {
                            MessageWindowTable6 = new NewWindowTable6Generate();
                        int indexStart = nameOfTable.IndexOf("]");

                        q = nameOfTable.Substring(indexStart + 1);

                        if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                        {
                            stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                            MessageWindowTable6.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                            stream.Close();
                            MessageWindowTable6.NameOfFile = q;
                        }

                        MessageWindowTable6.IsOpen = true;
                            if (MessageWindowTable6.ToConfirm)
                            {

                                TablesToGenerate.Add(MessageWindowTable6);
                            }
                            MessageWindowTable6.ToConfirm = false;
                        }
                        #endregion
                        #region table 7
                        if (nameOfTable.Substring(33, 7) == "Table7\t")
                        {
                            MessageWindowTable7 = new NewWindowTable7Generate();

                            int indexStart = nameOfTable.IndexOf("]");
                            q = nameOfTable.Substring(indexStart + 1);

                            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                            {
                                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                MessageWindowTable7.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                stream.Close();
                            MessageWindowTable7.NameOfFile = q;
                        }
                            MessageWindowTable7.IsOpen = true;
                            if (MessageWindowTable7.ToConfirm)
                            {
                                TablesToGenerate.Add(MessageWindowTable7);
                            }
                            MessageWindowTable7.ToConfirm = false;

                        }
                        #endregion
                        #region table 9
                        if (nameOfTable.Substring(33, 7) == "Table9\t")
                        {
                            MessageWindowTable9 = new NewWindowTable9Generate();
                            int indexStart = nameOfTable.IndexOf("]");

                            q = nameOfTable.Substring(indexStart + 1);

                            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                            {
                                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                MessageWindowTable9.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                stream.Close();
                                MessageWindowTable9.NameOfFile = q;
                            }
                            MessageWindowTable9.IsOpen = true;
                            if (MessageWindowTable9.ToConfirm)
                            {
                                TablesToGenerate.Add(MessageWindowTable9);
                            }
                            MessageWindowTable9.ToConfirm = false;

                        }
                        #endregion
                        #region table 10
                        if (nameOfTable.Substring(33, 7) == "Table10")
                        {
                            MessageWindowTable10 = new NewWindowTable10Generate();
                            int indexStart = nameOfTable.IndexOf("]");

                            q = nameOfTable.Substring(indexStart + 1);

                            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                            {
                                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                MessageWindowTable10.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                stream.Close();
                                MessageWindowTable10.NameOfFile = q;
                        }

                            MessageWindowTable10.IsOpen = true;
                            if (MessageWindowTable10.ToConfirm)
                            {
                                TablesToGenerate.Add(MessageWindowTable10);
                            }
                            MessageWindowTable10.ToConfirm = false;

                        }
                        #endregion
                        #region table 15
                        if (nameOfTable.Substring(33, 7) == "Table15")
                        {
                            MessageWindowTable15 = new NewWindowTable15Generate();
                            int indexStart = nameOfTable.IndexOf("]");

                            q = nameOfTable.Substring(indexStart + 1);

                            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                            {
                                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                MessageWindowTable15.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                stream.Close();
                                MessageWindowTable15.NameOfFile = q;
                            }
                            MessageWindowTable15.IsOpen = true;
                            if (MessageWindowTable15.ToConfirm)
                            {
                                TablesToGenerate.Add(MessageWindowTable15);
                            }
                            MessageWindowTable15.ToConfirm = false;

                        }
                        #endregion
                        #region table 16
                        if (nameOfTable.Substring(33, 7) == "Table16")
                        {
                            MessageWindowTable16 = new NewWindowTable16Generate();
                            int indexStart = nameOfTable.IndexOf("]");

                            q = nameOfTable.Substring(indexStart + 1);

                            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                            {
                                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                MessageWindowTable16.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                stream.Close();
                                MessageWindowTable16.NameOfFile = q;
                            }
                            MessageWindowTable16.IsOpen = true;
                            if (MessageWindowTable16.ToConfirm)
                            {
                                TablesToGenerate.Add(MessageWindowTable16);
                            }
                            MessageWindowTable16.ToConfirm = false;

                        }
                        #endregion
                        #region table 17
                        if (nameOfTable.Substring(33, 7) == "Table17") 
                        {
                            MessageWindowTable17 = new NewWindowTable17Generate();
                            int indexStart = nameOfTable.IndexOf("]");

                            q = nameOfTable.Substring(indexStart + 1);

                            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                            {
                                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                MessageWindowTable17.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                stream.Close();
                                MessageWindowTable17.NameOfFile = q;
                            }

                            MessageWindowTable17.IsOpen = true;
                            if (MessageWindowTable17.ToConfirm)
                            {
                                TablesToGenerate.Add(MessageWindowTable17);
                            }
                            MessageWindowTable17.ToConfirm = false;

                        }
                        #endregion
                        #region table 18
                        if (nameOfTable.Substring(33, 7) == "Table18")
                        {
                            MessageWindowTable18 = new NewWindowTable18Generate();
                            int indexStart = nameOfTable.IndexOf("]");

                            q = nameOfTable.Substring(indexStart + 1);

                            if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab"))
                            {
                                stream = File.Open(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".lab", FileMode.Open);

                                MessageWindowTable18.Tab = (ObservableCollection<Measure1>)bformatter.Deserialize(stream);
                                stream.Close();
                                MessageWindowTable18.NameOfFile = q;
                            }

                            MessageWindowTable18.IsOpen = true;
                            if (MessageWindowTable18.ToConfirm)
                            {
                                TablesToGenerate.Add(MessageWindowTable18);
                            }
                            MessageWindowTable18.ToConfirm = false;

                        }
                        #endregion



                    }
                    //musi mieć jakąś tabelę do wydrukowania
                    //bo jak wciśnie się cancel to by próbował się drukować
                    if (TablesToGenerate.Any())
                    {
                        string path = @"C:\ProgramData\DASLSystems\LaboratoryApp\cert.txt";

                        Document document = InformationAboutGauge.CreateTable(TablesToGenerate);

                        MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

                        PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
                        renderer.Document = document;

                        renderer.RenderDocument();

                        // Save the document...

                        try
                        {
                            string[] s = File.ReadAllLines(path);

                            
                            string filename = s[0] + "\\tab.pdf";

                            {
                                renderer.PdfDocument.Save(filename);
                                // ...and start a viewer.
                                //Process.Start(filename);
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Nie wybrano folderu zapisu.");
                            File.AppendAllText(MainWindowViewModel.path, e.ToString());
                        }
                    }

                }

        }

        private void GenerateRaportExecute()
        {
            MessageWindowRaport = new NewWindowRaport(SelectedGauge);
            MessageWindowRaport.AboutGauge = (gauge)SelectedGauge;
            MessageWindowRaport.IsOpen = true;

            if (MessageWindowRaport.ToConfirm)
            {

                try
                {
                    LaboratoryEntities context = MainWindowViewModel.Context;
                    {
                        certificate cert = new certificate();
                        cert.gauge_id = SelectedGauge.gaugeId;
                        //cert.gauge = SelectedGauge;
                        cert.cost = MessageWindowRaport.Cost;
                        //DateTime dt = new DateTime();

                        DateTime dt = DateTime.Now;

                        //if(SelectedGauge.model_of_gauges.type.name == "Luksomierz")
                        //{
                        //    var tmp = (from c in Context.gauges )
                        //}

                        cert.date = dt;
                        cert.name = MessageWindowRaport.NumberOfCertificate; //MessageWindowRaport.NumberOfCertificate;
                        cert.authorized_by = MessageWindowRaport.Author;
                        try
                        {
                            context.certificates.Add(cert);
                            context.SaveChanges();
                            CollectionOfCertificate.Add(cert);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Nie udało się utworzyć certyfikatu w bazie.");
                            File.AppendAllText(MainWindowViewModel.path, e.ToString());
                        }



                    }
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        MainWindowViewModel.FileLog.WriteLine(String.Format("Encja typu \"{0}\" w stanie \"{1}\" ma następujące błędy walidacji:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        File.AppendAllText(MainWindowViewModel.path, String.Format("Encja typu \"{0}\" w stanie \"{1}\" ma następujące błędy walidacji:",
                         eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                             MainWindowViewModel.FileLog.WriteLine(String.Format("- Właściwość: \"{0}\", Błąd: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage));
                             File.AppendAllText(MainWindowViewModel.path, String.Format("- Właściwość: \"{0}\", Błąd: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage));
                        }
                    }
                }
                catch (Exception e)
                { 
                    File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }


                ///////////////////////////////////////////////////////
                NewWindowRaport raport;
                // Create a MigraDoc document
                raport = MessageWindowRaport;
                Document document = InformationAboutGauge.CreateDocument(raport);        
        
                //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
                MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
                renderer.Document = document;

                renderer.RenderDocument();

                // Save the document...

                string path = @"C:\ProgramData\DASLSystems\LaboratoryApp\cert.txt";

                try
                {
                    string[] s = File.ReadAllLines(path);

                    string filename = s[0] + "\\cer.pdf";
                    //filename.Replace('\\','-');

                    if (!string.IsNullOrEmpty(raport.Author) && !string.IsNullOrEmpty(raport.Temperature))
                    {
                        renderer.PdfDocument.Save(filename);
                        // ...and start a viewer.
                        //Process.Start(filename);
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Nie wybrano folderu zapisu.");
                    File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }



                /// <summary>
                /// Imports all pages from a list of documents.
                /// </summary>

                  // Get file names
                  string[] files = GetFiles();
 
                  // Open the output document
                  PdfDocument outputDocument = new PdfDocument();
 
                  // Iterate files
                  foreach (string file in files)
                  {
                    // Open the document to import pages from it.
                    PdfDocument inputDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import);
 
                    // Iterate pages
                    int count = inputDocument.PageCount;
                    for (int idx = 0; idx < count; idx++)
                    {
                      // Get the page from the external document...
                      PdfPage page = inputDocument.Pages[idx];
                      // ...and add it to the output document.
                      outputDocument.AddPage(page);
                    }
                  }

                  try
                  {

                      string[] s = File.ReadAllLines(path);

                      raport.NumberOfCertificate = raport.NumberOfCertificate.Replace('/', '-');
                      string filename3 = s[0] + "\\" + raport.NumberOfCertificate + ".pdf";

                      // Save the document...
                      //const string filename3 = "ConcatenatedDocument1_tempfile.pdf";
                      outputDocument.Save(filename3);
                      // ...and start a viewer.
                      Process.Start(filename3);

                }
                catch(Exception e)
                  {
                      File.AppendAllText(MainWindowViewModel.path, e.ToString());
                  }

                
            }

        }


        static string[] GetFiles()
        {
            string path = @"C:\ProgramData\DASLSystems\LaboratoryApp\cert.txt";

            string[] s = File.ReadAllLines(path);

            DirectoryInfo dirInfo = new DirectoryInfo(s[0]);
            FileInfo[] fileInfos = new FileInfo[2];
            fileInfos[1] = new FileInfo(s[0]+"\\tab.pdf");
            fileInfos[0] = new FileInfo(s[0] + "\\cer.pdf");

            ArrayList list = new ArrayList();
            foreach (FileInfo info in fileInfos)
            {
                // HACK: Just skip the protected samples file...
                if (info.Name.IndexOf("protected") == -1)
                    list.Add(info.FullName);
            }
            return (string[])list.ToArray(typeof(string));
        }

        public static Document CreateTable( ObservableCollection <NewWindowTableGenerate> raport)
        {
            Document document = new Document();
            document.Info.Title = "Załącznik do świadectwa wzorcowania";
            document.Info.Subject = "Załącznik do świadectwa wzorcowania";
            document.Info.Author = "DASL Systems";
            
            //zmieniona wielkość czcionki
            InformationAboutGauge.DefineStylesInAttachment(document);

            //takie samo - rozmiar strony itp...
            DefineContentSectionInAttachment(document);

            InformationAboutGauge.DefineTablesInAttachment(document, raport);

            return document;
        }
        
        public static Document CreateDocument(NewWindowRaport raport)
        {
            // Create a new MigraDoc document
            Document document = new Document();
            document.Info.Title = "Świadectwo wzorcowania";
            document.Info.Subject = "Świadectwo wzorcowania";
            document.Info.Author = "DASL Systems";


            InformationAboutGauge.DefineStyles(document);

            DefineContentSection(document);

            InformationAboutGauge.DefineTables(document, raport);

            return document;
        }

        public static void DefineStylesInAttachment(Document document)
        {
            // Get the predefined style Normal.
            MigraDoc.DocumentObjectModel.Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";
            style.Font.Size = 7;
            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.Black;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 10;
            style.ParagraphFormat.SpaceBefore = 2;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

            style = document.Styles["Heading2"];
            style.Font.Size = 10;
            style.Font.Bold = false;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 2;
            style.ParagraphFormat.SpaceAfter = 0;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Left;

            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 2;
            style.ParagraphFormat.SpaceAfter = 2;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            style.ParagraphFormat.AddTabStop("1.5cm", TabAlignment.Center);
            style.ParagraphFormat.SpaceAfter = 2;
            style.ParagraphFormat.SpaceBefore = 0;

            style = document.Styles[StyleNames.Footer];
            style.Font.Size = 10;
            style.Font.Color = Colors.Black;
            style.ParagraphFormat.AddTabStop("6cm", TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 1.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Black;
        }

        public static void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            MigraDoc.DocumentObjectModel.Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";
            style.Font.Size = 12;
            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading1"];
            style.Font.Name = "Tahoma";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Color = Colors.Black;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 10;
            style.ParagraphFormat.SpaceBefore = 2;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 2;
            style.ParagraphFormat.SpaceAfter = 0;

            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 2;
            style.ParagraphFormat.SpaceAfter = 2;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            style.ParagraphFormat.AddTabStop("1.5cm", TabAlignment.Center);
            style.ParagraphFormat.SpaceAfter = 2;
            style.ParagraphFormat.SpaceBefore = 0;

            style = document.Styles[StyleNames.Footer];
            style.Font.Size = 10;
            style.Font.Color = Colors.Black;
            style.ParagraphFormat.AddTabStop("6cm", TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 1.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Black;
        }

        /// <summary>
        /// Defines page setup, headers, and footers.
        /// </summary>
        static void DefineContentSection(Document document)
        {
            Section section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.PageFormat = PageFormat.A4;

            section.PageSetup.PageWidth = PageSizeConverter.ToSize(PageSize.A4).Width;
            section.PageSetup.PageHeight = PageSizeConverter.ToSize(PageSize.A4).Height;
            section.PageSetup.TopMargin = 100;
            section.PageSetup.BottomMargin = 60;
            section.PageSetup.LeftMargin = 20;
            section.PageSetup.RightMargin = 10;

            section.PageSetup.StartingNumber = 1;

            HeaderFooter header = section.Headers.Primary;

            Paragraph paragraph1 = section.Headers.FirstPage.AddParagraph();

            // Header image
            Image image = header.AddImage(@"header4.png");

            image.Height = "2.1cm";
            image.Width = "19.6cm";
            image.LockAspectRatio = true;
            image.RelativeVertical = RelativeVertical.Line;
            image.RelativeHorizontal = RelativeHorizontal.Margin;
            image.Top = ShapePosition.Top;
            image.Left = ShapePosition.Left;
            image.WrapFormat.Style = WrapStyle.Through;



            //section.AddImage("C:\\Users\\daniel\\Desktop\\dasllogo.png");

            //header = section.Headers.EvenPage;
            //header.AddParagraph("Even Page Header");

            // Create a paragraph with centered page number. See definition of style "Footer".
            Paragraph paragraph = new Paragraph();
            
            paragraph.AddTab();
            paragraph.AddFormattedText("Świadectwo składa się z 1 strony. Może być okazywane lub kopiowane tylko w całości.",TextFormat.Bold);
            paragraph.AddLineBreak();
            Image img = paragraph.AddImage(@"linia.jpg");
            img.Height = "0.1cm";
            img.Width = "19.6cm";
            img.LockAspectRatio = true;
            img.RelativeVertical = RelativeVertical.Line;
            img.RelativeHorizontal = RelativeHorizontal.Margin;
            img.Top = ShapePosition.Top;
            img.Left = ShapePosition.Left;
            img.WrapFormat.Style = WrapStyle.Through;

            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.AddText("DASL Systems ul.Wadowicka 8A, 30-415 Kraków, tel./fax : +48 12 29 42 001, lab@dasl.pl, www.dasl.pl");


            //paragraph.AddPageField();
            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());
        }

        static void DefineContentSectionInAttachment(Document document)
        {
            Section section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.PageFormat = PageFormat.A4;

            section.PageSetup.PageWidth = PageSizeConverter.ToSize(PageSize.A4).Width;
            section.PageSetup.PageHeight = PageSizeConverter.ToSize(PageSize.A4).Height;
            section.PageSetup.TopMargin = 100;
            section.PageSetup.BottomMargin = 110;
            section.PageSetup.LeftMargin = 20;
            section.PageSetup.RightMargin = 10;

            section.PageSetup.StartingNumber = 1;

            HeaderFooter header = section.Headers.Primary;


            Table table = section.Headers.Primary.AddTable();
            
            /////////////////////////////////////////////
            /////////////////////////////////////////////
            /////////////////////////////////////////////

            Column column = table.AddColumn();
            column.Width = "10cm";
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table.AddColumn();
            column.Width = "10cm";
            column.Format.Alignment = ParagraphAlignment.Right;

            table.Rows.Height = "1.7cm";
            Row row = table.AddRow();
            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;


            // Header image
            Image image = row.Cells[0].AddImage(@"header5.png");

            image.Height = "1.5cm";
            image.Width = "13cm";
            image.Top = ShapePosition.Top;
            image.Left = ShapePosition.Left;
            image.WrapFormat.Style = WrapStyle.Through;

            Paragraph paragraph = row.Cells[1].AddParagraph();

            paragraph.Format.Alignment = ParagraphAlignment.Right;

            paragraph.AddText("Strona ");
            paragraph.AddPageField();
            paragraph.AddText(" z ");
            paragraph.AddNumPagesField();

            //for clone content of header in first page to the others pages
            section.Headers.EvenPage.Add(table.Clone());


            paragraph = new Paragraph();

            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.AddText("\n              Data: " + DateTime.Now.ToString("dd'/'MM'/'yyyy") + " Podpis:");


            string lin = "";
            try
            {
                
                foreach (string str in File.ReadAllLines(MainWindowViewModel.usersApplication))
                {
                    lin = str;
                    if (str.Contains(MainWindowViewModel.nameAndSurname) && str.Contains("PATH"))
                    {
                        int index = str.IndexOf("PATH");
                        //+5 because we need only direct path without text : "PATH="
                        lin = str.Substring(index + 5);
                    }
                }

            }
            catch (Exception e)
            {
                File.AppendAllText(MainWindowViewModel.path, e.ToString());
            }

            //it could be problem when we change localization of stamp
            try
            {
                Image img2 = paragraph.AddImage(lin);
                img2.Height = "1.5cm";
                img2.Width = "3.2cm";
                //img.LockAspectRatio = true;
                //img.RelativeVertical = RelativeVertical.Line;
                //img.RelativeHorizontal = RelativeHorizontal.Margin;
                //img.Top = ShapePosition.Top;
                //img.Left = ShapePosition.Left;
                //img.WrapFormat.Style = WrapStyle.Through;
            }
            catch (Exception e)
            {
                File.AppendAllText(MainWindowViewModel.path, e.ToString());
            }





            paragraph.AddTab();
            Image img = paragraph.AddImage(@"linia.jpg");
            img.Height = "0.1cm";
            img.Width = "19.6cm";
            img.LockAspectRatio = true;
            img.RelativeVertical = RelativeVertical.Line;
            img.RelativeHorizontal = RelativeHorizontal.Margin;
            img.Top = ShapePosition.Top;
            img.Left = ShapePosition.Left;
            img.WrapFormat.Style = WrapStyle.Through;

            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.AddText("DASL Systems ul.Wadowicka 8A, 30-415 Kraków, tel./fax : +48 12 29 42 001, lab@dasl.pl, www.dasl.pl");


            //paragraph.AddPageField();
            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());
        }


        public static void DefineTables(Document document, NewWindowRaport raport)
        {
            DemonstrateAlignment(document, raport);
        }
        public static void DefineTablesInAttachment(Document document, ObservableCollection <NewWindowTableGenerate> raport)
        {
            DemonstrateAlignmentInAttachment(document, raport);
        }
        public static void DemonstrateAlignmentInAttachment(Document document, ObservableCollection<NewWindowTableGenerate> raports)
        {
            //document.LastSection.AddParagraph("Cell Alignment", "Heading2");
            foreach (var raport in raports)
            {
                document.LastSection.AddParagraph(raport.NameOfFile+"\n"+ raport.Title, "Heading2");
                
                Table table = document.LastSection.AddTable();
                table.Borders.Visible = true;
                //table.Format.Shading.Color = Colors.LavenderBlush;
                //table.Shading.Color = Colors.LightBlue;
                table.TopPadding = 5;
                table.BottomPadding = 5;

                Column column;
                Row row;

                foreach (var element in raport.ColumnNames)
                {
                    column = table.AddColumn();
                    column.Format.Alignment = ParagraphAlignment.Center;
                    table.Columns.Width = 56;
                }

                row = table.AddRow();
                for (int i = 0; i < raport.ColumnNames.Count(); i++)
                {
                    row.Cells[i].AddParagraph(raport.ColumnNames[i]);
                    row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
                }

                #region for pętla zapis tabel
                for (int i = 0; i < raport.Tab.Count(); i++)
                    {
                        row = table.AddRow();

                        if (raport is NewWindowTable4Generate)
                        {
                            row.Cells[0].AddParagraph(raport.Tab[i].ValueOfIsolation.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            if(raport.Tab[i].ColorResult.Color !=null && raport.Tab[i].ColorResult.Color == System.Windows.Media.Colors.LightGray )
                            {
                                row.Cells[1].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[1].AddParagraph(raport.Tab[i].MeasureValue.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].IdealValue.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[3].AddParagraph(raport.Tab[i].Difference.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[4].AddParagraph(raport.Tab[i].DownMeasureError.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].UpMeasureError.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].ErrorInValue.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[7].AddParagraph(raport.Tab[i].ErrorInPercent.ToString() + " %");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;

                        }

                        if (raport is NewWindowTable5Generate)
                        {

                            row.Cells[0].AddParagraph(raport.Tab[i].MeasureValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[1].AddParagraph(raport.Tab[i].IdealValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].ErrorRelativePercent.ToString() + "%");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[3].AddParagraph(raport.Tab[i].MaxDifference.ToString() + "%");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[4].AddParagraph(raport.Tab[i].RealValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].RecommendValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].ErrorInValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[7].AddParagraph(raport.Tab[i].ErrorInPercent.ToString() );
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;

                        }

                        if (raport is NewWindowTable9Generate)
                        {
                            row.Cells[0].AddParagraph(raport.Tab[i].Multiples.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            if (raport.Tab[i].ColorResult.Color != null && raport.Tab[i].ColorResult.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[1].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[1].AddParagraph(raport.Tab[i].MeasureValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].IdealValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[3].AddParagraph(raport.Tab[i].Difference.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[4].AddParagraph(raport.Tab[i].DownMeasureError.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].UpMeasureError.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].ErrorInValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[7].AddParagraph(raport.Tab[i].ErrorInPercent.ToString() + " %");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                        }
                        if (raport is NewWindowTable6Generate)
                        {
                            if (raport.Tab[i].ColorResult.Color != null && raport.Tab[i].ColorResult.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[1].Shading.Color = Colors.LightGray;
                            }

                            row.Cells[0].AddParagraph(raport.Tab[i].Multiples.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[1].AddParagraph(raport.Tab[i].MeasureValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].IdealValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[3].AddParagraph(raport.Tab[i].DownMeasureError.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[4].AddParagraph(raport.Tab[i].UpMeasureError.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].ErrorInValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].ErrorInPercent.ToString() + " %");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                        }
                        if (raport is NewWindowTable7Generate)
                        {
                            if (raport.Tab[i].ColorResult2.Color != null && raport.Tab[i].ColorResult2.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[0].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[0].AddParagraph(raport.Tab[i].MeasureValue.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[1].AddParagraph(raport.Tab[i].IdealValue.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].Difference.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;

                            if (raport.Tab[i].ColorResult3.Color != null && raport.Tab[i].ColorResult3.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[3].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[3].AddParagraph(raport.Tab[i].MeasureValue25V.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;

                            row.Cells[4].AddParagraph(raport.Tab[i].Difference25V.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].RelativeError.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].RelativeError25V.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[7].AddParagraph(raport.Tab[i].ErrorInValue.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[8].AddParagraph(raport.Tab[i].ErrorInPercent.ToString() + " %");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                        }

                        if (raport is NewWindowTable1Generate || raport is NewWindowTable2Generate || raport is NewWindowTable3Generate || raport is NewWindowTable17Generate)
                        {
                            if (raport.Tab[i].ColorResult.Color != null && raport.Tab[i].ColorResult.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[0].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[0].AddParagraph(raport.Tab[i].MeasureValue.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[1].AddParagraph(raport.Tab[i].IdealValue.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].Difference.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[3].AddParagraph(raport.Tab[i].DownMeasureError.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[4].AddParagraph(raport.Tab[i].UpMeasureError.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].ErrorInValue.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].ErrorInPercent.ToString() + " %");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                        }
                        if (raport is NewWindowTable10Generate)
                        {
                            if (raport.Tab[i].ColorResult.Color != null && raport.Tab[i].ColorResult.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[2].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[0].AddParagraph(raport.Tab[i].Multiples.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[1].AddParagraph(raport.Tab[i].SymulatedResistance.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].MeasureValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[3].AddParagraph(raport.Tab[i].ResistanceMeasure.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;

                            row.Cells[4].AddParagraph(raport.Tab[i].IdealValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].DownMeasureError.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].UpMeasureError.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[7].AddParagraph(raport.Tab[i].ErrorInValue.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[8].AddParagraph(raport.Tab[i].ErrorInPercent.ToString() + " %");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                        }

                        if (raport is NewWindowTable15Generate)
                        {
                            if (raport.Tab[i].ColorResultTab15_50V.Color != null && raport.Tab[i].ColorResultTab15_50V.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[2].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[0].AddParagraph(raport.Tab[i].Multiples.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[1].AddParagraph(raport.Tab[i].ResistanceOfGround.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].MeasureValue.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[3].AddParagraph(raport.Tab[i].DifferenceResistance.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;

                            if (raport.Tab[i].ColorResultTab15_25V.Color != null && raport.Tab[i].ColorResultTab15_25V.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[4].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[4].AddParagraph(raport.Tab[i].MeasureValue25V.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].DifferenceResistancev2.ToString() + raport.Tab[i].Prefix2);

                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].RelativeError.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[7].AddParagraph(raport.Tab[i].RelativeError25V.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[8].AddParagraph(raport.Tab[i].ErrorInValuev2.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[9].AddParagraph(raport.Tab[i].ErrorInPercentv2.ToString() + " %");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                        }


                        if (raport is NewWindowTable16Generate)
                        {
                            if (raport.Tab[i].ColorResultTab16_50V.Color != null && raport.Tab[i].ColorResultTab16_50V.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[2].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[0].AddParagraph(raport.Tab[i].Multiples.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[1].AddParagraph(raport.Tab[i].ResistanceOfGroundv2.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].MeasureValueTab16.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[3].AddParagraph(raport.Tab[i].DifferenceResist10m.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;

                            if (raport.Tab[i].ColorResultTab16_25V.Color != null && raport.Tab[i].ColorResultTab16_25V.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[4].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[4].AddParagraph(raport.Tab[i].MeasureValue25VTab16.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].DifferenceResist10mv2.ToString() + raport.Tab[i].Prefix2);

                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].RelativeError.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[7].AddParagraph(raport.Tab[i].RelativeError25V.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[8].AddParagraph(raport.Tab[i].ErrorInValuev3.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[9].AddParagraph(raport.Tab[i].ErrorInPercentv3.ToString() + " %");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                        }

                        if (raport is NewWindowTable18Generate)
                        {
                            if (raport.Tab[i].ColorResult.Color != null && raport.Tab[i].ColorResult.Color == System.Windows.Media.Colors.LightGray)
                            {
                                row.Cells[2].Shading.Color = Colors.LightGray;
                            }
                            row.Cells[0].AddParagraph(raport.Tab[i].Multiples.ToString() + raport.Tab[i].Prefix);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[1].AddParagraph(raport.Tab[i].ReferenceVoltage.ToString());
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[2].AddParagraph(raport.Tab[i].MeasureValue.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[3].AddParagraph(raport.Tab[i].IdealValue.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[4].AddParagraph(raport.Tab[i].Difference.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[5].AddParagraph(raport.Tab[i].DownMeasureError.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[6].AddParagraph(raport.Tab[i].UpMeasureError.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[7].AddParagraph(raport.Tab[i].ErrorInValue.ToString() + raport.Tab[i].Prefix2);
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                            row.Cells[8].AddParagraph(raport.Tab[i].ErrorInPercent.ToString() + " %");
                            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                        }

                    }
                #endregion

                table.Rows.Height = 15;
            }
        }

        //this one!!!! is a my table
        public static void DemonstrateAlignment(Document document, NewWindowRaport raport)
        {

            Table table = document.LastSection.AddTable();
            table.Borders.Visible = false;
            //table.Format.Shading.Color = Colors.LavenderBlush;
            //table.Shading.Color = Colors.LightBlue;
            table.TopPadding = 5;
            table.BottomPadding = 5;

            Column column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Left;

            table.Columns[0].Width = 120;
            table.Columns[1].Width = 430;

            table.Rows.Height = 20;



            Row row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
            row.Cells[0].AddParagraph("Zgłaszający: ");
            row.Cells[1].AddParagraph(raport.AboutGauge.client.name + " " + raport.AboutGauge.client.adress);

            if (raport.AboutGauge.office != null)
            {
                row = table.AddRow();
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].AddParagraph("Oddział: ");
                row.Cells[1].AddParagraph(raport.AboutGauge.office.name.ToString());
            }
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Producent przyrządu: ");
            row.Cells[1].AddParagraph(raport.AboutGauge.model_of_gauges.manufacturer_name.ToString());
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Model:");
            row.Cells[1].AddParagraph(raport.AboutGauge.model_of_gauges.model.ToString());
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Nr fabryczny: ");
            row.Cells[1].AddParagraph(raport.AboutGauge.serial_number.ToString());
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Zastosowanie urządzenia: ");
            row.Cells[1].AddParagraph(raport.AboutGauge.model_of_gauges.usage.description);
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Metoda wzorcowania: ");
            row.Cells[1].AddParagraph(raport.TheCalibrationMethod.ToString());


            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Odniesienie do wzorca państwowego: ");

            int numberOfLines = 0;
            foreach (calibrator calibrator in raport.CollectionOfCalibrators)
            {

                if (calibrator.IsChecked)
                {
                    raport.NationalPattern += calibrator.name + "\n";
                    numberOfLines++;
                }
                
            }
            if (numberOfLines < 6)
            {
                
                for(; numberOfLines < 6; numberOfLines++)
                {
                    raport.NationalPattern += "\n";
                }
            }
            row.Cells[1].AddParagraph(raport.NationalPattern.ToString());

            try
            {
                row = table.AddRow();
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].AddParagraph("Temperatura otoczenia: ");
                row.Cells[1].AddParagraph("(" + raport.Temperature.ToString() + "± 2) °C");
            }
            catch
            {
                MessageBox.Show("Podaj temperaturę.");
            }

            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Wilgotność powietrza: ");
            row.Cells[1].AddParagraph(raport.Humidity);
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Stwierdzenie zgodności: ");
            if (raport.SelectedCompatibility == "Zgodny")
            {
                row.Cells[1].AddParagraph("Na podstawie przeprowadzonych badań oraz ich wyników stwierdzono, że przyrząd spełnia deklarowane parametry użytkowe i funkcjinalne");
            }
            else
            {
                row.Cells[1].AddParagraph("Na podstawie przeprowadzonych badań oraz ich wyników stwierdzono, że przyrząd nie spełnia deklarowanych parametrów użytkowych i funkcjinalnych");
            }

            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Sprawdzone funkcje: ");

            foreach(function fun in raport.CollectionOfCheckedFunction)
            {
                if(fun.IsChecked)
                {  
                    raport.CheckedFunction += fun.name + ";";
                }
                LaboratoryEntities context = MainWindowViewModel.Context;

            }

                row.Cells[1].AddParagraph(raport.CheckedFunction);
                row = table.AddRow();
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].AddParagraph("Niepewność pomiaru: ");
                row.Cells[1].AddParagraph(raport.Uncertainty);
                row = table.AddRow();
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].AddParagraph("Nr świadectwa: ");
                row.Cells[1].AddParagraph(raport.NumberOfCertificate);
                row = table.AddRow();
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].AddParagraph("Data badania: ");
                row.Cells[1].AddParagraph(raport.DateSurvey);
                row = table.AddRow();
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].AddParagraph("Zalecenia dotyczące kolejnego wzorcowania: ");
                row.Cells[1].AddParagraph(raport.Recommendations);

            try
            { 
                row = table.AddRow();
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].AddParagraph("Pomiary zatwierdził: ");

                row.Cells[1].AddParagraph(raport.Author);

                string line = "";
                if (raport.PrintStamp == "Tak")
                {
                    try
                    {
                        foreach (string str in File.ReadAllLines(MainWindowViewModel.usersApplication))
                        {
                            line = str;
                            if (str.Contains(raport.Author) && str.Contains("PATH"))
                            {
                                int index = str.IndexOf("PATH");
                                //+5 because we need only direct path without text : "PATH="
                                line = str.Substring(index +5);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        File.AppendAllText(MainWindowViewModel.path, e.ToString());
                    }
                    
                    //it could be problem when we change localization of stamp
                    try
                    {
                        Image img = row.Cells[1].AddImage(line);
                        img.Height = "1.6cm";
                        img.Width = "3.2cm";
                        //img.LockAspectRatio = true;
                        //img.RelativeVertical = RelativeVertical.Line;
                        //img.RelativeHorizontal = RelativeHorizontal.Margin;
                        //img.Top = ShapePosition.Top;
                        //img.Left = ShapePosition.Left;
                        //img.WrapFormat.Style = WrapStyle.Through;
                    }
                    catch (Exception e)
                    {
                        File.AppendAllText(MainWindowViewModel.path, e.ToString());
                    }

                }

            }
            catch
            {
                MessageBox.Show("Podaj swoje dane do świadectwa.");
            }



        }
        #endregion


        private void EditGaugeExecute()
        {
            MessageWindowGauge = new NewWindowGauge();
            MessageWindowGauge.AboutGauge = (gauge)SelectedGauge;

            MessageWindowGauge.IsOpen = true;

            model_of_gauges ModelOfGauge = new model_of_gauges() {type = new type(), usage = new usage() };
            type TypeOfGauge = new type();

            if (MessageWindowGauge.ToConfirm)
            {
                try
                {
                    using (LaboratoryEntities context = new LaboratoryEntities())
                    {
                        //find selected gauge in database
                        var GaugeToEdit = (from g in context.gauges
                                           where g.gaugeId == SelectedGauge.gaugeId
                                           select g).FirstOrDefault();

                        ModelOfGauge = (from m in context.model_of_gauges where m.model == MessageWindowGauge.SelectedModel select m).FirstOrDefault();
                        

                        GaugeToEdit.model_of_gauges = ModelOfGauge;
                        GaugeToEdit.serial_number = MessageWindowGauge.AboutGauge.serial_number;
                        
                        context.SaveChanges();

                        SerialNumber = MessageWindowGauge.AboutGauge.serial_number;
                        Manufacturer = MessageWindowGauge.SelectedManufacturer;
                        Model = MessageWindowGauge.SelectedModel;
                        Description = ModelOfGauge.usage.description;

                        MainWindowViewModel.selectedNode.NameOfItem = MessageWindowGauge.SelectedModel +"["+ MessageWindowGauge.AboutGauge.serial_number+"]";

                        SelectedGauge.model_of_gauges = ModelOfGauge;
                        SelectedGauge.model_of_gauges.type = ModelOfGauge.type;
                        SelectedGauge.model_of_gauges.usage = ModelOfGauge.usage;

                        MainWindowViewModel.selectedNode = SelectedGauge;
                    }


                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        MessageBox.Show(String.Format("Encja typu \"{0}\" w stanie \"{1}\" ma następujące błędy walidacji:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        File.AppendAllText(MainWindowViewModel.path, String.Format("Encja typu \"{0}\" w stanie \"{1}\" ma następujące błędy walidacji:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show(String.Format("- Właściwość: \"{0}\", Błąd: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage));
                            File.AppendAllText(MainWindowViewModel.path, String.Format("Encja typu \"{0}\" w stanie \"{1}\" ma następujące błędy walidacji:",
                           eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    File.AppendAllText(MainWindowViewModel.path,e.ToString());
                }


            }



            else
            {

            }


        }
    }
}
