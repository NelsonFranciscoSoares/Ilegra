using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ilegra.Core.Models;

namespace Ilegra.DomainQueries
{
    public static class DomainQueries
    {
        public static int NumberOfCustomers(IEnumerable<Customer> customers)
        {
            return customers.GroupBy(param => param.CNPJ,
                param => param,
                (key, value) => new
                {
                    CNJPJ = key,
                    Count = value.Count()
                }).Max(param => param.Count);
        }

        public static int NumberOfSalesman(IEnumerable<Salesman> salesman)
        {
            return salesman.GroupBy(param => param.CPF,
                param => param,
                (key, value) => new
                {
                    CPF = key,
                    Count = value.Count()
                }).Max(param => param.Count);
        }

        public static string TheMostExpensiveSale(IEnumerable<Sales> sales)
        {
            return
                sales.First(
                    param => param.Details.Any(param1 => param1.Price == param.Details.Max(param2 => param2.Price)))
                    .SaleId;
        }

        public static string TheWorstSalesman(IEnumerable<Sales> sales)
        {
            return sales.GroupBy(param => param.Name,
                param => param,
                (key, value) => new
                {
                    Name = key,
                    SalesDetails = value.SelectMany(param => param.Details),
                    Count = value.Min(param => param.Details.Count())
                }).First(param => param.SalesDetails.Count() == param.Count).Name;
        }
    }
}
