namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface ICommand<T>
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
