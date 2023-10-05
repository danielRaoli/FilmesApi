using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.EnderecoDto
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = " o logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = " o número é obrigatório")]
        public int Numero { get; set; }
    }
}
