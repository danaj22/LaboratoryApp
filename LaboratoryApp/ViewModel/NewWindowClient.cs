﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaboratoryApp.ViewModel;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowClient: ResultFromModalWindowBase
    {
        public InformationAboutClient AboutClient {get; set;}
        
        public View.ModalWindowClient MWindow;

        public NewWindowClient(View.ModalWindowClient window)
        {
            MWindow = window;
        }

        public ICommand ConfirmCommand
        {
            get
            {
                return new SimpleRelayCommand(ConfirmDialog);
            }
        }
        private void ConfirmDialog()
        {
            //dialog result set as 'true'
            MWindow.DialogResult = true;
        }

        public ICommand CancelCommand
        {
            get
            {
                return new SimpleRelayCommand(CancelDialog);
            }
        }

        public void CancelDialog()
        {
            //dialog result as 'false'
            MWindow.DialogResult = false;

        }


        
    }
}
