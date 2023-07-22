using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Abstractions;
using Domain.Core.Abstractions.Maybes;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.Core.Abstractions;

namespace Persistence.Products
{
    /// <summary>
    /// Implementation of the product repository.
    /// </summary>
    internal sealed class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ProductRepository(ApplicationDbContext dbContext)
			: base(dbContext)
        {
        }
    }
}
