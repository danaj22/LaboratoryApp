using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable5Generate : NewWindowTableGenerate
    {
         
        public NewWindowTable5Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Nastawiona wartość napięcia na mierniku sprawdzanym [V]");

            ColumnNames.Add("Rezystancja odniesienia [Ω]");
            ColumnNames.Add("Wartość prądu pomiarowego na mierniku kontrolnym [A]");
            ColumnNames.Add("Obliczona wartość napięcia pobierczego [V]");

            ColumnNames.Add("Błąd względny nastawy napięcia na mierniku sprawdzanym");
            ColumnNames.Add("Dopuszczalny błąd względny napięcia pobierczego");
            ColumnNames.Add("Rzeczywista wartość prądu pobierczego [mA]");

            ColumnNames.Add("Wymagana wartość prądu pobierczego [mA]");
            ColumnNames.Add("Niepewność całkowita rozszerzona pomiaru napięcia ±2u(x) [V]");
            ColumnNames.Add("Niepewność całkowita rozszerzona pomiaru prądu ±2u(x) [mA]");

            Title = "Sprawdzenie normy zgodnie z wymogami instrukcji IZ/004/DASL";
        }
        
    }
}
