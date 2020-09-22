using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnalPorg.Models
{
    public class ColaboradoresContext : DbContext
    {
        public DbSet<Colaboradores> Colaborador { get; set; }
    }
}