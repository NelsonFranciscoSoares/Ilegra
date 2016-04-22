using System;

namespace Ilegra.Core
{
    public interface IDataWriter : IDisposable
    {
        void Write(int amountOfCustomers,int amountOfSalesman, string mostExpensiveSaleId, string nameWorstSale);
    }
}