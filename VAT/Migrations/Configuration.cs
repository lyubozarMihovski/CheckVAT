namespace VAT.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VAT.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VatDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(VatDbContext context)
        {
            if (!context.Vats.Any())
            {
               var vats = new List<Vat>
               {
               new Vat { VatNumber = "BG101662883" },
               new Vat { VatNumber = "BG000275929" },
               new Vat { VatNumber = "BG122056515" },
               new Vat { VatNumber = "BG131437885" }
               };

               foreach (var vat in vats)
               {
                   context.Vats.Add(vat);
               }

               context.SaveChanges();
            }       
        }
    }
}
