using System;

namespace Day34AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book ADO.Net!");
            AddressBookRepo repo = new AddressBookRepo();
            //UC 20
            AddressBookModel model = new AddressBookModel();

            model.FirstName = "Eren";
            model.LastName = "Jeager";
            model._address = "25-4-710";
            model.City = "Wall Maria";
            model._State = "Anime";
            model.Zip = 400504;
            model.PhoneNumber = "8106529025";
            model.email = "erenjeager@gmail.com";
            model.RElationType = "Brother";
            model.StartDate = DateTime.Now;
            repo.AddDetials(model);

            //Call One Method At a Time Comment Other Method While Calling the Required Method
            //UC 16
            //repo.GetDetails();

            //UC 17
            //repo.Update(model);

            //UC-18 Alter Table Call This method First while Commenting GetDatRange method and vise versa
            //repo.Alter(model);

            //UC-18 Get Range
            //repo.GetDateRange(model);

            //UC 19
            //repo.Count(model);

            


        }


    }
}
