using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalPorg.Models
{
    public class Colaboradores
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
    }
}