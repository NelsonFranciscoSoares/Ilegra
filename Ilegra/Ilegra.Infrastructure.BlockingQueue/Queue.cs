using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ilegra.Core.Interfaces;
using Ilegra.Core.Models;

namespace Ilegra.Infrastructure.BlockingQueue
{
    public class Queue: IQueue
    {
        private BlockingCollection<Customer> CustomersQueue { get; set; }
        private BlockingCollection<Salesman> SalesmenQueue { get; set; }
        private BlockingCollection<Sales> SalesQueue { get; set; }

        public Queue()
        {
            this.CustomersQueue = new BlockingCollection<Customer>();
            this.SalesmenQueue = new BlockingCollection<Salesman>();
            this.SalesQueue = new BlockingCollection<Sales>();
        }

        public void Add(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                this.CustomersQueue.Add(customer);
            }
        }

        public void Add(IEnumerable<Salesman> salesmen)
        {
            foreach (var salesman in salesmen)
            {
                this.SalesmenQueue.Add(salesman);
            }
        }

        public void Add(IEnumerable<Sales> sales)
        {
            foreach (var sale in sales)
            {
                this.SalesQueue.Add(sale);
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return this.CustomersQueue.ToArray();
        }

        public IEnumerable<Salesman> GetSalesMen()
        {
            return this.SalesmenQueue.ToArray();
        }

        public IEnumerable<Sales> GetSales()
        {
            return this.SalesQueue.ToArray();
        }
    }
}
