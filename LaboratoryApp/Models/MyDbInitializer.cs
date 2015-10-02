using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LaboratoryApp.Migrations;

namespace LaboratoryApp.Models
{

    internal sealed class MyDbInitializer : MigrateDatabaseToLatestVersion<LaboratoryEntities, Configuration>
        {
        }

}
