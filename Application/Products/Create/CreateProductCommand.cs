using MediatR;

namespace Application.Products.Create;

/// <summary>
/// The create product command.
/// </summary>
/// <param name="Name">Name of the product.</param>
/// <param name="Sku">Sku of the product.</param>
/// <param name="Currency">Currency of the product price.</param>
/// <param name="Amount">Amont of the product price.</param>
public record CreateProductCommand(
	string Name,
	string Sku,
	string Currency,
	decimal Amount): IRequest<Guid>;
