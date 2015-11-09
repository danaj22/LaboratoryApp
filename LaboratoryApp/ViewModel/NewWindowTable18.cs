using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable18 : NewWindowTableTemplate
    {
        public NewWindowTable18()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
        }
    }
}
