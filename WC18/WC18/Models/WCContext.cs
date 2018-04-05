using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WC18.Models
{
    public class WCContext : DbContext
    {
        public DbSet<Registration> Registrations { get; set; }

        public WCContext() : base("name=WC") { Database.SetInitializer<WCContext>(null); }
    }
}