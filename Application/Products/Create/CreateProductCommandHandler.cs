using Application.Core.Data;
using Domain.Products;
using MediatR;

namespace Application.Products.Create
{
    /// <summary>
    /// The <see cref="CreateProductCommand"/> handler.
    /// </summary>
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
	{
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The product repository.</param>
        /// <param name="unitOfWork">The unitOfWork.</param>
        public CreateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc/>
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var product = new Product(
				request.Name,
				new Money(
                    request.Currency,
                    request.Amount),
				request.Sku);
			_repository.Create(product);
			await _unitOfWork.SaveChangesAsync(cancellationToken);
			return await Task.FromResult(product.Id);
		}
	}
}
