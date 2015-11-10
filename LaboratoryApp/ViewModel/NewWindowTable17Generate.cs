using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable17Generate : NewWindowTableGenerate
    {
        public NewWindowTable17Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Wartość prądu przemiennego na mierniku sprawdzanym [A]");
            ColumnNames.Add("Wartość prądu przemiennego na mierniku kontrolnym [A]");
            ColumnNames.Add("Różnica wartości prądu na mierniku sprawdzanym i kontrolnym [A]");
            ColumnNames.Add("Dopuszczalna dolna wartość limitu błedu mierzonego prądu [A]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błedu mierzonego prądu [A]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B+A) pomiaru prądu ±2S(x) [A]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu (B+A) pomiaru prądu ±2S(x)");
        }
    }
}
