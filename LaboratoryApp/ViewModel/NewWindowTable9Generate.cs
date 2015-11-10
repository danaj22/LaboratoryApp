using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable9Generate : NewWindowTableGenerate
    {
        public NewWindowTable9Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Impedancja dekady kontrolnej włączonej w przewód N pętli zwarciowej [Ω]");

            ColumnNames.Add("Wartość wskazana prądu zwarciowego [A]");
            ColumnNames.Add("Oczekiwana kontrolna wartość prądu zwarciowego przy zadanym napięciu sieci 230V [A]");
            ColumnNames.Add("Różnica prądu na mierniku sprawdzanym i kontrolnym [A]");

            ColumnNames.Add("Dopuszczalna dolna wartość limitu błędu prądu mierzonego [A]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błędu prądu mierzonego [A]");

            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B+A) pomiaru prądu ±2S(x)[A]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B) pomiaru pomiaru prądu ±2S(x)");
        }
    }
}
