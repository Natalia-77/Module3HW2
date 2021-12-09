using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using PhoneBook.Enum;
using PhoneBook.Models;
using PhoneBook.PhoneCollection.Abstractions;
using PhoneBook.Service;
using PhoneBook.Service.Abstractions;

namespace PhoneBook.PhoneCollection
{
    public class PhoneBook<T> : IPhoneBook<T>
         where T : Contact
    {
        private readonly IConfigService _configService;
        private IDictionary<CultureInfo, List<T>> _cultures;
        private IDictionary<SymdolTypes, List<T>> _symbols;
        private ICultureService _cultureService;
        private string _alphabeth;
        public PhoneBook()
        {
            _cultureService = new CultureService();
            _cultures = new Dictionary<CultureInfo, List<T>>();
            _symbols = new Dictionary<SymdolTypes, List<T>>();
            _configService = new ConfigService();
            _alphabeth = _configService.Config.Alphabeth.Letters;
            AddCultureToDictionary();
            AddSymbolToDictionary();
        }

        public IReadOnlyCollection<T> this[string key]
        {
            get
            {
                var collection = DefineCollection(key);
                var result = new List<T>();

                foreach (var contact in collection)
                {
                    if (contact.Name.StartsWith(key))
                    {
                        result.Add(contact);
                    }
                }

                return result;
            }
        }

        public void ShowEnglish()
        {
            foreach (var item in _alphabeth)
            {
                IReadOnlyCollection<T> listContact = this[item.ToString()];
                var count = 0;
                foreach (var resContact in listContact)
                {
                    if (count == 0)
                    {
                        System.Console.WriteLine(item.ToString());
                    }

                    if (resContact != null)
                    {
                        System.Console.WriteLine($"{resContact.LastName} {resContact.Name}");
                        count++;
                    }
                }
            }
        }

        public void Add(T contact)
        {
            var contactName = contact.Name;
            var valueContact = DefineCollection(contactName);
            valueContact.Add(contact);
            valueContact.Sort(new CompareNames<T>());
        }

        private void AddCultureToDictionary()
        {
            _cultureService.AddCulture("en-GB");
            _cultureService.AddCulture("ru-RU");
            foreach (var culture in _cultureService.GetAllCultures())
            {
                _cultures.Add(culture, new List<T>());
            }
        }

        private void AddSymbolToDictionary()
        {
            _symbols.Add(SymdolTypes.Symbol, new List<T>());
            _symbols.Add(SymdolTypes.Number, new List<T>());
        }

        private List<T> DefineCollection(string contactName)
        {
            try
            {
                var currentCulture = _cultureService.GetCultureInfo(contactName);
                return _cultures[currentCulture];
            }
            catch
            {
                char[] res = contactName.ToCharArray();

                if (char.IsDigit(res[0]))
                {
                    return _symbols[SymdolTypes.Number];
                }

                return _symbols[SymdolTypes.Symbol];
            }
        }
    }
}
