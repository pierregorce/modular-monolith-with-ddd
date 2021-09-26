namespace Core.Domain.Distribution
{
    public class Book
    {
        public Money PriceWithVat { get; }
        public StockQuantity Quantity { get; }
        public IReadOnlyList<> todo { get; }
        
        public DateTime AvailabilityDate { get; }
        
        public bool IsAvailable { get; }
    }
}