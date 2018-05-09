using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlToSqlProject.DataBaseModels;

namespace XmlToSqlProject.DbContexts
{
    public  class ContractDbContext: DbContext
    {
        public ContractDbContext()
            :base("DbConnection")
        { }

        public DbSet<ContractDbModel> Contracts { get; set; }
    }
}
