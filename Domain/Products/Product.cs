using Domain.Core.Abstractions;

namespace Domain.Products
{
    /// <summary>
    /// Represents the product entity.
    /// </summary>
	public class Product: Entity
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <param name="sku">Sku of the product.</param>
        public Product(string name, Money price, string sku)
		{
			Id = Guid.NewGuid();
			Name = name;
			Price = price;
			Sku = sku;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Product()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
		}

        /// <summary>
        /// Gets the product name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        public Money Price { get; private set; }

        /// <summary>
        /// Gets the sku of the product.
        /// </summary>
        public string Sku { get; private set; }
    }
}
