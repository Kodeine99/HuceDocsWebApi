using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HuceDocs.Data.DbContext
{
    public class HuceDocsContextFactory : IDesignTimeDbContextFactory<HuceDocsContext>
    {

        public HuceDocsContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("HuceDocs");

            var optionBuilder = new DbContextOptionsBuilder<HuceDocsContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new HuceDocsContext(optionBuilder.Options);
        }
    }
}