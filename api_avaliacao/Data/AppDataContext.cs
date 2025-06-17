using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_avaliacao.Models;
using Microsoft.EntityFrameworkCore;

namespace api_avaliacao.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions options) :
        base(options)
    { }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Item> Itens { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
}