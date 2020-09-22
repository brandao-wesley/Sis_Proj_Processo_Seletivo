using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Listagem_Vendas
{
     public partial class DM_Vendas : DbContext
{
    public DM_Vendas()
        : base("name=DM_Vendas")
    {
    }

    public virtual DbSet<Vendas> Vendas { get; set; }

        public static void Main()
        {
            Vendas db = new Vendas();

            Console.WriteLine("==============================================================================================================");
            Console.WriteLine("==============================================================================================================");
            Console.WriteLine("LISTAGEM DE DADOS");
            Console.WriteLine("===============================================================================================================");
            Console.WriteLine("===============================================================================================================");

            Console.WriteLine("Salesman:");
            Console.WriteLine(db.Salesman);
            Console.WriteLine("SalesOrderNumber:");
            Console.WriteLine(db.SalesOrderNumber);
            Console.WriteLine("ItensCount:");
            Console.WriteLine(db.ItensCount);
            Console.WriteLine("TotalValue:");
            Console.WriteLine(db.TotalValue);


        }
    }
}
