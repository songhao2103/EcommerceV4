namespace EcommerceV4.Domain.Aggregates.CompanyAggregate.Services
{
    public interface ICompanyChecker
    {
        Task<bool> IsNameTakenAsync(string name);
    }
}
