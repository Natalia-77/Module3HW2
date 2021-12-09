using System;
using System.Text;
using PhoneBook.Models;
using PhoneBook.PhoneCollection;

namespace PhoneBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            var phoneBook = new PhoneBook<Contact>();
            phoneBook.Add(new Contact() { Name = "Aarina", LastName = "Allegrova" });
            phoneBook.Add(new Contact() { Name = "Basha", LastName = "Petrova" });
            phoneBook.Add(new Contact() { Name = "Darina", LastName = "Vasilyeva" });
            phoneBook.Add(new Contact() { Name = "Cada", LastName = "Verba" });
            phoneBook.Add(new Contact() { Name = "*2", LastName = "Volya" });
            phoneBook.Add(new Contact() { Name = "===", LastName = "qwerty" });

            phoneBook.ShowEnglish();
        }
    }
}
