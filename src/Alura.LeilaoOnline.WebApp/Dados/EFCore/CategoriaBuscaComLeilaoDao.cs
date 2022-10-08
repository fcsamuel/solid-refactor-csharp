using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaBuscaComLeilaoDao : ICategoriaBuscaComLeilaoDao
    {
        private readonly CategoriaDaoEFCore categoriaDao;
        private readonly AppDbContext context;

        public CategoriaBuscaComLeilaoDao()
        {
            categoriaDao = new CategoriaDaoEFCore();
            context = new AppDbContext();
        }
        public Categoria GetCategoria(int id)
        {
            return categoriaDao.GetCategoria(id);
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return categoriaDao.GetCategorias();
        }

        public IEnumerable<Categoria> GetCategoriasComInfoLeilao()
        {
            return categoriaDao.GetCategoriasComInfoLeilao();
        }

        public IEnumerable<Categoria> GetCategoriasComLeiloes()
        {
            return context.Categorias
                .Include(c => c.Leiloes);
        }
    }
}
