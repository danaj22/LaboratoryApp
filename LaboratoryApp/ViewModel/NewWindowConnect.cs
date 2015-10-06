using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;

namespace LaboratoryApp.ViewModel
{
    class NewWindowConnect : ObservableObject
    {
        public NewWindowConnect()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            Models.LaboratoryEntities context = new Models.LaboratoryEntities();

            
            //create database
            var dbExists = "SELECT COUNT(*) FROM master.dbo.sysdatabases WHERE name = 'laboratory'";
            var query = "CREATE DATABASE laboratory;";
            string connectionString = "Data Source=DASL_SERWER;Integrated Security=True;MultipleActiveResultSets=True";
            var conn = new SqlConnection(connectionString);
            var command2 = new SqlCommand(dbExists, conn);
            var command = new SqlCommand(query, conn);
            
            if((int)l != 0)
            {

            }
            
            try
            {
                conn.Open();
                command2.ExecuteNonQuery();
            }

            catch(Exception e)
            {
                MessageBox.Show("Brak bazy danych.");
            }
            conn.Close();
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd w Tworzeniu bazy \n\n\n");
                MessageBox.Show(e.ToString());
            }

            try
            {
                conn.Open();
                command2.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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
        static string GetDbCreationQuery()
        {
            // your db name
            string dbName = "laboratory";

            // db creation query
            string query = "CREATE DATABASE " + dbName + ";";

            return query;
        }

        public void Confirm()
        {

            //if (!this.ToConfirm) ToConfirm = true;

            //// your connection string
            //string connectionString = "Server=localhost;integrated security=True;multipleactiveresultsets=True";

            //// your query:
            //var query = GetDbCreationQuery();

            //var conn = new SqlConnection(connectionString);
            //var command = new SqlCommand(query, conn);

            //conn.Open();
            ////command.ExecuteNonQuery();

            //try
            //{
            //    //conn.Open();
            //    try
            //    {
            //        command.ExecuteNonQuery();

            //        string script = System.IO.File.ReadAllText(@"Model1.edmx.sql");

            //        // split script on GO command
            //        System.Collections.Generic.IEnumerable<string> commandStrings = System.Text.RegularExpressions.Regex.Split(script, @"^\s*GO\s*$",
            //                                 System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            //        //thisConnection.Open();
            //        foreach (string commandString in commandStrings)
            //        {
            //            if (commandString.Trim() != "")
            //            {
            //                using (var command2 = new SqlCommand(commandString, conn))
            //                {
            //                    command2.ExecuteNonQuery();
            //                }
            //            }
            //        }
            //    }

            //    catch (Exception e)
                
            //    {
            //        //database doesn't exist
            //        MessageBox.Show(e.ToString());
            //    }

            //    //conn.Close();

            //    //MessageBox.Show("Database is created successfully");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("New window connect błąde\n\n" + ex.ToString());
            //}




            try
            {
                //"Server=localhost;integrated security=True;multipleactiveresultsets=True"
                //Constructing connection string from the inputs
                StringBuilder Con = new StringBuilder("data source=DASL_SERWER");
                //Con.Append(ServerName);
                Con.Append(";integrated security=True;multipleactiveresultsets=True;initial catalog=laboratory");
                //Con.Append(DatabaseName);
                Con.Append(";");

                string strCon = Con.ToString();
                updateConfigFile(strCon);
                //Create new sql connection
                SqlConnection Db = new SqlConnection();
                //to refresh connection string each time else it will use             previous connection string
                ConfigurationManager.RefreshSection("connectionStrings");
                Db.ConnectionString = strCon;
                //To check new connection string is working or not. Please use the existing table otherwise it will give error

                SqlDataAdapter da = new SqlDataAdapter("select * from clients", Db);

                Application.Current.Windows[0].DialogResult = true;

            }
            catch (Exception E)
            {
                MessageBox.Show(ConfigurationManager.ConnectionStrings["LaboratoryEntities"].ToString() + ".This is invalid connection", "Incorrect server/Database");
            }
            IsOpen = false;

        }

        public void updateConfigFile(string con)
        {
            //updating config file
            XmlDocument XmlDoc = new XmlDocument();
            //Loading the Config file
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "connectionStrings")
                {
                    //setting the coonection string
                    xElement.FirstChild.Attributes[1].Value = con;
                }
            }
            //writing the connection string in config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        public void Close()
        {
            IsOpen = false;
        }

        private string serverName;

        public string ServerName
        {
            get { return serverName; }
            set
            {
                serverName = value;
                OnPropertyChanged("ServerName");
            }
        }
        private string databaseName;

        public string DatabaseName
        {
            get { return databaseName; }
            set
            {
                databaseName = value;
                OnPropertyChanged("DatabaseName");
            }
        }
        private string login;

        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
