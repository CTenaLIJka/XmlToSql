using System;
using System.Xml.Linq;

namespace XmlToSqlProject.ContractData
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


        private string CUSTOMER = "customer";
        private string FULL_NAME = "fullName";
        private string INN = "inn";
        private string KPP = "kpp";

        private const string XMLNS = @"{http://zakupki.gov.ru/oos/export/1}";
        private const string OOS = @"{http://zakupki.gov.ru/oos/types/1}";


        public ContractXmlProvider()
        {

        }

        private string GetFullElementNameXmlns(string shortName)
        {
            return XMLNS + shortName;
        }

        private string GetFullElementNameOos(string shortName)
        {
            return OOS + shortName;
        }

        public ContractData GetContract(string filePath)
        {            
            try
            {
                XDocument xdoc = XDocument.Load(filePath);

                var xExportElement = xdoc.Element(GetFullElementNameXmlns("export"));
                var xContract = xExportElement.Element(GetFullElementNameXmlns(CONTRACT));
                var id = int.Parse(GetNodeValue(xContract, ID));
                var regNum = GetNodeValue(xContract, REG_NUM);
                var number = GetNodeValue(xContract, NUMBER);
                var publishDate = DateTime.Parse(GetNodeValue(xContract, PUBLISH_DATE));
                var signDate = DateTime.Parse(GetNodeValue(xContract, SIGN_DATE));
                var versionNumber = int.Parse(GetNodeValue(xContract, VERSION_NUMBER));
                var price = int.Parse(GetNodeValue(xContract, PRICE));
                var foundation = GetFoundation(xContract);
                var customer = GetCustomer(xContract);

                var contract = new ContractData()
                {
                    Id = id,
                    RegNumber = regNum,
                    Number = number,
                    PublishDate = publishDate,
                    SignDate = signDate,
                    Version = versionNumber,
                    Price = price,
                    Foundation = foundation,
                    Customer = customer,
                };
                return contract;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return new ContractData();            
        }

        private Customer GetCustomer(XElement xContract)
        {
            var xCustomer = xContract.Element(GetFullElementNameOos(CUSTOMER));
            var regNumber = GetNodeValue(xCustomer, REG_NUM);
            var fullName = GetNodeValue(xCustomer, FULL_NAME);
            var inn = GetNodeValue(xCustomer, INN);
            var kpp = GetNodeValue(xCustomer, KPP);
            var customer = new Customer
            {
                RegNumber = regNumber,
                FullName = fullName,
                Inn = inn,
                Kpp = kpp,
            };
            return customer;
        }

        private Foundation GetFoundation(XElement xContract)
        {
            var xFoundation = xContract.Element(GetFullElementNameOos(FOUNDATION));

            bool singleCustomer;
            bool.TryParse(GetNodeValue(xFoundation, SINGLE_CUSTOMER), out singleCustomer);

            var xOosOrder = xFoundation.Element(GetFullElementNameOos(OOS_ORDER));
            var notificationNumber = GetNodeValue(xOosOrder, NOTIFICATION_NUMBER);
            var lotNumber = int.Parse(GetNodeValue(xOosOrder, LOT_NUMBER));
            var placing = int.Parse(GetNodeValue(xOosOrder, PLACING));


            var foundation = new Foundation
            {
                SingleCustomer = singleCustomer,
                Order = new Order
                {
                    NotificationNumber = notificationNumber,
                    LotNumber = lotNumber,
                    Placing = placing
                }
            };
            return foundation;

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
