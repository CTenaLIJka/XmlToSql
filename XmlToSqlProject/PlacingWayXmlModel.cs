using System.Collections.Generic;

namespace XmlToSqlProject
{
    class PlacingWayXmlModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SubsystemType { get; set; }
        public bool IsActual { get; set; }
      //  public List<CompDocument> CompDocuments { get; set; }
        
        public PlacingWayXmlModel()
        { }
        public override string ToString()
        {
            return $"{Id} - {Code} - {Name} - {Type} - {SubsystemType} - {IsActual}";
        }
    }
}
