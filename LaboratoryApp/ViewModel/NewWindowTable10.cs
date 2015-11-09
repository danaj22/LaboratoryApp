using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable10 : NewWindowTableTemplate
    {
        public NewWindowTable10()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
        }
    }
}
