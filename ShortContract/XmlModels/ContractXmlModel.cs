using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortContract.XmlModels
{
    public class ContractXmlModel
    {
        public string Id { get; set; }
        public string Href { get; set; }
        public SupplierXmlModel Supplier { get; set; }
        public CustomerXmlModel Customer { get; set; }

    }
}
