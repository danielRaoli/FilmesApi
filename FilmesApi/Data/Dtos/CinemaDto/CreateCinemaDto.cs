using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.CinemaDto
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage ="O nome do cinema é obrigatório")]
        public string Name { get; set; }

        public int EnderecoId { get; set; }
    }
}
