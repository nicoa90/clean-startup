namespace Domain.Products
{
    /// <summary>
    /// Represents the product repository interface.
    /// </summary>
	public interface IProductRepository
	{
        /// <summary>
        /// Add the product to the repository.
        /// </summary>
        /// <param name="product">The product to be added.</param>
		void Create(Product product);
    }
}
