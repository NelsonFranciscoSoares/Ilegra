using System.Collections.Generic;
using Ilegra.Core.Models;

namespace Ilegra.Core.Interfaces
{
    public interface IParser
    {
        IEnumerable<Customer> ParseCustomerData(Dictionary<int, string> inputData);
        IEnumerable<Salesman> ParseSalesmanData(Dictionary<int, string> inputData);
        IEnumerable<Sales> ParseSales(Dictionary<int, string> inputData);
    }
}