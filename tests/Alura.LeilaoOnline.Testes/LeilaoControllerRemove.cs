using Xunit;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Controllers;
using Alura.LeilaoOnline.WebApp.Dados.EFCore;
using Alura.LeilaoOnline.WebApp.Services.Handlers;
using Moq;
using Alura.LeilaoOnline.WebApp.Dados;

namespace Alura.LeilaoOnline.Testes
{
    public class LeilaoControllerRemove
    {
        [Fact]
        public void DadoLeilaoInexistenteEntaoRetorna404()
        {
            // arrange
            var idLeilaoInexistente = 11232; // preciso entrar no banco para saber qual � inexistente!! teste deixa de ser autom�tico...
            var actionResultEsperado = typeof(NotFoundResult);
            var mockLeilao = new Mock<ILeilaoDao>();
            var mockCategoria = new Mock<ICategoriaDao>();

            var service = new ArquivamentoAdminService(
                mockLeilao.Object,
                mockCategoria.Object); ;
            var controller = new LeilaoController(service);

            // act
            var result = controller.Remove(idLeilaoInexistente);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmPregaoEntaoRetorna405()
        {
            // arrange
            var idLeilaoEmPregao = 11232; // qual leilao est� em preg�o???!! 
            var actionResultEsperado = typeof(StatusCodeResult);
            var mockLeilao = new Mock<ILeilaoDao>();
            var mockCategoria = new Mock<ICategoriaDao>();

            var service = new ArquivamentoAdminService(
                mockLeilao.Object,
                mockCategoria.Object);
            var controller = new LeilaoController(service);

            // act
            var result = controller.Remove(idLeilaoEmPregao);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmRascunhoEntaoExcluiORegistro()
        {
            // arrange
            var idLeilaoEmRascunho = 11232; // qual leilao est� em rascunho???!!
            var actionResultEsperado = typeof(NoContentResult);
            var mockLeilao = new Mock<ILeilaoDao>();
            var mockCategoria = new Mock<ICategoriaDao>();

            var service = new ArquivamentoAdminService(
                mockLeilao.Object,
                mockCategoria.Object);
            var controller = new LeilaoController(service);

            // act
            var result = controller.Remove(idLeilaoEmRascunho);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }
    }
}
