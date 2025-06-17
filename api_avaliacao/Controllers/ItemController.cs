
using api_avaliacao.Data;
using api_avaliacao.Data.Interfaces;
using api_avaliacao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_avaliacao.Controllers;

[ApiController]
[Authorize]
[Route("api/item")]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _itemRepository;
    private readonly ICategoriaRepository _categoriaRepository;
    public ItemController(IItemRepository itemRepository,
        ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
        _itemRepository = itemRepository;
    }

    [HttpPost("cadastrar")]
    [Authorize]
    public IActionResult Cadastrar([FromBody] Item item)
    {
        item.Categoria = _categoriaRepository.BuscarCategoriaPorId(item.CategoriaId);
        _itemRepository.Cadastrar(item);
        return Created("", item);
    }

    [HttpGet("listar")]
    [Authorize]
    public IActionResult Listar()
    {
        return Ok(_itemRepository.Listar());
    }

}