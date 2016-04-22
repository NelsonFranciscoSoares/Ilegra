using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ilegra.Core;

namespace Ilegra.Infrastructure.FileWriter
{
    public class FileWriter : IDataWriter
    {
        private string FilePath { get; set; }
        private StreamWriter Writer { get; set; }

        public FileWriter(string filePath)
        {
            this.FilePath = filePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            this.Writer = new StreamWriter(File.Create(this.FilePath));
        }
        
        public void Write(int amountOfCustomers,int amountOfSalesman, string mostExpensiveSaleId, string nameWorstSale)
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Format("Amount of Customers : {0}", amountOfCustomers));
            sb.AppendLine(string.Format("Amount of Customers : {0}", amountOfSalesman));
            sb.AppendLine(string.Format("The most expensive saleId : {0}", mostExpensiveSaleId));
            sb.AppendLine(string.Format("The worst salesman : {0}", nameWorstSale));

            this.Writer.Write(sb.ToString());
        }

        public void Dispose()
        {
            this.Writer.Dispose();
        }
    }
}
