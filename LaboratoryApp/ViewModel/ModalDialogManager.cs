using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LaboratoryApp.ViewModel
{
    public class ModalDialogManager : Control
    {
        public Window _window;

        static ModalDialogManager()
        {
            //this control really is a blank template - it really just contains a UI presence so it can be declaratively 
            //be added to a page.  

            //the DataContext of this control must be set to the ViewModel that you wish to display in the dialog.  Also you must 
            //configure a DataTemplate that associates the ViewModel to the View that will be shown inside this dialog
            // e.g
            //         <DataTemplate DataType="{x:Type vm:MessageWindowViewModel}">
            //              <v:MessageWindow/>
            //          </DataTemplate>
            //Usually these datatemplates are defined in a global resource library such as App.xaml
            //If this is not configured propertly instead of seeing your control - you will just see the classname in the resulting dialog
        }

        /// <summary>
        /// This is invoked when the red X is clicked or a keypress closes the window - 
        /// </summary>
        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }
        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(ModalDialogManager), new UIPropertyMetadata(null));


        /// <summary>
        /// This should be bound to IsOpen (or similar) in the ViewModel associated with ModalDialogManager
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(ModalDialogManager), new UIPropertyMetadata(false, IsOpenChanged));

        public bool ToConfirm
        {
            get { return (bool)GetValue(ToConfirmProperty); }
            set { SetValue(ToConfirmProperty, value); }
        }
        public static readonly DependencyProperty ToConfirmProperty =
            DependencyProperty.Register("ToConfirm", typeof(bool), typeof(ModalDialogManager), new UIPropertyMetadata(false, ToConfirmChanged));


        public static void ToConfirmChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ModalDialogManager m = d as ModalDialogManager;            
        }

        public static void IsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ModalDialogManager m = d as ModalDialogManager;
            bool newVal = (bool)e.NewValue;
            if (newVal)
                m.Show();
            else
                m.Close();
        }


        void Show()
        {
            if (_window != null) Close();

            Window w = new Window();
            _window = w;
            w.Closing += w_Closing;
            w.Owner = GetParentWindow(this);

            w.DataContext = this.DataContext;
            w.SetBinding(Window.ContentProperty, "");

            w.Height = DialogHeight;
            w.Width = DialogWidth;
            w.ResizeMode = DialogResizeMode;
            w.ShowDialog();
        }

        void w_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_internalClose)
            {
                _externalClose = true;
                if (CloseCommand != null) CloseCommand.Execute(null);
                _externalClose = false;
            }
        }

        bool _internalClose = false;
        bool _externalClose = false;

        void Close()
        {
            _internalClose = true;

            if (!_externalClose) _window.Close();

            _window = null;
            _internalClose = false;
        }

        Window GetParentWindow(FrameworkElement current)
        {
            if (current is Window)
                return current as Window;
            else if (current.Parent is FrameworkElement)
                return GetParentWindow(current.Parent as FrameworkElement);
            else
                return null;
        }


        #region DependencyProperties that control the look of the shown dialog

        public double DialogHeight
        {
            get { return (double)GetValue(DialogHeightProperty); }
            set { SetValue(DialogHeightProperty, value); }
        }
        public static readonly DependencyProperty DialogHeightProperty =
            DependencyProperty.Register("DialogHeight", typeof(double), typeof(ModalDialogManager));

        public double DialogWidth
        {
            get { return (double)GetValue(DialogWidthProperty); }
            set { SetValue(DialogWidthProperty, value); }
        }
        public static readonly DependencyProperty DialogWidthProperty =
            DependencyProperty.Register("DialogWidth", typeof(double), typeof(ModalDialogManager));

        public ResizeMode DialogResizeMode
        {
            get { return (ResizeMode)GetValue(DialogResizeModeProperty); }
            set { SetValue(DialogResizeModeProperty, value); }
        }
        public static readonly DependencyProperty DialogResizeModeProperty =
            DependencyProperty.Register("DialogResizeMode", typeof(ResizeMode), typeof(ModalDialogManager));

        //public ImageSource Icon
        //{
        //    get { return (ImageSource)GetValue(IconProperty); }
        //    set { SetValue(IconProperty, value); }
        //}
        //public static readonly DependencyProperty IconProperty =
        //    DependencyProperty.Register("Icon", typeof(ImageSource), typeof(ModalDialogManager), new UIPropertyMetadata(null));

        //public string Title
        //{
        //    get { return (string)GetValue(TitleProperty); }
        //    set { SetValue(TitleProperty, value); }
        //}
        //public static readonly DependencyProperty TitleProperty =
        //    DependencyProperty.Register("Title", typeof(string), typeof(ModalDialogManager), new UIPropertyMetadata(null));

        #endregion

    }

}
