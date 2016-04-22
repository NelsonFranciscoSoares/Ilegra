using System;
using System.Collections.Generic;
using Ilegra.Core.Interfaces;
using Ilegra.Core.Models;

namespace Ilegra.Infrastructure.Parser
{
    public class Parser : IParser
    {
        private const string CUSTOMER_IDENTIFIER = "001";
        private const string SALESMAN_IDENTIFIER = "002";
        private const string SALES_IDENTIFIER = "003";
        
        public IEnumerable<Customer> ParseCustomerData(Dictionary<int, string> inputData)
        {
            var customers = new List<Customer>();
            
            foreach (var data in inputData)
            {
                var dataSplitted = data.Value.Split('ç');
                if (dataSplitted[0] == CUSTOMER_IDENTIFIER)
                {
                    customers.Add(new Customer
                    {
                        Id = CUSTOMER_IDENTIFIER,
                        CNPJ = dataSplitted[1],
                        Name = dataSplitted[2],
                        BusinessArea = dataSplitted[3]
                    });
                }
            }
            
            return customers;
        }

        public IEnumerable<Salesman> ParseSalesmanData(Dictionary<int, string> inputData)
        {
            var salesman = new List<Salesman>();

            foreach (var data in inputData)
            {
                var dataSplitted = data.Value.Split('ç');
                if (dataSplitted[0] == SALESMAN_IDENTIFIER)
                {
                    salesman.Add(new Salesman
                    {
                        Id = SALES_IDENTIFIER,
                        CPF = dataSplitted[1],
                        Name = dataSplitted[2],
                        Salary = decimal.Parse(dataSplitted[3])
                    });
                }
            }

            return salesman;
        }

        public IEnumerable<Sales> ParseSales(Dictionary<int, string> inputData)
        {
            var sales = new List<Sales>();

            foreach (var data in inputData)
            {
                var dataSplitted = data.Value.Split('ç');
                if (dataSplitted[0] == SALES_IDENTIFIER)
                {
                    sales.Add(new Sales
                    {
                        Id = SALES_IDENTIFIER,
                        SaleId = dataSplitted[1],
                        Name = dataSplitted[3],
                        Details = ParseSalesDetails(dataSplitted[2])
                    });
                }
            }

            return sales;
        }

        private IEnumerable<SalesDetail> ParseSalesDetails(string details)
        {
            var salesDetails = new List<SalesDetail>();
            var dataSplitted = details.Substring(1, details.Length - 2).Split(',');

            foreach (var data in dataSplitted)
            {
                var dataItemSplitted = data.Split('-');
                salesDetails.Add(new SalesDetail
                {
                    ItemId = dataItemSplitted[0],
                    Quantity = int.Parse(dataItemSplitted[1]),
                    Price = decimal.Parse(dataItemSplitted[2])
                });
            }

            return salesDetails;
        }
    }
}
