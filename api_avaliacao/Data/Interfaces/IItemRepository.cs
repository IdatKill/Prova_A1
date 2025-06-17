
using api_avaliacao.Models;

namespace api_avaliacao.Data.Interfaces;

public interface IItemRepository
{
    void Cadastrar(Item Item);
    List<Item> Listar();

};