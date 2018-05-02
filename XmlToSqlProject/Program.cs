using System;
using System.IO;
using XmlToSqlProject.ContractData;

namespace XmlToSqlProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started Parsing PlacingWays");

            PlacingWayXmlProvider placingProvider = new PlacingWayXmlProvider();
            var placingWays = placingProvider.GetPlacingWays(@"XmlSources/nsiPlacingWay.xml");
            foreach (var item in placingWays)
                Console.WriteLine(item);
            

            Console.WriteLine("Ended Parsing PlacingWays");
            Console.WriteLine("--------------------------");
            Console.WriteLine();

            var contractFiles = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\contracts");
            var contractPath = contractFiles[0];
            var contractProvider = new ContractXmlProvider();
            var contract = contractProvider.GetContract(contractPath);

            Console.WriteLine(contract.ToString());
            Console.ReadLine();
        }

    }
}
