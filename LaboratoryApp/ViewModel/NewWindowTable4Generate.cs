using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable4Generate : NewWindowTableGenerate
    {
        public NewWindowTable4Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Napięcie pomiarowe rezystancji izolacji [V]");

            ColumnNames.Add("Odczytana wartość rezystancji na mierniku sprawdzanym [Ω]");
            ColumnNames.Add("Rzeczywista nastawiona wartość rezystancji na dekadzie kontrolnej [Ω]");
            ColumnNames.Add("Różnica wartości kontrolnej i sprawdzanej [Ω]");

            ColumnNames.Add("Dopuszczalna dolna wartość limitu błędu mierzonej rezystancji [Ω]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błędu mierzonej rezystancji [Ω]");

            ColumnNames.Add("Niepewność całkowita rozszerzona typu B ±2S(x) [Ω]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru rezystancji ±2S(x)");
        }
        
    }
}
