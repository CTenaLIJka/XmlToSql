using System.Collections.Generic;
using System.Xml.Linq;

namespace XmlToSqlProject
{
    class PlacingWayXmlProvider
    {
        private const string PLACING_WAYLIST = "nsiPlacingWayList";

        private const string PLACING_WAY = "nsiPlacingWay";
        private const string PLACING_WAY_ID = @"placingWayId";
        private const string CODE = @"code";
        private const string NAME = @"name";
        private const string TYPE = @"type";
        private const string SUBSYSTEM_TYPE = @"subsystemType";
        private const string ACTUAL = @"actual";
        private const string COMP_DOCUMENTS = @"compDocuments";
        private const string DOCUMENT = @"document";

        private const string XMLNS = @"{http://zakupki.gov.ru/oos/export/1}";
        private const string OOS = @"{http://zakupki.gov.ru/oos/types/1}";


        private string _xmlns;
        public PlacingWayXmlProvider()
        {
            _xmlns = string.Empty;
        }

        private string GetFullElementNameXmlns(string shortName)
        {
            return XMLNS + shortName;
        }
        private string GetFullElementNameOos(string shortName)
        {
            return OOS + shortName;
        }


        public List<PlacingWayXmlModel> GetPlacingWays(string filePath)
        {
            var list = new List<PlacingWayXmlModel>();
            XDocument xdoc = XDocument.Load(filePath);


            var xExportElement = xdoc.Element(GetFullElementNameXmlns("export"));
            var xPlaycingWays = xExportElement.Element(GetFullElementNameXmlns(PLACING_WAYLIST));

            foreach (XElement xPlacingWay in xPlaycingWays.Elements(GetFullElementNameXmlns(PLACING_WAY)))
            {
                list.Add(GetPlacingWay(xPlacingWay));
            }

            return list;
        }

        private PlacingWayXmlModel GetPlacingWay(XElement node)
        {
            var items = node.Elements();
            foreach (var el in items)
            {

            }
            var te = node.Element(GetFullElementNameOos(PLACING_WAY_ID));


            var placingId = int.Parse(node.Element(GetFullElementNameOos(PLACING_WAY_ID)).Value);
            var placingCode = node.Element(GetFullElementNameOos(CODE)).Value;
            var placingName = node.Element(GetFullElementNameOos(NAME)).Value;
            var placingType = node.Element(GetFullElementNameOos(TYPE)).Value;
            var placingSubsystemType = node.Element(GetFullElementNameOos(SUBSYSTEM_TYPE)).Value;
            var placingActual = bool.Parse(node.Element(GetFullElementNameOos(ACTUAL)).Value);

            var newPlacingWay = new PlacingWayXmlModel
            {
                Id = placingId,
                Code = placingCode,
                Name = placingName,
                Type = placingType,
                SubsystemType = placingSubsystemType,
                IsActual = placingActual
            };

            return newPlacingWay;
        }

    }
}
