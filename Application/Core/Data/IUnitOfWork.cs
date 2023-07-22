namespace Application.Core.Data
{
    /// <summary>
    /// The interface to access the Unitof work feature of the ORM.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all of the pending changes in the unit of work.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The number of entities that have been saved.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
