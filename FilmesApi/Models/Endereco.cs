using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="As informação de logradouro são obrigatórias")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage =" o número do endereço é obrigatório")]
        public int Numero { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
