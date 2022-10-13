using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class LeilaoDaoEFCore : ILeilaoDao
    {
        private readonly AppDbContext context;

        public LeilaoDaoEFCore()
        {
            context = new AppDbContext();
        }
        public IEnumerable<Leilao> GetAll()
        {
            return context.Leiloes
                .Include(l => l.Categoria);
        }
        public Leilao GetById(int id)
        {
            return context.Leiloes.Find(id);
        }
        public void Insert(Leilao leilao)
        {
            context.Leiloes.Add(leilao);
            context.SaveChanges();
        }
        public void Update(Leilao leilao)
        {
            context.Leiloes.Update(leilao);
            context.SaveChanges();
        }
        public void Delete(Leilao leilao)
        {
            context.Leiloes.Remove(leilao);
            context.SaveChanges();
        }
    }
}
