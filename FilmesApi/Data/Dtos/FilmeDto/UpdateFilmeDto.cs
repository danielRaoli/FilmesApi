using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.FilmeDto
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O titulo do filme é obrigatório")]
        [MaxLength(200, ErrorMessage = "O filme deve ter menos de 200 caracteres ")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O gênero do filme é obrigatório")]
        [MaxLength(80, ErrorMessage = "O gênero do filme deve ter menos de 80 caracteres")]
        public string Genero { get; set; }

        [Required]
        [Range(70, 600, ErrorMessage = "A duração do filme deve estar entre 70 e 600 minutos")]
        public int Duracao { get; set; }


    }
}
