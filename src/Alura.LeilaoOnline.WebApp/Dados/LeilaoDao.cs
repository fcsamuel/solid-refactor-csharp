using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeilaoDao
    {
        private readonly AppDbContext context;

        public LeilaoDao(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Leilao> GetLeiloes()
        {
            return context.Leiloes
                .Include(l => l.Categoria);
        }
        public Leilao GetLeilaoById(int id)
        {
            return context.Leiloes.Find(id);
        }
        public void PostLeilao(Leilao leilao)
        {
            context.Leiloes.Add(leilao);
            context.SaveChanges();
        }
        public void PutLeilao(Leilao leilao)
        {
            context.Leiloes.Update(leilao);
            context.SaveChanges();
        }
        public void RemoveLeilao(Leilao leilao)
        {
            context.Leiloes.Remove(leilao);
            context.SaveChanges();
        }
        public IEnumerable<Categoria> GetCategorias()
        {
            return context.Categorias.ToList();
        }
    }
}
