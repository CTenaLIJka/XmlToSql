using ShortContract.Contexts;
using ShortContract.Converters;
using ShortContract.DbModels;
using ShortContract.Providers;
using ShortContract.XmlModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortContract
{
    class Program
    {
        static void Main(string[] args)
        {

            var contractFiles = Directory.GetFiles(@"C:\Users\SSV\Documents\Visual Studio 2017\Projects\XmlToSqlProject\ShortContract\contracts");
            var contractProvider = new ContractXmlProvider();
            List<ContractXmlModel> contractXmlList = new List<ContractXmlModel>();
            foreach(var item in contractFiles)
            {
                var contract = contractProvider.GetContract(item);
                contractXmlList.Add(contract);
            }

            var contracts = CustomersConverter.ConvertContracts(contractXmlList);
            

            var suppliers = contractXmlList.Select(m => CustomersConverter.ConvertSupplier(m.Supplier));
            var customers = contractXmlList.Select(m => CustomersConverter.ConvertCustomer(m.Customer));
            var uniqSuppliers = suppliers.Distinct(new SupplierComparer()).ToList();
            var uniqCustomers = customers.Distinct(new CustomerComparer()).ToList();
           
            foreach(var item in contracts)
            {
               var sup = uniqSuppliers.FirstOrDefault(s => s.Inn.Equals(item.Supplier.Inn));
               item.Supplier = sup;
                var cus = uniqCustomers.FirstOrDefault(s => s.Inn.Equals(item.Customer.Inn));
                item.Customer = cus;
            }

            //foreach (var sup in uniqSuppliers)
            //{
            //    var contr = contracts.Where(c => c.SupplierId.Equals(sup.Id));
            //    foreach (var item in contr)
            //    {
            //        sup.Contracts.Add(item);
            //    }
            //}

            //foreach (var cust in uniqCustomers)
            //{
            //    var contr = contracts.Where(c => c.CustomerId.Equals(cust.Inn));
            //    foreach (var item in contr)
            //    {
            //        cust.Contracts.Add(item);
            //    }
            //}



            using (ContractContext context = new ContractContext())
            {
                //context.Contracts.RemoveRange(context.Contracts);
                //  context.Suppliers.RemoveRange(context.Suppliers);
                // context.SaveChanges();
                //context.Suppliers.AddRange(uniqSuppliers);
                context.Contracts.AddRange(contracts);
               // 
                context.SaveChanges();
            }

                Console.ReadLine();
        }
    }

    
}
