namespace Core.Domain.Publisher
{
    public class Book
    {
        public PageQuantity PageQuantity { get; }
        public Margin Margin { get; }
        public Format Format { get; }
        public PrintInformation PrintInformation { get; }
        public Colorimetry Colorimetry { get; }
        
        public IReadOnlyList<> todo { get; }
    }
}