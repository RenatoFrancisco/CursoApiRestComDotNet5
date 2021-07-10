using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }
        
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A {0} deve ter no mínimo {1} e no máximo {2} minutos.")]
        public int Duracao { get; set; }
    }
}