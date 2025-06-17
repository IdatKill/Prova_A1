using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_avaliacao.Models;

namespace api_avaliacao.Data;

public interface ICategoriaRepository
{
    void Cadastrar(Categoria categeoria);
    Categoria? BuscarCategoriaPorId(int id);
    List<Categoria> Listar();
}