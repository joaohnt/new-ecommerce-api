using Ecommerce.Application.Features.Customer.DTOs;
using Ecommerce.Domain.Pagination;
using MediatR;

namespace Ecommerce.Application.Features.Customer.Queries;

public record GetAllCustomersQuery(PageParams PageParams) : IRequest<PagedList<CustomerDto>>;
