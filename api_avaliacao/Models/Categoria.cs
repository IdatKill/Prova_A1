using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_avaliacao.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}