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
            return categoriaDao.GetCategorias();
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return leilaoDao.GetLeiloes();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return leilaoDao.GetLeilaoById(id);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            leilaoDao.PostLeilao(leilao);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            leilaoDao.PutLeilao(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilaoDao.RemoveLeilao(leilao);
            }
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = leilaoDao.GetLeilaoById(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                leilaoDao.PutLeilao(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = leilaoDao.GetLeilaoById(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                leilaoDao.PutLeilao(leilao);
            }
        }
    }
}
