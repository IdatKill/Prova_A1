using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_avaliacao.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}