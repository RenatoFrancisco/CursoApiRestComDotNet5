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
        public void Adicionar(Filme filme)
        {
            filme.Id = ++_id;
            _filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _filmes;
        }

        [HttpGet("{id:int}")]
        public Filme RecuperarFilmePorId(int id)
        {
            return _filmes.SingleOrDefault(f => f.Id == id);
        }
    }
}