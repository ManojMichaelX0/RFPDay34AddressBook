using System;

namespace Day34AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book ADO.Net!");
            AddressBookRepo repo = new AddressBookRepo();
            repo.GetDetails();

        }
    }
}
