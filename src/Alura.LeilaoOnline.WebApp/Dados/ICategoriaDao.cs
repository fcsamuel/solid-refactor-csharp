using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ICategoriaDao
    {
        IEnumerable<Categoria> GetCategorias();
        IEnumerable<Categoria> GetCategoriasComInfoLeilao();
        Categoria GetCategoria(int id);
    }
}
