using System;

namespace XmlToSqlProject.ContractData
{
    public class ContractData
    {
        public int Id { get; set; }
        public string RegNumber { get; set; }
        public string Number { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime SignDate { get; set; }
        public int Version { get; set; }
        public double Price { get; set; }
        public string Href { get; set; }
        public string Stage { get; set; }
        public Foundation Foundation { get; set; }
        public Customer Customer { get; set; }


        public override string ToString()
        {
            return $"{Id} - {RegNumber}";
        }

    }
}
