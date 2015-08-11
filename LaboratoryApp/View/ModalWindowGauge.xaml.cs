﻿using LaboratoryApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LaboratoryApp.View
{
    /// <summary>
    /// Interaction logic for ModalWindowGauge.xaml
    /// </summary>
    public partial class ModalWindowGauge : Window,IModalWindow
    {
        public InformationAboutModelOfGauge infoGauge = new InformationAboutModelOfGauge();

        public ModalWindowGauge()
        {
            InitializeComponent();
            NewWindowModelOfGauge tmp = new NewWindowModelOfGauge(this);
            DataContext = tmp;
            infoGauge = tmp.AboutModelOfGauge;
        }
        public ModalWindowGauge(InformationAboutModelOfGauge info)
        {
            InitializeComponent();
            DataContext = new NewWindowModelOfGauge(this) { AboutModelOfGauge = infoGauge = info };
        }
    }
}
