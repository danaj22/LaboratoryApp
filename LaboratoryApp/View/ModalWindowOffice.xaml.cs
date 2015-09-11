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
    /// Interaction logic for ModalWindowOffice.xaml
    /// </summary>
    public partial class ModalWindowOffice : Window, IModalWindow
    {
        public InformationAboutOffice infoOffice;

        public ModalWindowOffice()
        {
            InitializeComponent();
            ViewModel.NewWindowOffice tmp = new ViewModel.NewWindowOffice(this);
            DataContext = tmp;
            infoOffice = tmp.AboutOffice;
        }
        public ModalWindowOffice(InformationAboutOffice info)
        {
            InitializeComponent();
            DataContext = new ViewModel.NewWindowOffice(this) { AboutOffice = info };
        }
    }
}
