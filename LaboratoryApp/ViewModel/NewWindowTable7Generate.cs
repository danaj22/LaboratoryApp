using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable7Generate: NewWindowTableGenerate
    {
        
        public NewWindowTable7Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);

            ColumnNames.Add("Wartość rezystancji mierzonej na mierniku sprawdzanym dla napięcia 50V [Ω]");

            ColumnNames.Add("Wartość rezystancji nastawionej na dekadzie kontrolnej [Ω]");

            ColumnNames.Add("Różnica wartości rezystancji na mierniku sprawdzanym i dekadzie kontrolnej przy 50V [Ω]");
            ColumnNames.Add("Wartość rezystancji na mierniku sprawdzanym dla napięcia 25V [Ω]");

            ColumnNames.Add("Różnica wartości rezystancji na mierniku sprawdzanym i dekadzie kontrolnej przy 25V [Ω]");
            ColumnNames.Add("Dopuszczalna wartość błędu bezwzględnego mierzonej rezystancji dla napięcia 50V [Ω]");

            ColumnNames.Add("Dopuszczalna wartość błędu bezwzględnego mierzonej rezystancji dla napięcia 25V [Ω]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru rezystancji ±2S(x) [Ω]");

            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru rezystancji ±2S(x)");

            Title = "Sprawdzenie normy zgodnie z wymogami instrukcji IZ/007/DASL";
        }

    }
}
