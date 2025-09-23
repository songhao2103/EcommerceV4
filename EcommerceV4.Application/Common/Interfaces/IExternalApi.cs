namespace EcommerceV4.Application.Common.Interfaces
{
    public interface IExternalApi<T>
    {
        public Task<T> GetData();
    }
}
