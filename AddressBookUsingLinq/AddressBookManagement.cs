using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookUsingLinq
{
    class AddressBookManagement
    {
        /// <summary>
        /// Gets the name of the sorted data based on person. UC8
        /// </summary>
        /// <param name="datatable">The datatable.</param>
        public void GetSortedDataBasedOnPersonName(DataTable datatable)
        {
            //order by sorts the row in ascending order
            //thenby sorts the row again and return the row according to specified key 
            var recordData = datatable.AsEnumerable().Where(r => r.Field<string>("city") == "Lakers").OrderBy(r => r.Field<string>("firstName")).ThenBy(r => r.Field<string>("lastName"));
            foreach (var data in recordData)
            {
                Console.WriteLine("FirstName:- " + data.Field<string>("firstName"));
                Console.WriteLine("lastName:- " + data.Field<string>("lastName"));
                Console.WriteLine("Address:- " + data.Field<string>("address"));
                Console.WriteLine("City:- " + data.Field<string>("city"));
                Console.WriteLine("State:- " + data.Field<string>("state"));
                Console.WriteLine("zip:- " + Convert.ToInt32(data.Field<int>("zip")));
                Console.WriteLine("phoneNumber:- " + Convert.ToDouble(data.Field<Double>("phoneNumber")));
                Console.WriteLine("eMail:- " + data.Field<string>("eMail"));
                Console.WriteLine("***************");
            }
        }
    }
}
    

