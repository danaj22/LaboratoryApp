﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaboratoryApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Reflection;
    using System.Data.Entity.Core.EntityClient;

    //public static class ConnectionTools
    //{
    //    // all params are optional
    //    public static void ChangeDatabase(
    //        this DbContext source,
    //        string initialCatalog = "",
    //        string dataSource = "",
    //        string userId = "",
    //        string password = "",
    //        bool integratedSecuity = true,
    //        string configConnectionStringName = "")
    //    /* this would be used if the
    //    *  connectionString name varied from 
    //    *  the base EF class name */
    //    {
    //        try
    //        {
    //            // use the const name if it's not null, otherwise
    //            // using the convention of connection string = EF contextname
    //            // grab the type name and we're done
    //            var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
    //                ? source.GetType().Name
    //                : configConnectionStringName;

    //            // add a reference to System.Configuration
    //            var entityCnxStringBuilder = new EntityConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString);

    //            // init the sqlbuilder with the full EF connectionstring cargo
    //            var sqlCnxStringBuilder = new SqlConnectionStringBuilder
    //                (entityCnxStringBuilder.ProviderConnectionString);

    //            // only populate parameters with values if added
    //            if (!string.IsNullOrEmpty(initialCatalog))
    //                sqlCnxStringBuilder.InitialCatalog = initialCatalog;
    //            if (!string.IsNullOrEmpty(dataSource))
    //                sqlCnxStringBuilder.DataSource = dataSource;
    //            if (!string.IsNullOrEmpty(userId))
    //                sqlCnxStringBuilder.UserID = userId;
    //            if (!string.IsNullOrEmpty(password))
    //                sqlCnxStringBuilder.Password = password;

    //            // set the integrated security status
    //            sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;

    //            // now flip the properties that were changed
    //            source.Database.Connection.ConnectionString
    //                = sqlCnxStringBuilder.ConnectionString;
    //        }
    //        catch (Exception ex)
    //        {
    //            // set log item if required
    //        }
    //    }
    //}

    public partial class LaboratoryEntities : DbContext
    {
        public LaboratoryEntities() : base("LaboratoryEntities") { }
        
            public LaboratoryEntities(string connectionString)
            : base(connectionString)
        {
        }

        public static LaboratoryEntities ConnectToSqlServer()
            {
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    InitialCatalog = "laboratory",
                    ApplicationName = "EntityFramework",
                    PersistSecurityInfo = true,
                    IntegratedSecurity = true,
                    MultipleActiveResultSets = true,
                    UserID="daniel",
                    Password=""
                };

                // assumes a connectionString name in .config of MyDbEntities
                //var entityConnectionStringBuilder = new EntityConnectionStringBuilder
                //{
                    //Provider = "System.Data.SqlClient",
                    //ProviderConnectionString = sqlBuilder.ConnectionString
                //};

                return new LaboratoryEntities(sqlBuilder.ConnectionString);
            }
            /*"Server=localhost;integrated security=True;multipleactiveresultsets=True"
           string connectionString
            try
            {
                
                if(!Database.Exists() )
                {
                    
                    Database.SetInitializer(new MyDBInitializer());

                    try
                    {
                        try
                        {
                            //@"Server=(local);Database=laboratory;Trusted_Connection=Yes;"
                            thisConnection = new SqlConnection(@"Server=localhost;Database=laboratory;integrated security=True;multipleactiveresultsets=True");
                            System.Windows.MessageBox.Show(thisConnection.ToString());

                            if (thisConnection != null && thisConnection.State == System.Data.ConnectionState.Closed)
                            {
                                thisConnection.Open();
                            }
                            else if (thisConnection != null)
                               {
                                   thisConnection.Close();
                               }

                        }
                        catch(Exception e)
                        {
                            System.Windows.MessageBox.Show(e + "db error");
                            
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
                    }
                    catch (Exception e)
                    {
                        System.Windows.MessageBox.Show(e.ToString());
                    }
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Błąd przy tworzeniu bazy danych.");
            }
          */
        //}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<model_of_gauges> model_of_gauges { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<gauge> gauges { get; set; }
        public virtual DbSet<certificate> certificates { get; set; }
        public virtual DbSet<type> types { get; set; }
        public virtual DbSet<usage> usages { get; set; }
        public virtual DbSet<office> offices { get; set; }
        public virtual DbSet<calibrator> calibrators { get; set; }
        public virtual DbSet<calibrators_model_of_gauges> calibrators_model_of_gauges { get; set; }
        public virtual DbSet<function> functions { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
