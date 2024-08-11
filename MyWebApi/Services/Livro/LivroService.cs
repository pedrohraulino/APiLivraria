using MyWebApi.Models;
using MyWebApi.Data;
using MyWebApi.Dto.Livro;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Todos os Livros Foram Coletados";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }
            return resposta;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int livroId)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroId);
                if (livro != null)
                {
                    resposta.Dados = livro;
                    resposta.Mensagem = "Livro encontrado com sucesso";
                    resposta.Status = true;
                }
                else
                {
                    resposta.Mensagem = "Livro não encontrado";
                    resposta.Status = false;
                }
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }
            return resposta;
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int autorId)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros
                    .Include(l => l.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == autorId)
                    .ToListAsync();

                if (livros.Count == 0)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    resposta.Status = false;
                }
                else
                {
                    resposta.Dados = livros;
                    resposta.Mensagem = "Livros encontrados com sucesso";
                    resposta.Status = true;
                }
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }
            return resposta;
        }

        public async Task<ResponseModel<List<LivroModel>>> CadastrarLivro(CriarLivroDTO criarLivroDTO)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == criarLivroDTO.Autor.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum Autor Localizado";
                    resposta.Status = false;
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = criarLivroDTO.Titulo,
                    Autor = autor
                };
                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "Livro Criado com Sucesso";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }
            return resposta;
        }

        public async Task<ResponseModel<List<LivroModel>>> RemoverLivro(int livroId)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroId);
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum Livro Localizado";
                    resposta.Status = false;
                    return resposta;
                }

                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "Livro Removido com Sucesso";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }
            return resposta;
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(EditarLivroDto editarLivroDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == editarLivroDto.Id);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum Livro Localizado";
                    resposta.Status = false;
                    return resposta;
                }

                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == editarLivroDto.Autor.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum Autor Localizado";
                    resposta.Status = false;
                    return resposta;
                }

                livro.Titulo = editarLivroDto.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Dados Atualizados com Sucesso";
                resposta.Status = true;
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
