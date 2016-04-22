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
            return customers.GroupBy(param => param.CNPJ).Count();
        }

        public static int NumberOfSalesman(IEnumerable<Salesman> salesman)
        {
            return salesman.GroupBy(param => param.CPF).Count();
        }

        public static string TheMostExpensiveSale(IEnumerable<Sales> sales)
        {
            return sales.GroupBy(param => param.SaleId,
                param => param.Details,
                (key, value) => new
                {
                    SaleId = key,
                    SalesDetails = value.SelectMany(param => param)
                })
                .Select(param => new { param.SaleId, MaxPrice = param.SalesDetails.Max(param1 => param1.Price) })
                .Aggregate((i, j) => i.MaxPrice > j.MaxPrice ? i : j)
                .SaleId;
        }

        public static string TheWorstSalesman(IEnumerable<Sales> sales)
        {
            return sales.GroupBy(param => param.Name,
                param => param.Details,
                (key, value) => new
                {
                    Name = key,
                    SalesDetails = value.SelectMany(param => param),
                })
                .Select(param => new {param.Name, CountSales = param.SalesDetails.Count()})
                .Aggregate((i, j) => i.CountSales < j.CountSales ? i : j)
                .Name;
        }
    }
}
