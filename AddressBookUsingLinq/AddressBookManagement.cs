using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AddressBookUsingLinq
{
    class AddressBookManagement
    {

        /// <summary>
        /// Retrievings the contact details by state or city. UC6
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public void RetrievingContactDetailsByStateOrCity(DataTable dataTable)
        {
            //lambda syntax for getting data for particular city
            var recordData = dataTable.AsEnumerable().Where(r => r.Field<string>("city") == "Celtics");
            //lambda syntax for getting data for particular state
            var recordDataState = dataTable.AsEnumerable().Where(r => r.Field<string>("state") == "Charlotte");
            foreach (var data in recordDataState)
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


        /// <summary>
        /// Getting the count after grouping by city and state UC7
        /// </summary>
        /// <param name="datatable">The datatable.</param>
        public void GetCountByCityAndState(DataTable datatable)
        {
            //getting count for particular state or city
            var recordData = datatable.AsEnumerable().Where(r => r.Field<string>("city") == "Lakers" && r.Field<string>("state") == "Los Angeles").Count();
            //grouping data by city and state
            var recordedData = from data in datatable.AsEnumerable()
                               group data by new { city = data.Field<string>("city"), state = data.Field<string>("state") } into g
                               select new { city = g.Key, count = g.Count() };
            //displaying data for particular city or state
            Console.WriteLine(recordData);
            //displaying total grouped data
            foreach (var data in recordedData.AsEnumerable())
            {
                Console.WriteLine("city:- " + data.city.city);
                Console.WriteLine("state:- " + data.city.state);
                Console.WriteLine("lastName:- " + data.count);
                Console.WriteLine("*******************");
            }
        }
    }
}

    

