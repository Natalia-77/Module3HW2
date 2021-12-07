using System.Collections.Generic;
using PhoneBook.Models;

namespace PhoneBook.PhoneCollection.Abstractions
{
    public interface IPhoneBook<T> : IEnumerable<T>
         where T : Contact
    {
        public void Add(T contact);
    }
}
