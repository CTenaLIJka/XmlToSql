using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToSqlProject.DataBaseModels
{
    public class ContractDbModel
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
        public FoundationDbModel Foundation { get; set; }
        public CustomerDbModel Customer { get; set; }
    }
}
