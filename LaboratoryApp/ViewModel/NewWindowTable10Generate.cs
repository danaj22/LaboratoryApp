using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable10Generate : NewWindowTableGenerate
    {
        public NewWindowTable10Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Sinusoidalny prąd dotykowy zaczynający się od dodatniej połówki [mA]");
            ColumnNames.Add("Oporność symulująca oporność uziemienia [Ω]");
            ColumnNames.Add("Mierzona wartość napięcia dotykowego na mierniku sprawdzanym [V]");
            ColumnNames.Add("Mierzona wartość napięcia dotykowego na mierniku kontrolnym [V]");
            ColumnNames.Add("Oporność uziemienia na mierniku sprawdzanym [Ω]");
            ColumnNames.Add("Dopuszczalna dolna wartość limitu błędu mierzonego napięcia [V]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błędu mierzonego napięcia [V]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B) pomiaru napięcia ±2S(x) [V]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B) pomiaru napięcia ±2S(x)");
        }
    }
}
