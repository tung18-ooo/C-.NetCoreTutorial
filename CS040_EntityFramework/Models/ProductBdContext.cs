using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS040_EntityFramework.Models
{
    public class ProductBdContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            //builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();

        });

        public DbSet<Product> products { get; set; }

        private const string connect = @"
                Data Source=localhost,1433;
                Initial Catalog=data01;
                User ID=SA;Password=password123;
                TrustServerCertificate=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connect);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
