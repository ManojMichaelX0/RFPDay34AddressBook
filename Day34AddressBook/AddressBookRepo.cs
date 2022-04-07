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
                            addressBookModel.LastName = dr.GetString(1);
                            addressBookModel._address = dr.GetString(2);
                            addressBookModel.City = dr.GetString(3);
                            addressBookModel._State = dr.GetString(4);
                            addressBookModel.Zip = dr.GetInt32(5);
                            addressBookModel.PhoneNumber = dr.GetString(6);
                            addressBookModel.email = dr.GetString(7);
                            addressBookModel.RelationType = dr.GetString(8);
                           

                            //display retieved record

                            Console.WriteLine("FirstName : "+"{0}"+", Last Name : "+"{1}"+", Address : "+"{2}"+", City : "+"{3}"+", State"+"{4}"+", Zip : "+"{5}"+", PhoneNumber : "+"{6}"+", Email : "+"{7}"+", Relation Type : "+"{8}",addressBookModel.FirstName, addressBookModel.LastName, addressBookModel._address, addressBookModel.City, addressBookModel._State, addressBookModel.Zip, addressBookModel.PhoneNumber, addressBookModel.email,addressBookModel.RelationType);

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
        public bool AddAddressBook(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SPAddressBook", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@_address", model._address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@_State", model._State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@RelationType", model.RelationType);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
