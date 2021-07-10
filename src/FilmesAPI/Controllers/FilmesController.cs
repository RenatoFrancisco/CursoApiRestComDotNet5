using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Models;
using System;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IList<Filme> _filmes;

        public FilmesController() => _filmes = new List<Filme>();

        [HttpPost]
        public void Adicionar(Filme filme)
        {
            _filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }
    }
}