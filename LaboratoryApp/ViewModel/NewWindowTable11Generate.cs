using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable11Generate : NewWindowTableGenerate
    {
        public NewWindowTable11Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Impedancja pętli zwarcia na mierniku sprawdzanym [Ω]");
            ColumnNames.Add("Rezystancja pętli zwarcia na mierniku sprawdzanym [Ω]");
            ColumnNames.Add("Reaktancja pętli zwarcia na mierniku sprawdzanym [Ω]");
            ColumnNames.Add("Impendancja pętli zwarcia na mierniku kontrolnym [Ω]");
            ColumnNames.Add("Rezystancja pętli zwarcia na mierniku kontrolnym [Ω]");
            ColumnNames.Add("Reaktancja pętli zwarcia na mierniku kontrolnym [Ω]");
            ColumnNames.Add("Bezwzględny błąd pomiaru impedancji [Ω]");
            ColumnNames.Add("Bezwzględny błąd pomiaru rezystancji [Ω]");
            ColumnNames.Add("Bezwzględny błąd pomiaru reaktancji [Ω]");
            ColumnNames.Add("Dopuszczalny błąd pomiaru impedancji, rezystancji i reaktancji [Ω]");
            ColumnNames.Add("Niepewność całkowita rozszrzona pomiaru impedancji pętli [Ω]");
            ColumnNames.Add("Niepewność całkowita rozszrzona pomiaru impedancji pętli");

            Title = "Sprawdzenie normy zgodnie z wymogami instrukcji IZ/008/DASL";
        }
    }
}
