using Domain.Core.Abstractions.Maybes;
using Domain.Products;
using MediatR;

namespace Application.Products.Get
{
    public record GetProductQuery(Guid Id):
        IRequest<Maybe<Product>>;
}
