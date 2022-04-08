using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Day34AddressBook
{
    internal class ReadingTableAndWritingtoJson
    {
        public void GetJson()
        {
            string json=string.Empty;
            string path = @"Data Source=localhost\SQLEXPRESS;Database=Address_Book;Trusted_Connection=True";
            List<object> list = new List<object>();
            using(SqlConnection connect = new SqlConnection(path))
            {
                connect.Open();
                using (SqlCommand cmd = connect.CreateCommand())
                {
                    cmd.CommandText = "Select * From Address_Book_Table";
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, object> records = new Dictionary<string, object>();
                            for(int i=0; i<reader.FieldCount; i++)
                            {
                                records.Add(reader.GetName(i), reader[i]);
                            }
                            list.Add(records);
                        }
                    }
                }
            }
            json=JsonConvert.SerializeObject(list);
            using (StreamWriter sw = new StreamWriter(File.Create(@"D:\.net\Day 34 Address Book\Day34AddressBook\TableData_TO_JsonFile.json.")))
            {
                sw.Write(json);
            }
            ReadallLines();
            void ReadallLines()
            {
                string path = @"D:\.net\Day 34 Address Book\Day34AddressBook\TableData_TO_JsonFile.json";
                string[] lines;
                lines = File.ReadAllLines(path);
                foreach (var l in lines)
                {
                    Console.WriteLine(l);
                }
            }
        }
        

    }


}