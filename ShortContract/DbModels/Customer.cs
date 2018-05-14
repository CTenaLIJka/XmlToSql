using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortContract.DbModels
{
    [Table("Customers")]
    public class Customer
    {       
        [Key]
        public string Inn { get; set; }
        public string Kpp { get; set; }
        public string Okpo { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string RegNum { get; set; }
       
        public ICollection<Contract> Contracts { get; set; }                     
        

        public Customer()
        {
            Contracts = new List<Contract>();
        }
    }
}
