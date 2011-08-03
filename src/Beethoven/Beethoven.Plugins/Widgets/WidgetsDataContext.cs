using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Beethoven.Configuration;
using System.Configuration;
namespace Beethoven.Plugins.Widgets
{
    public class WidgetsDataContext : DbContext
    {
        private readonly BeethovenConfiguration _configuration = ConfigurationManager.GetSection("BeethovenConfiguration") as BeethovenConfiguration;

        public WidgetsDataContext()
        {
            base.Database.Connection.ConnectionString = _configuration.DataSource.ConnectionString;
        }

        public IDbSet<Widget> Widgets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Widget>().ToTable("Widgets");

            base.OnModelCreating(modelBuilder);
        }
    }  

}
