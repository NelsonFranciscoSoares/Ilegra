using System.Collections.Generic;
using Ilegra.Core.Models;

namespace Ilegra.Core.Interfaces
{
    public interface IQueue
    {
        void Add(IEnumerable<Customer> customers);
        void Add(IEnumerable<Salesman> salesmen);
        void Add(IEnumerable<Sales> sales);
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Salesman> GetSalesMen();
        IEnumerable<Sales> GetSales();
    }
}