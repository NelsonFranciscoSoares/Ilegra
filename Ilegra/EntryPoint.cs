using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ilegra.FileUtils;
using Ilegra.Infrastructure.BlockingQueue;
using Ilegra.Infrastructure.FileReader;
using Ilegra.Infrastructure.FileWriter;
using Ilegra.Infrastructure.Parser;

namespace Ilegra
{
    public class EntryPoint
    {
        public static void Main()
        {
            //Create objects
            var parser = new Parser();
            var queue = new Queue();
            var tasks = new List<Task>();

            // Step 1 - Get Files by Directory
            var filesList = DirectoryUtils.GetDatFilesByDirectory(@"data\in");

            //Step 2 - Iterate and read files 
            foreach (var file in filesList)
            {
                Dictionary<int, string> fileData = null;

                using (var fileReader = new FileReader(file))
                {
                    fileData = fileReader.ReadFile();    
                }

                //Run in parallel the data parse
                var t = Task.Run(() =>
                {
                    var customers = parser.ParseCustomerData(fileData);
                    var salesmen = parser.ParseSalesmanData(fileData);
                    var sales = parser.ParseSales(fileData);

                    queue.Add(customers);
                    queue.Add(salesmen);
                    queue.Add(sales);
                });

                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());

            //Step 3 - Get queue values and calculate values
            var customersList = queue.GetCustomers();
            var salesmenList = queue.GetSalesMen();
            var salesList = queue.GetSales();

            var numberOfCustomers = DomainQueries.DomainQueries.NumberOfCustomers(customersList);
            var numberOfSalesMen = DomainQueries.DomainQueries.NumberOfSalesman(salesmenList);
            var idTheMostExpensiveSale = DomainQueries.DomainQueries.TheMostExpensiveSale(salesList);
            var nameTheWorstSalesman = DomainQueries.DomainQueries.TheWorstSalesman(salesList);

            //Step 4 - Write to output file the results of calculated values
            using (var writer = new FileWriter(@"data\out\flatfile.done.dat"))
            {
                
            }

        }
    }
}
