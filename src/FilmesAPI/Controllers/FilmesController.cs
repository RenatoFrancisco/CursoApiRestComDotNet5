using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Models;
using System;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private static IList<Filme> _filmes = new List<Filme>();
        private static int _id;

        [HttpPost]
        public IActionResult Adicionar(Filme filme)
        {
            filme.Id = ++_id;
            _filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperarFilmes), new { Id =  filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _filmes;
        }

        [HttpGet("{id:int}")]
        public IActionResult RecuperarFilmePorId(int id)
        {
            var filme = _filmes.FirstOrDefault(f => f.Id == id);
            if (filme is not null)
                return Ok(filme);

            return NotFound();
        }
    }
}