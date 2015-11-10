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

            ColumnNames.Add("Nominalny prąd wyłącznika RCD [mA] (krotność 1x)");
            ColumnNames.Add("Zmierzony czas zadziałania wyłącznika RCD na mierniku sprawdzanym [ms]");
            ColumnNames.Add("Nastawiony czas zadziałania wyłącznika RCD na symulatorze RCD [ms]");
            ColumnNames.Add("Dopuszczalna dolna wartość limitu błędu mierzonego czasu [ms]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błędu mierzonego czasu [ms]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B zadawania czasu zadziałania ±2S(x) [ms]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B zadawania czasu zadziałania ±2S(x)");
        } 
    }
}
