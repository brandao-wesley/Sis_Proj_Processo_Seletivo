using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listagem_Vendas
{
    class Listagem
    {
        public static void Main()
        {
            Vendas db = new Vendas();

            Console.WriteLine("==============================================================================================================");
            Console.WriteLine("==============================================================================================================");
            Console.WriteLine("BEM-VINDO ao Simulador de necessidade Recursos (Salas)");
            Console.WriteLine("Disponibilidades das Salas de 08:00 às 20:00 (Somente hora fechada)");
            Console.WriteLine("Para SAIR digite 99999 na Hora Inicial e Final. O Resultado de Necessidades de Salas, será exibida ao Sair.");
            Console.WriteLine("===============================================================================================================");
            Console.WriteLine("===============================================================================================================");

            Console.WriteLine(db.Id);
            Console.WriteLine(db.Salesman);
            Console.WriteLine(db.SalesOrderNumber);
            Console.WriteLine("Wesley");
        }
    }
}
