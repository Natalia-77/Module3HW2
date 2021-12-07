using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualBasic.CompilerServices;
using PhoneBook.Enum;
using PhoneBook.Models;
using PhoneBook.PhoneCollection.Abstractions;

namespace PhoneBook.PhoneCollection
{
    public class PhoneBook<T> : IPhoneBook<T>
         where T : Contact
    {
        private readonly IDictionary<CultureInfo, IList<T>> _language;
        private readonly IDictionary<SymdolTypes, IList<T>> _chars;

        public PhoneBook()
        {
            _language = new Dictionary<CultureInfo, IList<T>>();
            _chars = new Dictionary<SymdolTypes, IList<T>>();
            AddCultureToDictionary();
            AddSymbolToDictionary();
        }

        public void Add(T contact)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        private void AddCultureToDictionary()
        {
            _language.Add(CultureInfo.GetCultureInfo("ru-RU"), new List<T>());
            _language.Add(CultureInfo.GetCultureInfo("en-US"), new List<T>());
        }

        private void AddSymbolToDictionary()
        {
            _chars.Add(SymdolTypes.Number, new List<T>());
            _chars.Add(SymdolTypes.Symbol, new List<T>());
            _chars.Add(SymdolTypes.Empty, new List<T>());
        }
    }
}
