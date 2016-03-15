using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable19Generate : NewWindowTableGenerate
    {
        public NewWindowTable19Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);

            ColumnNames.Add("Rezystancja pętli zwarcia na mierniku sprawdzanym [Ω]");
            ColumnNames.Add("Rezystancja pętli zwarcia na mierniku kontrolnym [Ω]");
            ColumnNames.Add("Bezwzględny błąd pomiaru rezystancji pętli zwarcia [Ω]");
            ColumnNames.Add("Dopuszczalny błąd pomiaru rezystancji pętli zwarcia [Ω]");
            ColumnNames.Add("Niepewność całkowita rozszerzona pomiaru rezystancji pętli zwarcia [Ω]");
            ColumnNames.Add("Niepewność całkowita rozszerzona pomiaru rezystancji pętli zwarcia");

            Title = "Sprawdzenie normy zgodnie z wymogami instrukcji IZ/009/DASL";
        }
    }
}
