using FilmesApi.Data.Dtos.EnderecoDto;
using FilmesApi.Data.Dtos.SessaoDto;

namespace FilmesApi.Data.Dtos.CinemaDto
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ReadEnderecoDto Endereco { get; set; }

        public virtual ICollection<ReadSessaoDto> Sessoes { get; set; }
    }
}
