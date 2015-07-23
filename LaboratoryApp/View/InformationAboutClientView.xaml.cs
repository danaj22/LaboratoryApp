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
using LaboratoryApp;
using System.ComponentModel;

namespace LaboratoryApp.View
{
    /// <summary>
    /// Interaction logic for InformationAboutClientView.xaml
    /// </summary>
    public partial class InformationAboutClientView : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static int i = 1;
        public InformationAboutClientView()
        {
            InitializeComponent();
            Imie = "ala ma kota "+i++.ToString();        
        }

        private string imie = "Adamiakowa";

        public string Imie
        {
            get { return (string)GetValue(ImieProperty); }
            set { SetValue(ImieProperty, value); }


        }
        public static readonly DependencyProperty ImieProperty = DependencyProperty.Register("Imie", typeof(string), typeof(InformationAboutClientView), new PropertyMetadata(default(string)));

    }
}
