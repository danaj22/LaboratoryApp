using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable6Generate : NewWindowTableGenerate
    {
        public NewWindowTable6Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            
            ColumnNames.Add("Zakres prądu uszkodzeniowego na mierniku sprawdzanym");
            ColumnNames.Add("Wartość prądu uszkodzeniowego na mierniku sprawdzanym [mA]");
            ColumnNames.Add("Zmierzona wartość prądu uszkodzeniowego [mA]");
            ColumnNames.Add("Dopuszczalna dolna wartość limitu błędu mierzonego prądu [mA]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błędu mierzonego prądu [mA]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru prądu ±2S(x) [mA]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru prądu ±2S(x)");
        } 
    }
}
