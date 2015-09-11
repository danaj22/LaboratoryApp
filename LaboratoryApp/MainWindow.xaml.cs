using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LaboratoryApp.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Data.SqlClient;
using System.Data.Entity;

namespace LaboratoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {

            ////Connect to the local, default instance of SQL Server. 
            //Microsoft.SqlServer.Server srv;
            //srv = new Microsoft.SqlServer.Server();
            ////Define a Database object variable by supplying the server and the database name arguments in the constructor. 
            //Database db;
            //db = new Database(srv, "Test_SMO_Database");
            ////Create the database on the instance of SQL Server. 
            //db.Create();
            try
            {
                Database.SetInitializer<LaboratoryEntities>(new CreateDatabaseIfNotExists<LaboratoryEntities>());
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Błąd przy tworzeniu bazy danych.");
            }
            // MessageWindowGauge = new NewWindowGauge() { AboutGauge = new gauge() };

            //MessageWindowGauge.IsOpen = true;

            //if (MessageWindowGauge.ToConfirm)
            //{

            //}
            //String str;
            //SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            //str = "CREATE DATABASE laboratory ON PRIMARY " +
            //    "(NAME = MyDatabase_Data, " +
            //    "FILENAME = 'C:\\MyDatabaseData.mdf', " +
            //    "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
            //    "LOG ON (NAME = MyDatabase_Log, " +
            //    "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
            //    "SIZE = 1MB, " +
            //    "MAXSIZE = 5MB, " +
            //    "FILEGROWTH = 10%)";

            //SqlCommand myCommand = new SqlCommand(str, myConn);
            //try
            //{
            //    myConn.Open();
            //    myCommand.ExecuteNonQuery();
            //    MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButton.OK,MessageBoxImage.Information);
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //finally
            //{
                
            //}
            InitializeComponent();
        }

    }
    
}
