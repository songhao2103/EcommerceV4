namespace EcommerceV4.Domain.Common.Interfaces
{
    internal interface IBusinessRule<T>
    {
        string Message { get; set; }

        public bool Invoke(T command);
    }
}
