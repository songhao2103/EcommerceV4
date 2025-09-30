using EcommerceV4.Application.Common.Constants;

public abstract class BaseQuery
{
    public int PageIndex { get; set; } = PaginationDefault.DEFAULT_PAGE_INDEX;

    public int PageSize { get; set; } = PaginationDefault.DEFAULT_PAGE_SIZE;

    public string? SearchKey { get; set; }
}