using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable2Generate : NewWindowTableGenerate
    {
        public NewWindowTable2Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Nastawiona wartość częstotliwości napięcia przemiennego o wartości 230V [Hz]");
            ColumnNames.Add("Wartość częstotliwości napięcia przemiennego na mierniku sprawdzanym [Hz]");
            ColumnNames.Add("Różnica częstotliwości na mierniku sprawdzanym i kontrolnym [Hz]");
            ColumnNames.Add("Dopuszczalna dolna wartość limitu błędu mierzonej częstotliwości [Hz]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błędu mierzonej częstotliwości [Hz]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B+A) pomiaru częstotliwości ±2S(x)[Hz]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B+A) pomiaru pomiaru częstotliwości ±2S(x)");
        }
        
    }
}
