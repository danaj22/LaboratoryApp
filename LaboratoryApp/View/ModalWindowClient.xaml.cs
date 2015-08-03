using LaboratoryApp.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace LaboratoryApp.View
{
    /// <summary>
    /// Interaction logic for ModalWindowClient.xaml
    /// </summary>
    public partial class ModalWindowClient : Window
    {
        //public InformationAboutClient infoClient;

        public ModalWindowClient()
        {
            InitializeComponent();
            DataContext = new NewWindowClient(this);
        }

        public InformationAboutClient AllInformation;

        public ModalWindowClient(InformationAboutClient info)
        {
            InitializeComponent();
            DataContext = new NewWindowClient(this) { AboutClient = AllInformation = info };
        }
    }
}
