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
    /// Interaction logic for ModalWindowAddClient.xaml
    /// </summary>
    public partial class ModalWindowAddClient : Window
    {
        public ModalWindowAddClient()
        {
            InitializeComponent();
        }

        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(CancelDialog, CanCancelDialog);
            }
        }
        private void CancelDialog()
        {

            this.Close();

        }

        private bool CanCancelDialog()
        { return true; }

    }
}
