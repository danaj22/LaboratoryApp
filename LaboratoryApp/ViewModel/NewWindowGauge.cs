﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowGauge:OpenNewWindow
    {
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
        public string SerialNumber { get; set; }
    }
}
