using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LaboratoryApp.ViewModel
{
    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;// ((double)value).ToString("N3", CultureInfo.CreateSpecificCulture("sv-SE"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string g = (string) value;
            string sub1,sub2;

            if(g.Contains(","))
            {
                sub1 = g.Substring(0,g.IndexOf(","));
                sub2 = g.Substring(g.IndexOf(",") + 1);

                if(sub2.Length >=4)
                {
                    sub2 = sub2.Substring(0,4);
                }

                g = sub1 + "." + sub2;


                value = g;
            }
            else if(g.Contains("."))
            {
                sub1 = g.Substring(g.IndexOf(".")+1);
                sub2 = g.Substring(0, g.IndexOf("."));
                
                if (sub2.Length >= 4)
                {
                    sub2 = sub2.Substring(0, 4);
                }

                g = sub1 + "." + sub2;
                value = g;

            }
            else
            {
                value = g;
            }
            return value;
        }
    }
}
