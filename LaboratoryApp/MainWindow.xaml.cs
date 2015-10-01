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
using System.Data;

namespace LaboratoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        static string GetDbCreationQuery()
        {
            // your db name
            string dbName = "laboratory";

            // db creation query
            string query = "CREATE DATABASE " + dbName + ";";

            return query;
        }

        public MainWindow()
        {

            // your connection string
            string connectionString = "Server=localhost;integrated security=True;multipleactiveresultsets=True";

            // your query:
            var query = GetDbCreationQuery();

            var conn = new SqlConnection(connectionString);
            var command = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                try
                {
                    command.ExecuteNonQuery();

                    string script = System.IO.File.ReadAllText(@"Model1.edmx.sql");

                    // split script on GO command
                    System.Collections.Generic.IEnumerable<string> commandStrings = System.Text.RegularExpressions.Regex.Split(script, @"^\s*GO\s*$",
                                             System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                    //thisConnection.Open();
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command2 = new SqlCommand(commandString, conn))
                            {
                                command2.ExecuteNonQuery();
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    //database doesn't exist
                }

                conn.Close();

                //MessageBox.Show("Database is created successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if ((conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            }

            //string connectionString = "Server=localhost;Database=laboratory;integrated security=True;multipleactiveresultsets=True";

            //var conn = new SqlConnection(connectionString);

            //var query = GetDbCreationQuery(conn);

            //var command = new SqlCommand(query, (SqlConnection)conn);

            //try
            //{
            //    conn.Open();
            //    command.ExecuteNonQuery();
            //    System.Windows.MessageBox.Show("Database is created successfully");
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    if ((conn.State == System.Data.ConnectionState.Open))
            //    {
            //        conn.Close();
            //    }
            //}
            ////Connect to the local, default instance of SQL Server. 
            //Microsoft.SqlServer.Server srv;
            //srv = new Microsoft.SqlServer.Server();
            ////Define a Database object variable by supplying the server and the database name arguments in the constructor. 
            //Database db;
            //db = new Database(srv, "Test_SMO_Database");
            ////Create the database on the instance of SQL Server. 
            //db.Create();
            //try
            //{
            //    Database.SetInitializer<LaboratoryEntities>(new CreateDatabaseIfNotExists<LaboratoryEntities>());
            //}
            //catch (Exception)
            //{
            //    System.Windows.MessageBox.Show("Błąd przy tworzeniu bazy danych.");
            //}
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

        /*
        static string GetDbCreationQuery(SqlConnection conn)
        {
            Database.SetInitializer(new MyDBInitializer());
            SqlConnection thisConnection = new SqlConnection(@"Server=localhost;integrated security=True;multipleactiveresultsets=True");
            
            if (thisConnection != null && thisConnection.State == System.Data.ConnectionState.Closed)
            {
                thisConnection.Open();
            }
            string script = System.IO.File.ReadAllText(@"Model1.edmx.sql");

            // split script on GO command
            System.Collections.Generic.IEnumerable<string> commandStrings = System.Text.RegularExpressions.Regex.Split(script, @"^\s*GO\s*$",
                                     System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //thisConnection.Open();
            foreach (string commandString in commandStrings)
            {
                if (commandString.Trim() != "")
                {
                    using (var command = new SqlCommand(commandString, thisConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            thisConnection.Close();

            //// your db name
            //string dbName = "laborator";

            //// db creation query
            //string query = "CREATE DATABASE " + dbName + ";";

            return "oo";
        }
        */
    }
    
}
