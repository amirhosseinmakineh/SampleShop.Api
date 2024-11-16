using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleShop.InfraStracture.Context
{
    public class DesignTimeFactory
    {
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SampleShopDbContext>
        {

            public SampleShopDbContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<SampleShopDbContext>();
                builder.UseSqlServer("Data Source =.;Initial Catalog = SampleShopApiDb;Integrated Security = true;TrustServerCertificate = True;");
                return new SampleShopDbContext(builder.Options);
            }
        }
    }
}
