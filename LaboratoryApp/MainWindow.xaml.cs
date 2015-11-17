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
using System.Globalization;
using System.Threading;

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


                if ((conn.State == ConnectionState.Open))
                {
                    conn.Close();
                }
            

            InitializeComponent();
        }

        
    }
    
}
