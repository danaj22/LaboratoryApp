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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaboratoryApp.View
{
    /// <summary>
    /// Interaction logic for InformationAboutOfficeView.xaml
    /// </summary>
    public partial class InformationAboutOfficeView : UserControl
    {
        public InformationAboutOfficeView()
        {
            InitializeComponent();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

    }
}
