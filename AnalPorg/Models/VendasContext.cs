using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnalPorg.Models
{
    public class VendasContext : DbContext
    {
        public DbSet<Vendas> Venda { get; set; }
    }
}