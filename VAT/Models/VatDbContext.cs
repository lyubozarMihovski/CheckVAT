using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace VAT.Models
{
    public class VatDbContext : DbContext
    {
        public VatDbContext()
            : base("DefaultConnection")
        {
        }

        public static VatDbContext Create()
        {
            return new VatDbContext();
        }

        public DbSet<Vat> Vats { get; set; }
    }
}