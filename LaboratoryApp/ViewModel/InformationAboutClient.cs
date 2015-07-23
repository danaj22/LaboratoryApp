using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp
{
    class InformationAboutClient:InformationAboutSelectedNodeViewModelBase
    {
        public override string Name
        {
            get { return "Client's informations"; }
        }

        public ObservableCollection<client> Clients { get; set; }

        public InformationAboutClient()
        {
            Clients = new ObservableCollection<client>();
        }

        
    }
}
