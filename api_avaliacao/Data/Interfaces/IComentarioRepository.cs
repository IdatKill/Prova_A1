using api_avaliacao.Models;
using System.Collections.Generic;

namespace api_avaliacao.Data.Interfaces
{
    public interface IComentarioRepository
    {
        void Cadastrar(Comentario comentario);
        void Excluir(Comentario comentario);
        List<Comentario> ListarPorItemId(int itemId);
        Comentario? BuscarPorId(int comentarioId);
    }
}