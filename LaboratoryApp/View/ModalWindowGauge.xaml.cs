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
    /// Interaction logic for ModalWindowGauge.xaml
    /// </summary>
    public partial class ModalWindowGauge : Window,IModalWindow
    {
        public InformationAboutGauge infoGauge = new InformationAboutGauge();

        public ModalWindowGauge()
        {
            InitializeComponent();
            NewWindowGauge tmp = new NewWindowGauge(this);
            DataContext = tmp;
            infoGauge = tmp.AboutGauge;
        }
        public ModalWindowGauge(InformationAboutGauge info)
        {
            InitializeComponent();
            DataContext = new NewWindowGauge(this) { AboutGauge = infoGauge = info };
        }
    }
}
