﻿using LaboratoryApp.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

        string line, ValueOfCell;
        double cons, percnt, impNum, idealVal;

        private void GenerateTables()
        {
            string q = "";
            //MessageWindowTable1 = new NewWindowTable1Generate();

            //string[] tables = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + Model + "$.txt");
            //foreach(string table in tables)
            {
                //
                {
                    string[] nameOfData = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + Model + ".txt");
                    

                    foreach (string nameOfTable in nameOfData)
                    {
                        if (nameOfTable.Contains("Table1"))
                        {
                            MessageWindowTable1 = new NewWindowTable1Generate();

                            int indexStart = nameOfTable.IndexOf("]");
                            //int indexStart = nameOfTable.IndexOf("\t");

                            q = nameOfTable.Substring(indexStart+1);



                            string[] dataToTable = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".txt");
                            foreach (string str in dataToTable)
                            {
                                line = str;

                                //read IdealValue
                                int index = str.IndexOf("\t");
                                ValueOfCell = str.Substring(0, index);
                                idealVal = Convert.ToDouble(ValueOfCell);

                                //read Percent
                                line = str.Substring(index + 1);
                                index = line.IndexOf("\t");
                                ValueOfCell = line.Substring(0, index);
                                percnt = Convert.ToDouble(ValueOfCell);

                                //read ImportantNumber
                                line = line.Substring(index + 1);
                                index = line.IndexOf("\t");
                                ValueOfCell = line.Substring(0, index);
                                impNum = Convert.ToDouble(ValueOfCell);

                                //read Constant
                                line = line.Substring(index + 1);
                                ValueOfCell = line;
                                cons = Convert.ToDouble(ValueOfCell);

                                Measure1 m = new Measure1();
                                m.ImportantNumber = impNum;
                                m.Constant = cons;
                                m.Percent = percnt;
                                m.IdealValue = idealVal;
                                MessageWindowTable1.Tab.Add(m);
                            }
                            MessageWindowTable1.IsOpen = true;
                            if (MessageWindowTable1.ToConfirm)
                            {
                                //NewWindowRaport raport;
                                // Create a MigraDoc document
                                //raport = MessageWindowRaport;
                                Document document = InformationAboutGauge.CreateTable(MessageWindowTable1);

                                //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
                                MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

                                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
                                renderer.Document = document;

                                renderer.RenderDocument();

                                // Save the document...

                                //string path = @"C:\ProgramData\DASLSystems\LaboratoryApp\cert.txt";

                                try
                                {
                                    //string[] s = File.ReadAllLines(path);

                                    //raport.NumberOfCertificate = raport.NumberOfCertificate.Replace('/', '-');
                                    string filename = @"C:\ProgramData\DASLSystems\LaboratoryApp\tables\abcd.pdf";
                                    //filename.Replace('\\','-');

                                    //if (!string.IsNullOrEmpty(raport.Author) && !string.IsNullOrEmpty(raport.Temperature))
                                    {
                                        renderer.PdfDocument.Save(filename);
                                        // ...and start a viewer.
                                        Process.Start(filename);
                                    }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Nie wybrano folderu zapisu.");
                                    File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                }
                            }
                            MessageWindowTable1.ToConfirm = false;
                        }

                        if (nameOfTable.Contains("Table2"))
                        {
                            MessageWindowTable2 = new NewWindowTable2Generate();

                            int indexTableData = nameOfTable.IndexOf("\t");
                            q = nameOfTable.Substring(indexTableData + 1);



                            string[] dataToTable = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\tables\" + q + ".txt");
                            foreach (string str in dataToTable)
                            {
                                line = str;

                                //read IdealValue
                                int index = str.IndexOf("\t");
                                ValueOfCell = str.Substring(0, index);
                                idealVal = Convert.ToDouble(ValueOfCell);

                                //read Percent
                                line = str.Substring(index + 1);
                                index = line.IndexOf("\t");
                                ValueOfCell = line.Substring(0, index);
                                percnt = Convert.ToDouble(ValueOfCell);

                                //read ImportantNumber
                                line = line.Substring(index + 1);
                                index = line.IndexOf("\t");
                                ValueOfCell = line.Substring(0, index);
                                impNum = Convert.ToDouble(ValueOfCell);

                                //read Constant
                                line = line.Substring(index + 1);
                                ValueOfCell = line;
                                cons = Convert.ToDouble(ValueOfCell);

                                Measure1 m = new Measure1();
                                m.ImportantNumber = impNum;
                                m.Constant = cons;
                                m.Percent = percnt;
                                m.IdealValue = idealVal;
                                MessageWindowTable2.Tab.Add(m);
                            }
                            MessageWindowTable2.IsOpen = true;
                            if (MessageWindowTable2.ToConfirm)
                            {

                            }
                            MessageWindowTable2.ToConfirm = false;
                        }
                    }
                    
                    
                }

                //if (table.Contains("Table2"))
                {
                   // MessageWindowTable2 = new NewWindowTable2Generate();

                    string[] s = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + Model + ".txt");

                    foreach (string str in s)
                    {
                        //line = str;

                        ////read IdealValue
                        //int index = str.IndexOf("\t");
                        //ValueOfCell = str.Substring(0, index);
                        //idealVal = Convert.ToDouble(ValueOfCell);

                        ////read Percent
                        //line = str.Substring(index + 1);
                        //index = line.IndexOf("\t");
                        //ValueOfCell = line.Substring(0, index);
                        //percnt = Convert.ToDouble(ValueOfCell);

                        ////read ImportantNumber
                        //line = line.Substring(index + 1);
                        //index = line.IndexOf("\t");
                        //ValueOfCell = line.Substring(0, index);
                        //impNum = Convert.ToDouble(ValueOfCell);

                        ////read Constant
                        //line = line.Substring(index + 1);
                        //ValueOfCell = line;
                        //cons = Convert.ToDouble(ValueOfCell);

                        //Measure1 m = new Measure1();
                        //m.ImportantNumber = impNum;
                        //m.Constant = cons;
                        //m.Percent = percnt;
                        //m.IdealValue = idealVal;
                       // MessageWindowTable2.Tab.Add(m);
                    }

                   // MessageWindowTable2.IsOpen = true;
                   // if (MessageWindowTable2.ToConfirm)
                    {

                    }
                   // MessageWindowTable2.ToConfirm = false;
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

                    raport.NumberOfCertificate = raport.NumberOfCertificate.Replace('/', '-');
                    string filename = s[0] + "\\" + raport.NumberOfCertificate + ".pdf";
                    //filename.Replace('\\','-');

                    if (!string.IsNullOrEmpty(raport.Author) && !string.IsNullOrEmpty(raport.Temperature))
                    {
                        renderer.PdfDocument.Save(filename);
                        // ...and start a viewer.
                        Process.Start(filename);
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show("Nie wybrano folderu zapisu.");
                    File.AppendAllText(MainWindowViewModel.path, e.ToString());
                }

            }

        }

        public static Document CreateTable(NewWindowTable1Generate raport)
        {
            Document document = new Document();
            document.Info.Title = "Załącznik do świadectwa wzorcowania";
            document.Info.Subject = "Załącznik do świadectwa wzorcowania";
            document.Info.Author = "DASL Systems";
            
            //zmieniona wielkość czcionki
            InformationAboutGauge.DefineStylesInAttachment(document);

            //takie samo - rozmiar strony itp...
            DefineContentSection(document);

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
            section.PageSetup.BottomMargin = 10;
            section.PageSetup.LeftMargin = 20;
            section.PageSetup.RightMargin = 10;

            section.PageSetup.StartingNumber = 1;

            HeaderFooter header = section.Headers.Primary;

            Paragraph paragraph1 = section.Headers.FirstPage.AddParagraph();

            //header.AddImage("C:\\Users\\daniel\\Desktop\\dasllogo.png");
            //header.AddParagraph("Laboratorium Przyrządów Pomiarowych\nŚWIADECTWO WZORCOWANIA");
            //Table t = new Table();
            //header.AddTable();

            //paragraph1.AddText("\nCreated on ");
            //paragraph1.AddFormattedText(CreateDate, TextFormat.Bold);
            //paragraph1.AddFormattedText("\n" + Properties.Length, TextFormat.Bold);
            //paragraph1.AddText(" Records");
            // paragraph1.AddFormattedText("\n" + TurnoverPercent, TextFormat.Bold);
            ////paragraph1.AddText(" Turnover Rate");
            //paragraph1.Format.Font.Size = 10;
            //paragraph1.Format.Alignment = ParagraphAlignment.Right;
            //header.Section.AddParagraph("Laboratorium Przyrządów Pomiarowych\nŚWIADECTWO WZORCOWANIA");
            //header.AddParagraph("Laboratorium Przyrządów Pomiarowych\nŚWIADECTWO WZORCOWANIA");

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

        public static void DefineTables(Document document, NewWindowRaport raport)
        {
            DemonstrateAlignment(document, raport);
        }
        public static void DefineTablesInAttachment(Document document, NewWindowTable1Generate raport)
        {
            DemonstrateAlignmentInAttachment(document, raport);
        }
        public static void DemonstrateAlignmentInAttachment(Document document, NewWindowTable1Generate raport)
        {
            //document.LastSection.AddParagraph("Cell Alignment", "Heading2");

            document.LastSection.AddParagraph("Nazwa tabeli", "Heading2"); 

            Table table = document.LastSection.AddTable();
            table.Borders.Visible = true;
            //table.Format.Shading.Color = Colors.LavenderBlush;
            //table.Shading.Color = Colors.LightBlue;
            table.TopPadding = 5;
            table.BottomPadding = 5;

            Column column;
            Row row;          

            foreach(var element in raport.ColumnNames)
            {
                column = table.AddColumn();
                column.Format.Alignment = ParagraphAlignment.Center;
                table.Columns.Width = 50;
            }


            row = table.AddRow();
            for (int i = 0; i < raport.ColumnNames.Count(); i++)
            {
                row.Cells[i].AddParagraph(raport.ColumnNames[i]);
                row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
            }

            
                
            for (int i = 0; i < raport.Tab.Count(); i++)
            {
                row = table.AddRow();

                row.Cells[0].AddParagraph(raport.Tab[i].MeasureValue.ToString());
                row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                row.Cells[1].AddParagraph(raport.Tab[i].IdealValue.ToString());
                row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                row.Cells[2].AddParagraph(raport.Tab[i].Difference.ToString());
                row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                row.Cells[3].AddParagraph(raport.Tab[i].DownMeasureError.ToString());
                row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
                row.Cells[4].AddParagraph(raport.Tab[i].UpMeasureError.ToString());
                row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;

            }
            


            table.Rows.Height = 15;



            //Row row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
            //row.Cells[0].AddParagraph("aaaaa");
            //row.Cells[1].AddParagraph("bbbb");

            //if (raport.AboutGauge.office != null)
            //{
            //    row = table.AddRow();
            //    row.Cells[0].Format.Font.Bold = true;
            //    row.Cells[0].AddParagraph("Oddział: ");
            //    row.Cells[1].AddParagraph(raport.AboutGauge.office.name.ToString());
            //}
            //row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].AddParagraph("Producent przyrządu: ");
            //row.Cells[1].AddParagraph(raport.AboutGauge.model_of_gauges.manufacturer_name.ToString());
            //row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].AddParagraph("Model:");
            //row.Cells[1].AddParagraph(raport.AboutGauge.model_of_gauges.model.ToString());
            //row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].AddParagraph("Nr fabryczny: ");
            //row.Cells[1].AddParagraph(raport.AboutGauge.serial_number.ToString());
            //row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].AddParagraph("Zastosowanie urządzenia: ");
            //row.Cells[1].AddParagraph(raport.AboutGauge.model_of_gauges.usage.description);
            //row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].AddParagraph("Metoda wzorcowania: ");
            //row.Cells[1].AddParagraph(raport.TheCalibrationMethod.ToString());


            //row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].AddParagraph("Odniesienie do wzorca państwowego: ");

            //int numberOfLines = 0;
            //foreach (calibrator calibrator in raport.CollectionOfCalibrators)
            //{

            //    if (calibrator.IsChecked)
            //    {
            //        raport.NationalPattern += calibrator.name + "\n";
            //        numberOfLines++;
            //    }

            //}
            //if (numberOfLines < 6)
            //{

            //    for (; numberOfLines < 6; numberOfLines++)
            //    {
            //        raport.NationalPattern += "\n";
            //    }
            //}
            //row.Cells[1].AddParagraph(raport.NationalPattern.ToString());

            //try
            //{
            //    row = table.AddRow();
            //    row.Cells[0].Format.Font.Bold = true;
            //    row.Cells[0].AddParagraph("Temperatura otoczenia: ");
            //    row.Cells[1].AddParagraph("(" + raport.Temperature.ToString() + "± 2) °C");
            //}
            //catch
            //{
            //    MessageBox.Show("Podaj temperaturę.");
            //}

            //row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].AddParagraph("Wilgotność powietrza: ");
            //row.Cells[1].AddParagraph(raport.Humidity);
            //row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].AddParagraph("Stwierdzenie zgodności: ");
            //if (raport.SelectedCompatibility == "Zgodny")
            //{
            //    row.Cells[1].AddParagraph("Na podstawie przeprowadzonych badań oraz ich wyników stwierdzono, że przyrząd spełnia deklarowane parametry użytkowe i funkcjinalne");
            //}
            //else
            //{
            //    row.Cells[1].AddParagraph("Na podstawie przeprowadzonych badań oraz ich wyników stwierdzono, że przyrząd nie spełnia deklarowanych parametrów użytkowych i funkcjinalnych");
            //}

            //row = table.AddRow();
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].AddParagraph("Sprawdzone funkcje: ");

            //foreach (function fun in raport.CollectionOfCheckedFunction)
            //{
            //    if (fun.IsChecked)
            //    {
            //        raport.CheckedFunction += fun.name + ";";
            //    }
            //    LaboratoryEntities context = MainWindowViewModel.Context;

            //}
            //try
            //{
            //    row.Cells[1].AddParagraph(raport.CheckedFunction);
            //    row = table.AddRow();
            //    row.Cells[0].Format.Font.Bold = true;
            //    row.Cells[0].AddParagraph("Niepewność pomiaru: ");
            //    row.Cells[1].AddParagraph(raport.Uncertainty);
            //    row = table.AddRow();
            //    row.Cells[0].Format.Font.Bold = true;
            //    row.Cells[0].AddParagraph("Nr świadectwa: ");
            //    row.Cells[1].AddParagraph(raport.NumberOfCertificate);
            //    row = table.AddRow();
            //    row.Cells[0].Format.Font.Bold = true;
            //    row.Cells[0].AddParagraph("Data badania: ");
            //    row.Cells[1].AddParagraph(raport.DateSurvey);
            //    row = table.AddRow();
            //    row.Cells[0].Format.Font.Bold = true;
            //    row.Cells[0].AddParagraph("Zalecenia dotyczące kolejnego wzorcowania: ");
            //    row.Cells[1].AddParagraph(raport.Recommendations);
            //}
            //catch
            //{
            //    MessageBox.Show("Brak danych miernika");
            //}
            //try
            //{
            //    row = table.AddRow();
            //    row.Cells[0].Format.Font.Bold = true;
            //    row.Cells[0].AddParagraph("Pomiary zatwierdził: ");

            //    row.Cells[1].AddParagraph(raport.Author);

            //    string line = "";
            //    if (raport.PrintStamp == "Tak")
            //    {
            //        try
            //        {
            //            foreach (string str in File.ReadAllLines(MainWindowViewModel.usersApplication))
            //            {
            //                line = str;
            //                if (str.Contains(raport.Author) && str.Contains("PATH"))
            //                {
            //                    int index = str.IndexOf("PATH");
            //                    //+5 because we need only direct path without text : "PATH="
            //                    line = str.Substring(index + 5);
            //                }
            //            }

            //        }
            //        catch (Exception e)
            //        {
            //            File.AppendAllText(MainWindowViewModel.path, e.ToString());
            //        }

            //        //it could be problem when we change localization of stamp
            //        try
            //        {
            //            Image img = row.Cells[1].AddImage(line);
            //            img.Height = "1.5cm";
            //            img.Width = "1.5cm";
            //            //img.LockAspectRatio = true;
            //            //img.RelativeVertical = RelativeVertical.Line;
            //            //img.RelativeHorizontal = RelativeHorizontal.Margin;
            //            //img.Top = ShapePosition.Top;
            //            //img.Left = ShapePosition.Left;
            //            //img.WrapFormat.Style = WrapStyle.Through;
            //        }
            //        catch (Exception e)
            //        {
            //            File.AppendAllText(MainWindowViewModel.path, e.ToString());
            //        }

            //    }

            //}
            //catch
            //{
            //    MessageBox.Show("Podaj swoje dane do świadectwa.");
            //}



        }

        //this one!!!! is a my table
        public static void DemonstrateAlignment(Document document, NewWindowRaport raport)
        {
            //document.LastSection.AddParagraph("Cell Alignment", "Heading2");

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
            try
            {
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
            }
            catch
            {
                MessageBox.Show("Brak danych miernika");
            }
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
                        img.Height = "1.5cm";
                        img.Width = "1.5cm";
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























            // MessageWindowGauge = new NewWindowGauge();//{ AboutGauge = new gauge() { model_of_gauges = new model_of_gauges() } };
            // MessageWindowGauge.AboutGauge = (gauge)SelectedGauge;


            // //fill data in edit window 
            // //MessageWindowGauge.AboutGauge.serial_number = SerialNumber;
            //// MessageWindowGauge.AboutGauge.model_of_gauges = ModelOfGaugeItem;
            // //MessageWindowGauge.Manufacturer = ModelOfGaugeItem.manufacturer_name;
            // //MessageWindowGauge.SelectedModel = ModelOfGaugeItem.model;


            // MessageWindowGauge.IsOpen = true;

            // if(MessageWindowGauge.ToConfirm)
            // {
            //     using (LaboratoryEntities Context = new LaboratoryEntities())
            //     {
            //         var gaugeToEdit = (from g in Context.gauges where g.gaugeId == SelectedGauge.gaugeId select g).FirstOrDefault();

            //         if(!String.IsNullOrEmpty(MessageWindowGauge.AboutGauge.model_of_gauges.model.ToString())
            //            && !String.IsNullOrEmpty(MessageWindowGauge.AboutGauge.model_of_gauges.manufacturer_name.ToString())
            //            && !String.IsNullOrEmpty(MessageWindowGauge.AboutGauge.serial_number.ToString()))

            //         {
            //             var ModelOfGaugeToAdd = (from m in Context.model_of_gauges where m.model == MessageWindowGauge.SelectedModel select m).FirstOrDefault();
            //             gaugeToEdit.model_of_gauges = ModelOfGaugeToAdd;

            //             gaugeToEdit.serial_number = MessageWindowGauge.AboutGauge.serial_number;
            //             //gaugeToEdit.model_of_gauges.manufacturer_name = ModelOfGaugeToAdd.manufacturer_name;
            //             //gaugeToEdit.model_of_gauges.model = ModelOfGaugeToAdd.model;



            //             Context.SaveChanges();

            //             //set new data in main window view
            //             SerialNumber = MessageWindowGauge.AboutGauge.serial_number;
            //             ModelOfGaugeItem.manufacturer_name = MessageWindowGauge.Manufacturer;
            //             ModelOfGaugeItem.model = MessageWindowGauge.SelectedModel;
            //             //ModelOfGaugeItem.usage.description = gaugeToEdit.model_of_gauges.usage.description;

            //             MainWindowViewModel.selectedNode.NameOfItem = MessageWindowGauge.AboutGauge.model_of_gauges.model;
            //             MainWindowViewModel.selectedNode = SelectedGauge;
            //         }
            //     }
            //     MessageWindowGauge.ToConfirm = false;

            // }


        }
    }
}
