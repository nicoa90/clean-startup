using Domain.Core.Utils;

namespace Domain.Core.Abstractions
{
    /// <summary>
    /// Represents the base class that all entities derive from.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        protected Entity(Guid id)
            : this()
        {
            Ensure.NotNull(id, "The identifier is required.", nameof(id));
            Id = id;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <remarks>
        /// Required by EF Core.
        /// </remarks>
        protected Entity() => Id = default!;

        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        public virtual Guid Id { get; protected set; }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (obj is not Entity other)
            {
                return false;
            }

            return ReferenceEquals(this, obj);
        }

        /// <inheritdoc />
        public override int GetHashCode() => Id!.GetHashCode();
    }
}
