using Domain.Core.Abstractions;
using Domain.Core.Abstractions.Maybes;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Core.Abstractions
{
    /// <summary>
    /// Represents the generic repository with the most common repository methods.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    internal abstract class GenericRepository<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        protected GenericRepository(ApplicationDbContext dbContext) => DbContext = dbContext;

        /// <summary>
        /// Gets the database context.
        /// </summary>
        protected ApplicationDbContext DbContext { get; }

        /// <summary>
        /// Gets the entity with the specified identifier.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <returns>The maybe instance that may contain the entity with the specified identifier.</returns>
        public async Task<Maybe<TEntity>> GetBydIdAsync(Guid id) =>
            Maybe<TEntity>.From(await DbContext.Set<TEntity>().FindAsync(new object[] { id }).ConfigureAwait(true) ?? default!);

        /// <summary>
        /// Creates the specified entity into the database.
        /// </summary>
        /// <param name="entity">The entity to be inserted into the database.</param>
        public virtual void Create(TEntity entity) =>
            DbContext.Set<TEntity>().Add(entity);

        /// <summary>
        /// Creates the specified entities into the database.
        /// </summary>
        /// <param name="entities">The entities to be inserted into the database.</param>
        public void CreateRange(IReadOnlyCollection<TEntity> entities) =>
            DbContext.Set<TEntity>().AddRange(entities);

        /// <summary>
        /// Updates the specified entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        public void Update(TEntity entity) => DbContext.Set<TEntity>().Update(entity);

        /// <summary>
        /// Removes the specified entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed from the database.</param>
        public void Remove(TEntity entity) => DbContext.Remove(entity);

        /// <summary>
        /// Checks if any entity meets the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>True if any entity meets the specified specification, otherwise false.</returns>
        protected async Task<bool> AnyAsync(Specification<TEntity> specification) =>
            await DbContext.Set<TEntity>().AnyAsync(specification);

        /// <summary>
        /// Gets the first entity that meets the specified specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The maybe instance that may contain the first entity that meets the specified specification.</returns>
        protected async Task<Maybe<TEntity>> FirstOrDefaultAsync(Specification<TEntity> specification) =>
            (await DbContext.Set<TEntity>().FirstOrDefaultAsync(specification))!;
    }
}
