using Ecommerce.Application.Customer.DTOs;
using Ecommerce.Domain.Pagination;
using MediatR;

namespace Ecommerce.Application.Customer.Queries;

public record GetAllCustomersQuery(PageParams PageParams) : IRequest<PagedList<CustomerDto>>;
