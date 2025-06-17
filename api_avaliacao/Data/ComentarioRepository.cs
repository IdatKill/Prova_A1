using api_avaliacao.Data.Interfaces;
using api_avaliacao.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api_avaliacao.Data
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppDataContext _context;
        public ComentarioRepository(AppDataContext context)
        {
            _context = context;
        }

        public Comentario? BuscarPorId(int comentarioId)
        {
            return _context.Comentarios.Find(comentarioId);
        }

        public void Cadastrar(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            _context.SaveChanges();
        }

        public void Excluir(Comentario comentario)
        {
            _context.Comentarios.Remove(comentario);
            _context.SaveChanges();
        }

        public List<Comentario> ListarPorItemId(int itemId)
        {
           
            return _context.Comentarios
                .Include(c => c.Usuario)
                .Where(c => c.ItemId == itemId)
                .ToList();
        }
    }
}