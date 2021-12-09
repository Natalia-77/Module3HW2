using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service.Abstractions
{
   public interface ICultureService
    {
        public void AddCulture(string nameCulture);
        public CultureInfo GetCultureInfo(string stringToTest);
        public CultureInfo[] GetAllCultures();
    }
}
