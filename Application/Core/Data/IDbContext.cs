using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Data
{
    /// <summary>
    /// Represents the database context interface.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Gets the database set for the specified entity type.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>The database set for the specified entity type.</returns>
        DbSet<TEntity> Set<TEntity>()
            where TEntity : Entity;
    }
}
