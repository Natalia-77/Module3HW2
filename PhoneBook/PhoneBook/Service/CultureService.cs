using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PhoneBook.Service.Abstractions
{
    public class CultureService : ICultureService
    {
        private IDictionary<string, CultureInfo> _dictionary;
        public CultureService()
        {
            _dictionary = new Dictionary<string, CultureInfo>();
        }

        public void AddCulture(string nameCulture)
        {
            var cultureInfo = new CultureInfo(nameCulture);
            _dictionary.Add(nameCulture, cultureInfo);
        }

        public CultureInfo[] GetAllCultures()
        {
            return _dictionary.Values.ToArray();
        }

        public CultureInfo GetCultureInfo(string contactName)
        {
            contactName = contactName.ToLower();
            byte[] namebyte = Encoding.Default.GetBytes(contactName);
            var eng = false;
            var rus = false;
            foreach (var ch in namebyte)
            {
                if ((ch >= 97) && (ch <= 122))
                {
                    eng = true;
                }

                if ((ch >= 224) && (ch <= 255))
                {
                    rus = true;
                }
            }

            if (eng)
            {
                return _dictionary["en-GB"];
            }

            if (rus)
            {
                return _dictionary["ru-RU"];
            }

            throw new ArgumentException("Can't define language");
        }
    }
}
