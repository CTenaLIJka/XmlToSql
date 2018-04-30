using System;

namespace XmlToSqlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PlacingWayXmlProvider placingProvider = new PlacingWayXmlProvider();
            var placingWays = placingProvider.GetPlacingWays(@"XmlSources/nsiPlacingWay.xml");
            foreach (var item in placingWays)
                Console.WriteLine(item);
            Console.ReadLine();
        }

    }
}
