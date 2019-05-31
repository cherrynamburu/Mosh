namespace Mosh.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mosh.Models.RecordContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;


        }

        protected override void Seed(Mosh.Models.RecordContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
