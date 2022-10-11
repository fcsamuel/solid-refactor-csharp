using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Dados.EFCore;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class CategoriasComLeiloesProdutoService : IProdutoService
    {
        private readonly DefaultProdutoService defaultProdutoService;
        private readonly ICategoriaBuscaComLeilaoDao categoriaDao;

        public CategoriasComLeiloesProdutoService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            defaultProdutoService = new DefaultProdutoService(leilaoDao, categoriaDao);
            this.categoriaDao = new CategoriaBuscaComLeilaoDao();
        }
        public Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id)
        {
            return defaultProdutoService.ConsultaCategoriaPorIdComLeiloesEmPregao(id);
        }

        public IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao()
        {
            return categoriaDao
                .GetCategoriasComLeiloes()
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

        public IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo)
        {
            return defaultProdutoService.PesquisaLeiloesEmPregaoPorTermo(termo);
        }
    }
}
