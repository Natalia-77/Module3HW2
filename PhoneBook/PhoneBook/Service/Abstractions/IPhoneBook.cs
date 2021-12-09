using System.Collections.Generic;
using PhoneBook.Models;

namespace PhoneBook.PhoneCollection.Abstractions
{
    public interface IPhoneBook<T>
    {
        public IReadOnlyCollection<T> this[string key] { get; }
        public void Add(T contact);
    }
}
