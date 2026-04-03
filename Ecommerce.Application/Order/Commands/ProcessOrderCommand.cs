using Ecommerce.Application.Order.DTOs;
using MediatR;

namespace Ecommerce.Application.Order.Commands;

public class ProcessOrderCommand : IRequest<bool>
{
    public int OrderId { get; set; }
}