using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable9 : NewWindowTableTemplate
    {
        public NewWindowTable9()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
        }
    }
}
