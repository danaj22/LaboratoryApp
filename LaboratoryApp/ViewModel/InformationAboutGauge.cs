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

        private int serialNumber;
        public int SerialNumber
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

        #endregion


        public InformationAboutGauge(object SelectedNode)
        {
            SelectedGauge = (gauge) SelectedNode;
            //InitializeCollectionOfManufacturers();

            //ModelOfGaugeItem = new model_of_gauges();
            SerialNumber = SelectedGauge.serial_number;
            Manufacturer = SelectedGauge.model_of_gauges.manufacturer_name;
            Model = SelectedGauge.model_of_gauges.model;
            Description = SelectedGauge.model_of_gauges.usage.description;
            
        }
        public InformationAboutGauge()
        { 
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
                            MessageBox.Show(String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State));
                            foreach (var ve in eve.ValidationErrors)
                            {
                                MessageBox.Show(String.Format("- Property: \"{0}\", Error: \"{1}\"",
                                    ve.PropertyName, ve.ErrorMessage));
                            }
                        }
                    }
                    catch (Exception e)
                    { MessageBox.Show(e.ToString()); }


                    //MainWindowViewModel.rootElement.Children[MainWindowViewModel.selectedNode]
                    //MainWindowViewModel.LoadView();
                    //gauge MainWindowViewModel.selectedNode;
                }
                
            }
        }
        public ICommand EditGaugeCommand
        { get { return new SimpleRelayCommand(EditGaugeExecute); } }

        #region create raport pdf 
        public ICommand GenerateRaportCommand
        { get { return new SimpleRelayCommand(GenerateRaportExecute); } }

        private void GenerateRaportExecute()
        
        {
            MessageWindowRaport = new NewWindowRaport();
            MessageWindowRaport.AboutGauge = (gauge) SelectedGauge;
            MessageWindowRaport.IsOpen = true;


            if (MessageWindowRaport.ToConfirm)
            {

                try
                {
                    LaboratoryEntities context = new LaboratoryEntities();
                    {
                        certificate cert = new certificate();
                        cert.gauge_id = SelectedGauge.gaugeId;
                        //cert.gauge = SelectedGauge;
                        cert.cost = MessageWindowRaport.Cost;
                        //DateTime dt = new DateTime();

                        DateTime dt = DateTime.Today;

                        cert.date = dt;
                        cert.name = "bbb"; //MessageWindowRaport.NumberOfCertificate;
                        cert.authorized_by = "aaa";

                        context.certificates.Add(cert);
                        context.SaveChanges();

                    }
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        MessageBox.Show(String.Format("Encja typu \"{0}\" w stanie \"{1}\" ma następujące błędy walidacji:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show(String.Format("- Właściwość: \"{0}\", Błąd: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage));
                        }
                    }
                }
                catch (Exception e)
                { MessageBox.Show(e.ToString()); }


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
                string filename = "1HelloMigraDoc.pdf";
                
                if (!string.IsNullOrEmpty(raport.Author) && !string.IsNullOrEmpty(raport.Temperature))
                {
                    renderer.PdfDocument.Save(filename);
                    // ...and start a viewer.
                    Process.Start(filename);
                }

                

            }
 
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

        public static void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            MigraDoc.DocumentObjectModel.Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Times New Roman";

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
            style.ParagraphFormat.SpaceBefore = 2;

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

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
            section.PageSetup.BottomMargin = 5;

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
            Image image = header.AddImage("C:\\Users\\daniel\\Desktop\\header2.png");
            
            image.Height = "2.1cm";
            image.Width = "17.6cm";
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
            paragraph.AddText("Świadectwo składa się z 1 strony. Może być okazywane lub kopiowane tylko w całości.\nDASL Systems ul.Wadowicka 8A, 30-415 Kraków, tel./fax : +48 12 29 42 001, lab@dasl.pl, www.dasl.pl");


            //paragraph.AddPageField();
            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());
        }

        public static void DefineTables(Document document, NewWindowRaport raport)
        {
           // Paragraph paragraph = document.LastSection.AddParagraph("Laboratorium Przyrządów Pomiarowych\n", "Heading1");
            //paragraph.AddText("ŚWIADECTWO WZORCOWANIA");// = document.LastSection.AddParagraph("ŚWIADECTWO WZORCOWANIA", "Heading1");
            //paragraph.AddBookmark("Tables");

            DemonstrateAlignment(document, raport);           
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

            table.Columns[0].Width = 100;
            table.Columns[1].Width = 400;

            //column = table.AddColumn();
            //column.Format.Alignment = ParagraphAlignment.Right;

            table.Rows.Height = 20;

            Row row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
            row.Cells[0].AddParagraph("Zgłaszający: ");
            row.Cells[1].AddParagraph(raport.AboutGauge.Parent.NameOfItem + " " /*+ raport.AboutGauge.client.adress*/);
            
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
            row.Cells[1].AddParagraph(raport.SelectedCompatibility);
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Sprawdzone funkcje: ");
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

            model_of_gauges ModelOfGauge = new model_of_gauges();

            if(MessageWindowGauge.ToConfirm)
            {
                try
                {
                    using(LaboratoryEntities context = new LaboratoryEntities())
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

                        MainWindowViewModel.selectedNode.NameOfItem = MessageWindowGauge.SelectedModel;

                        SelectedGauge.model_of_gauges = ModelOfGauge;

                        MainWindowViewModel.selectedNode = SelectedGauge;
                  }
                
                
            }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        MessageBox.Show(String.Format("Encja typu \"{0}\" w stanie \"{1}\" ma następujące błędy walidacji:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show(String.Format("- Właściwość: \"{0}\", Błąd: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage));
                        }
                    }
                }
                catch (Exception e)
                { MessageBox.Show(e.ToString()); }
            
               
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
           //     using (LaboratoryEntities context = new LaboratoryEntities())
           //     {
           //         var gaugeToEdit = (from g in context.gauges where g.gaugeId == SelectedGauge.gaugeId select g).FirstOrDefault();

           //         if(!String.IsNullOrEmpty(MessageWindowGauge.AboutGauge.model_of_gauges.model.ToString())
           //            && !String.IsNullOrEmpty(MessageWindowGauge.AboutGauge.model_of_gauges.manufacturer_name.ToString())
           //            && !String.IsNullOrEmpty(MessageWindowGauge.AboutGauge.serial_number.ToString()))
                    
           //         {
           //             var ModelOfGaugeToAdd = (from m in context.model_of_gauges where m.model == MessageWindowGauge.SelectedModel select m).FirstOrDefault();
           //             gaugeToEdit.model_of_gauges = ModelOfGaugeToAdd;

           //             gaugeToEdit.serial_number = MessageWindowGauge.AboutGauge.serial_number;
           //             //gaugeToEdit.model_of_gauges.manufacturer_name = ModelOfGaugeToAdd.manufacturer_name;
           //             //gaugeToEdit.model_of_gauges.model = ModelOfGaugeToAdd.model;

                        

           //             context.SaveChanges();

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
