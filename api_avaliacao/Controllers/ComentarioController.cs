using api_avaliacao.Data.Interfaces;
using api_avaliacao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace api_avaliacao.Controllers
{
    [ApiController]
    [Authorize] 
    [Route("api/comentario")]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        [HttpGet("listar/{itemId}")]
        public IActionResult ListarPorItemId(int itemId)
        {
            var comentarios = _comentarioRepository.ListarPorItemId(itemId);
            var resultado = comentarios.Select(c => new
            {
                c.ComentarioId,
                c.Texto,
                c.Data,
                c.ItemId,
                Usuario = new { c.Usuario?.Nome, c.Usuario?.UsuarioId }
            });
            return Ok(resultado);
        }

        [HttpPost("cadastrar")]
        [Authorize]
        public IActionResult Cadastrar([FromBody] Comentario comentario)
        {
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            comentario.UsuarioId = usuarioId;
            comentario.Data = DateTime.Now;

            _comentarioRepository.Cadastrar(comentario);
            return Created("", comentario);
        }


        [HttpDelete("excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            var comentario = _comentarioRepository.BuscarPorId(id);
            if (comentario == null)
            {
                return NotFound(new { message = "Não encontrado." });
            }

            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            if (comentario.UsuarioId != usuarioId)
            {
                return Unauthorized(new { message = "Você não tem permissão." });
            }

            _comentarioRepository.Excluir(comentario);
            return NoContent();
        }
    }
}