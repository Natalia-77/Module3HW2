using System;
using System.Collections.Generic;
using PhoneBook.Models;

namespace PhoneBook.Service
{
    public class CompareNames<T> : IComparer<T>
        where T : Contact
    {
        public int Compare(T x, T y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }
}
