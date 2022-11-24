namespace DI.Services
{
    public interface IGenericService<T>
    {

    }
    public class GenericService<T> : IGenericService<T>
    {
        public T Data { get; private set; }

        public GenericService(T data)
        {
            Data = data;
        }
    }
}
