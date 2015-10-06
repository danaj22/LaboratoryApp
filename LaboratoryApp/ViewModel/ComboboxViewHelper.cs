using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LaboratoryApp.ViewModel
{
    public class ComboboxViewHelper : ObservableObject
    {
        public ObservableCollection<String> Manufacturers
        {
            get { return (ObservableCollection<String>)GetValue(ManufacturersProperty); }
            set { SetValue(ManufacturersProperty, value); }
        }

        public static object GetSelectedItem(DependencyObject obj)
        {
            return (object)obj.GetValue(ManufacturersProperty);
        }
        public static void SetSelectedItem(DependencyObject obj, object value)
        {
            obj.SetValue(ManufacturersProperty, value);
        }

        // Using a DependencyProperty as the backing store for Manufacturers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManufacturersProperty =
            DependencyProperty.Register("Manufacturers", typeof(ObservableCollection<String>), typeof(ComboboxViewHelper), new PropertyMetadata(null));

        public ObservableCollection<String> Models
        {
            get { return (ObservableCollection<String>)GetValue(ModelsProperty); }
            set { SetValue(ModelsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Models.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelsProperty =
            DependencyProperty.Register("Models", typeof(ObservableCollection<String>), typeof(ComboboxViewHelper), new PropertyMetadata(null));

        public String SelectedManufacturer
        {
            get { return (String)GetValue(SelectedManufacturerProperty); }
            set { SetValue(SelectedManufacturerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedManufacturer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedManufacturerProperty =
            DependencyProperty.Register("SelectedManufacturer", typeof(String), typeof(ComboboxViewHelper), new PropertyMetadata(null, OnSelectedProjectChanged));

        public String SelectedModel
        {
            get { return (String)GetValue(SelectedModelProperty); }
            set { SetValue(SelectedModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedModelProperty =
            DependencyProperty.Register("SelectedModel", typeof(String), typeof(ComboboxViewHelper), new PropertyMetadata(null));

        private static void OnSelectedProjectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //ComboboxViewHelper v = d as ComboboxViewHelper;
           // v.SelectedLanguage = "aaa"; //your logic here eg. v.SelectedManufacturer.Language;
        }
    }
}
