using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LaboratoryApp;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace LaboratoryApp.ViewModel
{
    public class TreeViewHelper : DependencyObject
    {
        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.RegisterAttached("SelectedItem", //name of property
                                                                        typeof(object), //type of property 
                                                                        typeof(TreeViewHelper), //type of owner property
                                                                        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectedItemChanged));//metadata

        //create a dictionary to add a new behavior
        private static Dictionary<DependencyObject, TreeViewSelectedItemBehavior> behaviors = new Dictionary<DependencyObject, TreeViewSelectedItemBehavior>();

        //static methods to get and set 
        public static object GetSelectedItem(DependencyObject obj)
        {
            return (object)obj.GetValue(SelectedItemProperty);
        }
        public static void SetSelectedItem(DependencyObject obj, object value)
        {
            obj.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// It is a Dependency Property which set a DialogResult after click on a button in dialog window
        /// </summary>
        public static readonly DependencyProperty DialogResultProperty = DependencyProperty.RegisterAttached(
                                                                            "DialogResult",
                                                                            typeof(bool?),
                                                                            typeof(TreeViewHelper),
                                                                            new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null)
                window.DialogResult = e.NewValue as bool?;
        }
        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
        

        //when click new item in TreeView  SelectedItem is changing...
        private static void SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is TreeView))
            {
                return;
            }
            //if 
            if (!behaviors.ContainsKey(d))
            {
                behaviors.Add(d, new TreeViewSelectedItemBehavior(d as TreeView));
            }
            TreeViewSelectedItemBehavior view = behaviors[d];
            view.ChangeSelectedItem(e.NewValue);

        }

        private class TreeViewSelectedItemBehavior
        {
            readonly TreeView view;

            //behavior when item is selected
            public TreeViewSelectedItemBehavior(TreeView view)
            {

                this.view = view;
                view.SelectedItemChanged += (sender, e) => SetSelectedItem(view, e.NewValue);

            }
            internal void ChangeSelectedItem(object p)
            {
                try
                {
                    var item = (TreeViewItem)view.ItemContainerGenerator.ContainerFromItem(p);
                    if (item != null)
                        item.IsSelected = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        
        }

        
    }

    public static class FwExtensions
    {
        public static void SendUIRefreshNotification(this ObservableCollection<client> observableCollection, client item)
        {
            var index = observableCollection.IndexOf(item);
            observableCollection.Remove(item);
            observableCollection.Insert(index, item);
        }

        public static void SendUIRefreshNotification(this ObservableCollection<client> observablecollection)
        {
            var a = observablecollection.ToList();
            foreach (var item in a)
            {
                observablecollection.SendUIRefreshNotification(item);
            }
        }
    }
}
