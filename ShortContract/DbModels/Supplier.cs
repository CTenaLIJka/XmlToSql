using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortContract.DbModels
{
    [Table("Suppliers")]
    public class Supplier
    {      
        [Key]
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        //public string FirmName { get; set; }
        public string Okpo { get; set; }
        public string OktmoCode { get; set; }
        public string Address { get; set; }
     
        public virtual ICollection<Contract> Contracts {get;set;}

        public Supplier()
        {
            Contracts = new List<Contract>();
        }
    }
}
