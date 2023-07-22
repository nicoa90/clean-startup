using System.Reflection;
using Application.Core.Data;
using Domain.Core.Abstractions;
using Domain.Core.Abstractions.Maybes;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    /// <summary>
    /// Represents the applications database context.
    /// </summary>
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork, IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">Options to DbContext.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets the database set for the specified entity type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>The database set for the specified entity type.</returns>
        public new DbSet<TEntity> Set<TEntity>()
            where TEntity : Entity
            => base.Set<TEntity>();

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
