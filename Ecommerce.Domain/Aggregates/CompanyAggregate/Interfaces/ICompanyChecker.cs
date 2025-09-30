namespace EcommerceV4.Domain.Aggregates.CompanyAggregate.Interfaces
{
    public interface ICompanyChecker
    {
        Task<bool> IsNameTakenAsync(string name);
    }
}
