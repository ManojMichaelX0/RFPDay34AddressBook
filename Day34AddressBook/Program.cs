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
            //UC 16
            //repo.GetDetails();

            //UC 17
            //repo.Update(model);

            //UC-18 Alter Table Call This method First while Commenting GetDatRange method and vise versa
            repo.Alter(model);

            //UC-18 Get Range
            repo.GetDateRange(model);
        }
    }
}
