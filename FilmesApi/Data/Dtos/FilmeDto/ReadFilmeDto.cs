using FilmesApi.Data.Dtos.SessaoDto;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.FilmeDto
{
    public class ReadFilmeDto
    {

        public string Titulo { get; set; }


        public string Genero { get; set; }


        public int Duracao { get; set; }

        public DateTime ConsultDate = DateTime.Now;

        public virtual ICollection<ReadSessaoDto> Sessoes { get; set; }


    }
}
