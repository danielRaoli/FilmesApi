using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdcionarFilme([FromBody] FilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RetornaFilmeId), new { id = filme.Id }, filme);

    }

    [HttpGet]
    public IEnumerable<FilmeDto> RetornaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<FilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }


    [HttpGet("{id}")]
    public IActionResult RetornaFilmeId(int id)
    {
        var filme =_context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null)
        {
            return NotFound();
        }
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilme(int id, [FromBody]FilmeDto filmeDto)
    {
        Filme filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if(filme == null) { return NotFound(); }
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpPatch("{id}")]
    public IActionResult UpdateParcialFilme(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        Filme filme = _context.Filmes.FirstOrDefault(f => f.Id ==id);
        if(filme == null) { return NotFound(); }

        
        var filmeParaAtualiza = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualiza, ModelState);
        if (!TryValidateModel(filmeParaAtualiza)) { return ValidationProblem(ModelState); }
        filme = _mapper.Map(filmeParaAtualiza, filme);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpDelete]
    public IActionResult DeletFilme(int id)
    {
        Filme filme = _context.Filmes.FirstOrDefault(f => f.Id==id);
        if(filme == null) { return NotFound(); }
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

}
