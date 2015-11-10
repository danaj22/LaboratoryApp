using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable18Generate : NewWindowTableGenerate
    {
        public NewWindowTable18Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Wartość rezystancji nastawionej na dekadzie kontrolnej [Ω]");
            ColumnNames.Add("Wartość napięcia odniesienia [V]");
            ColumnNames.Add("Hipotetyczna wartość prądu równoważnego [A]");
            ColumnNames.Add("Wartość prądu równoważnego na mierniku sprawdzanym [A]");
            ColumnNames.Add("Różnica wartości prądu na mierniku sprawdzanym i kontrolnym [A]");
            ColumnNames.Add("Dopuszczalna dolna wartość limitu błędu mierzonego prądu [A]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błędu mierzonego prądu [A]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B+A) pomiaru prądu ±2S(x) [A]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B+A) pomiaru prądu ±2S(x)");
        }
    }
}
