using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarTrader.EntityFramework.Entities;

namespace CarTrader.EntityFramework.Context
{
    public class CarTraderContext : DbContext
    {
        public CarTraderContext() : base(typeof(CarTraderContext).Name)
        {
        }

        public DbSet<AdvertEntity> Adverts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
