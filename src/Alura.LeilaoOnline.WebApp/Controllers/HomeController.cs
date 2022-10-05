using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.AspNetCore.Routing;
using Alura.LeilaoOnline.WebApp.Dados.EFCore;
using Alura.LeilaoOnline.WebApp.Dados;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILeilaoDao leilaoDao;
        private readonly ICategoriaDao categoriaDao;

        public HomeController(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            this.leilaoDao = leilaoDao;
            this.categoriaDao = categoriaDao;
        }
        public IActionResult Index()
        {
            var categorias = categoriaDao.GetCategoriasComInfoLeilao();
            return View(categorias);
        }

        [Route("[controller]/StatusCode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            if (statusCode == 404) return View("404");
            return View(statusCode);
        }

        [Route("[controller]/Categoria/{categoria}")]
        public IActionResult Categoria(int categoria)
        {
            var categ = categoriaDao.GetCategoria(categoria);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termo)
        {
            ViewData["termo"] = termo;
            var termoNormalized = termo.ToUpper();
            var leiloes = leilaoDao
                .GetLeiloes()
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descricao.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termoNormalized));
            return View(leiloes);
        }
    }
}
