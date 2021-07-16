using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Models;
using System.Linq;
using FilmesAPI.Data;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly FilmeContext _context;
        public FilmesController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Adicionar(Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmes), new { Id =  filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id:int}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
            if (filme is not null)
                return Ok(filme);

            return NotFound();
        }
    }
}