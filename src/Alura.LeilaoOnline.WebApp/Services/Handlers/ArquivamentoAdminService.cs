using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class ArquivamentoAdminService : IAdminService
    {
        private readonly IAdminService adminService;
        private readonly ILeilaoDao leilaoDao;

        public ArquivamentoAdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            adminService = new DefaultAdminService(leilaoDao, categoriaDao);
            this.leilaoDao = leilaoDao;
        }
        public void CadastraLeilao(Leilao leilao)
        {
            adminService.CadastraLeilao(leilao);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return adminService.ConsultaCategorias();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return adminService.ConsultaLeilaoPorId(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return adminService.ConsultaLeiloes().Where(leilao => leilao.Situacao != SituacaoLeilao.Arquivado);
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            adminService.FinalizaPregaoDoLeilaoComId(id);
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            adminService.IniciaPregaoDoLeilaoComId(id);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            adminService.ModificaLeilao(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                leilaoDao.PutLeilao(leilao);
            }
        }
    }
}
