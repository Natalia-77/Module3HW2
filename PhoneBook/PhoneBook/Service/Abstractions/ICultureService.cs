using System.Globalization;

namespace PhoneBook.Service.Abstractions
{
   public interface ICultureService
    {
        public void AddCulture(string nameCulture);
        public CultureInfo GetCultureInfo(string stringToTest);
        public CultureInfo[] GetAllCultures();
    }
}
