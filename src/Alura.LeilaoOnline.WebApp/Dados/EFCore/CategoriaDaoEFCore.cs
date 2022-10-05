using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDaoEFCore : ICategoriaDao
    {
        private readonly AppDbContext context;
        public CategoriaDaoEFCore()
        {
            context = new AppDbContext();
        }
        public IEnumerable<Categoria> GetCategorias()
        {
            return context.Categorias.ToList();
        }

        public IEnumerable<Categoria> GetCategoriasComInfoLeilao()
        {
            return context.Categorias
                .Include(c => c.Leiloes)
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                });
        }
        public Categoria GetCategoria(int id)
        {
            return context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id); ;
        }
    }
}
