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
            string connectionString = @"Data Source=DASL_SERWER;integrated security=True;multipleactiveresultsets=True";

            // your query:
            //var query = GetDbCreationQuery();

            var conn = new SqlConnection(connectionString);
            //var command = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                try
                {
                    //command.ExecuteNonQuery();

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
                       //         command2.ExecuteNonQuery();
                            }
                        }
                    }
                }

                catch (Exception e)
                {
                    //database doesn't exist
                    MessageBox.Show(e.ToString());
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

            InitializeComponent();
        }

        
    }
    
}
