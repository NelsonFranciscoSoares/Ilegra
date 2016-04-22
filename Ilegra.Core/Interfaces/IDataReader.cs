using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ilegra.Core.Interfaces
{
    public interface IDataReader : IDisposable
    {
        Task<Dictionary<int, string>> ReadFile();
    }
}