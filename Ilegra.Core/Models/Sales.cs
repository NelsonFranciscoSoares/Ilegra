using System.Collections;
using System.Collections.Generic;

namespace Ilegra.Core.Models
{
    public class Sales : BaseEntity
    {
        public string SaleId { get; set; }
        public IEnumerable<SalesDetail> Details { get; set; }
    }
}