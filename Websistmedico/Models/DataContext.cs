using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Websistmedico.Models
{


    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") { }
        public DbSet<CHoras> tabhoras { get; set; }
        public DbSet<CMedico> tabmedico { get; set; }
        public DbSet<CPaciente> tabpaciente { get; set; }
    }
}