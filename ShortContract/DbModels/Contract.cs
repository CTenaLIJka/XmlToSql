using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortContract.DbModels
{
    [Table("Contracts")]
    public class Contract
    {
        public string Id { get; set; }
        public string Href { get; set; }

        
        public string SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

    }
}

