using ShortContract.XmlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShortContract.Providers
{
    public class ContractXmlProvider
    {

        private string CONTRACT = "contract";

        private string ID = "id";
        private string REG_NUM = "regNum";
        private string NUMBER = "number";
        private string PUBLISH_DATE = "publishDate";
        private string SIGN_DATE = "signDate";
        private string VERSION_NUMBER = "versionNumber";
        private string PRICE = "price";

        private string FOUNDATION = "foundation";
        private string SINGLE_CUSTOMER = "singleCustomer";
        private string OOS_ORDER = "oosOrder";
        private string NOTIFICATION_NUMBER = "notificationNumber";
        private string LOT_NUMBER = "lotNumber";
        private string PLACING = "placing";

        private string HREF = "href";

        private string CUSTOMER = "customer";
        private string FULL_NAME = "fullName";
        private string SHORT_NAME = "shortName";
        private string ORGANIZATION_NAME = "organizationName";
        private string INN = "inn";
        private string INN_B = "INN";
        private string KPP = "kpp";
        private string KPP_B = "KPP";
        private string OKPO = "okpo";
        private string OKPO_B = "OKPO";

        private string SUPPLIERS = "suppliers";
        private string SUPPLIER = "supplier";
        private string LEGAL_ENTITY_RF = "legalEntityRF";
        private string OKTMO_CODE = "oktmoCode";
        private string OKTMO = "oktmo";
        private string OKTMO_B = "OKTMO";
        private string CODE = "code";
        private string ADDRESS = "address";
        private string FACTUAL_ADDRESS = "factualAddress";



        private const string XMLNS = @"{http://zakupki.gov.ru/oos/export/1}";
        private const string OOS = @"{http://zakupki.gov.ru/oos/types/1}";


        public ContractXmlProvider()
        {

        }

        public ContractXmlModel GetContract(string filePath)
        {
            try
            {
                XDocument xdoc = XDocument.Load(filePath);

                var xExportElement = xdoc.Element(GetFullElementNameXmlns("export"));
                var xContract = xExportElement.Element(GetFullElementNameXmlns(CONTRACT));
                var version = xContract.Attribute("schemeVersion").Value;
                var id = GetNodeValue(xContract, ID);
                var href = GetNodeValue(xContract, HREF);
                var customer = GetCustomer(xContract, version);
                var supplier = GetSupplier(xContract, version);

                var contract = new ContractXmlModel()
                {
                    Id = id,
                    Href = href,
                    Customer = customer,
                    Supplier = supplier
                };
                return contract;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return new ContractXmlModel();
        }

        private CustomerXmlModel GetCustomer(XElement xContract, string version)
        {
            if (version.Equals("7.0"))
            {
                return GetCustomerV6(xContract);
            }
            if (version.Equals("6.3"))
            {
                return GetCustomerV6(xContract);
            }
            if (version.Equals("6.0"))
            {
                return GetCustomerV6(xContract);
            }

            if (version.Equals("5.0"))
            {
                return GetCustomerV5(xContract);
            }
            if (version.Equals("4.5"))
            {
                return GetCustomerV45(xContract);
            }
            return new CustomerXmlModel();
        }
        private SupplierXmlModel GetSupplier(XElement xContract, string version)
        {
            if (version.Equals("7.0"))
            {
                return GetSupplierV6(xContract);
            }
            if (version.Equals("6.3"))
            {
                return GetSupplierV6(xContract);
            }
            if (version.Equals("6.0"))
            {
                return GetSupplierV6(xContract);
            }
            if (version.Equals("5.0"))
            {
                return GetSupplierV5(xContract);
            }
            if (version.Equals("4.5"))
            {
                return GetSupplierV45(xContract);
            }
            return new SupplierXmlModel();
        }

        
     

        private CustomerXmlModel GetCustomerV6(XElement xContract)
        {
            var xCustomer = xContract.Element(GetFullElementNameOos(CUSTOMER));
            var regNum = GetNodeValue(xCustomer, REG_NUM);
            var fullName = GetNodeValue(xCustomer, FULL_NAME);
            var shortName = GetNodeValue(xCustomer, SHORT_NAME);
            var inn = GetNodeValue(xCustomer, INN);
            var kpp = GetNodeValue(xCustomer, KPP);
            var okpo = GetNodeValue(xCustomer, OKPO_B);


            var customer = new CustomerXmlModel
            {               
                FullName = fullName,
                Inn = inn,
                Kpp = kpp,
                Okpo = okpo,
                ShortName = shortName,
                RegNum = regNum
            };
            return customer;
        }

        private SupplierXmlModel GetSupplierV6(XElement xContract)
        {
            var xSuppliers = xContract.Element(GetFullElementNameOos(SUPPLIERS));
            var xSupplier = xSuppliers.Element(GetFullElementNameOos(SUPPLIER));
            var xLegalEntityRf = xSupplier.Element(GetFullElementNameOos(LEGAL_ENTITY_RF));
            var fullName = GetNodeValue(xLegalEntityRf, FULL_NAME);
            var shortName = GetNodeValue(xLegalEntityRf, SHORT_NAME);
            var inn = GetNodeValue(xLegalEntityRf, INN_B);
            var kpp = GetNodeValue(xLegalEntityRf, KPP_B); 
            var okpo = GetNodeValue(xLegalEntityRf, OKPO_B);            
            var xOktmo = xLegalEntityRf.Element(GetFullElementNameOos(OKTMO_B));
            var oktmoCode = GetNodeValue(xOktmo, CODE);
            var address = GetNodeValue(xLegalEntityRf, ADDRESS);

            var supplier = new SupplierXmlModel
            {
                FullName = fullName,
                Inn = inn,
                Kpp = kpp,
                Okpo = okpo,
                ShortName = shortName,
                OktmoCode = oktmoCode,
                Address = address
            };

            return supplier;
        }

        private CustomerXmlModel GetCustomerV5(XElement xContract)
        {
            var xCustomer = xContract.Element(GetFullElementNameOos(CUSTOMER));
            var regNum = GetNodeValue(xCustomer, REG_NUM);
            var fullName = GetNodeValue(xCustomer, FULL_NAME);
            var shortName = GetNodeValue(xCustomer, SHORT_NAME);
            var inn = GetNodeValue(xCustomer, INN);
            var kpp = GetNodeValue(xCustomer, KPP);
            var okpo = GetNodeValue(xCustomer, OKPO_B);


            var customer = new CustomerXmlModel
            {
                FullName = fullName,
                Inn = inn,
                Kpp = kpp,
                Okpo = okpo,
                ShortName = shortName,
                RegNum = regNum
            };
            return customer;
        }

        private SupplierXmlModel GetSupplierV5(XElement xContract)
        {
            var xSuppliers = xContract.Element(GetFullElementNameOos(SUPPLIERS));
            var xSupplier = xSuppliers.Element(GetFullElementNameOos(SUPPLIER));
            var xLegalEntityRf = xSupplier.Element(GetFullElementNameOos(LEGAL_ENTITY_RF));
            var fullName = GetNodeValue(xLegalEntityRf, FULL_NAME);
            var shortName = GetNodeValue(xLegalEntityRf, SHORT_NAME);
            var inn = GetNodeValue(xLegalEntityRf, INN_B);
            var kpp = GetNodeValue(xLegalEntityRf, KPP_B);
            var okpo = GetNodeValue(xLegalEntityRf, OKPO_B);
            var xOktmo = xLegalEntityRf.Element(GetFullElementNameOos(OKTMO_B));
            var oktmoCode = GetNodeValue(xOktmo, CODE);
            var address = GetNodeValue(xLegalEntityRf, ADDRESS);

            var supplier = new SupplierXmlModel
            {
                FullName = fullName,
                Inn = inn,
                Kpp = kpp,
                Okpo = okpo,
                ShortName = shortName,
                OktmoCode = oktmoCode,
                Address = address
            };

            return supplier;
        }




        private CustomerXmlModel GetCustomerV45(XElement xContract)
        {
            var xCustomer = xContract.Element(GetFullElementNameOos(CUSTOMER));
            var regNum = GetNodeValue(xCustomer, REG_NUM);
            var fullName = GetNodeValue(xCustomer, FULL_NAME);
            var shortName = GetNodeValue(xCustomer, SHORT_NAME);
            var inn = GetNodeValue(xCustomer, INN);
            var kpp = GetNodeValue(xCustomer, KPP);
            var okpo = GetNodeValue(xCustomer, OKPO);


            var customer = new CustomerXmlModel
            {
                FullName = fullName,
                Inn = inn,
                Kpp = kpp,
                Okpo = okpo,
                ShortName = shortName,
                RegNum = regNum
            };
            return customer;
        }

        private SupplierXmlModel GetSupplierV45(XElement xContract)
        {
            var xSuppliers = xContract.Element(GetFullElementNameOos(SUPPLIERS));
            var xSupplier = xSuppliers.Element(GetFullElementNameOos(SUPPLIER));           
            var fullName = GetNodeValue(xSupplier, FULL_NAME);
            var shortName = GetNodeValue(xSupplier, ORGANIZATION_NAME);
            var inn = GetNodeValue(xSupplier, INN);
            var kpp = GetNodeValue(xSupplier, KPP);
            var okpo = GetNodeValue(xSupplier, OKPO);
            var oktmoCode = GetNodeValue(xSupplier, OKTMO_CODE);
            var address = GetNodeValue(xSupplier, FACTUAL_ADDRESS);

            var supplier = new SupplierXmlModel
            {
                FullName = fullName,
                Inn = inn,
                Kpp = kpp,
                Okpo = okpo,
                ShortName = shortName,
                OktmoCode = oktmoCode,
                Address = address
            };

            return supplier;
        }

        private string GetFullElementNameXmlns(string shortName)
        {
            return XMLNS + shortName;
        }
        private string GetFullElementNameOos(string shortName)
        {
            return OOS + shortName;
        }

        private string GetNodeValue(XElement xContract, string nodeName)
        {
            try
            {
                var elementName = GetFullElementNameOos(nodeName);
                var node = xContract.Element(elementName);
                return node.Value;
            }
            catch { return string.Empty; }
        }


    }
}
