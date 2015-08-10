using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LaboratoryApp.ViewModel
{
    class WindowService : Window, IWindowService
    {
        public bool? ShowWindow(object ViewModel)
        {
            var window = new Window();
            window.Owner = Application.Current.MainWindow;
            window.Content = ViewModel;
            return window.ShowDialog();
        }
    }
}
