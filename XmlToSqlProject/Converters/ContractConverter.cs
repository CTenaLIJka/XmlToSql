using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlToSqlProject.DataBaseModels;
using XmlToSqlProject.ContractData;

namespace XmlToSqlProject.Converters
{
    public class ContractConverter
    {

        public ContractDbModel Convert(ContractData.ContractData contract)
        {
            return new ContractDbModel();
        }
    }
}
