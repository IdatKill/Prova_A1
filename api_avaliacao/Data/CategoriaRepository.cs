using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_avaliacao.Models;

namespace api_avaliacao.Data;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDataContext _context;
    public CategoriaRepository(AppDataContext context)
    {
        _context = context;
    }

    public Categoria? BuscarCategoriaPorId(int id)
    {
        return _context.Categorias.Find(id);
    }

    public void Cadastrar(Categoria categeoria)
    {
        _context.Categorias.Add(categeoria);
        _context.SaveChanges();
    }

    public List<Categoria> Listar()
    {
        return _context.Categorias.ToList();
    }
}