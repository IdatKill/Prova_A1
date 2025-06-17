using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_avaliacao.Data;
using api_avaliacao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_avaliacao.Controllers;

[ApiController]
[Authorize]
[Route("api/categoria")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository;
    public CategoriaController(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    [HttpGet("listar")]
    public IActionResult Listar()
    {
        return Ok(_categoriaRepository.Listar());
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar([FromBody] Categoria categoria)
    {
        _categoriaRepository.Cadastrar(categoria);
        return Created("", categoria);
    }

}