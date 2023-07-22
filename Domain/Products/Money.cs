using Domain.Core.Abstractions;

namespace Domain.Products
{
    /// <summary>
    /// Represents the Money object.
    /// </summary>
    public class Money: ValueObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="currency">The money currency.</param>
        /// <param name="amount">The money amount.</param>
        public Money(string currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        private Money()
        {
        }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        public string Currency { get; private set; }

        /// <summary>
        /// Gets the Amount.
        /// </summary>
        public decimal Amount { get; private set; }

        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Currency;
            yield return Amount;
        }
    }
}
