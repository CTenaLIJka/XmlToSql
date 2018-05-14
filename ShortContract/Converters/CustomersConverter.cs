using ShortContract.DbModels;
using ShortContract.XmlModels;
using System.Collections.Generic;
using System.Linq;

namespace ShortContract.Converters
{
    public class CustomersConverter
    {

        static public Customer ConvertCustomer(CustomerXmlModel model)
        {
            Customer newModel = new Customer();
            newModel.Inn = model.Inn;
            newModel.Kpp = model.Kpp;
            newModel.Okpo = model.Okpo;
            newModel.FullName = model.FullName;
            newModel.ShortName = model.ShortName;
            newModel.RegNum = model.RegNum;

            return newModel;
        }

        static public Supplier ConvertSupplier(SupplierXmlModel model)
        {
            Supplier newModel = new Supplier();
            newModel.Inn = model.Inn;
            newModel.Kpp = model.Kpp;
            newModel.Okpo = model.Okpo;
            newModel.FullName = model.FullName;
            newModel.ShortName = model.ShortName;
            newModel.OktmoCode = model.OktmoCode;
            newModel.Address = model.Address;

            return newModel;
        }

        public static Contract ConvertContract(ContractXmlModel model)
        {
            Contract newModel = new Contract();
            newModel.Id = model.Id;
            newModel.Href = model.Href;
            newModel.SupplierId = model.Supplier.Inn;
            newModel.CustomerId = model.Customer.Inn;
            newModel.Supplier = ConvertSupplier(model.Supplier);
            newModel.Customer = ConvertCustomer(model.Customer);
            return newModel;
        }

        public static List<Contract> ConvertContracts(List<ContractXmlModel> models)
        {
            
            var contracts = models.Select(m => ConvertContract(m));   

            return contracts.ToList();

        }



    }
    class SupplierComparer : IEqualityComparer<Supplier>
    {
        public string GetComparablePart(Supplier s)
        {
            return s.Inn;
        }
        public bool Equals(Supplier x, Supplier y)
        {
            return GetComparablePart(x).Equals(GetComparablePart(y));
        }

        public int GetHashCode(Supplier obj)
        {
            return GetComparablePart(obj).GetHashCode();
        }
    }

    class CustomerComparer : IEqualityComparer<Customer>
    {
        public string GetComparablePart(Customer s)
        {
            return s.Inn;
        }
        public bool Equals(Customer x, Customer y)
        {
            return GetComparablePart(x).Equals(GetComparablePart(y));
        }

        public int GetHashCode(Customer obj)
        {
            return GetComparablePart(obj).GetHashCode();
        }
    }
}
