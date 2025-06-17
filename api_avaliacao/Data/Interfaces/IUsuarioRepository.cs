
using api_avaliacao.Models;

namespace api_avaliacao.Data.Interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    List<Usuario> Listar();
    Usuario? BuscarUsuarioPorEmailSenha(string email, string senha);

}