using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        private readonly ILeilaoDao leilaoDao;

        public LeilaoApiController(ILeilaoDao leilaoDao)
        {
            this.leilaoDao = leilaoDao;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = leilaoDao.GetLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = leilaoDao.GetLeilaoById(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            leilaoDao.PostLeilao(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            leilaoDao.PutLeilao(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = leilaoDao.GetLeilaoById(id);
            if (leilao == null)
            {
                return NotFound();
            }
            leilaoDao.RemoveLeilao(leilao);
            return NoContent();
        }


    }
}
