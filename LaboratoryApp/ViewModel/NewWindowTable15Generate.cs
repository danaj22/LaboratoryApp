using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable15Generate : NewWindowTableGenerate
    {
        public NewWindowTable15Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);

            ColumnNames.Add("Wartość rezystancji nastawionej na dekadzie kontrolnej [Ω]");

            ColumnNames.Add("Hipotetyczna rezystywność gruntu [Ω*m]");

            ColumnNames.Add("Zmierzona wartość rezystywności gruntu na mierniku sprawdzanym przy 50V [Ω*m]");
            ColumnNames.Add("Różnica wartości rezystywności na mierniku sprawdzanym i hipotetycznej przy 50V [Ω*m]");

            ColumnNames.Add("Zmierzona wartość rezystywności gruntu na mierniku sprawdzanym przy 25V [Ω*m]");
            ColumnNames.Add("Różnica wartości rezystywności na mierniku sprawdzanym i hipotetycznej przy 25V [Ω*m]");

            ColumnNames.Add("Dopuszczalna wartość błedu bezwzględnego mierzonej rezystywności dla napięcia 50V [Ω*m]");
            ColumnNames.Add("Dopuszczalna wartość błedu bezwzględnego mierzonej rezystywności dla napięcia 25V [Ω*m]");

            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru rezystywności ±2S(x) [Ω*m]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru rezystywności ±2S(x)");
        }

    }
}
