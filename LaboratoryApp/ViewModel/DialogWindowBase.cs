using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LaboratoryApp.ViewModel
{
    public class DialogWindowBase : ObservableObject
    {
        public SimpleRelayCommand OkCommand { get; set; }
        public SimpleRelayCommand CancelCommand { get; set; }
        
        public DialogWindowBase()
        {
            OkCommand = new SimpleRelayCommand(Ok_Executed);
            CancelCommand = new SimpleRelayCommand(CancelExecuted);
            
        }

        private void CancelExecuted()
        {
            DialogResultValue = false;
        }

        private void Ok_Executed()
        {
            DialogResultValue = true;
        }


        private bool? dialogResult;
        public bool? DialogResultValue
        {
            get { return dialogResult; }
            set
            {
                dialogResult = value;
                OnPropertyChanged("DialogResultValue");
            }
        }


        private object baseContent = null;

        public object BaseContent 
        {
            get { return baseContent; }
            set
            {
                baseContent = value;
                OnPropertyChanged("BaseContent");
            }
        }


    }
}
