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
        /// Gets the count of each type after grouping by type UC10
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public void GetCountByType(DataTable dataTable)
        {
            var recordData = dataTable.AsEnumerable().GroupBy(r => r.Field<string>("type")).Select(r => new { type = r.Key, count = r.Count() });
            foreach (var data in recordData)
            {
                Console.WriteLine("Count for type- " + data.count);
            }
        }
    }
}
 