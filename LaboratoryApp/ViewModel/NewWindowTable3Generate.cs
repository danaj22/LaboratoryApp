﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowTable3Generate : NewWindowTableGenerate
    {
         public NewWindowTable3Generate()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            GenerateRandomValuesCommand = new SimpleRelayCommand(GenerateRandomValues);
            ColumnNames.Add("Wartość rezystancji nastawionej na dekadzie kontrolnej [Ω]");
            ColumnNames.Add("Wartość rezystancji mierzonej na mierniku sprawdzanym [Ω]");
            ColumnNames.Add("Różnica wartości rezystancji na mierniku sprawdzanym i kontrolnym [Ω]");
            ColumnNames.Add("Dopuszczalna dolna wartość limitu błędu mierzonej rezystancji [Ω]");
            ColumnNames.Add("Dopuszczalna górna wartość limitu błędu mierzonej rezystancji [Ω]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru rezystancji ±2S(x)[Ω]");
            ColumnNames.Add("Niepewność całkowita rozszerzona typu B pomiaru pomiaru rezystancji ±2S(x)");
        }
        
    }
}
