namespace Ilegra.Core.Models
{
    public class Customer:BaseEntity
    {
        public string CNPJ { get; set; }
        public string BusinessArea { get; set; }
    }
}