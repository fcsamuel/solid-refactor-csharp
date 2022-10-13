using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IQuery<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
