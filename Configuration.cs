namespace Qualica.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Qualica.Models.QualicaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Qualica.Models.QualicaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Transactions.AddOrUpdate(x => x.ID,
                            new Models.Transaction { ID = 1, Amount = 100, From_Account = Guid.NewGuid(), Reference = "Spur", To_Account = Guid.NewGuid(), Transaction_date = new DateTime(2018, 1, 1, 12, 30, 10) },
                            new Models.Transaction { ID = 2, Amount = 200, From_Account = Guid.NewGuid(), Reference = "Telkom", To_Account = Guid.NewGuid(), Transaction_date = new DateTime(2018, 2, 5, 11, 29, 15) },
                            new Models.Transaction { ID = 3, Amount = 300, From_Account = Guid.NewGuid(), Reference = "PnP", To_Account = Guid.NewGuid(), Transaction_date = new DateTime(2018, 4, 6, 2, 11, 5) });
        }
    }
}
