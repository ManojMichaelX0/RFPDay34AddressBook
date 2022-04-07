using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Day34AddressBook
{
    internal class AddressBookRepo
    {
        public static string connectionString = @"Data Source=localhost\SQLEXPRESS;Database=Address_Book;Trusted_Connection=True";
        SqlConnection connection = new SqlConnection(connectionString);

        //UC 16
        public void GetDetails()
        {
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"SELECT * FROM Address_Book_Table";

                    //Define Sql Command Object
                    SqlCommand cmd = new SqlCommand(query, this.connection);

                    this.connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    //check if there are records

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            addressBookModel.FirstName = dr.GetString(0);
                            addressBookModel.RelationType = dr.GetString(8);


                            //display retieved record

                            Console.WriteLine("FirstName : " + "{0}" + ", Last Name : " + "{1}" + ", Address : " + "{2}" + ", City : " + "{3}" + ", State" + "{4}" + ", Zip : " + "{5}" + ", PhoneNumber : " + "{6}" + ", Email : " + "{7}" + ", Relation Type : " + "{8}", addressBookModel.FirstName, addressBookModel.LastName, addressBookModel._address, addressBookModel.City, addressBookModel._State, addressBookModel.Zip, addressBookModel.PhoneNumber, addressBookModel.email, addressBookModel.RelationType);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    //Close Data Reader
                    dr.Close();
                    this.connection.Close();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        //UC 17
        public void Update(AddressBookModel addressBookModel)
        {
            string query = @"Update Address_Book_Table Set RelationType ='Me' Where FirstName='Manoj'";
            SqlCommand cmd = new SqlCommand(query, this.connection);
            this.connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            AddressBookModel addressBook = new AddressBookModel();
            Console.WriteLine("Update Successfull");

            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    addressBook.FirstName = dr.GetString(0);
                    addressBook.RelationType = dr.GetString(8);
                    //display 

                    Console.WriteLine("FirstName : " + "{0}" + "Relation Type : " + "{8}", addressBookModel.FirstName, addressBookModel.RelationType);


                }
            }
            dr.Close();
            this.connection.Close();
        }

    }

}
