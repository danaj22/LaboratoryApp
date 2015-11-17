using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable1Generate: NewWindowTableGenerate
    {
        
        public NewWindowTable1Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);

            ColumnNames.Add("Wartość napięcia przemiennego na mierniku sprawdzanym [V]");
            ColumnNames.Add("Wartość napięcia przemiennego na mierniku kontrolnym [V]");
            ColumnNames.Add("Różnica napięcia przemiennego na mierniku sprawdzanym i kontrolnym [V]");
            ColumnNames.Add("Dopuszczalna dolna wartość limitu błędu mierzonego napięcia [V]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błędu mierzonego napięcia [V]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru napięcia przemiennego ±2S(x)[V]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru napięcia przemiennego ±2S(x)");

            Title = "Sprawdzenie normy zgodnie z wymogami instrukcji IZ/004/DASL";
        }


        
    }
}

