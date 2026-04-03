using Ecommerce.Application.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Order.Queries;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public int OrderId { get; set; }
}