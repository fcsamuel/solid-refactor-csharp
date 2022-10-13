using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        private readonly ILeilaoDao leilaoDao;
        private readonly ICategoriaDao categoriaDao;

        public DefaultAdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            this.leilaoDao = leilaoDao;
            this.categoriaDao = categoriaDao;
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return categoriaDao.GetAll();
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return leilaoDao.GetAll();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return leilaoDao.GetById(id);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            leilaoDao.Insert(leilao);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            leilaoDao.Update(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilaoDao.Delete(leilao);
            }
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = leilaoDao.GetById(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                leilaoDao.Update(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = leilaoDao.GetById(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                leilaoDao.Update(leilao);
            }
        }
    }
}
