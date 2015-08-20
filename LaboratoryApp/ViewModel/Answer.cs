using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryApp.ViewModel
{

        public interface IQuestion
        {
            string Name { get; set; }
            void GetContent();
        }

        public class Category
        {
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }
}
