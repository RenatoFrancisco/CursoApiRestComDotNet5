using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Models;
using System.Linq;
using FilmesAPI.Data;
using AutoMapper;
using FilmesAPI.Data.DTOs;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;
        
        public FilmesController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Adicionar(CreateFilmeDTO filmeDTO)
        {
            var filme = _mapper.Map<Filme>(filmeDTO);
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
            var filme = ObterPorId(id);
            if (filme is not null)
            {
                var filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
                return Ok(filmeDTO);
            }

            return NotFound();
        }
    
        [HttpPut("{id:int}")]
        public IActionResult Atualizar(int id, UpdateFilmeDTO filmeDTO)
        {
            var filme = ObterPorId(id);
            if (filme is null)
                return NotFound();

            _mapper.Map(filmeDTO, filme);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int")]
        public IActionResult Deletar(int id)
        {
            var filme = ObterPorId(id);
            if (filme is null)
                return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

        private Filme ObterPorId(int id) => _context.Filmes.FirstOrDefault(f => f.Id == id);
    }
}