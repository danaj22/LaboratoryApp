using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        
        private Nullable<int> modalOfGaugeId;
        public Nullable<int> ModalOfGaugeId
        {
            get { return modalOfGaugeId; }
            set 
            {
                modalOfGaugeId = value;
                OnPropertyChanged("ModalOfGaugeId");
            }
        }

        private gauge gauge;
        public virtual gauge Gauge
        {
            get { return gauge; }
            set 
            { 
                gauge = value;
                OnPropertyChanged("Gauge");
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
            CollectionOfManufacturers = (from m in context.gauges select m.manufacturer_name).Distinct().ToList();
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
                CollectionOfModels = (from g in context.gauges where g.manufacturer_name == SelectedManufacturer select g.model).ToList(); 
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

        private int? gaugeIdToAdd;

        public int? GaugeIdToAdd
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
                var productToDelete = (from p in context.products
                                      where p.productId == this.GaugeId
                                      select p).FirstOrDefault();

                context.products.Remove(productToDelete);
                context.SaveChanges();
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
            //document.Info.Title = "Created with PDFsharp";

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
            //gfx.DrawString(MessageWindowRaport.AboutGauge.Gauge.manufacturer_name, font, XBrushes.Black, rect, XStringFormats.Center);

            //gfx.DrawString(MessageWindowRaport.AboutGauge.Gauge.model, font, XBrushes.Black, rect2, XStringFormats.Center);

            //gfx.DrawString(MessageWindowRaport.AboutGauge.Gauge.usage.description, font, XBrushes.Black, rect, XStringFormats.Center);

            

            //// Save the document...
            //string filename = "HelloWorld.pdf";
            //filename = month.ToString() + filename;
            //document.Save(filename);
            //// ...and start a viewer.
            //Process.Start(filename);



            ///////////////////////////////////////////////////////
            // Create a MigraDoc document
            
            Document document =  InformationAboutGauge.CreateDocument();

            //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();

            // Save the document...
            string filename = "HelloMigraDoc.pdf";
            renderer.PdfDocument.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
 
        }

        public static Document CreateDocument()
        {
            // Create a new MigraDoc document
            Document document = new Document();
            document.Info.Title = "Hello, MigraDoc";
            document.Info.Subject = "Demonstrates an excerpt of the capabilities of MigraDoc.";
            document.Info.Author = "Stefan Lange";

            InformationAboutGauge.DefineStyles(document);

            InformationAboutGauge.DefineCover(document);
            
            DefineContentSection(document);

            InformationAboutGauge.DefineTables(document);

            return document;
        }
        /// <summary>
        /// Defines the cover page.
        /// </summary>
        public static void DefineCover(Document document)
        {
            Section section = document.AddSection();

            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.SpaceAfter = "3cm";

            Image image = section.AddImage("../../images/Logo landscape.png");
            image.Width = "10cm";

            paragraph = section.AddParagraph("A sample document that demonstrates the\ncapabilities of MigraDoc");
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = Colors.DarkRed;
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Format.SpaceAfter = "3cm";

            paragraph = section.AddParagraph("Rendering date: ");
            paragraph.AddDateField();
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
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.PageBreakBefore = true;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;
        }
        /// <summary>
        /// Defines the cover page.
        /// </summary>
        

        /// <summary>
        /// Defines page setup, headers, and footers.
        /// </summary>
        static void DefineContentSection(Document document)
        {
            Section section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.StartingNumber = 1;

            HeaderFooter header = section.Headers.Primary;
            header.AddParagraph("\tOdd Page Header");

            header = section.Headers.EvenPage;
            header.AddParagraph("Even Page Header");

            // Create a paragraph with centered page number. See definition of style "Footer".
            Paragraph paragraph = new Paragraph();
            paragraph.AddTab();
            paragraph.AddPageField();

            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());
        }

        public static void DefineParagraphs(Document document)
        {
            Paragraph paragraph = document.LastSection.AddParagraph("Paragraph Layout Overview", "Heading1");
            paragraph.AddBookmark("Paragraphs");

            DemonstrateAlignment(document);
            DemonstrateIndent(document);
            DemonstrateBordersAndShading(document);
        }
        public static void DefineTables(Document document)
        {
            Paragraph paragraph = document.LastSection.AddParagraph("Table Overview", "Heading1");
            paragraph.AddBookmark("Tables");

            DemonstrateSimpleTable(document);
            DemonstrateAlignment(document);
            DemonstrateCellMerge(document);
        }

        public static void DemonstrateSimpleTable(Document document)
        {
            document.LastSection.AddParagraph("Simple Tables", "Heading2");

            Table table = new Table();
            table.Borders.Width = 0;

            Column column = table.AddColumn(Unit.FromCentimeter(2));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn(Unit.FromCentimeter(5));

            Row row = table.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;
            Cell cell = row.Cells[0];
            cell.AddParagraph("Itemus");
            cell = row.Cells[1];
            cell.AddParagraph("Descriptum");

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("1");
            cell = row.Cells[1];

            row = table.AddRow();
            cell = row.Cells[0];
            cell.AddParagraph("2");
            cell = row.Cells[1];

            table.SetEdge(0, 0, 2, 3, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);

            document.LastSection.Add(table);
        }

        

        public static void DemonstrateCellMerge(Document document)
        {
            document.LastSection.AddParagraph("Cell Merge", "Heading2");

            Table table = document.LastSection.AddTable();
            table.Borders.Visible = true;
            table.TopPadding = 5;
            table.BottomPadding = 5;

            Column column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Right;

            table.Rows.Height = 35;

            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Merge Right");
            row.Cells[0].MergeRight = 1;

            row = table.AddRow();
            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Bottom;
            row.Cells[0].MergeDown = 1;
            row.Cells[0].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Bottom;
            row.Cells[0].AddParagraph("Merge Down");

            table.AddRow();
        }

        
        static void DemonstrateIndent(Document document)
        {
            document.LastSection.AddParagraph("Indent", "Heading2");

            document.LastSection.AddParagraph("Left Indent", "Heading3");

            Paragraph paragraph = document.LastSection.AddParagraph();
            paragraph.Format.LeftIndent = "2cm";

            document.LastSection.AddParagraph("Right Indent", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.RightIndent = "1in";

            document.LastSection.AddParagraph("First Line Indent", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.FirstLineIndent = "12mm";

            document.LastSection.AddParagraph("First Line Negative Indent", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.LeftIndent = "1.5cm";
            paragraph.Format.FirstLineIndent = "-1.5cm";
        }

        static void DemonstrateBordersAndShading(Document document)
        {
            document.LastSection.AddPageBreak();
            document.LastSection.AddParagraph("Borders and Shading", "Heading2");

            document.LastSection.AddParagraph("Border around Paragraph", "Heading3");

            Paragraph paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Borders.Width = 0;
            paragraph.Format.Borders.Color = Colors.Navy;
            paragraph.Format.Borders.Distance = 3;

            document.LastSection.AddParagraph("Shading", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Shading.Color = Colors.LightCoral;

            document.LastSection.AddParagraph("Borders & Shading", "Heading3");

            paragraph = document.LastSection.AddParagraph();
            paragraph.Style = "TextBox";
        }

        public static void DemonstrateAlignment(Document document)
        {
            document.LastSection.AddParagraph("Cell Alignment", "Heading2");

            Table table = document.LastSection.AddTable();
            table.Borders.Visible = true;
            table.Format.Shading.Color = Colors.LavenderBlush;
            table.Shading.Color = Colors.Salmon;
            table.TopPadding = 5;
            table.BottomPadding = 5;

            Column column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn();
            column.Format.Alignment = ParagraphAlignment.Right;

            table.Rows.Height = 35;

            Row row = table.AddRow();
            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Top;
            row.Cells[0].AddParagraph("Text");
            row.Cells[1].AddParagraph("Text");
            row.Cells[2].AddParagraph("Text");

            row = table.AddRow();
            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
            row.Cells[0].AddParagraph("Text");
            row.Cells[1].AddParagraph("Text");
            row.Cells[2].AddParagraph("Text");

            row = table.AddRow();
            row.VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Bottom;
            row.Cells[0].AddParagraph("Text");
            row.Cells[1].AddParagraph("Text");
            row.Cells[2].AddParagraph("Text");
        }
 






        private void EditGaugeExecute()
        {
            
            MessageWindowGauge = new NewWindowGauge() { AboutGauge = new InformationAboutGauge() { Gauge = new gauge() } };

            MessageWindowGauge.AboutGauge.SerialNumber = SerialNumber;
            MessageWindowGauge.AboutGauge.SelectedManufacturer = Gauge.manufacturer_name;
            MessageWindowGauge.AboutGauge.SelectedModel = Gauge.model;


            MessageWindowGauge.IsOpen = true;

            if(MessageWindowGauge.ToConfirm)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    var gaugeToEdit = (from g in context.products where g.productId == this.GaugeId select g).FirstOrDefault();

                    if(MessageWindowGauge.AboutGauge.SelectedManufacturer != null
                       && MessageWindowGauge.AboutGauge.SelectedModel != null
                       && MessageWindowGauge.AboutGauge.SerialNumber != null)
                    {
                        gaugeToEdit.serial_number = MessageWindowGauge.AboutGauge.SerialNumber;
                        GaugeIdToAdd = (from g in context.gauges where g.model == MessageWindowGauge.AboutGauge.SelectedModel select g.gaugeId).FirstOrDefault();
                        gaugeToEdit.gauge_id = GaugeIdToAdd;

                        context.SaveChanges();

                        //set new data in main window view
                        this.SerialNumber = MessageWindowGauge.AboutGauge.SerialNumber;
                        Gauge.manufacturer_name = gaugeToEdit.gauge.manufacturer_name;
                        Gauge.model = gaugeToEdit.gauge.model;
                        Gauge.usage.description = gaugeToEdit.gauge.usage.description;
                    }
                }
                MessageWindowGauge.ToConfirm = false;
            }
            else
            {

            }
        }
    }
}
