namespace Listagem_Vendas
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vendas
    {
        public int Id { get; set; }

        public string Salesman { get; set; }

        public int SalesOrderNumber { get; set; }

        public decimal TotalValue { get; set; }

        public int ItensCount { get; set; }
    }
}
