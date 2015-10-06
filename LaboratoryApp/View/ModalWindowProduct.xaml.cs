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
    /// Interaction logic for ModalWindowProduct.xaml
    /// </summary>
    public partial class ModalWindowProduct : Window, IModalWindow
    {
        public InformationAboutGauge infoProduct = new InformationAboutGauge();

        public ModalWindowProduct()
        {
            InitializeComponent();

            NewWindowGauge tmp = new NewWindowGauge(this);
            DataContext = tmp;
            infoProduct = tmp.AboutGauge;
        }
        public ModalWindowProduct(InformationAboutGauge info)
        {
            InitializeComponent();
            DataContext = new ViewModel.NewWindowGauge(this) { AboutGauge = infoProduct = info };
        }
    }
}
