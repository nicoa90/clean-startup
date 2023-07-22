using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Core.Abstractions
{
    /// <summary>
    /// Represents a concrete domain error.
    /// </summary>
    public sealed class DomainError : ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainError"/> class.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="message">The error message.</param>
        public DomainError(string code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the empty error instance.
        /// </summary>
        internal static DomainError None => new DomainError(string.Empty, string.Empty);

        public static implicit operator string(DomainError error) => error?.Code ?? string.Empty;

        /// <inheritdoc/>
        public override string ToString() => Code ?? string.Empty;

        /// <inheritdoc />
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Message;
        }
    }
}
