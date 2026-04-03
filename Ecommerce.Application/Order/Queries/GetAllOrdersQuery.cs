using Ecommerce.Application.Customer.DTOs;
using Ecommerce.Application.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Order.Queries;

public class GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>> {};