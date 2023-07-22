using Application.Core.Data;
using Domain.Core.Abstractions.Maybes;
using Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Get
{
    /// <summary>
    /// The <see cref="GetProductQuery"/> handler.
    /// </summary>
    internal sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, Maybe<Product>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductQueryHandler"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public GetProductQueryHandler(IDbContext dbContext) => _dbContext = dbContext;

        /// <inheritdoc/>
        public async Task<Maybe<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            Maybe<Product> maybeProduct = await _dbContext.Set<Product>()
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (maybeProduct.HasNoValue)
            {
                return Maybe<Product>.None;
            }

            return maybeProduct.Value;
        }
    }
}
