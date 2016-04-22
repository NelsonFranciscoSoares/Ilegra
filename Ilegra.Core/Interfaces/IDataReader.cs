using System;
using System.Collections.Generic;

namespace Ilegra.Core.Interfaces
{
    public interface IDataReader : IDisposable
    {
        Dictionary<int, string> ReadFile();
    }
}