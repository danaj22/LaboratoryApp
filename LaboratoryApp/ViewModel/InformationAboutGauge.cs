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
                OnPropertyChanged("SerialNumer");
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

        private office office;
        public office Office
        {
            get { return office; }
            set
            { 
                office = value;
                OnPropertyChanged("Office");
            }
        }


        List<string> collectionOfManufacturers;
        public List<string> CollectionOfManufacturers
        {
            get { return this.collectionOfManufacturers; }
            set 
            {
                collectionOfManufacturers = value;
                OnPropertyChanged("CollectionOfManufacturers");
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

        private void InitializeCollectionOfManufacturers()
        {
            LaboratoryEntities context = new LaboratoryEntities();
            CollectionOfManufacturers = (from m in context.model_of_gauges select m.manufacturer_name).Distinct().ToList();
        }


        private string selectedManufacturer;
        public string SelectedManufacturer
        {
            get { return selectedManufacturer; }
            set 
            { 
                selectedManufacturer = value;
                InitializeCollectionOfModels();
                OnPropertyChanged("SelectedManufacturer");
            }
        }

        private void InitializeCollectionOfModels()
        {
            if(SelectedManufacturer != null)
            {
                LaboratoryEntities context = new LaboratoryEntities();               
                CollectionOfModels = (from g in context.model_of_gauges where g.manufacturer_name == SelectedManufacturer select g.model).ToList(); 
            }
        }


        List<string> collectionOfModels;
        public List<string> CollectionOfModels
        {
            get { return collectionOfModels; }
          set 
          { 
              collectionOfModels = value;
              OnPropertyChanged("CollectionOfModels");
          }
        }
        
        private string selectedModel;
        public string SelectedModel
        {
            get { return selectedModel; }
            set
            {
                selectedModel = value;
                OnPropertyChanged("SelectedModel");
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

        public InformationAboutGauge()
        {
            InitializeCollectionOfManufacturers();
            //collectionOfModels = new List<string>();
            //collectionOfManufacturers = new List<string>();
        }


        public ICommand DeleteGaugeCommand
        { get { return new SimpleRelayCommand(DeleteGaugeExecute); } }

        private void DeleteGaugeExecute()
        {
            var result = MessageBox.Show("Czy na pewno chcesz usunąć bezzwłocznie i definitywnie ten miernik?", "Usuwanie miernika", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                LaboratoryEntities context = new LaboratoryEntities();
                //delete selected client
                var gaugeToDelete = //(gauge)MainWindowViewModel.selectedNode;
                                     (from g in context.gauges
                                     where g.gaugeId == this.GaugeId
                                     select g).FirstOrDefault();

                context.gauges.Remove(gaugeToDelete);
                context.SaveChanges();
                MainWindowViewModel.LoadView();
                //gauge MainWindowViewModel.selectedNode;
                
            }
        }
        public ICommand EditGaugeCommand
        { get { return new SimpleRelayCommand(EditGaugeExecute); } }


        public ICommand GenerateRaportCommand
        { get { return new SimpleRelayCommand(GenerateRaportExecute); } }

        private void GenerateRaportExecute()
        
        {
            MessageWindowRaport = new NewWindowRaport() { AboutGauge = new InformationAboutGauge() };
            MessageWindowRaport.AboutGauge = this;
            MessageWindowRaport.IsOpen = true;


            //// Create a new PDF document
            //PdfDocument document = new PdfDocument();
            //document.Info.TitleOfItem = "Created with PDFsharp";

            //// Create an empty page
            //PdfPage page = document.AddPage();

            //// Get an XGraphics object for drawing
            //XGraphics gfx = XGraphics.FromPdfPage(page);

            //// Create a font
            //XFont font = new XFont("Verdana", 10, XFontStyle.BoldItalic);

            //XRect rect = new XRect(40, 100, 250, 220);
            //XRect rect2 = new XRect(0, 0, 250, 220);
            //// generate random number
            //Random rnd = new Random();
            //int month = rnd.Next(1, 13); // creates a number between 1 and 12
            //int dice = rnd.Next(1, 7); // creates a number between 1 and 6
            //int card = rnd.Next(52); // creates a number between 0 and 51

            //gfx.DrawRectangle(XBrushes.SeaShell, rect);
            //gfx.DrawRectangle(XBrushes.BurlyWood, rect2);
            //// Draw the text
            //gfx.DrawString(MessageWindowRaport.AboutGauge.ModelOfGaugeItem.manufacturer_name, font, XBrushes.Black, rect, XStringFormats.Center);

            //gfx.DrawString(MessageWindowRaport.AboutGauge.ModelOfGaugeItem.model, font, XBrushes.Black, rect2, XStringFormats.Center);

            //gfx.DrawString(MessageWindowRaport.AboutGauge.ModelOfGaugeItem.usage.description, font, XBrushes.Black, rect, XStringFormats.Center);

            

            //// Save the document...
            //string filename = "HelloWorld.pdf";
            //filename = month.ToString() + filename;
            //document.Save(filename);
            //// ...and start a viewer.
            //Process.Start(filename);


            if (MessageWindowRaport.ToConfirm)
            {
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
                renderer.PdfDocument.Save(filename);
                // ...and start a viewer.
                Process.Start(filename);
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
            header.AddParagraph("Laboratorium Przyrządów Pomiarowych\nŚWIADECTWO WZORCOWANIA");
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
            Image image = header.AddImage("C:\\Users\\daniel\\Desktop\\dasllogo.png");
            image.Height = "2.5cm";
            image.LockAspectRatio = true;
            image.RelativeVertical = RelativeVertical.Line;
            image.RelativeHorizontal = RelativeHorizontal.Margin;
            image.Top = ShapePosition.Top;
            image.Left = ShapePosition.Inside;
            image.WrapFormat.Style = WrapStyle.Through;
            

            //section.AddImage("C:\\Users\\daniel\\Desktop\\dasllogo.png");
            
            //header = section.Headers.EvenPage;
            //header.AddParagraph("Even Page Header");

            // Create a paragraph with centered page number. See definition of style "Footer".
            Paragraph paragraph = new Paragraph();
            
            paragraph.AddTab();
            paragraph.AddText("Świadectwo składa się z 1 strony. Może być okazywane lub kopiowane tylko w całości.\n");


            paragraph.AddPageField();
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
            table.Format.Shading.Color = Colors.LavenderBlush;
            table.Shading.Color = Colors.LightBlue;
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
            row.Cells[1].AddParagraph(raport.AboutGauge.Office.client.name + " " + raport.AboutGauge.Office.client.adress);
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Oddział: ");
            row.Cells[1].AddParagraph(raport.AboutGauge.Office.name.ToString());
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Producent przyrządu: ");
            row.Cells[1].AddParagraph(raport.AboutGauge.ModelOfGaugeItem.manufacturer_name.ToString());
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Model:");
            row.Cells[1].AddParagraph(raport.AboutGauge.ModelOfGaugeItem.model.ToString());
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Nr fabryczny: ");
            row.Cells[1].AddParagraph(raport.AboutGauge.SerialNumber.ToString());
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Zastosowanie urządzenia: ");
            row.Cells[1].AddParagraph(raport.AboutGauge.ModelOfGaugeItem.usage.description);
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Metoda wzorcowania: ");
            row.Cells[1].AddParagraph(raport.TheCalibrationMethod.ToString());
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Odniesienie do wzorca państwowego: ");
            row.Cells[1].AddParagraph(raport.NationalPattern.ToString());
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Temperatura otoczenia: ");
            row.Cells[1].AddParagraph(raport.Temperature.ToString());
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
            row = table.AddRow();
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Pomiary zatwierdził: ");
            row.Cells[1].AddParagraph(raport.Author);
            
            
        }
 

        private void EditGaugeExecute()
        {
            
            MessageWindowGauge = new NewWindowGauge() { AboutGauge = new InformationAboutGauge() { ModelOfGaugeItem = new model_of_gauges() } };

            MessageWindowGauge.AboutGauge.SerialNumber = SerialNumber;
            MessageWindowGauge.AboutGauge.SelectedManufacturer = ModelOfGaugeItem.manufacturer_name;
            MessageWindowGauge.AboutGauge.SelectedModel = ModelOfGaugeItem.model;


            MessageWindowGauge.IsOpen = true;

            if(MessageWindowGauge.ToConfirm)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    var gaugeToEdit = (from g in context.gauges where g.gaugeId == this.GaugeId select g).FirstOrDefault();

                    if(!String.IsNullOrEmpty(MessageWindowGauge.AboutGauge.SelectedManufacturer)
                       && !String.IsNullOrEmpty(MessageWindowGauge.AboutGauge.SelectedModel)
                       && !String.IsNullOrEmpty(MessageWindowGauge.AboutGauge.SerialNumber.ToString()))
                    
                    {
                        gaugeToEdit.serial_number = MessageWindowGauge.AboutGauge.SerialNumber;
                        GaugeIdToAdd = (from m in context.model_of_gauges where m.model == MessageWindowGauge.AboutGauge.SelectedModel select m.model_of_gaugeId).FirstOrDefault();
                        gaugeToEdit.model_of_gauges.model_of_gaugeId = GaugeIdToAdd;

                        context.SaveChanges();

                        //set new data in main window view
                        this.SerialNumber = MessageWindowGauge.AboutGauge.SerialNumber;
                        this.ModelOfGaugeItem.manufacturer_name = gaugeToEdit.model_of_gauges.manufacturer_name;
                        this.ModelOfGaugeItem.model = gaugeToEdit.model_of_gauges.model;
                        this.ModelOfGaugeItem.usage.description = gaugeToEdit.model_of_gauges.usage.description;
                    }
                }
                MessageWindowGauge.ToConfirm = false;
                MainWindowViewModel.LoadView();
            
            }
            else
            {

            }

        }
    }
}
