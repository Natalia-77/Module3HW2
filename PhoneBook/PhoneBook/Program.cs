using System;
using PhoneBook.Models;
using PhoneBook.PhoneCollection;

namespace PhoneBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var phoneBook = new PhoneBook<Contact>();
            phoneBook.Add(new Contact() { Name = "Aarina", LastName = "Allegrova" });
            phoneBook.Add(new Contact() { Name = "Basha", LastName = "Petrova" });
            phoneBook.Add(new Contact() { Name = "Darina", LastName = "Vasilyeva" });
            phoneBook.Add(new Contact() { Name = "Cada", LastName = "Verba" });
            phoneBook.Add(new Contact() { Name = "Анна", LastName = "Volya" });

            // phoneBook.ShowEnglish();
            phoneBook.ShowRussian();
        }
    }
}
