using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
        IEnumerable<Leilao> GetLeiloes();
        Leilao GetLeilaoById(int id);
        void PostLeilao(Leilao leilao);
        void PutLeilao(Leilao leilao);
        void RemoveLeilao(Leilao leilao);
    }
}
