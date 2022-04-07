using System;

namespace Day34AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book ADO.Net!");
            AddressBookRepo repo = new AddressBookRepo();
            AddressBookModel model = new AddressBookModel();
            //Call One Method At a Time Comment Other Method While Calling the Required Method
            //repo.Update(model);
            //repo.GetDetails();
            //repo.Alter(model);
            repo.GetDateRange(model);
        }
    }
}
