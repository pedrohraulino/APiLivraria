using MyWebApi.Models;
using MyWebApi.Data;
using MyWebApi.Dto.Autor;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Services.Autor
{
  public class AutorService : IAutorInterface
  {
    private readonly AppDbContext _context;

    public AutorService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
    {
      ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
      try
      {
        var autores = await _context.Autores.ToListAsync();
        resposta.Dados = autores;
        resposta.Mensagem = "Todos os Autores Foram Coletados";
        resposta.Status = true;
      }
      catch (Exception ex)
      {
        resposta.Mensagem = ex.Message;
        resposta.Status = false;
      }
      return resposta;
    }

    public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int autorId)
    {
      ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
      try
      {
        var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorId);
        if (autor != null)
        {
          resposta.Dados = autor;
          resposta.Mensagem = "Autor encontrado com sucesso";
          resposta.Status = true;
        }
        resposta.Mensagem = "Autor não encontrado";
        resposta.Status = false;
        return resposta;

      }
      catch (Exception ex)
      {
        resposta.Mensagem = ex.Message;
        resposta.Status = false;
        return resposta;
      }
    }

    public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int livroId)
    {
      ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
      try
      {
        var livro = await _context.Livros
            .Include(a => a.Autor)
            .FirstOrDefaultAsync(a => a.Id == livroId);

        if (livro?.Autor != null)
        {
          resposta.Dados = livro.Autor;
          resposta.Mensagem = "Autor encontrado com sucesso";
          resposta.Status = true;
          return resposta;
        }
        resposta.Mensagem = "Nenhum registro encontrado";
        resposta.Status = false;
        return resposta;
      }
      catch (Exception ex)
      {
        resposta.Mensagem = ex.Message;
        resposta.Status = false;
        return resposta;
      }
    }

    public async Task<ResponseModel<List<AutorModel>>> CadastrarAutor(AutorCriacaoDto autorCriacaoDto)
    {
      ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
      try
      {
        var autor = new AutorModel()
        {
          Nome = autorCriacaoDto.Nome,
          Sobrenome = autorCriacaoDto.Sobrenome
        };
        _context.Add(autor);
        await _context.SaveChangesAsync();

        resposta.Dados = await _context.Autores.ToListAsync();
        resposta.Mensagem = "Autor Criado com Sucesso";
        return resposta;
      }
      catch (Exception ex)
      {
        resposta.Mensagem = ex.Message;
        resposta.Status = false;
        return resposta;
      }
    }

    public async Task<ResponseModel<List<AutorModel>>> RemoverAutor(int autorId)
    {
      ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
      try
      {
        var autor = await _context.Autores
        .FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorId);
        if (autor == null)
        {
          resposta.Mensagem = "Nenhum Autor Localizado";
          return resposta;
        }
        _context.Remove(autor);
        await _context.SaveChangesAsync();
        resposta.Dados = await _context.Autores.ToListAsync();
        return (resposta);
      }
      catch (Exception ex)
      {
        resposta.Mensagem = ex.Message;
        resposta.Status = false;
      }
      return resposta;
    }

    public async Task<ResponseModel<List<AutorModel>>> EditarAutor(EditarAutorDto editarAutorDto)
    {
      ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
      try
      {
        var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == editarAutorDto.Id);
        if (autor == null)
        {
          resposta.Mensagem = "Nenhum Autor Localizado";
          return resposta;
        }

        autor.Nome = editarAutorDto.Nome;
        autor.Sobrenome = editarAutorDto.Sobrenome;
        _context.Update(autor);
        await _context.SaveChangesAsync();
        resposta.Dados = await _context.Autores.ToListAsync();
        resposta.Mensagem = "Dados Atualizados";
        return resposta;
      }
      catch (Exception ex)
      {
        resposta.Mensagem = ex.Message;
        resposta.Status = false;
      }
      return resposta;
    }
  }
}
